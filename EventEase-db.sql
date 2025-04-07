-- DATABASE CREATION 
USE master;
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EventEaseDB') 
    DROP DATABASE EventEaseDB;
GO

CREATE DATABASE EventEaseDB;
GO

USE EventEaseDB;
GO

-- TABLE CREATION 
CREATE TABLE Venue (
    VenueID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    VenueName VARCHAR(250) NOT NULL,
    Location VARCHAR(250) NOT NULL,
    Capacity INT NOT NULL,
	
);
ALTER TABLE Venue
ADD ImageUrl VARCHAR(Max) NOT NULL;

ALTER TABLE Venue
ALTER COLUMN ImageUrl VARCHAR(MAX) NOT NULL;


CREATE TABLE Event (
    EventID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    EventName VARCHAR(250) NOT NULL,
    EventDate DATE NOT NULL,
    Description VARCHAR(250) NOT NULL,
    VenueID INT NOT NULL,
    FOREIGN KEY (VenueID) REFERENCES Venue(VenueID)
);

CREATE TABLE Booking(
    BookingID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    EventID INT NOT NULL,
    VenueID INT NOT NULL,
    BookingDate DATETIME, 
    FOREIGN KEY (EventID) REFERENCES Event(EventID),
    FOREIGN KEY (VenueID) REFERENCES Venue(VenueID)
);

-- TABLE INSERTION 
-- Insert into Venue
-- Insert into Venue (with ImageUrl included)
INSERT INTO Venue (VenueName, Location, Capacity, ImageUrl)
VALUES 
('GrandWest Arena', 'Cape Town', 5000, 'https://example.com/images/grandwest_arena.jpg'),
('Sun City Superbowl', 'North West', 6000, 'https://example.com/images/sun_city_superbowl.jpg'),
('Durban ICC', 'Durban', 3000, 'https://example.com/images/durban_icc.jpg'),
('Gallagher Convention Centre', 'Midrand', 2500, 'https://example.com/images/gallagher_convention.jpg'),
('Boardwalk Convention Centre', 'Port Elizabeth', 2000, 'https://example.com/images/boardwalk_convention.jpg');

-- Check VenueID inserted
SELECT * FROM Venue;

-- Insert into Event - must use correct VenueID
-- Let's assume the VenueID is 1 (based on identity starting from 1)
INSERT INTO Event (EventName, EventDate, Description, VenueID)
VALUES 
('Nasty C Live', '2025-07-10', 'Zulu Man With Some Power Tour', 2),
('Amapiano Festival', '2025-09-15', 'SA’s top Amapiano DJs', 3),
('Heritage Day Bash', '2025-09-24', 'Celebrate South African culture', 4),
('Jazz on the Lake', '2025-08-12', 'Live jazz performances by local artists', 5),
('Comedy Night SA', '2025-10-05', 'Featuring South Africa’s funniest comedians', 6);

-- Check EventID inserted
SELECT * FROM Event;





-- Insert into Booking - use actual IDs
-- Assume EventID = 1, VenueID = 1
INSERT INTO Booking (EventID, VenueID, BookingDate)
VALUES (1, 1, '2025-04-15'),
(2, 2, '2025-06-01'),
(3, 3, '2025-07-20'),
(4, 4, '2025-08-01'),
(5, 5, '2025-07-15'),
(6, 6, '2025-09-10');


-- Check Booking
SELECT * FROM Booking;

