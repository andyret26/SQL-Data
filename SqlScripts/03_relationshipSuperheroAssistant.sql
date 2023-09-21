ALTER TABLE Assistant
ADD SuperheroId INT;

-- Add FK & Constraint
ALTER TABLE Assistant
ADD CONSTRAINT FK_Assistant
FOREIGN KEY (SuperheroId)
REFERENCES Superhero(Id);