CREATE TABLE coffee_shop (
shop_id INT IDENTITY(1, 1) CONSTRAINT PK_coffee_shop PRIMARY KEY,
[name] VARCHAR(255) NOT NULL,
[location] VARCHAR(255) NOT NULL,
has_hot_food BIT NOT NULL,
has_coffee_flavors BIT NOT NULL,
