-- 17. The titles and taglines of movies that are in the "Family" genre that Samuel L. Jackson has acted in.
-- Order the results alphabetically by movie title.
-- (4 rows)
SELECT m.title, m.tagline
FROM movie AS m
INNER JOIN movie_actor AS ma ON m.movie_id = ma.movie_id
INNER JOIN person AS p ON ma.actor_id = p.person_id
INNER JOIN movie_genre AS mg ON m.movie_Id = mg.movie_id
INNER JOIN genre AS g ON mg.genre_id = g.genre_id
WHERE g.genre_name = 'Family' AND p.person_Name = 'Samuel L. Jackson'
ORDER BY m.title ASC;
