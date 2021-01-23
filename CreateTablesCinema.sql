CREATE TABLE Movies (
	movieName varchar(255),
	category varchar(255),
	ageLimit int,
	currentPrice int,
	previousPrice int,
	poster varchar(1000),
	PRIMARY KEY(movieName)
);


CREATE TABLE Hall (
	hall varchar(10),
	numOfRows varchar(10),
	numOfSeats varchar(10),
	PRIMARY KEY(hall)
);


CREATE TABLE Screenings (
	movieName varchar(255),
	sHour varchar(255),
	sDate varchar(255) NOT NULL,
	hall varchar NOT NULL,
	PRIMARY KEY(sHour,sDate, hall),
);


CREATE TABLE Tickets (
    movieName varchar(30),
	numOfSeat nvarchar(20),
	numOfRow nvarchar(20),
	sDate nvarchar(30),
	sHour varchar(30),
	hall varchar(10),
   	PRIMARY KEY (sDate,sHour,numOfSeat, numOfRow,hall)
);


CREATE TABLE Users (
	email varchar(255),
	userName varchar(255),
	userPassword varchar(255),
	permission varchar(255) DEFAULT 'regular',
	PRIMARY KEY(userName)
);


CREATE TABLE Cart (
	sDate nvarchar(20),
	sHour varchar(30),
	hall varchar(20),
	movieName nvarchar(30),
	numOfSeat nvarchar(20),
	numOfRow nvarchar(20),
	price int,
   	PRIMARY KEY (sDate,sHour,numOfSeat,numOfRow, hall)
);
