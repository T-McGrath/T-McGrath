-- 18. The count of the number of cities (name column 'num_cities') and the state abbreviation for each state and territory (exclude state abbreviation DC).
-- Order the results by state abbreviation.
-- (55 rows)
SELECT COUNT(*) AS num_cities, state_abbreviation
FROM city
WHERE state_abbreviation <> 'DC'
GROUP BY state_abbreviation;
--HAVING state_abbreviation <> 'DC'; -- This works instead of the WHERE. Not sure which is "better."
