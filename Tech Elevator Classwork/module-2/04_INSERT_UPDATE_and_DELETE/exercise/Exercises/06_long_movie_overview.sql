-- 6. For movies that are longer than 3 hours and 30 minutes (210 minutes), set their overview to "This is a long movie. N minutes long."
--    where N is the length. Eg. "This is a long movie. 229 minutes long." (5 rows)
BEGIN TRANSACTION
UPDATE movie SET overview = 'This is a long movie. ' + CONVERT(varchar, length_minutes) + ' minutes long.'
WHERE length_minutes > 210

SELECT * FROM movie WHERE length_minutes > 210
COMMIT;