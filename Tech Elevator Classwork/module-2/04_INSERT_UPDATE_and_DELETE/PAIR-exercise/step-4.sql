-- select the park name, campground name, open_from_mm, open_to_mm & daily_fee ordered by park name and then campground name
-- (expected: 7 rows, starting with "Blackwoods")
SELECT p.name AS park_name, c.name AS campground_name, c.open_from_mm, c.open_to_mm, c.daily_fee
FROM park AS p
INNER JOIN campground AS c ON p.park_id = c.park_id
ORDER BY p.name ASC, c.name ASC

-- select the park name and the total number of campgrounds for each park ordered by park name
-- (expected: 3 rows, starting with "Acadia")
SELECT p.name AS park_name, COUNT(c.campground_id) AS total_num_campgrounds
FROM park AS p
INNER JOIN campground AS c ON p.park_id = c.park_id
GROUP BY p.name
ORDER BY p.name ASC;

-- select the park name, campground name, site number, max occupancy, accessible, max rv length, utilities where the campground name is 'Blackwoods'
-- (expected: 12 rows)
SELECT p.name AS park_name, c.name AS campground_name, s.site_number, s.max_occupancy, s.accessible, s.max_rv_length, s.utilities
FROM park AS p
INNER JOIN campground AS c ON p.park_id = c.park_id
INNER JOIN site AS s ON c.campground_id = s.campground_id
WHERE c.name = 'Blackwoods'

-- select site number, reservation name, reservation from and to date ordered by reservation from date
-- (expected: 44 rows, starting with the earliest date)
SELECT s.site_number, r.name AS reservation_name, r.from_date, r.to_date
FROM site AS s
INNER JOIN reservation AS r ON s.site_id = r.site_id
ORDER BY r.from_date ASC;
