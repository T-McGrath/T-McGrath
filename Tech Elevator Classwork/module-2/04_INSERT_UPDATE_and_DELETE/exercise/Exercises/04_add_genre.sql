-- 4. Add a "Sports" genre to the genre table. Add the movie "Coach Carter" to the newly created genre. (1 row each)
BEGIN TRANSACTION
INSERT INTO genre (genre_name)
VALUES ('Sports')

INSERT INTO movie_genre (movie_id, genre_id)
VALUES ((SELECT movie_id FROM movie WHERE title = 'Coach Carter'),
	(SELECT genre_id FROM genre WHERE genre_name = 'Sports'))

SELECT * FROM movie_genre WHERE movie_id = 7214
--SELECT * FROM genre WHERE genre_id IN (18, 36, 11776)
COMMIT;
