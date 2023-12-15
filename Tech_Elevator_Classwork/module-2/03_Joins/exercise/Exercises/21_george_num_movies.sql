-- 21. For every person in the person table with the first name of "George", list the number of movies they've been in. Name the count column 'num_of_movies'.
-- Include all Georges, even those that have not appeared in any movies. Display the names in alphabetical order. 
-- (59 rows)
SELECT p.person_name, COUNT(m.movie_id) AS num_of_movies
FROM person AS p
LEFT OUTER JOIN movie_actor AS ma ON p.person_id = ma.actor_id
LEFT OUTER JOIN movie AS m ON ma.movie_id = m.movie_id
WHERE p.person_name LIKE 'George %'
GROUP BY p.person_id, p.person_name -- There are TWO George Wallaces!
ORDER BY p.person_name ASC

