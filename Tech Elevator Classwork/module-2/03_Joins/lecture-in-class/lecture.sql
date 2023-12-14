-- INNER JOIN

---- Write a query to retrieve the city name and state name state abbreviation for the 2 cities named "Columbus" in the database
--SELECT city_name, state_abbreviation
--FROM city
--WHERE city_name = 'Columbus';

---- Modify the previous query to retrieve the names of the states (rather than their abbreviations).
--SELECT city_name, s.state_name
--FROM city AS c
--INNER JOIN state AS s
--ON c.state_abbreviation = s.state_abbreviation
--WHERE city_name = 'Columbus';

--select * 
--from city 
--INNER JOIN state
--ON city.state_abbreviation = state.state_abbreviation
---- Write a query to retrieve the names of all the national parks with their state abbreviations.
---- (Some parks will appear more than once in the results, because they cross state boundaries.)
--select park_name, park_state.state_abbreviation 
--from park 
--inner join park_state on park.park_id = park_state.park_id 

--SELECT p.park_name, ps.state_abbreviation 
--FROM park p
--JOIN park_state ps ON p.park_id = ps.park_id 


---- The park_state table is an associative table that can be used to connect the park and state tables.
---- Modify the previous query to retrieve the names of the states rather than their abbreviations.
--SELECT p.park_name, s.state_name
--FROM park AS p
--JOIN park_state AS ps ON p.park_id = ps.park_id
--JOIN state AS s ON s.state_abbreviation = ps.state_abbreviation

---- Modify the previous query to include the name of the state's capital city.
--SELECT p.park_name, s.state_name, c.city_name as capital_city
--FROM park AS p
--JOIN park_state AS ps ON p.park_id = ps.park_id
--JOIN state AS s ON s.state_abbreviation = ps.state_abbreviation
--INNER JOIN city as c ON c.city_id = s.capital

---- Modify the previous query to include the area of each park.
--SELECT p.park_name, s.state_name, c.city_name as capital_city, p.area
--FROM park as p
--JOIN park_state AS ps ON p.park_id = ps.park_id
--JOIN state AS s ON s.state_abbreviation = ps.state_abbreviation
--INNER JOIN city as c ON c.city_id = s.capital

---- Write a query to retrieve the names and populations of all the cities in the Midwest census region.
--SELECT c.city_name, c.population
--FROM city AS c
--INNER JOIN state ON state.state_abbreviation = c.state_abbreviation
--Where state.census_region = 'Midwest'

-- Write a query to retrieve the number of cities in the city table for each state in the Midwest census region.
--SELECT COUNT(*) AS number_of_cities, state.state_abbreviation, state.state_name
--FROM city
--INNER JOIN state ON state.state_abbreviation = city.state_abbreviation
--WHERE state.census_region = 'Midwest'
--GROUP BY state.state_abbreviation, state.state_name

-- Modify the previous query to sort the results by the number of cities in descending order.
SELECT COUNT(*) AS number_of_cities, state.state_abbreviation, state.state_name
FROM city
INNER JOIN state ON state.state_abbreviation = city.state_abbreviation
WHERE state.census_region = 'Midwest'
GROUP BY state.state_abbreviation, state.state_name
ORDER BY COUNT(*) desc;


-- LEFT JOIN

-- Write a query to retrieve the state name and the earliest date a park was established in that state (or territory) for every record in the state table that has park records associated with it.


-- Modify the previous query so the results include entries for all the records in the state table, even if they have no park records associated with them.
SELECT state_name, MIN(date_established) as earliest_date
FROM state
LEFT JOIN park_state ON state.state_abbreviation = park_state.state_abbreviation
LEFT JOIN park ON park_state.park_id = park.park_id
GROUP BY state_name
ORDER BY earliest_date




-- UNION

-- Write a query to retrieve all the place names in the city and state tables that begin with "W" sorted alphabetically. (Washington is the name of a city and a state--how many times does it appear in the results?)
SELECT c.city_name AS place_name 
FROM city AS c
WHERE c.city_name LIKE 'W%'
UNION 
SELECT s.state_name AS place_name
FROM state s
WHERE s.state_name LIKE 'W%'
ORDER BY place_name;

SELECT c.city_name AS place_name 
FROM city AS c
WHERE c.city_name LIKE 'W%'
UNION ALL
SELECT s.state_name AS place_name
FROM state s
WHERE s.state_name LIKE 'W%'
ORDER BY place_name;

-- Modify the previous query to include a column that indicates whether the place is a city or state.

SELECT c.city_name AS place_name, 'city', 'Luna'
FROM city AS c
WHERE c.city_name LIKE 'W%'
UNION ALL
SELECT s.state_name AS place_name, 'state', 'Foxy'
FROM state s
WHERE s.state_name LIKE 'W%'
ORDER BY place_name;

-- MovieDB
-- After running the script to set up the MovieDB database, make sure it is selected in SSMS and confirm it is working correctly by writing queries to retrieve...

-- The names of all the movie genres


-- The titles of all the Comedy movies

