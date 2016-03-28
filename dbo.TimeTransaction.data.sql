DROP TABLE  [dbo].[TimeTransactions];

CREATE TABLE [dbo].[TimeTransactions] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [TransactionDate] DATETIME NOT NULL,
    [ProjectId]       UNIQUEIDENTIFIER NOT NULL,
    [EmployeeId]      UNIQUEIDENTIFIER NOT NULL,
    [Time]            DECIMAL (8, 4)     NOT NULL,
    [Comment]         NVARCHAR (255)   NULL,
    [Created]         DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TimeTransactions_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_TimeTransactions_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id])
);


INSERT INTO [dbo].[TimeTransactions] (
	[Id], 
	[TransactionDate], 
	[ProjectId], 
	[EmployeeId], 
	[Time], 
	[Comment], 
	[Created]) 
VALUES (
	N'be57da8b-4495-48f1-bada-f3dd36fd355d', 
	N'2016-03-26 00:00:00', 
	N'41d7aa9c-9497-43e0-89a7-ec5edc28f7e8', 
	N'6e44a8af-8f39-4f15-a665-19e0c3ac75b9', 
	2.45, 
	N'Test', 
	N'2016-03-26 00:00:00')


select newid()

--EXEC sp_rename 'TimeTransaction', 'TimeTransactions';
--EXEC sp_rename 'ExpenditureTransaction', 'ExpenditureTransactions';

ALTER TABLE TimeTransactions 
ADD CONSTRAINT FK_TimeTransactions_Projects FOREIGN KEY (ProjectId) 
    REFERENCES Projects (Id);

ALTER TABLE TimeTransactions 
ADD CONSTRAINT FK_TimeTransactions_Employees FOREIGN KEY (EmployeeId) 
    REFERENCES Employees (Id);
