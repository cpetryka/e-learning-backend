create function get_class_file_owners(p_user_id uuid)
    returns TABLE("Id" uuid, "Name" character varying, "Surname" character varying)
    language sql
    as
$$
SELECT DISTINCT
    ownerUser."Id",
    ownerUser."Name",
    ownerUser."Surname"
FROM "FileResources"
         INNER JOIN "ClassFileResources"
                    ON "ClassFileResources"."FileResourceId" = "FileResources"."Id"
         INNER JOIN "Classes"
                    ON "ClassFileResources"."ClassId" = "Classes"."Id"
         INNER JOIN "Users" AS ownerUser
                    ON "FileResources"."UserId" = ownerUser."Id"
WHERE "Classes"."UserId" = p_user_id;
$$;

alter function get_class_file_owners(uuid) owner to inzynier;

