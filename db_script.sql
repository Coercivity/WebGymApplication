CREATE TABLE RoleGroup(
	Id INT PRIMARY KEY,
	RoleName NVARCHAR(12) NOT NULL
);


CREATE TABLE StatisticsData(
	Id INT IDENTITY PRIMARY KEY,
	StartDate DATE NOT NULL,
	FinishDate DATE NOT NULL,
	VisitsAmount INT NOT NULL,
);


CREATE TABLE Account(
	Id INT IDENTITY PRIMARY KEY,
	
	LoginData NVARCHAR(50) NOT NULL,
	PasswordData NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	GroupId INT NOT NULL FOREIGN KEY REFERENCES RoleGroup(Id),


);

CREATE TABLE Client(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(16) NOT NULL,
	AccountId INT UNIQUE FOREIGN KEY REFERENCES Account(Id),
	StatisticsDataId INT UNIQUE FOREIGN KEY REFERENCES StatisticsData(Id)
);


CREATE TABLE Coach(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(16) NOT NULL,
	Experience INT NOT NULL,
	Degree NVARCHAR(50) NOT NULL,
	AccountId INT UNIQUE FOREIGN KEY REFERENCES Account(Id)

);

CREATE TABLE Abonement(
	Id INT IDENTITY PRIMARY KEY,
	StartDate DATE NOT NULL,
	FinishDate DATE NOT NULL,
	VisitsAmount INT NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Client(Id)
);



CREATE TABLE Attendance(
	ID INT PRIMARY KEY,
	CoachId INT FOREIGN KEY REFERENCES Coach(Id),
	StatisticsDataId INT FOREIGN KEY REFERENCES StatisticsData(Id),
	StartTime DATE NOT NULL,
	FinishTime DATE NOT NULL,
	Pulse INT NOT NULL,
	HeadPressure INT NOT NULL,
	HeartPressure INT NOT NULL,
	WeightData FLOAT NOT NULL,
);


CREATE TABLE ServiceDataType(
	Id INT IDENTITY PRIMARY KEY,
	NameData NVARCHAR(50),
	Price MONEY
);

CREATE TABLE ServiceData(
	AbonementId INT,
	AttendanceId INT,
	ServiceDataTypeId INT,
	FOREIGN KEY(AbonementId) REFERENCES Abonement(Id),
	FOREIGN KEY(AttendanceId) REFERENCES Attendance(Id),
	FOREIGN KEY(ServiceDataTypeId) REFERENCES ServiceDataType(Id),
	PRIMARY KEY(AbonementId, AttendanceId)
);