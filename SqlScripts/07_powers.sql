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