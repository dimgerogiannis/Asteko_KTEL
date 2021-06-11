DROP DATABASE project_db;
CREATE DATABASE project_db;
use project_db;
SET GLOBAL log_bin_trust_function_creators = 1;

CREATE TABLE IF NOT EXISTS User (
	username VARCHAR(30) NOT NULL,
	name VARCHAR(20) NOT NULL,
	surname VARCHAR(20) NOT NULL,
	password VARCHAR(64) NOT NULL,
	property ENUM('client', 'bus_driver', 'chief', 'quality_manager', 'itinerary_distributor') NOT NULL,
	PRIMARY KEY (username));

CREATE TABLE IF NOT EXISTS Employee (
	username VARCHAR(30) NOT NULL,
	salary DECIMAL(6, 2) NOT NULL,
    hireDate DATE NOT NULL,
	experience INT NOT NULL,
	PRIMARY KEY (username),
	FOREIGN KEY (username) REFERENCES User(username));

CREATE TABLE IF NOT EXISTS BusDriver (
	username VARCHAR(30) NOT NULL,
	complaintsCounter INT NOT NULL,
    fired BOOLEAN NOT NULL,
	PRIMARY KEY (username),
	FOREIGN KEY (username) REFERENCES Employee(username));

CREATE TABLE IF NOT EXISTS Chief (
	username VARCHAR(30) NOT NULL,
	PRIMARY KEY (username),
	FOREIGN KEY (username) REFERENCES Employee(username));

CREATE TABLE IF NOT EXISTS TicketPrice(
	id INT UNIQUE NOT NULL,
    price DECIMAL(4,2) NOT NULL);

INSERT INTO TicketPrice VALUES (1, 1.60);

CREATE TABLE IF NOT EXISTS MontlyCardPrice(
	id INT UNIQUE NOT NULL,
    price INT NOT NULL);

INSERT INTO MontlyCardPrice VALUES (1, 40);
    
CREATE TABLE IF NOT EXISTS DiscountCategory(
	id INT NOT NULL AUTO_INCREMENT,
    category ENUM('no_discount', 'student', 'soldier', 'low_income', 'dissabilities') NOT NULL,
    discountPercentage INT NOT NULL,
    PRIMARY KEY (id));
    
INSERT INTO DiscountCategory (category, discountPercentage) VALUES
	('no_discount', 0),
	('student', 20),
    ('soldier', 30),
    ('low_income', 70),
    ('dissabilities', 80);

CREATE TABLE IF NOT EXISTS QualityManager (
	username VARCHAR(30) NOT NULL,
	PRIMARY KEY (username),
	FOREIGN KEY (username) REFERENCES Employee(username));

CREATE TABLE IF NOT EXISTS ItineraryDistributionManager (
	username VARCHAR(30) NOT NULL,
	isResponsibleForWeek TINYINT NOT NULL,
	PRIMARY KEY (username),
	FOREIGN KEY (username) REFERENCES Employee(username));

CREATE TABLE IF NOT EXISTS Client (
	username VARCHAR(30) NOT NULL,
	balance DECIMAL(6, 2) NOT NULL,
	monthlyCard TINYINT NOT NULL,
	discountID INT NOT NULL,
	PRIMARY KEY (username),
	FOREIGN KEY (username) REFERENCES User(username),
    FOREIGN KEY (discountID) REFERENCES DiscountCategory(id));

CREATE TABLE IF NOT EXISTS PaidLeaveDates (
	busDriverUsername VARCHAR(30) NOT NULL,
	paidLeaveDate DATE NOT NULL,
	PRIMARY KEY (busDriverUsername, paidLeaveDate),
	FOREIGN KEY (busDriverUsername) REFERENCES BusDriver(username));

CREATE TABLE IF NOT EXISTS DismissalPetition (
	petitionID INT NOT NULL AUTO_INCREMENT,
	targetUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (petitionID),
	FOREIGN KEY (targetUsername) REFERENCES BusDriver(username));

CREATE TABLE IF NOT EXISTS SanitaryComplaint (
	complaintID INT NOT NULL AUTO_INCREMENT,
	targetUsername VARCHAR(30) NOT NULL,
	summary VARCHAR(300) NOT NULL,
	category ENUM('wear_mask_refusal', 'close_distance', 'has_illness_symptoms') NOT NULL,
	busDriverUsername VARCHAR(30),
	PRIMARY KEY (complaintID),
	FOREIGN KEY (targetUsername) REFERENCES Client(username));

CREATE TABLE IF NOT EXISTS ClientComplaint (
	complaintID INT NOT NULL AUTO_INCREMENT,
	targetUsername VARCHAR(30) NOT NULL,
    checked BOOLEAN NOT NULL,
	summary VARCHAR(300) NOT NULL,
	category ENUM('rude_bus_driver', 'late_for_no_reason', 'aggresive_behavior', 'aggresive_driving', 'driving_rules_violation') NOT NULL,
	clientUsername VARCHAR(30), 
	PRIMARY KEY (complaintID),
	FOREIGN KEY (clientUsername) REFERENCES Client(username),
	FOREIGN KEY (targetUsername) REFERENCES BusDriver(username));

CREATE TABLE IF NOT EXISTS DisciplinaryComplaint (
	disciplinaryComplaintID INT NOT NULL AUTO_INCREMENT,
	targetUsername VARCHAR(30) NOT NULL,
    submittedDatetime DATETIME NOT NULL,
	comment VARCHAR(200) NOT NULL,
	qualityManagerUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (disciplinaryComplaintID),
	FOREIGN KEY (targetUsername) REFERENCES BusDriver(username),
	FOREIGN KEY (qualityManagerUsername) REFERENCES QualityManager(username));

CREATE TABLE IF NOT EXISTS Bus (
	busID INT NOT NULL AUTO_INCREMENT,
	size ENUM('small', 'medium', 'large') NOT NULL,
	PRIMARY KEY (busID));

CREATE TABLE IF NOT EXISTS BusLine (
	number INT NOT NULL,
	duration INT NOT NULL,
	PRIMARY KEY (number));

CREATE TABLE IF NOT EXISTS Itinerary (
	itineraryID INT NOT NULL AUTO_INCREMENT,
	status ENUM('delayed', 'no_delayed') NOT NULL,
    lateReason VARCHAR(50),
	travelDatetime DATETIME NOT NULL,
	availableSeats INT NOT NULL,
	distributorUsername VARCHAR(30) NOT NULL,
	busDriverUsername VARCHAR(30),
	busLineNumber INT NOT NULL,
	busID INT NOT NULL,
	PRIMARY KEY (itineraryID),
	FOREIGN KEY (distributorUsername) REFERENCES ItineraryDistributionManager(username),
	FOREIGN KEY (busDriverUsername) REFERENCES BusDriver(username),
	FOREIGN KEY (busLineNumber) REFERENCES BusLine(number),
	FOREIGN KEY (busID) REFERENCES Bus(busID));

CREATE TABLE IF NOT EXISTS Reservation (
	reservationID INT NOT NULL AUTO_INCREMENT,
	reservationDate DATETIME NOT NULL,
	travelDatetime DATETIME NOT NULL,
	travelBusLine INT NOT NULL,
	chargedPrice DECIMAL(4,2) NOT NULL,
	clientUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (reservationID),
	FOREIGN KEY (clientUsername) REFERENCES Client(username));

CREATE TABLE IF NOT EXISTS Ticket (
	ticketID INT NOT NULL AUTO_INCREMENT,
	delayedItinerary BOOLEAN NOT NULL,
	used BOOLEAN NOT NULL,
	issued BOOLEAN NOT NULL,
	clientUsername VARCHAR(30) NOT NULL,
	itineraryID INT NOT NULL,
	PRIMARY KEY (ticketID),
	FOREIGN KEY (clientUsername) REFERENCES Client(username),
	FOREIGN KEY (itineraryID) REFERENCES Itinerary(itineraryID));

CREATE TABLE IF NOT EXISTS DiscountApplication (
	applicationID INT NOT NULL AUTO_INCREMENT,
	applicationDatetime DATETIME NOT NULL,
	possibleRejectionReason VARCHAR(250),
	category ENUM('student', 'soldier', 'low_income', 'dissabilities'),
	phoneNumber BIGINT NOT NULL,
	status ENUM('accepted', 'rejected', 'pending'),
	taxIdentificationNumber BIGINT NOT NULL,
	clientUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (applicationID),
	FOREIGN KEY (clientUsername) REFERENCES Client(username));

CREATE TABLE IF NOT EXISTS Stop (
	id INT NOT NULL AUTO_INCREMENT,
    number INT NOT NULL,
	stopName VARCHAR(40) NOT NULL,
	PRIMARY KEY (id, number),
	FOREIGN KEY (number) REFERENCES BusLine(number));

CREATE TABLE IF NOT EXISTS Poll (
	title VARCHAR(80) NOT NULL,
	expired BOOLEAN NOT NULL,
	startingDate DATE NOT NULL,
	endingDate DATE NOT NULL,
	question VARCHAR(200) NOT NULL,
	qualityManagerUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (title),
	FOREIGN KEY (qualityManagerUsername) REFERENCES QualityManager(username));

CREATE TABLE IF NOT EXISTS PollChoice (
	pollChoiceID INT NOT NULL AUTO_INCREMENT,
	choice VARCHAR(50) NOT NULL,
	title VARCHAR(80) NOT NULL,
	PRIMARY KEY (pollChoiceID),
	FOREIGN KEY (title) REFERENCES Poll(title) ON DELETE CASCADE);

CREATE TABLE IF NOT EXISTS PollVote (
	pollChoiceID INT NOT NULL,
	clientUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (pollChoiceID, clientUsername),
	FOREIGN KEY (pollChoiceID) REFERENCES PollChoice(pollChoiceID) ON DELETE CASCADE,
	FOREIGN KEY (clientUsername) REFERENCES Client(username));

CREATE TABLE IF NOT EXISTS AdvertisementComponent (
	advertisementComponentID INT NOT NULL AUTO_INCREMENT,
	busCount INT NOT NULL,
	busPart ENUM('inside', 'outside'),
	busSize Enum('small', 'medium', 'large'),
	PRIMARY KEY (advertisementComponentID));

CREATE TABLE IF NOT EXISTS AdvertisementContract (
	contractID INT NOT NULL AUTO_INCREMENT,
	duration INT NOT NULL,
	expired BOOLEAN NOT NULL,
	signDate DATE NOT NULL,
	enterprise VARCHAR(60) NOT NULL,
	price INT NOT NULL,
	chiefUsername VARCHAR(30) NOT NULL,
	advertisementComponentID INT NOT NULL,
	PRIMARY KEY (contractID),
	FOREIGN KEY (chiefUsername) REFERENCES Chief(username),
	FOREIGN KEY (advertisementComponentID) REFERENCES AdvertisementComponent(advertisementComponentID));

CREATE TABLE IF NOT EXISTS PaidLeaveApplication (
	paidLeaveApplicationID INT NOT NULL AUTO_INCREMENT,
	busDriverUsername VARCHAR(30) NOT NULL,
	reason VARCHAR(200) NOT NULL,
    rejectionReason VARCHAR(200),
	applicationDate DATE NOT NULL,
	status ENUM('accepted', 'rejected', 'pending'),
	requestedDate DATE NOT NULL,
	PRIMARY KEY (paidLeaveApplicationID));
    
CREATE TABLE IF NOT EXISTS Transaction (
	transactionID INT NOT NULL AUTO_INCREMENT,
	ticketID INT NOT NULL,
	price DECIMAL(4,2) NOT NULL,
	purchaseDatetime DATETIME NOT NULL,
	PRIMARY KEY (transactionID),
	FOREIGN KEY (ticketID) REFERENCES Ticket(ticketID));
    
CREATE TABLE IF NOT EXISTS File (
	fileID INT NOT NULL AUTO_INCREMENT,
	fileName VARCHAR(100) NOT NULL,
    fileSize BIGINT NOT NULL,
	file LONGBLOB NOT NULL,
	applicationID INT,
	contractID INT,
	PRIMARY KEY (fileID),
	FOREIGN KEY (applicationID) REFERENCES DiscountApplication(applicationID) ON DELETE CASCADE,
	FOREIGN KEY (contractID) REFERENCES AdvertisementContract(contractID));

CREATE TABLE IF NOT EXISTS LastMinuteTravelRequest (
	lastMinuteTravelRequestID INT NOT NULL AUTO_INCREMENT,
	applicationDate DATE NOT NULL,
	travelDatetime DATETIME NOT NULL,
	travelBusLine INT NOT NULL,
	status ENUM('pending', 'accepted', 'rejected') NOT NULL,
	clientUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (lastMinuteTravelRequestID),
	FOREIGN KEY (travelBusLine) REFERENCES BusLine(number),
	FOREIGN KEY (clientUsername) REFERENCES Client (username));

CREATE TABLE IF NOT EXISTS Feedback (
	feedbackID INT NOT NULL AUTO_INCREMENT,
	feedbackText VARCHAR(300) NOT NULL,
	qualityManagerUsername VARCHAR(30) NOT NULL,
	PRIMARY KEY (feedbackID),
	FOREIGN KEY (qualityManagerUsername) REFERENCES QualityManager(username));
    
/*
=================
=================
*/

DELIMITER //
CREATE FUNCTION DatetimeAdder(days INT, hours INT, minutes INT)
RETURNS Datetime
BEGIN
	DECLARE currDate Datetime;
	SET currDate = CURDATE();
	SET currDate = DATE_ADD(currDate, INTERVAL days DAY);
	SET currDate = DATE_ADD(currDate, INTERVAL hours HOUR);
	SET currDate = DATE_ADD(currDate, INTERVAL minutes MINUTE);
	RETURN currDate;
END; //
DELIMITER ;

DELIMITER //
CREATE FUNCTION EncryptPassword(_password VARCHAR(30))
RETURNS VARCHAR(64)
BEGIN
	RETURN (SHA2(concat(_password, '4#$@*Rwerfwefdabwdsijn'), 256));
END; //
DELIMITER ;

SET @dt = NULL;

INSERT INTO User VALUES
	('user1' , 'Βασίλης' , 'Παπαδόπουλος'  , EncryptPassword('1'), 'bus_driver'           ),
	('user2' , 'Κώστας'  , 'Γεωργίου'      , EncryptPassword('1'), 'bus_driver'           ),
	('user3' , 'Γιάννης' , 'Δημητρίου'     , EncryptPassword('1'), 'chief'                ),
	('user4' , 'Βαγγέλης', 'Ιωάννου'       , EncryptPassword('1'), 'itinerary_distributor'),
	('user5' , 'Νίκος'   , 'Βασιλείου'     , EncryptPassword('1'), 'quality_manager'      ),
	('user6' , 'Θανάσης' , 'Αθανασίου'     , EncryptPassword('1'), 'client'               ),
	('user7' , 'Διονύσης', 'Χατζής'        , EncryptPassword('1'), 'client'               ),
	('user8' , 'Διονύσης', 'Διονυσιότης'   , EncryptPassword('1'), 'client'               ),
	('user9' , 'Θοδωρής' , 'Θεοδωρόπουλος' , EncryptPassword('1'), 'client'               ),
	('user10', 'Λευτέρης', 'Διακουμής'     , EncryptPassword('1'), 'client'               ),
	('user11', 'Βασίλης' , 'Χρονόπουλος'   , EncryptPassword('1'), 'client'               ),
	('user12', 'Βασίλης' , 'Αλευράς'       , EncryptPassword('1'), 'bus_driver'           ),
    ('user13', 'Βασίλης' , 'Βακαλόπουλος'  , EncryptPassword('1'), 'bus_driver'           ),
    ('user14', 'Βασίλης' , 'Δήμας'         , EncryptPassword('1'), 'bus_driver'           ),
    ('user15', 'Βασίλης' , 'Νικολακόπουλος', EncryptPassword('1'), 'bus_driver'           );

INSERT INTO Employee VALUES 
	('user1' , 900.00 , '2021-02-10', 2),
	('user2' , 930.00 , '2021-02-10', 3),
	('user3' , 1700.00, '2021-02-10', 2),
	('user4' , 1400.00, '2021-02-10', 6),
	('user5' , 1300.00, '2021-02-10', 1),
	('user12', 900.00 , '2021-02-10', 2),
    ('user13', 900.00 , '2021-02-10', 2),
    ('user14', 900.00 , '2021-02-10', 2),
    ('user15', 900.00 , '2021-02-10', 2);
    
INSERT INTO BusDriver VALUES
	('user1' , 0, 0),
	('user2' , 1, 0),
    ('user12', 0, 0),
    ('user13', 0, 0),
    ('user14', 0, 0),
    ('user15', 0, 0);

INSERT INTO Chief VALUES
	('user3');

INSERT INTO QualityManager VALUES
	('user5');

INSERT INTO ItineraryDistributionManager VALUES
	('user4', true);

INSERT INTO Client VALUES
	('user6' , 100, 1, 2),
	('user7' , 20 , 1, 3),
	('user8' , 30 , 0, 4),
	('user9' , 30 , 0, 1),
	('user10', 20 , 0, 1),
	('user11', 48 , 0, 1);
    
INSERT INTO SanitaryComplaint (targetUsername, summary, category, busDriverUsername) VALUES
	('user8', 'Ο επιβάτης δεν φορούσε μάσκα.', 'wear_mask_refusal', 'user2'),
    ('user8', 'Ο επιβάτης δεν φορούσε μάσκα.', 'wear_mask_refusal', 'user1');

INSERT INTO ClientComplaint (targetUsername, checked, summary, category, ClientUsername) VALUES
	('user1', false,'Ο οδηγός ήταν αγενής.', 'rude_bus_driver', 'user9'),
    ('user1', false,'Ο οδηγός ήταν προσβλητικός.', 'rude_bus_driver', 'user8'),
    ('user1', false,'Ο οδηγός άργησε χωρίς λόγο.', 'late_for_no_reason', 'user6'),
    ('user1', false,'Ο οδηγός ήταν αγενής.', 'rude_bus_driver', 'user10'),
    ('user1', false,'Ο οδηγός ήταν προσβλητικός.', 'rude_bus_driver', 'user8'),
    ('user1', false,'Ο οδηγός άργησε χωρίς λόγο.', 'late_for_no_reason', 'user6'),
    ('user1', false,'Ο οδηγός ήταν αγενής.', 'rude_bus_driver', 'user9'),
    ('user1', false,'Ο οδηγός ήταν προσβλητικός.', 'rude_bus_driver', 'user8'),
    ('user1', false,'Ο οδηγός άργησε χωρίς λόγο.', 'late_for_no_reason', 'user6'),
    ('user1', false,'Ο οδηγός άργησε χωρίς λόγο.', 'late_for_no_reason', 'user6');

INSERT INTO Bus (size) VALUES
	('small' ),
	('small' ),
	('medium'),
	('large' ),
	('large' ),
    ('small' ),
	('small' ),
	('medium'),
	('large' ),
	('large' );

INSERT INTO BusLine (number, duration) VALUES
	(1, 15),
	(2, 30),
	(3, 60),
	(4, 15);


DROP PROCEDURE IF EXISTS InsertItineraries;
DELIMITER $$
CREATE PROCEDURE InsertItineraries()
BEGIN
	DECLARE counter INT;
	DECLARE nextSunday DATE;
	SET nextSunday = curdate() + INTERVAL 6 - weekday(curdate()) DAY;
    
	SET counter = -60;
	WHILE (DatetimeAdder(counter, 0, 0) <= nextSunday) DO
		INSERT INTO Itinerary (status, travelDatetime, availableSeats, distributorUsername, busDriverUsername, busLineNumber, busID) VALUES 
			('no_delayed', DatetimeAdder(counter, 8, 0),  2, 'user4', 'user1', 3, 1),
			('no_delayed', DatetimeAdder(counter, 9, 0),  2, 'user4', 'user1', 3, 1),
			('no_delayed', DatetimeAdder(counter, 10, 0), 2, 'user4', 'user1', 3, 1),
			('no_delayed', DatetimeAdder(counter, 11, 0), 2, 'user4', 'user1', 3, 1),
			('no_delayed', DatetimeAdder(counter, 12, 0), 2, 'user4', 'user1', 3, 1),
			('no_delayed', DatetimeAdder(counter, 13, 0), 2, 'user4', 'user1', 3, 1),
			('no_delayed', DatetimeAdder(counter, 14, 0), 2, 'user4', 'user1', 3, 1),
			('no_delayed', DatetimeAdder(counter, 8, 0),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 8, 30),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 9, 0),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 9, 30),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 10, 0),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 10, 30),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 11, 0),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 11, 30),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 12, 0),  2, 'user4', 'user2', 2, 2),
			('no_delayed', DatetimeAdder(counter, 8, 0),  2, 'user4', 'user12', 4, 1),
			('no_delayed', DatetimeAdder(counter, 8, 15),  2, 'user4', 'user12', 4, 2),
			('no_delayed', DatetimeAdder(counter, 8, 30),  2, 'user4', 'user12', 4, 3),
			('no_delayed', DatetimeAdder(counter, 8, 45),  2, 'user4', 'user12', 4, 3),
			('no_delayed', DatetimeAdder(counter, 9, 00),  2, 'user4', 'user12', 4, 3),
			('no_delayed', DatetimeAdder(counter, 8, 00),  2, 'user4', 'user13', 1, 4),
			('no_delayed', DatetimeAdder(counter, 8, 15),  2, 'user4', 'user13', 1, 4),
			('no_delayed', DatetimeAdder(counter, 8, 30),  2, 'user4', 'user13', 1, 4),
			('no_delayed', DatetimeAdder(counter, 8, 45),  2, 'user4', 'user13', 1, 4),
			('no_delayed', DatetimeAdder(counter, 9, 00),  2, 'user4', 'user13', 1, 4);
		SET counter = counter + 1;
    END WHILE;
END$$
DELIMITER ;

Call InsertItineraries();


DROP PROCEDURE IF EXISTS InsertTransactionsAndTickets;
DELIMITER $$
CREATE PROCEDURE InsertTransactionsAndTickets()
BEGIN
	DECLARE counter INT;
    DECLARE nextSunday DATE;
    DECLARE id INT;
    SET nextSunday = curdate() + INTERVAL 6 - weekday(curdate()) DAY;
    SET counter = -60;
    SET id = 1;
    # first insert the tickets
    WHILE (DatetimeAdder(counter, 0, 0) <= nextSunday) DO
		INSERT INTO Ticket (delayedItinerary, used, issued, clientUsername, itineraryID) VALUES 
		(false, false, false, 'user6', id+0),
        (false, false, false, 'user7', id+1),
        (false, false, false, 'user8', id+2),
        (false, false, false, 'user9', id+3),
        (false, false, false, 'user10', id+4),
        (false, false, false, 'user11', id+5),
        (false, false, false, 'user6', id+6),
        (false, false, false, 'user7', id+7),
        (false, false, false, 'user8', id+8),
        (false, false, false, 'user9', id+9),
        (false, false, false, 'user10', id+10),
        (false, false, false, 'user11', id+11),
        (false, false, false, 'user6', id+12),
        (false, false, false, 'user7', id+13),
        (false, false, false, 'user8', id+14),
        (false, false, false, 'user9', id+15),
        (false, false, false, 'user10', id+16),
        (false, false, false, 'user11', id+17),
        (false, false, false, 'user6', id+18),
        (false, false, false, 'user7', id+19),
        (false, false, false, 'user8', id+20),
        (false, false, false, 'user9', id+21),
        (false, false, false, 'user10', id+22),
        (false, false, false, 'user11', id+23),
        (false, false, false, 'user6', id+24),
        (false, false, false, 'user7', id+25);
        # second round of tickets shifted by 3
        INSERT INTO Ticket (delayedItinerary, used, issued, clientUsername, itineraryID) VALUES 
		(false, false, false, 'user9', id+0),
        (false, false, false, 'user10', id+1),
        (false, false, false, 'user11', id+2),
        (false, false, false, 'user6', id+3),
        (false, false, false, 'user7', id+4),
        (false, false, false, 'user8', id+5),
        (false, false, false, 'user9', id+6),
        (false, false, false, 'user10', id+7),
        (false, false, false, 'user11', id+8),
        (false, false, false, 'user6', id+9),
        (false, false, false, 'user7', id+10),
        (false, false, false, 'user8', id+11),
        (false, false, false, 'user9', id+12),
        (false, false, false, 'user10', id+13),
        (false, false, false, 'user11', id+14),
        (false, false, false, 'user6', id+15),
        (false, false, false, 'user7', id+16),
        (false, false, false, 'user8', id+17),
        (false, false, false, 'user9', id+18),
        (false, false, false, 'user10', id+19),
        (false, false, false, 'user11', id+20),
        (false, false, false, 'user6', id+21),
        (false, false, false, 'user7', id+22),
        (false, false, false, 'user8', id+23),
        (false, false, false, 'user9', id+24),
        (false, false, false, 'user10', id+25);
        SET counter = counter + 1;
        SET id = id + 26;
    END WHILE;
    # now time for the transactions
    # reset the values
    SET counter = -60;
    SET id = 1;
    WHILE (DatetimeAdder(counter, 0, 0) <= nextSunday) DO
		INSERT INTO Transaction(ticketID, price, purchaseDatetime) VALUES
        (id+0, 2.50, SUBTIME(DatetimeAdder(counter, 8, 0), '0:30')),
        (id+1, 2.50, SUBTIME(DatetimeAdder(counter, 9, 0), '0:30')),
        (id+2, 2.50, SUBTIME(DatetimeAdder(counter, 10, 0), '0:30')),
        (id+3, 2.50, SUBTIME(DatetimeAdder(counter, 11, 0), '0:30')),
        (id+4, 2.50, SUBTIME(DatetimeAdder(counter, 12, 0), '0:30')),
        (id+5, 2.50, SUBTIME(DatetimeAdder(counter, 13, 0), '0:30')),
        (id+6, 2.50,SUBTIME(DatetimeAdder(counter, 14, 0), '0:30')),
        (id+7, 2.50, SUBTIME(DatetimeAdder(counter, 8, 0), '0:30')),
        (id+8, 2.50, SUBTIME(DatetimeAdder(counter, 8, 30), '0:30')),
        (id+9, 2.50, SUBTIME(DatetimeAdder(counter, 9, 0), '0:30')),
        (id+10, 2.50, SUBTIME(DatetimeAdder(counter, 9, 30), '0:30')),
        (id+11, 2.50, SUBTIME(DatetimeAdder(counter, 10, 0), '0:30')),
        (id+12, 2.50, SUBTIME(DatetimeAdder(counter, 10, 30), '0:30')),
        (id+13, 2.50, SUBTIME(DatetimeAdder(counter, 11, 0), '0:30')),
        (id+14, 2.50, SUBTIME(DatetimeAdder(counter, 11, 30), '0:30')),
        (id+15, 2.50, SUBTIME(DatetimeAdder(counter, 12, 0), '0:30')),
        (id+16, 2.50, SUBTIME(DatetimeAdder(counter, 8, 0), '0:30')),
        (id+17, 2.50, SUBTIME(DatetimeAdder(counter, 8, 15), '0:30')),
        (id+18, 2.50, SUBTIME(DatetimeAdder(counter, 8, 30), '0:30')),
        (id+19, 2.50, SUBTIME(DatetimeAdder(counter, 8, 45), '0:30')),
        (id+20, 2.50, SUBTIME(DatetimeAdder(counter, 9, 00), '0:30')),
        (id+21, 2.50, SUBTIME(DatetimeAdder(counter, 8, 00), '0:30')),
        (id+22, 2.50, SUBTIME(DatetimeAdder(counter, 8, 15), '0:30')),
        (id+23, 2.50, SUBTIME(DatetimeAdder(counter, 8, 35), '0:30')),
        (id+24, 2.50, SUBTIME(DatetimeAdder(counter, 8, 45), '0:30')),
        (id+25, 2.50, SUBTIME(DatetimeAdder(counter, 9, 00), '0:30'));
        # second round of purchases
        SET id = id + 26;
        INSERT INTO Transaction(ticketID, price, purchaseDatetime) VALUES
        (id+0, 2.50, SUBTIME(DatetimeAdder(counter, 8, 0), '0:25')),
        (id+1, 2.50, SUBTIME(DatetimeAdder(counter, 9, 0), '0:25')),
        (id+2, 2.50, SUBTIME(DatetimeAdder(counter, 10, 0), '0:25')),
        (id+3, 2.50, SUBTIME(DatetimeAdder(counter, 11, 0), '0:25')),
        (id+4, 2.50, SUBTIME(DatetimeAdder(counter, 12, 0), '0:25')),
        (id+5, 2.50, SUBTIME(DatetimeAdder(counter, 13, 0), '0:25')),
        (id+6, 2.50,SUBTIME(DatetimeAdder(counter, 14, 0), '0:25')),
        (id+7, 2.50, SUBTIME(DatetimeAdder(counter, 8, 0), '0:25')),
        (id+8, 2.50, SUBTIME(DatetimeAdder(counter, 8, 30), '0:25')),
        (id+9, 2.50, SUBTIME(DatetimeAdder(counter, 9, 0), '0:25')),
        (id+10, 2.50, SUBTIME(DatetimeAdder(counter, 9, 30), '0:25')),
        (id+11, 2.50, SUBTIME(DatetimeAdder(counter, 10, 0), '0:25')),
        (id+12, 2.50, SUBTIME(DatetimeAdder(counter, 10, 30), '0:25')),
        (id+13, 2.50, SUBTIME(DatetimeAdder(counter, 11, 0), '0:25')),
        (id+14, 2.50, SUBTIME(DatetimeAdder(counter, 11, 30), '0:25')),
        (id+15, 2.50, SUBTIME(DatetimeAdder(counter, 12, 0), '0:25')),
        (id+16, 2.50, SUBTIME(DatetimeAdder(counter, 8, 0), '0:25')),
        (id+17, 2.50, SUBTIME(DatetimeAdder(counter, 8, 15), '0:25')),
        (id+18, 2.50, SUBTIME(DatetimeAdder(counter, 8, 30), '0:25')),
        (id+19, 2.50, SUBTIME(DatetimeAdder(counter, 8, 45), '0:25')),
        (id+20, 2.50, SUBTIME(DatetimeAdder(counter, 9, 00), '0:25')),
        (id+21, 2.50, SUBTIME(DatetimeAdder(counter, 8, 00), '0:25')),
        (id+22, 2.50, SUBTIME(DatetimeAdder(counter, 8, 15), '0:25')),
        (id+23, 2.50, SUBTIME(DatetimeAdder(counter, 8, 35), '0:25')),
        (id+24, 2.50, SUBTIME(DatetimeAdder(counter, 8, 45), '0:25')),
        (id+25, 2.50, SUBTIME(DatetimeAdder(counter, 9, 00), '0:25'));
        SET counter = counter + 1;
        SET id = id + 26;
    END WHILE;
    
    # finally update the available slots on the itinerary
    # need the set else the update won't work
    SET SQL_SAFE_UPDATES = 0;
    UPDATE ITINERARY
    SET availableSeats = 0;
    SET SQL_SAFE_UPDATES = 1;
END$$
DELIMITER ;

CALL insertTransactionsAndTickets();


INSERT INTO Stop (number, stopName) VALUES
	(1 , 'Φαρών 6'           ),
	(1 , 'Νόρμαν 7'          ),
	(1 , 'Αγίου Ανδρέα 78'   ),
	(1 , 'Χαρίλαου Τρικόπη 7'),
	(1 , 'Πολυτέκων 47'      ),
	(1 , 'Σιδηροδρόμων 284'  ),
	(2 , 'Σιδηροδρόμων 284'   ),
	(2 , 'Ναυαρίνου 23'      ),
	(2 , 'Καβάλας 89'        ),
	(2 , 'Μαυρομιχάλη 84'    ),
	(2 , 'Δ. Ράλλη 76'       ),
	(2 , 'Ναυαρίνου 23'      ),
	(3 , 'Ναυαρίνου 23'    ),
	(3 , 'Ύδρας 98'          ),
	(3 , 'Αγίου Γεωργίου 32' ),
	(3 , 'ΕΛ. Βενιζέλου 90' ),
	(3 , 'Γούναρη 22'       ),
	(3 , 'Κάστορος 73'      ),
	(4 , 'Αγίου Νικολάου 54'),
	(4 , 'Κυψέλης 65'       ),
	(4 , 'Αριστομένους 21'  ),
	(4 , 'Κοραή 43'         ),
	(4 , 'Τερψιθέας 90'     ),
	(4 , 'Αλεξάνδριας 43'   );

INSERT INTO Poll (title, expired, startingDate, endingDate, question, qualityManagerUsername) VALUES 
	('Προσθήκη νέων στάσεων.', true, DatetimeAdder(-10, 0, 0), DatetimeAdder(-2, 0, 0), 'Θα θέλατε το δρομολόγιο 1 να έχει περισσότερες στάσεις;', 'user5');

INSERT INTO PollChoice (choice, title) VALUES 
	('Ναι'  , 'Προσθήκη νέων στάσεων.'),
	('Όχι'   , 'Προσθήκη νέων στάσεων.'),
	('Δεν το χρησιμοποιώ', 'Προσθήκη νέων στάσεων.');

INSERT INTO PollVote VALUES
	(1, 'user6'),
	(2, 'user7'),
	(2, 'user8');
    
INSERT INTO AdvertisementComponent (busCount, busPart, busSize) VALUES
	(2, 'inside', 'small');

INSERT INTO AdvertisementContract (duration, expired, signDate, enterprise, price, chiefUsername, advertisementComponentID)
	VALUES (10, false, DatetimeAdder(-3, 0, 0), 'Microtransaction', 2000, 'user3', 1);

INSERT INTO PaidLeaveApplication (busDriverUsername, reason, applicationDate, status, requestedDate) VALUES 
	('user1', 'Πρέπει να συνοδεύσω την μητέρα μου στο νοσοκομείο για εξετάσεις.', DatetimeAdder(-3, 0, 0), 'pending', DatetimeAdder(15, 0, 0));
    
INSERT INTO Feedback (feedbackText, qualityManagerUsername) values
	('Το δρομολόγιο με αριθμό Χ αργεί σχεδόν πάντα να ολοκληρωθεί...', 'user5'),
    ('Πρεπει να προστεθεί και άλλη γραμμή που να καλύπτει τις περιοχές Χ, Υ, Ζ.', 'user5');
    

/*  
---------------------
STORED PROCEDURES AND EVENTS
---------------------
*/
DROP PROCEDURE IF EXISTS GenerateItineraryAndTicket;
DELIMITER $$
CREATE PROCEDURE GenerateItineraryAndTicket()
BEGIN
	INSERT INTO Itinerary (status, travelDatetime, availableSeats, distributorUsername, busDriverUsername, busLineNumber, busID) VALUES 
		('no_delayed', DATE_FORMAT(CURRENT_TIMESTAMP(), "%Y-%m-%d %T"), 2, 'user4', 'user2', 1, 1);
	
	SET @t = (select max(itineraryID) from itinerary);
    
	INSERT INTO Ticket (delayedItinerary, used, issued, clientUsername, itineraryID) VALUES 
		(false, false, false, 'user7', @t); 
END$$
DELIMITER ;

/*
=====================
=====================
*/

DROP PROCEDURE IF EXISTS SetOldTicketsAsUsed;
DELIMITER $$
CREATE PROCEDURE SetOldTicketsAsUsed()
BEGIN
	DECLARE _ticketID INT;
	DECLARE finishedFlag INT;
	DECLARE _cursor CURSOR FOR 	
		SELECT ticketID 
		FROM Ticket 
		inner join Itinerary on Ticket.itineraryID = Itinerary.itineraryID 
		inner join BusLine on itinerary.busLineNumber = BusLine.number 
		where DATE_ADD(itinerary.travelDatetime, INTERVAL duration MINUTE) <= current_timestamp();
						   
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET finishedFlag = 1;
	OPEN _cursor;
	SET finishedFlag = 0;
	FETCH _cursor INTO _ticketID;
	WHILE (finishedFlag = 0) DO 
		UPDATE Ticket SET used = 1 WHERE ticketID = _ticketID;
		FETCH _cursor INTO _ticketID;
	END WHILE;
	CLOSE _cursor;
END$$
DELIMITER ;

/*
=====================
=====================
*/

DROP PROCEDURE IF EXISTS DeleteExpiredLastMinuteTravelRequest;
DELIMITER $$
CREATE PROCEDURE DeleteExpiredLastMinuteTravelRequest()
BEGIN
	DECLARE _id INT;
	DECLARE finishedFlag INT;
	DECLARE _cursor CURSOR FOR 	
		SELECT lastMinuteTravelRequestID 
		FROM LastMinuteTravelRequest  
		inner join BusLine on LastMinuteTravelRequest.travelBusLine = BusLine.number 
		where DATE_ADD(LastMinuteTravelRequest.travelDatetime, INTERVAL duration MINUTE) <= current_timestamp();
                               
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET finishedFlag = 1;
    OPEN _cursor;
    SET finishedFlag = 0;
    FETCH _cursor INTO _id;
    WHILE (finishedFlag = 0) DO 
		DELETE FROM LastMinuteTravelRequest WHERE lastMinuteTravelRequestID = _id;
        FETCH _cursor INTO _id;
    END WHILE;
    CLOSE _cursor;
END$$
DELIMITER ;

/*
=====================
=====================
*/

DROP PROCEDURE IF EXISTS DeleteExpiredPaidLeaveApplications;
DELIMITER $$
CREATE PROCEDURE DeleteExpiredPaidLeaveApplications()
BEGIN
	DECLARE _id INT;
	DECLARE finishedFlag INT;
	DECLARE _cursor CURSOR FOR	
		SELECT paidLeaveApplicationID 
		FROM PaidLeaveApplication  
		where requestedDate <= current_timestamp();
                               
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET finishedFlag = 1;
	OPEN _cursor;
	SET finishedFlag = 0;
	FETCH _cursor INTO _id;
	WHILE (finishedFlag = 0) DO 
		DELETE FROM PaidLeaveApplication WHERE paidLeaveApplicationID = _id;
		FETCH _cursor INTO _id;
	END WHILE;
	CLOSE _cursor;
END$$
DELIMITER ;

/*
=====================
=====================
*/

DROP PROCEDURE IF EXISTS DeleteExpiredReservations;
DELIMITER $$
CREATE PROCEDURE DeleteExpiredReservations()
BEGIN
	DECLARE _id INT;
	DECLARE finishedFlag INT;
	DECLARE _cursor CURSOR FOR	
		SELECT reservationID
		FROM Reservation  
		where travelDatetime <= current_timestamp();
                               
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET finishedFlag = 1;
	OPEN _cursor;
	SET finishedFlag = 0;
	FETCH _cursor INTO _id;
	WHILE (finishedFlag = 0) DO 
		DELETE FROM Reservation WHERE reservationID = _id;
		FETCH _cursor INTO _id;
	END WHILE;
	CLOSE _cursor;
END$$
DELIMITER ;

/*
=====================
=====================
*/

DROP EVENT IF EXISTS ModifyExpiredStuff;
DELIMITER $$
CREATE EVENT ModifyExpiredStuff
	ON SCHEDULE EVERY 1 minute
	STARTS current_timestamp()
	ON COMPLETION PRESERVE
DO
	BEGIN
		CALL DeleteExpiredReservations();
		CALL DeleteExpiredPaidLeaveApplications();
		CALL DeleteExpiredLastMinuteTravelRequest();
		CALL SetOldTicketsAsUsed();
	END$$
DELIMITER ;

DROP EVENT IF EXISTS ResetComplaintCounter;
DELIMITER $$
CREATE EVENT ResetComplaintCounter
	ON SCHEDULE AT '2021-12-31 23:59:59' + INTERVAL 1 YEAR
	ON COMPLETION PRESERVE
DO
	BEGIN
		UPDATE BusDriver SET complaintsCounter = 0;
	END$$
DELIMITER ;

