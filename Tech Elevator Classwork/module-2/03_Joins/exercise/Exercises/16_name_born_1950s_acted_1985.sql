-- 16. The names and birthdays of actors born in the 1950s who acted in movies that were released in 1985.
-- Order the results by actor from oldest to youngest.
-- (20 rows)
SELECT DISTINCT p.person_name, p.birthday
FROM person AS p
INNER JOIN movie_actor AS ma ON p.person_id = ma.actor_id
INNER JOIN movie AS m ON ma.movie_id = m.movie_id
WHERE p.birthday BETWEEN '1950-01-01' AND '1959-12-31'
	AND YEAR(m.release_date) = 1985
ORDER BY p.birthday ASC;
