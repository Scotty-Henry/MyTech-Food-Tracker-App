
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

GO

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
	constraint pk_user_profile primary key (id)
);

GO

CREATE TABLE meal_type
(
	meal_category varchar(50)	not null,
	meal_id		int			not null,

	constraint pk_mealType primary key (meal_id)
);

GO

Insert into meal_type (meal_category, meal_id) values ('Breakfast', 1);
Insert into meal_type (meal_category, meal_id) values ('Lunch', 2);
Insert into meal_type (meal_category, meal_id) values ('Dinner', 3);
Insert into meal_type (meal_category, meal_id) values ('Snack - 1', 4);
Insert into meal_type (meal_category, meal_id) values ('Snack - 2', 5);

GO

CREATE TABLE food
(
	ndbno			varchar(10)		not null,
	serving_size	varchar(10)		not null,
	food_name		varchar(100)	not null,
	protein			int				not null,
	carb			int				not null,
	fat				int				not null,
	cal				int				not null,

	constraint pk_food primary key (ndbno)
);

CREATE TABLE meal
(
	meal_id		int			identity(1,1),
	user_id		int			not null,
	meal_type	int			not null,
	meal_date	date		not null,
	

	constraint fk_meal_userProfile Foreign Key (user_id) references user_profile (id),
	constraint fk_meal_mealType Foreign Key (meal_type) references meal_type (meal_id),
	constraint pk_meal primary key (meal_id)

);
CREATE TABLE meal_food
(
	ndbno		varchar(10)		not null,
	meal_id		int			not null,
	qty			int			not null,

	constraint fk_mealFood_food Foreign Key (ndbno) references food (ndbno),
	constraint fk_mealFood_meal Foreign Key (meal_id) references meal (meal_id),

	
	
);




COMMIT TRANSACTION;