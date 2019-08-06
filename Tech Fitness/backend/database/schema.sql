﻿
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='DemoDB')
DROP DATABASE DemoDB;
GO

-- Create a new DemoDB Database
CREATE DATABASE DemoDB;
GO

-- Switch to the DemoDB Database
USE DemoDB
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);
CREATE TABLE user_profile
(
	id			int			not null,
	name		varchar(50)	not null,
	birthdate   date		not null,
	currWeight	int			not null,
	goalWeight	int			not null, 
	height		int			not null,
	activityLevel	varchar(50)	not null

	constraint fk_userProfile_users Foreign Key (id) references users (id),

);

COMMIT TRANSACTION;