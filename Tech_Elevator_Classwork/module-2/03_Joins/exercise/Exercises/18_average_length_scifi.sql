-- 18. The average length of movies in the "Science Fiction" genre. Name the column 'average_length'.
-- (1 row, expected result between 110-120)
SELECT AVG(m.length_minutes) AS average_length
FROM movie AS m
INNER JOIN movie_genre AS mg ON m.movie_id = mg.movie_id
INNER JOIN genre AS g ON mg.genre_id = g.genre_id
WHERE g.genre_name = 'Science Fiction'
--ORDER BY average_length ASC ***not needed because there's only one row...
