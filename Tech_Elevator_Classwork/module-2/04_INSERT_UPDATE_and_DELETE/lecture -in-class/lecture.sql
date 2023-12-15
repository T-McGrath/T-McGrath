-- INSERT

-- Add Disneyland to the park table. (It was established on 7/17/1955, has an area of 2.1 square kilometers and does not offer camping.)
INSERT INTO park (park_name, date_established, area, has_camping) 
OUTPUT INSERTED.park_name
VALUES ('Disneyland 3', '1955-07-17', 2.1, 0);
			
-- Add Hawkins, IN (with a population of 30,000 and an area of 38.1 square kilometers) and Cicely, AK (with a popuation of 839 and an area of 11.4 square kilometers) to the city table.
insert into city (city_name, population, area, state_abbreviation)
values ('Hawkins', 30000, 38.1, 'IN'),
		('Cicely', 839, 11.4, 'AK')
			
			
			
-- Since Disneyland is in California (CA), add a record representing that to the park_state table.
INSERT INTO park_state (park_id, state_abbreviation)
VALUES (( SELECT park_id FROM park WHERE park_name = 'Disneyland'), 'CA');


-- UPDATE

-- Change the state nickname of California to "The Happiest Place on Earth."
update state set state_nickname = 'The Happiest Place on Earth'
where state_abbreviation = 'CA';

update state set state_nickname = 'One giant place' 
where state_nickname = 'The Last Frontier'

-- Increase the population of California by 1,000,000.
update state set population += 10000000
where state_abbreviation = 'CA';

-- Change the capital of California to Anaheim.
update state set capital = (select city_id from city where city_name = 'Anaheim')
where state_abbreviation = 'CA'

-- Change California's nickname back to "The Golden State", reduce the population by 1,000,000, and change the capital back to Sacramento.
update state set state_nickname = 'The Golden State',
population -= 1000000,
capital = (select city_id from city where city_name = 'Sacramento')
where state_abbreviation = 'CA'

-- DELETE

-- Delete Hawkins, IN from the city table.
DELETE FROM city
WHERE city_name = 'Hawkins' AND state_abbreviation = 'IN'

-- Delete all cities with a population of less than 1,000 people from the city table.
select * from city where population <1000
delete from city where population <1000


-- REFERENTIAL INTEGRITY

-- Try adding a city to the city table with "XX" as the state abbreviation.
DECLARE @OutputTable TABLE (id INT)

INSERT INTO state (state_abbreviation, state_name, population, area, sales_tax, capital)
VALUES ('XX', 'Exity', 1, 1, 1.0, 1)
INSERT INTO city(city_name, state_abbreviation,population, area )
OUTPUT inserted.city_id INTO @OutputTable(id)
VALUES ('HAPPYNULL', 'XX', 0, 0)

UPDATE state 
set capital = (select id from @OutputTable)
where state_abbreviation = 'XX'
;


-- Try deleting California from the state table.
DELETE FROM state
WHERE state_abbreviation = 'CA';

-- Try deleting Disneyland from the park table. Try again after deleting its record from the park_state table.


DELETE FROM park_state
WHERE park_id = (SELECT park_id FROM park WHERE park_name = 'Yellowstone')

DELETE FROM park
WHERE park_name = 'Yellowstone'


-- CONSTRAINTS

-- NOT NULL constraint
-- Try adding Smallville, KS to the city table without specifying its population or area.
INSERT INTO city (city_name, state_abbreviation)
VALUES ('Smallville' , 'KS')

-- DEFAULT constraint
-- Try adding Smallville, KS again, specifying an area but not a population.
INSERT INTO city (city_name, state_abbreviation, area)
VALUES ('Smallville' , 'KS' , 6)

-- Retrieve the new record to confirm it has been given a default, non-null value for population.
select *
from city
where city_name = 'Smallville'

-- UNIQUE constraint
-- Try changing California's nickname to "Vacationland" (which is already the nickname of Maine).
UPDATE state SET state_nickname = 'Vacationland'
WHERE state_abbreviation = 'CA'; 

-- CHECK constraint
-- Try changing the census region of Florida (FL) to "Southeast" (which is not a valid census region).
UPDATE state SET census_region = 'Southeast'
WHERE state_abbreviation = 'FL'


-- TRANSACTIONS

-- Delete the record for Smallville, KS within a transaction.
BEGIN TRANSACTION
select * from city where city_name = 'Smallville'
DELETE FROM city
WHERE city_name = 'Smallville' AND state_abbreviation = 'KS'
select * from city where city_name = 'Smallville'
--ROLLBACK; -- or should I commit?
COMMIT
-- Delete all of the records from the park_state table, but then "undo" the deletion by rolling back the transaction.
BEGIN TRANSACTION;
DELETE FROM park_state;
SELECT COUNT(*) FROM park_state;
ROLLBACK;
SELECT COUNT(*) FROM park_state;


-- Update all of the cities to be in the state of Texas (TX), but then roll back the transaction.
BEGIN TRANSACTION;
UPDATE city SET state_abbreviation = 'TX';
SELECT TOP 5 city_name, state_abbreviation FROM city;
ROLLBACK;
SELECT TOP 5 city_name, state_abbreviation FROM city;

-- Demonstrate two different SQL connections trying to access the same table where one is inside of a transaction but hasn't committed yet.
