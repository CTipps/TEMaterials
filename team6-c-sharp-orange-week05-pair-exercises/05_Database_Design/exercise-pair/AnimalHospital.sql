--
--
USE master;
Go
-- Delete the application database (IF EXISTS)
DROP DATABASE IF EXISTS AnimalHospital;
GO
--Create a new application DB AnimalHospital
CREATE DATABASE AnimalHospital;
GO
-- Switch to the application database
USE AnimalHospital
GO
-- DROP TABLE dbo.Hospital;
-- DROP TABLE dbo.Procedure;
-- DROP TABLE dbo.Owner;
-- DROP TABLE dbo.Pet;
-- DROP TABLE dbo.Visit_Line;
-- DROP TABLE dbo.Visit;



CREATE	TABLE	Hospital (						
				Hospital_Id	int	IDENTITY(1,1) PRIMARY KEY,
				Hospital_Name nvarchar (50) NOT NULL		
			)						
GO									
									
CREATE	TABLE	ProcedureA (						
				Procedure_Id int IDENTITY(1,1) PRIMARY KEY,
				Procedure_Name nvarchar (50) NOT NULL		
			)						
GO									
									
CREATE	TABLE	OwnerA (						
				Owner_Id int IDENTITY(1,1) PRIMARY KEY,
				Title nvarchar (15),
				First_Name nvarchar (60) NOT NULL,
				Last_Name nvarchar (60) NOT NULL,
				Address	nvarchar (60) NOT NULL,
				City nvarchar (60) NOT NULL,
				State nvarchar (60) NOT NULL,
				Owner_Account nvarchar (60) NOT NULL		
			)						
GO									
									
CREATE	TABLE	Pet	(						
				Pet_Id	int	IDENTITY(1,1) PRIMARY KEY,
				Pet_Name nvarchar (35),
				Pet_Type nvarchar (35),
				Pet_Age	int,
				Owner_Id int NOT NULL		
			)						
GO									

CREATE	TABLE	Visit	(						
				Visit_Id	int	IDENTITY(1,1) 	NOT NULL	PRIMARY KEY	,
				Visit_Date	DATE		NOT NULL		,
				Tax	decimal		NOT NULL		,
				Invoice_Num	int		NOT NULL		,
				Hospital_Id	int		NOT NULL	
				)									

CREATE	TABLE	Visit_Line	(						
				Line_Id	int	IDENTITY(1,1) 	NOT NULL	PRIMARY KEY	,
				Owner_Id	int		NOT NULL		,
				Pet_Id	int		NOT NULL		,
				Procedure_Id	int		NOT NULL		,
				Amount	decimal		NOT NULL		,
				Visit_Id	int NOT NULL
			)						
GO									
									

									
ALTER TABLE PET									
ADD FOREIGN KEY (Owner_Id) References OwnerA(Owner_Id);							
									
ALTER TABLE Visit_Line									
ADD FOREIGN KEY (Owner_Id) References OwnerA(Owner_Id);							
ALTER TABLE Visit_Line									
ADD FOREIGN KEY (Pet_Id) References	Pet(Pet_Id);								
ALTER TABLE Visit_Line									
ADD FOREIGN KEY (Procedure_Id) References ProcedureA(Procedure_Id);	
ALTER TABLE Visit_Line									
ADD FOREIGN KEY (Visit_Id)	References	Visit(Visit_Id);
									
ALTER TABLE Visit									
ADD FOREIGN KEY (Hospital_Id) References Hospital(Hospital_Id);							
									
INSERT INTO OwnerA (Title, First_Name, Last_Name, Address, City, State, Owner_Account)									
VALUES ('MR', 'Richard','Cook','123 This Street','My City','Ontario','Z5Z 6G6')

INSERT INTO Hospital (Hospital_Name)									
VALUES ('HILLTOP ANIMAL HOSPITAL')

INSERT INTO Pet (Pet_Name, Pet_Type, Pet_Age, Owner_Id)									
VALUES ('ROVER','DOG','2', 1)

INSERT INTO Pet (Pet_Name, Pet_Type, Pet_Age, Owner_Id)									
VALUES ('MORRIS','CAT','2', 1)

INSERT INTO ProcedureA (Procedure_Name)									
VALUES ('Rabies Vaccination')

INSERT INTO Visit( Visit_Date, Tax, Invoice_Num, Hospital_Id)									
VALUES ('2002-01-13', 0.08, 987,1)

INSERT INTO Visit_Line( Owner_Id, Pet_Id, Procedure_Id, Amount, Visit_Id)									
VALUES (1,1,1, 30.00, 1)

INSERT INTO Visit_Line( Owner_Id, Pet_Id, Procedure_Id, Amount, Visit_Id)									
VALUES (1,2,1, 24.00,1)



-- To verify the functionality os the databese we run the query below

--SELECT h.Hospital_Name, v.Invoice_Num, v.Visit_Date,O.Title, o.First_Name, o.Last_Name, p.Pet_Name, p.Pet_Age, p.Pet_Type, pa.Procedure_Name, Amount, Tax, vl.Line_Id
--  FROM Visit_Line vl JOIN Visit v ON(vl.Visit_Id = v.Visit_Id)
--					 JOIN Hospital h ON (v.Hospital_Id = h.Hospital_Id)
--					 JOIN OwnerA o ON (o.Owner_Id = vl.Owner_Id) 
--					 JOIN Pet p ON (p.Pet_Id = vl.Pet_Id)
--					 JOIN ProcedureA pa ON (pa.Procedure_Id = vl.Procedure_Id)

