ALTER TABLE Assistant
ADD SuperheroId INT;

-- Add FK & Constraint
ALTER TABLE Assistant
ADD CONSTRAINT FK_Assistant
FOREGEIGN KEY (SuperheroId)
REFERENCES Superhero(Id);