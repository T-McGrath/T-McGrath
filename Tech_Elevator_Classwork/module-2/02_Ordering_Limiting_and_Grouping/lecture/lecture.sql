-- ORDERING RESULTS

-- Populations of all states from largest to smallest.
--SELECT population
--FROM state
--ORDER BY population desc

-- States sorted alphabetically (A-Z) within their census region. The census regions are sorted in reverse alphabetical (Z-A) order.
--SELECT  state_name, census_region
--FROM state
--ORDER BY census_region DESC, state_name; 

-- The biggest park by area
--SELECT TOP(1) park_name, area 
--FROM park
--ORDER BY area DESC;

-- LIMITING RESULTS

-- The 10 largest cities by populations
--SELECT TOP(10) city_name
--FROM city
--ORDER BY population DESC;

-- The 20 oldest parks from oldest to youngest in years, sorted alphabetically by name.
--SELECT TOP(20) park_name, DATEDIFF(day, date_established, GETDATE())/365.0 AS age_in_years
--FROM park
--ORDER BY age_in_years DESC, park_name;

-- CONCATENATING OUTPUTS

-- All city names and their state abbreviation.
--SELECT city_name + ', ' + state_abbreviation AS city_and_state
--FROM city;

-- All park names and area
--SELECT park_name + ' has area of ' + CAST(area AS VARCHAR) + ' sq. miles' AS name_and_area
--FROM park;

-- The census region and state name of all states in the West & Midwest sorted in ascending order.
--SELECT (census_region + ' ' + state_name) AS region_and_state
--FROM state
--WHERE census_region IN ('West', 'MidWest')
--ORDER BY state_name;


-- AGGREGATE FUNCTIONS

-- Average population across all the states. Note the use of alias, common with aggregated values.
--SELECT AVG(population) AS avg_population
--FROM state;

-- Total population in the West and South census regions
--SELECT SUM(population) AS total_population
--FROM state
--WHERE census_region IN ('West', 'South');

-- The number of cities with populations greater than 1 million


-- The number of state nicknames.


-- The area of the smallest and largest parks.



-- GROUP BY

-- Count the number of cities in each state, ordered from most cities to least.
--SELECT state_abbreviation, count(*) AS num_cities 
--FROM city
--GROUP BY state_abbreviation
--ORDER BY num_cities DESC;


-- Determine the average park area depending upon whether parks allow camping or not.
--SELECT AVG(area) AS avg_area, has_camping
--FROM park
--GROUP BY has_camping;

-- Sum of the population of cities in each state ordered by state abbreviation.
--SELECT state_abbreviation, SUM(population) AS total_population
--FROM city
--GROUP BY state_abbreviation
--HAVING SUM(population) > 500000 -- Can alter results based on the summary row(s) provided by the GROUP BY
--ORDER BY state_abbreviation;
-- The smallest city population in each state ordered by city population.
--SELECT state_abbreviation, MIN(population) AS min_population
--FROM city
--GROUP BY state_abbreviation
--ORDER BY min_population ASC


-- Miscelleneous

-- While you can use TOP to limit the number of results returned by a query,
-- it's recommended to use OFFSET and FETCH if you want to get
-- "pages" of results.
-- For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)
--SELECT city_name, population
--FROM city
--ORDER BY city_name
--OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;


-- SUBQUERIES (optional)
-- This example represents if you didn't know the abbreviation of California.
-- In that case, we have to run a subquery to grab the abbreviation from the state table.
--SELECT city_name
--FROM city
--WHERE state_abbreviation = (SELECT state_abbreviation FROM state WHERE state_name = 'California');

-- Include state name rather than the state abbreviation while counting the number of cities in each state,
--SELECT (SELECT state_name FROM state WHERE state.state_abbreviation = city.state_abbreviation) AS state, COUNT(*) AS num_cities
--FROM city
--GROUP BY state_abbreviation;

-- Include the names of the smallest and largest parks on the query where we got the area from the smallest & largest parks.
--SELECT park_name, area
--FROM park, (SELECT MIN(area) AS smallest, MAX(area) AS largest FROM park) as smallest_or_largest
--WHERE area = smallest OR area = largest;



-- List the capital cities for the states in the Northeast census region.
SELECT state_abbreviation, city_name
FROM city
WHERE city_id IN
	(
		SELECT capital
		FROM state
		WHERE census_region = 'Northeast'
	)
ORDER BY state_abbreviation;
