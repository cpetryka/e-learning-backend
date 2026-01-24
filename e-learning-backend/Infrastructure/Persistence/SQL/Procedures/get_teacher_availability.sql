create function get_teacher_availability(_teacher_id uuid)
    returns TABLE("Day" date, "Timeslots" jsonb)
    language sql
    as
$$
SELECT
    a."Date" AS "Day",
    jsonb_agg(
            jsonb_build_object(
                    'TimeFrom', to_char(ts."StartTime", 'HH24:MI:SS'),
                    'TimeUntil', to_char(ts."EndTime", 'HH24:MI:SS')
            ) ORDER BY ts."StartTime"
    ) AS "Timeslots"
FROM "Availabilities" a
         JOIN "TimeSlots" ts ON a."Id" = ts."AvailabilityId"
WHERE a."TeacherId" = _teacher_id
  AND (a."Date"::date + ts."StartTime"::time) >= (now() + interval '1 hour')
  AND a."Date" <= (now() + interval '35 days')
  AND NOT EXISTS (
    SELECT 1
    FROM "Classes" cls
             JOIN "Participations" p ON p."UserId" = cls."UserId"
             JOIN "CourseVariants" cv ON cv."Id" = p."CourseVariantId"
             JOIN "Courses" c ON c."Id" = cv."CourseId"
    WHERE c."TeacherId" = _teacher_id
      AND cls."StartTime" = (a."Date"::date + ts."StartTime"::time)
)
GROUP BY a."Date"
ORDER BY a."Date";
$$;

alter function get_teacher_availability(uuid) owner to inzynier;

