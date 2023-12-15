USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

CREATE TABLE customers (
	customer_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	customer_name varchar(50) NOT NULL,
	address varchar(100) NOT NULL,
	phone_num varchar(15) NOT NULL,
	payment_info varchar(25) NOT NULL
	PRIMARY KEY (customer_id),
	FOREIGN KEY (user_id) REFERENCES users(user_id)
)

INSERT INTO customers (user_id, customer_name, address, phone_num, payment_info) VALUES (1, 'Will Kline', '123 Main St.', '555-123-4567', '1234-5678-9010');

CREATE TABLE orders (
	order_id int IDENTITY(1,1) NOT NULL,
	customer_id int NOT NULL,
	order_date_time datetime NOT NULL,
	order_status varchar(15) NOT NULL,
	is_delivery bit NOT NULL,
	total_price decimal(5, 2) NOT NULL
	PRIMARY KEY (order_id),
	FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
)

INSERT INTO orders (customer_id, order_date_time, order_status, is_delivery, total_price) VALUES (1, '1987-11-30 05:30:00', 'Pending', 1, 100.50);

CREATE TABLE recipes (
	recipe_id int IDENTITY(1,1) NOT NULL,
	recipe_name varchar(50) NOT NULL,
	recipe_price decimal(4, 2) NOT NULL,
	is_available bit NOT NULL
	PRIMARY KEY (recipe_id)
)



INSERT INTO recipes (recipe_name, recipe_price, is_available) VALUES ('The Craig Special', '15.00', 1);
INSERT INTO recipes (recipe_name, recipe_price, is_available) VALUES ('The Bougie Veggie Delight', '15.00', 1);
INSERT INTO recipes (recipe_name, recipe_price, is_available) VALUES ('Chicken, Bacon, and Ranch Pie', '15.00', 1);
INSERT INTO recipes (recipe_name, recipe_price, is_available) VALUES ('Deep Dish Meat Lovers', '15.00', 1);
INSERT INTO recipes (recipe_name, recipe_price, is_available) VALUES ('The Hawaiian Chicken', '15.00', 1);
INSERT INTO recipes (recipe_name, recipe_price, is_available) VALUES ('Build Your Own', '15.00', 1);

CREATE TABLE ingredients (
	ingredient_id int IDENTITY(1,1) NOT NULL,
	ingredient_name varchar (25) NOT NULL,
	ingredient_type varchar (25) NOT NULL,
	is_available bit NOT NULL
	PRIMARY KEY (ingredient_id)
)


INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Thin Crust', 'Crust', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Regular Sauce', 'Sauce', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Sausage', 'Meat', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('White Onion', 'Vegetable', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Pepper', 'Vegetable', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Mozzarella', 'Cheese', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Ricotta', 'Cheese', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Broccoli', 'Vegetable', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Spinach', 'Vegetable', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Artichoke Heart', 'Premium', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Thick Crust', 'Crust', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Bacon', 'Meat', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Ranch', 'Sauce', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Chicken', 'Meat', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Red Onion', 'Vegetable', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Tomato', 'Vegetable', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Chicago Deep Dish', 'Crust', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Ham', 'Meat', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Meatballs', 'Premium', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Pepperoni', 'Meat', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('Pineapple', 'Premium', 1);
INSERT INTO ingredients (ingredient_name, ingredient_type, is_available) VALUES ('BBQ Sauce', 'Sauce', 1);

CREATE TABLE recipe_ingredient (
	recipe_id int NOT NULL,
	ingredient_id int NOT NULL
	FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	FOREIGN KEY (ingredient_id) REFERENCES ingredients(ingredient_id),
	PRIMARY KEY (recipe_id, ingredient_id)
)


INSERT INTO recipe_ingredient VALUES (1, 1);
INSERT INTO recipe_ingredient VALUES (1, 2);
INSERT INTO recipe_ingredient VALUES (1, 6);
INSERT INTO recipe_ingredient VALUES (1, 3);
INSERT INTO recipe_ingredient VALUES (1, 4);
INSERT INTO recipe_ingredient VALUES (1, 5);
INSERT INTO recipe_ingredient VALUES (2, 1);
INSERT INTO recipe_ingredient VALUES (2, 2);
INSERT INTO recipe_ingredient VALUES (2, 6);
INSERT INTO recipe_ingredient VALUES (2, 7);
INSERT INTO recipe_ingredient VALUES (2, 8);
INSERT INTO recipe_ingredient VALUES (2, 9);
INSERT INTO recipe_ingredient VALUES (2, 10);
INSERT INTO recipe_ingredient VALUES (3, 11);
INSERT INTO recipe_ingredient VALUES (3, 12);
INSERT INTO recipe_ingredient VALUES (3, 13);
INSERT INTO recipe_ingredient VALUES (3, 14);
INSERT INTO recipe_ingredient VALUES (3, 15);
INSERT INTO recipe_ingredient VALUES (3, 16);
INSERT INTO recipe_ingredient VALUES (3, 6);
INSERT INTO recipe_ingredient VALUES (4, 17);
INSERT INTO recipe_ingredient VALUES (4, 2);
INSERT INTO recipe_ingredient VALUES (4, 6);
INSERT INTO recipe_ingredient VALUES (4, 12);
INSERT INTO recipe_ingredient VALUES (4, 18);
INSERT INTO recipe_ingredient VALUES (4, 3);
INSERT INTO recipe_ingredient VALUES (4, 19);
INSERT INTO recipe_ingredient VALUES (4, 20);
INSERT INTO recipe_ingredient VALUES (5, 1);
INSERT INTO recipe_ingredient VALUES (5, 6);
INSERT INTO recipe_ingredient VALUES (5, 14);
INSERT INTO recipe_ingredient VALUES (5, 12);
INSERT INTO recipe_ingredient VALUES (5, 21);
INSERT INTO recipe_ingredient VALUES (5, 22);
INSERT INTO recipe_ingredient VALUES (6, 6);

CREATE TABLE sizes (
	size_id int IDENTITY(1, 1) NOT NULL,
	size_name VARCHAR (15) NOT NULL,
	is_available bit NOT NULL,
	PRIMARY KEY (size_id)
)

INSERT INTO sizes (size_name, is_available) VALUES ('Byte', 1);
INSERT INTO sizes (size_name, is_available) VALUES ('Kilobyte', 1);
INSERT INTO sizes (size_name, is_available) VALUES ('Megabyte', 1);
INSERT INTO sizes (size_name, is_available) VALUES ('Gigabyte', 1);

CREATE TABLE order_recipe (
	order_id int NOT NULL,
	recipe_id int NOT NULL,
	size_id int NOT NULL
	PRIMARY KEY (order_id, recipe_id),
	FOREIGN KEY (order_id) REFERENCES orders(order_id),
	FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	FOREIGN KEY (size_id) REFERENCES sizes(size_id)
	
)


GO