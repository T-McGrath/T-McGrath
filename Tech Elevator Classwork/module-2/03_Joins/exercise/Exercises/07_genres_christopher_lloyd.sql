-- 7. The genres of movies that Christopher Lloyd has appeared in, sorted alphabetically.
-- (8 rows) Hint: DISTINCT will prevent duplicate values in your query results.
SELECT DISTINCT g.genre_name
FROM genre AS g
INNER JOIN movie_genre AS mg ON g.genre_id = mg.genre_id
--INNER JOIN movie AS m ON mg.movie_id = m.movie_id DON'T NEED THIS STEP!
INNER JOIN movie_actor AS ma ON mg.movie_id = ma.movie_id
INNER JOIN person AS p ON ma.actor_id = p.person_id
WHERE p.person_name = 'Christopher Lloyd'
ORDER BY g.genre_name ASC;
