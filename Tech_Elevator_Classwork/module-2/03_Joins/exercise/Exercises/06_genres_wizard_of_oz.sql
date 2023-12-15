-- 6. The genres of "The Wizard of Oz" sorted in alphabetical order (A-Z).
-- (3 rows)
SELECT g.genre_name
FROM genre AS g
INNER JOIN movie_genre AS mg ON g.genre_id = mg.genre_id
INNER JOIN movie AS m ON mg.movie_id = m.movie_id
WHERE m.title = 'The Wizard of Oz'
ORDER BY g.genre_name ASC
