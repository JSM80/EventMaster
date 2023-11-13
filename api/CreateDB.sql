USE EventMaster
GO

DROP TABLE IF EXISTS [dbo].[UserRelation]

DROP TABLE IF EXISTS [dbo].[Ticket]
DROP TABLE IF EXISTS [dbo].[Event]
DROP TABLE IF EXISTS [dbo].[User]
DROP FUNCTION IF EXISTS [dbo].[fn_TicketsSold]

DROP PROCEDURE IF EXISTS [dbo].[sp_GetRelations]

GO

CREATE TABLE [dbo].[User] (
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[FirstName] NVARCHAR(255) NOT NULL,
[LastName] NVARCHAR(255) NOT NULL,
[EMail] NVARCHAR(255) NOT NULL, 
[PasswordHash] NVARCHAR NOT NULL,
[Address1] NVARCHAR(255) NOT NULL,
[Address2] NVARCHAR(255) NOT NULL,
[Zip] NVARCHAR(25) NOT NULL,
[City] NVARCHAR(255) NOT NULL,
[Country] NVARCHAR(255) NOT NULL,
[Lat] FLOAT NOT NULL, 
[Long] FLOAT NOT NULL,
[CreatedAtUTC] DATETIME NOT NULL DEFAULT GETUTCDATE()
)
GO

CREATE TABLE [dbo].[Event](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[Address1] NVARCHAR(255) NOT NULL,
[Address2] NVARCHAR(255) NOT NULL,
[Zip] NVARCHAR(25) NOT NULL,
[City] NVARCHAR(255) NOT NULL,
[Country] NVARCHAR(255) NOT NULL,
[Lat] FLOAT NOT NULL, 
[Long] FLOAT NOT NULL,
[CreatedAtUTC] DATETIME NOT NULL DEFAULT GETUTCDATE(),
[StartUTC] DATETIME NOT NULL,
[EndUTC] DATETIME NOT NULL,
[Title] NVARCHAR(255) NOT NULL,
[Description] NVARCHAR(MAX) NOT NULL,
[Owner] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User](Id),
[MaximumTickets] INT NOT NULL
)
GO

CREATE TABLE [dbo].[Ticket](
[Id] INT NOT NULL IDENTITY(1,1),
[TicketNumber] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
[PurchasedUTC] DATETIME NOT NULL DEFAULT GETUTCDATE(),
[UserId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User](Id),
[EventId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Event](Id),
[CheckedIn] BIT NOT NULL DEFAULT 0
)
GO


CREATE TABLE [dbo].[UserRelation](
[PrimaryUser] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User](Id),
[SecondaryUser] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[User](Id),
[Accepted] BIT NOT NULL DEFAULT 0 -- Zero(False) means pending. Entry should be deleted on decline.
)
GO


ALTER TABLE [dbo].[Ticket]
ADD
PRIMARY KEY ([ID], [TicketNumber])
GO

CREATE FUNCTION [dbo].[fn_TicketsSold] (@EventId INT)
RETURNS INT
AS
BEGIN
	DECLARE @Sold INT;
	SET @Sold = (SELECT COUNT(ID) FROM [dbo].[Ticket] WHERE [EventId] = @EventId)
	RETURN @Sold
END
GO

ALTER TABLE [dbo].[Event]
ADD 
Sold as ([dbo].[fn_TicketsSold](id)),
Available as ([MaximumTickets] - ([dbo].[fn_TicketsSold](id)))

GO

CREATE TRIGGER tr_PreventExceedMaximumTickets
ON [dbo].[Ticket]
INSTEAD OF INSERT
AS
BEGIN
    -- Check if the new rows would exceed the maximum tickets for the associated event
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN [dbo].[Event] e ON i.EventId = e.Id
        WHERE [dbo].[fn_TicketsSold](i.EventId) + (SELECT COUNT(*) FROM i) > e.MaximumTickets
    )
    BEGIN
        RAISERROR('Adding more tickets would exceed the maximum tickets allowed for the event.', 16, 1);
        -- You can choose to do other actions here, such as logging the attempt or rolling back the transaction.
    END
    ELSE
    BEGIN
        -- If the condition is not met, proceed with the insert
        INSERT INTO [dbo].[Ticket] ([TicketNumber], [PurchasedUTC], [UserId], [EventId], [CheckedIn])
        SELECT [TicketNumber], [PurchasedUTC], [UserId], [EventId], [CheckedIn]
        FROM inserted;
    END
END
GO
CREATE PROCEDURE sp_GetRelations(@UserId INT)
AS
SELECT 
[PrimaryUser] Relation from [dbo].[UserRelation] where [SecondaryUser] = @UserId and [Accepted] = 1
UNION
SELECT [SecondaryUser] Relation from [dbo].[UserRelation] where [PrimaryUser] = @UserId and [Accepted] = 1
GO

