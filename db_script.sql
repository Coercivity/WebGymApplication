CREATE TABLE RoleGroup(
	Id INT PRIMARY KEY,
	RoleName NVARCHAR(12) NOT NULL
);


CREATE TABLE StatisticsData(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	StartDate DATE,
	FinishDate DATE,
	MedianPulse INT,
	MedianHeadPressure INT,
	MedianHeartPressure INT,
	WeightData FLOAT,
	VisitsAmount INT,
	MedianCaloriesSpent FLOAT
);


CREATE TABLE Account(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	
	LoginData NVARCHAR(50) NOT NULL,
	PasswordData NVARCHAR(100) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	GroupId INT NOT NULL FOREIGN KEY REFERENCES RoleGroup(Id),

);

CREATE TABLE Client(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	FirstName NVARCHAR(50),
	Surname NVARCHAR(50),
	Patronymic NVARCHAR(50),
	PhoneNumber VARCHAR(16),
	Sex NVARCHAR(10),
	BirthDate DATE,
	AccountId UNIQUEIDENTIFIER UNIQUE FOREIGN KEY REFERENCES Account(Id),
	StatisticsDataId UNIQUEIDENTIFIER UNIQUE FOREIGN KEY REFERENCES StatisticsData(Id)
);


CREATE TABLE Coach(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	FirstName NVARCHAR(50),
	Surname NVARCHAR(50),
	Patronymic NVARCHAR(50),
	PhoneNumber VARCHAR(16),
	Experience INT,
	Degree NVARCHAR(50),
	AccountId UNIQUEIDENTIFIER UNIQUE FOREIGN KEY REFERENCES Account(Id)

);

CREATE TABLE Abonement(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	StartDate DATE,
	FinishDate DATE,
	VisitsAmount INT,
	ClientId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Client(Id),
	IsValid BIT
);



CREATE TABLE Attendance(
	ID UNIQUEIDENTIFIER PRIMARY KEY,
	CoachId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Coach(Id),
	StatisticsDataId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES StatisticsData(Id),
	StartTime DATETIME ,
	FinishTime DATETIME ,
	Pulse INT,
	HeadPressure INT,
	HeartPressure INT,
	WeightData FLOAT,
	CaloriesSpent FLOAT
);


CREATE TABLE ServiceDataType(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	NameData NVARCHAR(50),
	Price MONEY
);

CREATE TABLE ServiceData(
	AbonementId UNIQUEIDENTIFIER,
	AttendanceId UNIQUEIDENTIFIER,
	ServiceDataTypeId UNIQUEIDENTIFIER,
	FOREIGN KEY(AbonementId) REFERENCES Abonement(Id),
	FOREIGN KEY(AttendanceId) REFERENCES Attendance(Id),
	FOREIGN KEY(ServiceDataTypeId) REFERENCES ServiceDataType(Id),
	PRIMARY KEY(AbonementId, AttendanceId)
);


CREATE TABLE Schedule(
	ID UNIQUEIDENTIFIER PRIMARY KEY,
	Description NVARCHAR(100)

);


CREATE TABLE TrainType(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	ImagePath NVARCHAR(50),
	Description NVARCHAR(50)
);

CREATE TABLE DayNamings(
	Id INT PRIMARY KEY,
	DayData NVARCHAR(12)
);


CREATE TABLE Position(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	CoachId  UNIQUEIDENTIFIER,
	ScheduleId UNIQUEIDENTIFIER,
	StartTime DATETIME ,
	FinishTime DATETIME ,
	DayNamingsId INT,
	TrainTypeId UNIQUEIDENTIFIER,
	FOREIGN KEY(DayNamingsId) REFERENCES DayNamings(Id),
	FOREIGN KEY(TrainTypeId) REFERENCES TrainType(Id),
	FOREIGN KEY(CoachId) REFERENCES Coach(Id),
	FOREIGN KEY(ScheduleId) REFERENCES Schedule(Id)
	
);


INSERT INTO RoleGroup VALUES
(1, 'Admin'),
(2, 'Coach'),
(3, 'Client');


INSERT INTO DayNamings VALUES
(1, N'??????????????????????'),
(2, N'??????????????'),
(3, N'??????????'),
(4, N'??????????????'),
(5, N'??????????????'),
(6, N'??????????????');

