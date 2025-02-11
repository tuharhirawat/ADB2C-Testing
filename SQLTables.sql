USE MyWebAppDB;



CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);


CREATE PROCEDURE AddUser
@FullName NVARCHAR(100),
@Email NVARCHAR(100),
@PasswordHash NVARCHAR(255)
AS
BEGIN
    INSERT INTO Users (FullName, Email, PasswordHash)
    VALUES (@FullName, @Email, @PasswordHash);
END;


CREATE PROCEDURE GetUserByEmail
@Email NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Users WHERE Email = @Email;
END;


EXEC AddUser 'John Doe', 'john@example.com', 'hashedpassword123';

EXEC GetUserByEmail 'john@example.com';

select * from Users