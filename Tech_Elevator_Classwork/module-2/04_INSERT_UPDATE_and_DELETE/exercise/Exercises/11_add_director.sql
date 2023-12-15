-- 11. Hollywood is remaking the classic movie "The Blob" and doesn't have a director yet. Add yourself to the person table, 
--     and assign yourself as the director of "The Blob" (the movie is already in the movie table). (1 record each)
BEGIN TRANSACTION
INSERT INTO person (person_name, birthday)
VALUES ('T McG', '1984-04-23')

UPDATE movie SET director_id = (SELECT person_id FROM person WHERE person_name = 'T McG')
WHERE title = 'The Blob'

--SELECT * FROM movie WHERE title = 'The Blob'
--SELECT person_name FROM person WHERE person_id = 3984916
COMMIT;