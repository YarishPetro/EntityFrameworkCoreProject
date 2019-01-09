CREATE DATABASE TeamDB;
GO

USE TeamDB;
GO

DROP TABLE Players;

CREATE TABLE Teams
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	Country NVARCHAR(15)
);

CREATE TABLE Players
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Age INT NOT NULL,
	Position NVARCHAR(20) NOT NULL,
	TeamId INT NOT NULL
		FOREIGN KEY REFERENCES Teams(Id),

	CHECK (Position = 'Middefender' OR Position = 'Goalkeeper' OR Position = 'Defender' OR Position = 'Striker') ,
	CHECK (Age > 0 AND Age < 150)
);

INSERT INTO Teams
VALUES
('Dynamo Kiev', 'Ukraine'),
('Real Madrid', 'Spain');

INSERT INTO Players
VALUES
('Denys', 'Boyko', 30, 'Goalkeeper', 1),
('Mykyta', 'Burda', 23, 'Defender', 1),
('Viktor', 'Tsyhankov', 21, 'Middefender', 1),
('Mykola', 'Shaparenko', 20, 'Middefender', 1),
('Artem', 'Besedin', 22, 'Striker', 1);

INSERT INTO Players
VALUES
('Thibaut', 'Courtois', 26, 'Goalkeeper', 2),
('Sergio', 'Ramos', 33, 'Defender', 2),
('Daniel', 'Carvajal', 26, 'Defender', 2),
('Luca', 'Modric', 33, 'Middefender', 2),
('Toni', 'Kroos', 29, 'Middefender', 2),
('Garet', 'Bale', 29, 'Striker', 2);


