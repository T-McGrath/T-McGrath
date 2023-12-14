-- 12. The titles of the movies in the "Star Wars Collection" that weren't directed by George Lucas, sorted alphabetically.
-- (5 rows)
SELECT m.title
FROM movie AS m
INNER JOIN collection AS c ON m.collection_id = c.collection_id
INNER JOIN person AS p ON m.director_id = p.person_id
WHERE c.collection_name = 'Star Wars Collection' AND p.person_name != 'George Lucas'
ORDER BY m.title ASC;
