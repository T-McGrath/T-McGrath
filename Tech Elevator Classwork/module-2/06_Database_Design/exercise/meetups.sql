USE master;
GO

IF DB_ID('Meetups') IS NOT NULL
BEGIN
	ALTER DATABASE Meetups SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE Meetups;
END
GO

CREATE DATABASE Meetups;
GO

USE Meetups
GO

CREATE TABLE member (member_number int IDENTITY(1, 1) 
					CONSTRAINT PK_member PRIMARY KEY,
					last_name varchar(20) NOT NULL,
					first_name varchar(20) NOT NULL,
					email_address varchar(50) NOT NULL,
					phone_number varchar(15),
					date_of_birth date NOT NULL,
					is_on_email_list bit DEFAULT 1);

CREATE TABLE [group] (group_number int IDENTITY(1, 1) 
					CONSTRAINT PK_group PRIMARY KEY,
					group_name varchar(50) NOT NULL 
					CONSTRAINT UQ_name UNIQUE);

CREATE TABLE [event] (event_number int IDENTITY(1, 1) 
					CONSTRAINT PK_event PRIMARY KEY,
					event_name varchar(50) NOT NULL,
					event_description varchar(100) NOT NULL,
					start_date_time datetime NOT NULL,
					duration_in_minutes int CHECK (duration_in_minutes >= 30),
					group_in_charge int 
					CONSTRAINT FK_event_group FOREIGN KEY REFERENCES [group] (group_number));

CREATE TABLE member_group (member_number int 
						CONSTRAINT FK_member_group_member FOREIGN KEY REFERENCES member (member_number),
						group_number int
						CONSTRAINT FK_member_group_group FOREIGN KEY REFERENCES [group] (group_number),
						CONSTRAINT PK_member_group PRIMARY KEY (member_number, group_number));

CREATE TABLE member_event (member_number int
						CONSTRAINT FK_member_event_member FOREIGN KEY REFERENCES member (member_number),
						event_number int
						CONSTRAINT FK_member_event_event FOREIGN KEY REFERENCES [event] (event_number),
						CONSTRAINT PK_member_event PRIMARY KEY (member_number, event_number));


-----------------------POPULATE TABLES-----------------------
INSERT INTO member (last_name, first_name, email_address, phone_number, date_of_birth, is_on_email_list)
VALUES ('McGrath', 'Trevor', 'stuff@things.com', '111-111-1111', '1984-04-23', 0),
		('Chalk', 'Jenny', 'email@gmail.com', '123-456-7890', '1980-09-25', 0),
		('Solo', 'Han', 'ishotfirst@maybe.net', null, '1977-05-25', 1),
		('Mandalorian', 'The', 'iheartgrogu@alot.gov', '999-999-9998', '1982-10-17', 1),
		('McGrath', 'Hobbes', 'imacat@meow.lol', null, '2013-03-31', 1),
		('Chalk', 'Mozzarella', 'catsRthecoolest@meow.lol', null, '2020-05-14', 0),
		('Shirey', 'Stephen', 'yay4teachingmath@someschool.org', '555-666-7777', '2000-10-08', 0),
		('Thompson', 'Kim', 'imthebestteacherever@totalmodesty.edu', '987-654-3210', '1965-05-16', 1);

INSERT INTO [group] (group_name)
VALUES ('Video Game Club'),
		('Wine Drinkers of America'),
		('CATS!');

INSERT INTO [event] (event_name, event_description, start_date_time, duration_in_minutes, group_in_charge)
VALUES ('Super Smash Bros Tourney', 'Let''s play Smash!', DATEADD(month, 2, GETDATE()), 180, 1),
		('Wine Tasting', 'Taste some wine at that one winery.', DATEADD(year, 5, GETDATE()), 270, 2),
		('CATS!', 'CATS!', GETDATE(), 10000, 3),
		('Play video games with cats?', 'Ever heard of goat yoga? Now it''s time for cat video games!', 
			DATEADD(hour, -10, GETDATE()), 30, 1);

INSERT INTO member_group (member_number, group_number)
VALUES (1, 1), (1, 3),
		(2, 2), (2, 3),
		(3, 1),
		(4, 3),
		(5, 2), (5, 3),
		(6, 2), (6, 3),
		(7, 1),
		(8, 1), (8, 2);

INSERT INTO member_event (member_number, event_number)
VALUES (1, 1), (1, 2), (1, 3), (1, 4),
		(2, 2), (2, 3), (2, 4),
		(3, 4),
		(4, 1), (4, 4),
		(5, 3), (5, 4),
		(6, 3), (6, 4),
		(7, 1), (7, 4),
		(8, 1), (8, 2), (8, 3);
