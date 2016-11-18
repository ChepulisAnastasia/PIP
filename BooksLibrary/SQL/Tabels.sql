CREATE TABLE Books (
	ISBN nchar(13) not null PRIMARY KEY ,
	author nchar(40) null,
	name nchar(50) not null,
	publication_type nchar(50) null,
	tome smallint null,
	compiler nchar(40) null,
	language nchar(30) null,
	translator nchar(40) null,
	place_publication nchar(20) null,
	publishing nchar(6) null,
	year int null CHECK (year>1970),
	number smallint not null,
	price money not null
);

CREATE TABLE Knowledge  (
	id int not null PRIMARY KEY IDENTITY (1, 1),
	knowledge varchar(20) not null
);

CREATE TABLE Catalogs (
	ISBN nchar(13) not null REFERENCES Books,
	knowledge_id int not null REFERENCES Knowledge
);

CREATE TABLE Instances  (
	id int not null PRIMARY KEY IDENTITY (1, 1),
	room  smallint not null CHECK(room <= 10),
	rack smallint not null CHECK(rack <= 30),
	shelf smallint not null CHECK(shelf <= 50),
	existence nchar(3) DEFAULT 'да',
	ISBN nchar(13) not null references Books
);
ALTER TABLE Instances
	ADD CONSTRAINT Existence_Book CHECK (existence IN ('да', 'нет'))
GO

CREATE TABLE Readers  (
	id int not null PRIMARY KEY IDENTITY (1, 1),
	last_name varchar(20) not null,
	name varchar(20) not null,
	middle_name varchar(20) not null,
	age  smallint not null CHECK (age  > 16),
	address  varchar(40) not null,
	phone  varchar(13) not null,
);

CREATE TABLE Extradition(
	id int PRIMARY KEY IDENTITY (1, 1),
	instance_id int references Instances not null,
	reader_id int references Readers not null,
	date_extradition date null,
	return_date date null
);
ALTER TABLE Extradition ADD DEFAULT SYSDATETIME() FOR date_extradition;