-- INNER JOIN

-- Write a query to retrieve the name and state abbreviation for the 2 cities named "Columbus" in the database
--SELECT city_name, state_abbreviation
--FROM city
--WHERE city_name = 'Columbus';

-- Modify the previous query to retrieve the names of the states (rather than their abbreviations).
--SELECT city_name, state.state_name
--FROM city
--INNER JOIN state ON state.state_abbreviation = city.state_abbreviation
--WHERE city_name = 'Columbus';

-- Write a query to retrieve the names of all the national parks with their state abbreviations.
-- (Some parks will appear more than once in the results, because they cross state boundaries.)
--SELECT park_name, park_state.state_abbreviation
--FROM park
--INNER JOIN park_state ON park.park_id = park_state.park_id

-- The park_state table is an associative table that can be used to connect the park and state tables.
-- Modify the previous query to retrieve the names of the states rather than their abbreviations.
--SELECT p.park_name, s.state_name
--FROM park AS p
--INNER JOIN park_state AS ps ON p.park_id = ps.park_id
--INNER JOIN [state] AS s ON ps.state_abbreviation = s.state_abbreviation;

-- Modify the previous query to include the name of the state's capital city.
--SELECT p.park_name, c.city_name AS capital_name, s.state_name
--FROM park AS p
--INNER JOIN park_state AS ps ON p.park_id = ps.park_id
--INNER JOIN [state] AS s ON ps.state_abbreviation = s.state_abbreviation
--INNER JOIN city AS c ON s.Capital = c.city_id;

-- Modify the previous query to include the area of each park.
--SELECT p.park_name, p.area AS park_area, c.city_name AS capital_name, s.state_name
--FROM park AS p
--INNER JOIN park_state AS ps ON p.park_id = ps.park_id
--INNER JOIN [state] AS s ON ps.state_abbreviation = s.state_abbreviation
--INNER JOIN city AS c ON s.Capital = c.city_id;

-- Write a query to retrieve the names and populations of all the cities in the Midwest census region.
--SELECT c.city_name, c.population
--FROM city AS c
--INNER JOIN state AS s ON c.state_abbreviation = s.state_abbreviation
--WHERE census_region = 'Midwest';

-- Write a query to retrieve the number of cities in the city table for each state in the Midwest census region.
--SELECT COUNT(*) AS num_cities, s.state_name
--FROM city AS c
--INNER JOIN state AS s ON c.state_abbreviation = s.state_abbreviation
--WHERE s.census_region = 'Midwest'
--GROUP BY s.state_name;

-- Modify the previous query to sort the results by the number of cities in descending order.
--SELECT COUNT(*) AS num_cities, s.state_name
--FROM city AS c
--INNER JOIN state AS s ON c.state_abbreviation = s.state_abbreviation
--WHERE s.census_region = 'Midwest'
--GROUP BY s.state_name
--ORDER BY num_cities DESC;

-- LEFT JOIN

-- Write a query to retrieve the state name and the earliest date a park was established in that state (or territory) for every record in the state table that has park records associated with it.


-- Modify the previous query so the results include entries for all the records in the state table, even if they have no park records associated with them.
SELECT s.state_name,  MIN(p.date_established) AS oldest_park_est
FROM state AS s
LEFT OUTER JOIN park_state AS ps ON s.state_abbreviation = ps.state_abbreviation
LEFT OUTER JOIN park AS p ON ps.park_id = p.park_id
GROUP BY s.state_name
ORDER BY oldest_park_est ASC;


-- UNION

-- Write a query to retrieve all the place names in the city and state tables that begin with "W" sorted alphabetically. (Washington is the name of a city and a state--how many times does it appear in the results?)


-- Modify the previous query to include a column that indicates whether the place is a city or state.



-- MovieDB
-- After running the script to set up the MovieDB database, make sure it is selected in SSMS and confirm it is working correctly by writing queries to retrieve...

-- The names of all the movie genres


-- The titles of all the Comedy movies

