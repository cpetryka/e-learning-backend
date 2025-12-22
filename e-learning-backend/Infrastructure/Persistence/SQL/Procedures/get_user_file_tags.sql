create function get_user_file_tags(_user_id uuid)
    returns TABLE("TagId" uuid, "TagName" text, "OwnerId" uuid)
    language sql
    as
$$
SELECT DISTINCT
    t."Id"      AS "TagId",
    t."Name"    AS "TagName",
    t."UserId" AS "OwnerId"
FROM "FileResources" fr
         JOIN "ClassFileResources" cfr ON cfr."FileResourceId" = fr."Id"
         JOIN "Classes" c ON c."Id" = cfr."ClassId"
         JOIN "Participations" p ON p."CourseId" = c."CourseId"
         JOIN "TagFiles" tf ON tf."FileResourceId" = fr."Id"
         JOIN "Tags" t ON t."Id" = tf."TagId"
WHERE fr."UserId" = _user_id
   OR p."UserId" = _user_id;
$$;

alter function get_user_file_tags(uuid) owner to inzynier;



