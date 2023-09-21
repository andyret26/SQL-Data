-- Linking table creation for Superhero & Power realtionship M2M
CREATE TABLE SuperheroPower (
	SuperheroId INT,
	PowerId INT,
	PRIMARY KEY (SuperheroId, PowerId),
	FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id),
	FOREIGN KEY (PowerId) REFERENCES Power(Id)
);