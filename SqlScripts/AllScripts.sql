CREATE DATABASE SuperheroesDb;
GO

USE SuperheroesDb;

-- Superhero table creation
CREATE TABLE Superhero (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255),
	Alias VARCHAR(255), 
	Origin VARCHAR(255)
);

-- Assistant table creation
CREATE TABLE Assistant (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255)
);

-- Power table creation
CREATE TABLE Power (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255),
	Description VARCHAR(MAX)
);


ALTER TABLE Assistant
ADD SuperheroId INT;

-- Add FK & Constraint
ALTER TABLE Assistant
ADD CONSTRAINT FK_Assistant
FOREIGN KEY (SuperheroId)
REFERENCES Superhero(Id);

-- Linking table creation for Superhero & Power realtionship M2M
CREATE TABLE SuperheroPower (
	SuperheroId INT,
	PowerId INT,
	PRIMARY KEY (SuperheroId, PowerId),
	FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id),
	FOREIGN KEY (PowerId) REFERENCES Power(Id)
);

-- Insert superheroes of random choice
INSERT INTO Superhero (Name, Alias, Origin)
VALUES
	('Spiderman', 'Peter Parker', 'New York'),
	('Batman', 'Bruce Wayne', 'Gotham'),
	('Deadpool', 'Wade Wilson', 'Canada');


-- Insert assistants to ass.table
INSERT INTO Assistant (Name, SuperheroId)
VALUES
	('Mary Jane', 1),
	('Alfred Pennyworth', 2),
	('Weasel', 3);

    -- INsert powers to powertable
INSERT INTO Power (Name, Description)
VALUES
	('Flight', 'Airtime'),
	('Web', 'Can shoot web'),
	('Super Strength', 'Very strong physically'),
	('Rich', 'Heavily equipped with cool stuff');

-- give superstrength to Wade and Peter 
-- give flight, webshoot and superstrength to Peter only
-- Give rich to Bruce only (obviously)
INSERT INTO SuperheroPower (SuperheroId, PowerId)
VALUES
	(1, 1),
	(1, 2),
	(1, 3),
	(2, 4),
	(3, 3);		


-- Update one superhero's data (name), here; Batman
UPDATE Superhero
SET Name = 'In Combat Merchant'
WHERE Id = 2;

-- Delete ass. by name , pick useless idiot Weasel
DELETE FROM Assistant
WHERE Name = 'Weasel';