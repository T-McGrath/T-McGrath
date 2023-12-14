-- 2. The names and birthdays of actors in "The Fifth Element"
-- Order the results alphabetically (A-Z) by name.
-- (15 rows)
SELECT p.person_name, p.birthday
FROM person AS p
INNER JOIN movie_actor AS ma ON p.person_id = ma.actor_id
INNER JOIN movie AS m ON ma.movie_id = m.movie_id
WHERE m.title LIKE '%Element'
ORDER BY p.person_name ASC
