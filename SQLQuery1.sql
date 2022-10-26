Create database TestUsers;

USE TestUsers;
Create table Registration(id INT IDENTITY(1,1) PRIMARY KEY,
username Varchar(100), password Varchar(100),
email Varchar(100), IsActive INT);

SELECT * FROM Registration;