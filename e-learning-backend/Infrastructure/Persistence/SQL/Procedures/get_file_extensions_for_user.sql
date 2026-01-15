create function get_file_extensions_for_user(p_user_id uuid)
    returns TABLE("Extension" text)
    language sql
    as
$$
SELECT DISTINCT
    UPPER(
            REVERSE(SPLIT_PART(REVERSE("FileResources"."Path"), '.', 1))
    ) AS "Extension"
FROM "FileResources"
         LEFT JOIN "ClassFileResources" ON "ClassFileResources"."FileResourceId" = "FileResources"."Id"
         LEFT JOIN "Classes" ON "ClassFileResources"."ClassId" = "Classes"."Id"
         LEFT JOIN "Users" AS ownerUser ON "FileResources"."UserId" = ownerUser."Id"
         LEFT JOIN "TagFiles" ON "TagFiles"."FileResourceId" = "FileResources"."Id"
WHERE ("Classes"."UserId" = p_user_id OR "FileResources"."UserId" = p_user_id)
  AND "FileResources"."Path" ~ '\.'; 
$$;

alter function get_file_extensions_for_user(uuid) owner to inzynier;

