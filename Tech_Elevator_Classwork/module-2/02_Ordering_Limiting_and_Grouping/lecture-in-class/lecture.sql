-- ORDERING RESULTS

-- Populations of all states from largest to smallest.
--select population from state order by population desc

-- States sorted alphabetically (A-Z) within their census region. The census regions are sorted in reverse alphabetical (Z-A) order.
--select state_name, census_region from state order by census_region desc, state_name asc

-- The biggest park by area
--SELECT TOP(1) park_name, area FROM park ORDER BY area desc


-- LIMITING RESULTS

-- The 10 largest cities by populations
--Select top 10 city_name from city
--where area > 15
--order by population desc

---- The 20 oldest parks from oldest to youngest in years, sorted alphabetically by name.
--SELECT TOP(20) park_name, date_established
--FROM park
--ORDER BY date_established ASC, park_name ASC;


--SELECT TOP(20) park_name, DATEDIFF(d,date_established, CONVERT(date,GETDATE()))/365 as yearsOld
--FROM park
--ORDER BY date_established asc

--SELECT TOP 20 YEAR(GETDATE()) - YEAR(date_established) AS age, park_name
--FROM park
--ORDER BY age DESC, park_name ASC;

-- CONCATENATING OUTPUTS

-- All city names and their state abbreviation.
--SELECT (city_name + ', '+ state_abbreviation) as city_state FROM city;

---- All park names and area
--SELECT (park_name + ' ' + CAST(area as VARCHAR)) as park_name_area
--FROM park

---- The census region and state name of all states in the West & Midwest sorted in ascending order.
--SELECT CONCAT(state_name,' ' , census_region)
--FROM state
--WHERE census_region in ('West', 'Midwest')
--Order by state_name;

--SELECT (census_region + ': ' + state_name) AS region_and_state
--FROM state
--WHERE census_region LIKE '%west'
--ORDER BY region_and_state;

---- AGGREGATE FUNCTIONS

---- Average population across all the states. Note the use of alias, common with aggregated values.
--select AVG(population) as avgPop
--from state 

---- Total population in the West and South census regions
--SELECT SUM(population) AS west_south_pop
--FROM state
--WHERE census_region IN ('West','South');

-- The number of cities with populations greater than 1 million
----we modified this to show how many states are represented by the 10 cities returned in the original results
--SELECT COUNT(distinct state_abbreviation) AS big_cities_in_states_count
--FROM city
--WHERE population > 1000000;

---- The number of state nicknames.
--SELECT Count(state_nickname) as nickname_count, Count(*) as row_count
--FROM state
----WHERE state_nickname IS NOT NULL

---- The area of the smallest and largest parks.
--SELECT MIN(area) AS smallest_park, MAX(area) AS largest_park
--FROM park;


-- GROUP BY

-- Count the number of cities in each state, ordered from most cities to least.
--SELECT state_abbreviation, COUNT(*) AS city_count
--FROM city
--GROUP BY state_abbreviation 
--ORDER BY city_count DESC

-- Determine the average park area depending upon whether parks allow camping or not.
--SELECT AVG(area) AS average_area, has_camping
--FROM park
--GROUP BY has_camping;

-- Sum of the population of cities in each state ordered by state abbreviation.
----modified to order by total population instead
--SELECT SUM(population) as total_pop, state_abbreviation from city 
--WHERE city_name like 'N%'
--group by state_abbreviation 
--HAVING SUM(population)> 500000
--ORDER BY total_pop




-- The smallest city population in each state ordered by city population.
SELECT state_abbreviation, MIN(population) as smol_city FROM city GROUP BY state_abbreviation ORDER BY smol_city;


-- Miscelleneous

-- While you can use TOP to limit the number of results returned by a query,
-- it's recommended to use OFFSET and FETCH if you want to get
-- "pages" of results.
-- For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

SELECT city_name, population
FROM city
ORDER BY city_name
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;

-- SUBQUERIES (optional)

select city.city_name, city.state_abbreviation
from city
where city.state_abbreviation = (select state.state_abbreviation from state where state.state_name = 'California') 

select city.city_name, city.state_abbreviation
from city
where city.state_abbreviation IN (select state.state_abbreviation from state where state.state_name = 'California' OR state.state_name = 'New Mexico') 


-- Include state name rather than the state abbreviation while counting the number of cities in each state,
select count(city.city_name) as count_of_cities, state_abbreviation, (select state.state_name from state where state.state_abbreviation = city.state_abbreviation) as state_name
from city
group by state_abbreviation

-- Include the names of the smallest and largest parks on the query where we got the area of the smallest and largest parks
SELECT MIN(area) AS smallest_park, MAX(area) AS largest_park
From park

SELECT park_name, area
FROM park ,
	( 
		SELECT MIN(area) as smallest, MAX(area) AS largest FROM park where area > 0
	) as smallest_or_largest
WHERE park.area = smallest_or_largest.smallest OR park.area = smallest_or_largest.largest;




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
