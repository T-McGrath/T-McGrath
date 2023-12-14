CREATE TABLE Person (person_id INT IDENTITY (1, 1),
					person_name VARCHAR DEFAULT 'anonymous',
					phone_number VARCHAR NOT NULL,
					[address] VARCHAR NOT NULL,
					bank_account_number VARCHAR NOT NULL,
					CONSTRAINT PK_person PRIMARY KEY (person_id))


CREATE TABLE Painting (painting_id INT IDENTITY(1, 1),
						CONSTRAINT pk_painting_id PRIMARY KEY (painting_id),
						title VARCHAR NOT NULL,
						is_for_sale BIT DEFAULT '0',
						artist_id INT,
						CONSTRAINT FK_painting FOREIGN KEY (artist_id) REFERENCES person (person_id))   

CREATE TABLE [Transaction] (painting_id INT,
							customer_id INT,
							transaction_date_time DATETIME DEFAULT GETDATE(),
							sale_price DECIMAL(9, 2) NOT NULL,
							CONSTRAINT PK_transaction PRIMARY KEY (painting_id, customer_id, transaction_date_time),
							CONSTRAINT FK_transaction_painting FOREIGN KEY (painting_id) REFERENCES Painting (painting_id),
							CONSTRAINT FK_transaction_person FOREIGN KEY (customer_id) REFERENCES Person (person_id))