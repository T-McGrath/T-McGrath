-- 15. The title of the movie and the name of director for movies where the director was also an actor in the same movie.
-- Order the results by movie title (A-Z)
-- (73 rows)
SELECT m.title, p.person_name
FROM movie AS m
INNER JOIN movie_actor AS ma ON m.movie_id = ma.movie_id
INNER JOIN person AS p ON ma.actor_id = p.person_id
WHERE m.director_id = ma.actor_id
ORDER BY m.title ASC;