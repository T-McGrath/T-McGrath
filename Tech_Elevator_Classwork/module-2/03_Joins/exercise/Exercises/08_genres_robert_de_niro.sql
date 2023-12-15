-- 8. The genres of movies that Robert De Niro has appeared in that were released in 2010 or later, sorted alphabetically.
-- (6 rows)
SELECT DISTINCT g.genre_name
FROM genre AS g
INNER JOIN movie_genre AS mg ON g.genre_id = mg.genre_id
INNER JOIN movie_actor AS ma ON mg.movie_id = ma.movie_id
INNER JOIN movie AS m ON ma.movie_id = m.movie_id
INNER JOIN person AS p ON ma.actor_id = p.person_id
WHERE p.person_name = 'Robert De Niro' AND m.release_date >= '2010-01-01'
ORDER BY g.genre_name ASC;