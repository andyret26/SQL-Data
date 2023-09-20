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
