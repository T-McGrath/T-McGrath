SELECT m.first_name, m.last_name, g.group_name
FROM member as m
INNER JOIN member_group AS mg ON m.member_number = mg.member_number
INNER JOIN [group] AS g ON mg.group_number = g.group_number
WHERE g.group_name = 'CATS!';


SELECT m.first_name, m.last_name, e.event_name, e.event_description, g.group_name
FROM member AS m
INNER JOIN member_event AS me ON m.member_number = me.member_number
INNER JOIN [event] AS e ON me.event_number = e.event_number
INNER JOIN [group] AS g ON e.group_in_charge = g.group_number
WHERE e.event_number = 2