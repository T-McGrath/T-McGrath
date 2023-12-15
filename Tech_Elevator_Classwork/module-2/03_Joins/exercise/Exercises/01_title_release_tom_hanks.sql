-- 1. The titles and release dates of movies that Tom Hanks has appeared in. 
-- Order the results by release date, newest to oldest.
-- (47 rows)
SELECT m.title, m.release_date
FROM movie AS m
INNER JOIN movie_actor AS ma ON m.movie_id = ma.movie_id
INNER JOIN person AS p ON ma.actor_id = p.person_id
WHERE p.person_name = 'Tom Hanks'
ORDER BY release_date DESC;