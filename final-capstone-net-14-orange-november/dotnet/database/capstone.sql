USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	password_reset_code varchar(50) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE agencies (
	agency_id int NOT NULL PRIMARY KEY,
	name nvarchar(255) NOT NULL,
	street nvarchar(255),
	city nvarchar(255) NOT NULL,
	state nvarchar(255) NOT NULL,
	postal_code nvarchar(10) NOT NULL,
	email nvarchar(255),
	phone nvarchar(255),
	lat float NOT NULL,
	lon float NOT NULL,
	about nvarchar(max),
	url nvarchar(255)
)

CREATE TABLE species (
	species_id int NOT NULL PRIMARY KEY,
	name nvarchar(255) NOT NULL,
	plural nvarchar(255) NOT NULL,
	young_singular nvarchar(255) NOT NULL,
	young_plural nvarchar(255) NOT NULL,
)

CREATE TABLE breeds (
	breed_id int NOT NULL PRIMARY KEY,
	name nvarchar(255) NOT NULL,
	species_id int FOREIGN KEY REFERENCES species(species_id) NOT NULL,
)

CREATE TABLE pets (
	pet_id int NOT NULL PRIMARY KEY,
	species_id int FOREIGN KEY REFERENCES species(species_id) NOT NULL,
	breed_id int FOREIGN KEY REFERENCES breeds(breed_id) NOT NULL,
	agency_id int FOREIGN KEY REFERENCES agencies(agency_id) NOT NULL,
	primary_image_id int NOT NULL,
	primary_image_url nvarchar(255) NOT NULL,
	thumbnail_url nvarchar(255) NOT NULL,
	name nvarchar(255) NOT NULL,
	description_text nvarchar(max),
	sex nvarchar(6),
	age_group nvarchar(20),
	age_string nvarchar(255),
	activity_level nvarchar(20),
	exercise_needs nvarchar(20),
	owner_experience nvarchar(20),
	size_group nvarchar(20),
	vocal_level nvarchar(20)
)

CREATE TABLE user_pet (
	user_id int FOREIGN KEY REFERENCES users(user_id) NOT NULL,
	pet_id int FOREIGN KEY REFERENCES pets(pet_id) NOT NULL
	CONSTRAINT PK_user_pet PRIMARY KEY (user_id, pet_id)
)

CREATE TABLE pictures (
	picture_id int NOT NULL PRIMARY KEY,
	pet_id int NOT NULL,
	url nvarchar(255) NOT NULL
)

--ALTER TABLE pets
--WITH CHECK ADD CONSTRAINT FK_PetPicture
--FOREIGN KEY (primary_image_id) REFERENCES pictures(picture_id);

--populate default data
-- user/password
INSERT INTO users (username, email, password_hash, salt, password_reset_code, user_role) VALUES ('user', 'user@user.com', 'Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'ssrpcgg4b3c','user');
--admin/password
INSERT INTO users (username, email, password_hash, salt, password_reset_code, user_role) VALUES ('admin', 'admin@admin.com','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=', 'ssrp48g4b3c', 'admin');

GO

--SELECT * FROM users;
--SELECT * FROM species;
--SELECT * FROM breeds;
--SELECT * FROM agencies;
--SELECT * FROM pets;
--SELECT * FROM pictures;

--INSERT INTO user_pet (user_id, pet_id) VALUES (1, 12888403);
--INSERT INTO user_pet (user_id, pet_id) VALUES (1, 17043962);
--SELECT * FROM user_pet;

--SELECT pet_id, species_id, breed_id, agency_id, primary_image_url, thumbnail_url, name,
--	description_text, sex, age_group, age_string, activity_level, exercise_needs,
--	owner_experience, size_group, vocal_level
--FROM pets
--EXCEPT
--SELECT pets.pet_id, species_id, breed_id, agency_id, primary_image_url, thumbnail_url, name,
--	description_text, sex, age_group, age_string, activity_level, exercise_needs,
--	owner_experience, size_group, vocal_level
--FROM pets
--JOIN user_pet ON user_pet.pet_id = pets.pet_id
--JOIN users ON users.user_id = user_pet.user_id
--WHERE user_pet.user_id = 1;
