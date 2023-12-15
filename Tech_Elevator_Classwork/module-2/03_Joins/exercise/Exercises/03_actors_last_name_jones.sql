-- 3. For all actors with the last name of "Jones", display the actor's name and movie titles they appeared in. 
-- Order the results by the actor names (A-Z) and then by movie title (A-Z). 
-- (48 rows)
SELECT p.person_name, m.title
FROM person AS p
INNER JOIN movie_actor AS ma ON p.person_id = ma.actor_id
INNER JOIN movie AS m ON ma.movie_id = m.movie_id
WHERE p.person_name LIKE '% Jones'
ORDER BY p.person_name ASC, m.title ASC;
