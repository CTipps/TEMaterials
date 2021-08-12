USE master;
GO

DROP DATABASE IF EXISTS ProjectOrganizer
GO

CREATE DATABASE ProjectOrganizer
GO

USE ProjectOrganizer
GO

CREATE TABLE Department (
Department_Id int IDENTITY PRIMARY KEY,
Name nvarchar(30)
)

CREATE TABLE Project (
Project_Id int IDENTITY PRIMARY KEY,
Project_Title nvarchar(30) NOT NULL,
Project_Start DATE,
Department_Id int,
)

CREATE TABLE Employee (
Employee_Id int IDENTITY PRIMARY KEY,
Job_Title nvarchar(30) NOT NULL,
Last_Name nvarchar(30) NOT NULL,
First_Name nvarchar(30) NOT NULL,
Gender nvarchar(30) NOT NULL,
Date_Of_Birth DATE NOT NULL,
Date_Of_Hire Date NOT NULL,
Department_Id int NOT NULL,
)

CREATE TABLE Project_Assignment (	
	Project_Id INT NOT NULL,
	Employee_Id INT NOT NULL,
	CONSTRAINT pk_project_employee PRIMARY KEY (project_id, employee_id)
);

ALTER TABLE employee ADD CONSTRAINT fk_employee_department FOREIGN KEY (department_id) REFERENCES department(department_id);

ALTER TABLE Project_Assignment ADD FOREIGN KEY (project_id) REFERENCES project(project_id);
ALTER TABLE Project_Assignment ADD FOREIGN KEY (employee_id) REFERENCES employee(employee_id);

INSERT INTO department (name) VALUES ('Complaints Department'),('Ministry of Silly Walks'),('Argument Clinic'),('Being Hit On The Head Lessons');

INSERT INTO project (Project_Title, Project_Start) VALUES ('Quest For Holy Grail', '1975-04-27');
INSERT INTO project (Project_Title, Project_Start) VALUES ('Count To Three', '1981-01-23');
INSERT INTO project (Project_Title, Project_Start) VALUES ('Throwing The Holy Hand Grenade', '2005-06-06');
INSERT INTO project (Project_Title, Project_Start) VALUES ('Defeat The Black Knight', '2015-08-25');

INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (1, 'Arthur', 'King', 'male', '1946-06-20', '2018-08-28', 'King Complaints');
INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (1, 'Court', 'Segler', 'male', '1995-12-22', '2018-08-28', 'Counter Complainer');
INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (2, 'Chad', 'Allen', 'male', '1974-07-23', '2018-08-28', 'Walk Judge');
INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (2, 'Angela', 'Kay', 'female', '1976-01-30', '2018-08-28', 'High Round Stepper');
INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (3, 'Aric', 'Nichols', 'male', '1999-05-26', '2018-08-28', 'Payment Collector');
INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (3, 'Harley', 'Marie', 'female', '1998-06-05', '2018-08-28', 'Head Arguer');
INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (4, 'Kyrie', 'Elizabeth', 'female', '2001-05-05', '2018-08-28', 'Club Polisher');
INSERT INTO employee (department_id, first_name, last_name, gender, Date_Of_Birth, Date_Of_Hire, Job_Title)
VALUES (4, 'Lisa', 'Kirking', 'female', '1971-09-10', '2018-08-28', 'Bonker');


INSERT INTO Project_Assignment (project_id, employee_id) VALUES (1, 1);
INSERT INTO Project_Assignment (project_id, employee_id) VALUES (1, 8);
INSERT INTO Project_Assignment (project_id, employee_id) VALUES (2, 2);
INSERT INTO Project_Assignment (project_id, employee_id) VALUES (2, 7);
INSERT INTO Project_Assignment (project_id, employee_id) VALUES (3, 3);
INSERT INTO Project_Assignment (project_id, employee_id) VALUES (3, 5);
INSERT INTO Project_Assignment (project_id, employee_id) VALUES (4, 4);
INSERT INTO Project_Assignment (project_id, employee_id) VALUES (4, 6);