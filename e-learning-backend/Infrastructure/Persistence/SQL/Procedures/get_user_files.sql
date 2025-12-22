create function get_user_files(_user_id uuid, _tag_ids uuid[] DEFAULT NULL::uuid[], _types text[] DEFAULT NULL::text[], _student_id uuid DEFAULT NULL::uuid, _course_id uuid DEFAULT NULL::uuid, _owner_ids uuid[] DEFAULT NULL::uuid[])
    returns TABLE("FileId" uuid, "FileName" text, "RelativePath" text, "UploadedAt" timestamp with time zone, "Tags" jsonb, "ParticipationUsers" jsonb, "OwnerInfo" jsonb, "Courses" jsonb)
    language sql
    as
$$
SELECT fr."Id"      AS "FileId",
       fr."Name"    AS "FileName",
       fr."Path"    AS "RelativePath",
       fr."AddedAt" AS "UploadedAt",

    /* Tags */
       COALESCE(
               jsonb_agg(DISTINCT jsonb_build_object(
                       'Id', t."Id",
                       'Name', t."Name"
                                          )) FILTER (WHERE t."Id" IS NOT NULL),
               '[]'::jsonb
       )            AS "Tags",

    /* ParticipationUsers (Tylko studenci z tego konkretnego wariantu/klasy) */
       COALESCE(
               jsonb_agg(DISTINCT jsonb_build_object(
                       'Id', u."Id",
                       'Name', u."Name",
                       'Surname', u."Surname"
                                          )) FILTER (WHERE u."Id" IS NOT NULL AND u."Id" <> fr."UserId"),
               '[]'::jsonb
       )            AS "ParticipationUsers",

    /* OwnerInfo */
       COALESCE(
               (jsonb_agg(DISTINCT jsonb_build_object(
                       'Id', owner_u."Id",
                       'Name', owner_u."Name",
                       'Surname', owner_u."Surname"
                                   )) FILTER (WHERE owner_u."Id" IS NOT NULL)) -> 0,
               '{}'::jsonb
       )            AS "OwnerInfo",

    /* Courses -> JSON array (Mimo że klasa jest w wariancie, pokazujemy kurs główny) */
       COALESCE(
               jsonb_agg(DISTINCT jsonb_build_object(
                       'Id', courses."Id",
                       'Name', courses."Name"
                                          )) FILTER (WHERE courses."Id" IS NOT NULL),
               '[]'::jsonb
       )            AS "Courses"

FROM "FileResources" fr
         LEFT JOIN "ClassFileResources" cfr ON cfr."FileResourceId" = fr."Id"
         LEFT JOIN "Classes" c ON c."Id" = cfr."ClassId"
         LEFT JOIN "CourseVariants" cv ON cv."Id" = c."CourseVariantId"
         LEFT JOIN "Courses" courses ON courses."Id" = cv."CourseId"
         LEFT JOIN "Participations" p ON p."CourseVariantId" = cv."Id"
         LEFT JOIN "Users" u ON u."Id" = p."UserId"
         LEFT JOIN "TagFiles" tf ON tf."FileResourceId" = fr."Id"
         LEFT JOIN "Tags" t ON t."Id" = tf."TagId"
         LEFT JOIN "Users" owner_u ON owner_u."Id" = fr."UserId"
WHERE
    (fr."UserId" = _user_id OR p."UserId" = _user_id)
  AND (
    _types IS NULL OR REVERSE(SPLIT_PART(REVERSE(fr."Path"), '.', 1)) = ANY (_types)
    )
  AND (
    _owner_ids IS NULL OR fr."UserId" = ANY (_owner_ids)
    )
  AND (
    _course_id IS NULL OR courses."Id" = _course_id
    )
  AND (
    _student_id IS NULL OR p."UserId" = _student_id
    )
  AND (
    _tag_ids IS NULL OR t."Id" = ANY (_tag_ids)
    )
  AND fr."Path" ~ '\.'
GROUP BY fr."Id", fr."Name", fr."Path", fr."AddedAt", fr."UserId";
$$;

alter function get_user_files(uuid, uuid[], text[], uuid, uuid, uuid[]) owner to inzynier;

