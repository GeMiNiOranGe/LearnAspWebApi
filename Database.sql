USE [Master]
GO

-- change database name here and...
DECLARE @DbName     NVARCHAR(50)  = N'LearnAspWebApi'
DECLARE @DeleteStmt NVARCHAR(Max) = N'DROP    DATABASE IF EXISTS '  + QuoteName(@DbName)
DECLARE @CreateStmt NVARCHAR(Max) = N'CREATE  DATABASE '            + QuoteName(@DbName)
EXECUTE sys.sp_ExecuteSql @Stmt = @DeleteStmt
EXECUTE sys.sp_ExecuteSql @Stmt = @CreateStmt
GO

-- and here...
USE [LearnAspWebApi]
GO

CREATE TABLE [dbo].[Employee] (
    [EmployeeId]    [varchar](10)   NOT NULL,
    [Name]          [nvarchar](50)  NOT NULL,
    [DateOfBirth]   [date]          NOT NULL,
);

CREATE TABLE [dbo].[Account] (
    [AccountId]     [int]           NOT NULL IDENTITY(1, 1),
    [Username]      [varchar](255)  NOT NULL,
    [Password]      [varchar](255)  NOT NULL,

    [EmployeeId]    [varchar](10)   NOT NULL,
);
GO

-- add unique key --------------------------------------------------------
ALTER TABLE [dbo].[Account]
ADD CONSTRAINT [UK_Username]   UNIQUE ([Username])
  , CONSTRAINT [UK_EmployeeId] UNIQUE ([EmployeeId])
GO

-- add primary key -------------------------------------------------------
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeId])
ALTER TABLE [dbo].[Account]  ADD CONSTRAINT [PK_Account]  PRIMARY KEY ([AccountId])

-- add foreign key -------------------------------------------------------
ALTER TABLE [dbo].[Account] ADD
CONSTRAINT [FK_Account_Employee]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employee]([EmployeeId]);
GO

INSERT INTO [dbo].[Employee]
        ([EmployeeId],  [Name],                 [DateOfBirth])
VALUES  ('EMP00001',    N'Trần Tuấn Toàn',      '1975-09-21')
     ,  ('EMP00002',    N'Phan Tuấn Tài',       '1990-03-21')
     ,  ('EMP00003',    N'Trần Thị Ngọc Châu',  '1985-09-01')
     ,  ('EMP00004',    N'Trần Anh Tuấn',       '1995-05-19')
     ,  ('EMP00005',    N'Trần Đình Vũ',        '1990-03-15')
     ,  ('EMP00006',    N'Trương Mai Anh',      '1980-05-19')
     ,  ('EMP00007',    N'Vương Trắc',          '1987-01-17')
     ,  ('EMP00008',    N'Phan Ngô Ngọc Lam',   '2000-04-01')
     ,  ('EMP00009',    N'Huỳnh Vũ',            '1999-07-28')
     ,  ('EMP00010',    N'Tố Huỳnh Nga',        '1982-07-18')
GO

INSERT INTO [dbo].[Account]
        ([Username],    [Password], [EmployeeId])
VALUES  ('tvtoan',      'EMP00001', 'EMP00001')
     ,  ('pttai',       'EMP00002', 'EMP00002')
     ,  ('ttnchau',     'EMP00003', 'EMP00003')
     ,  ('tatuan',      'EMP00004', 'EMP00004')
     ,  ('tdvu',        'EMP00005', 'EMP00005')
     ,  ('tmanh',       'EMP00006', 'EMP00006')
     ,  ('vtrac',       'EMP00007', 'EMP00007')
     ,  ('pnnlam',      'EMP00008', 'EMP00008')
     ,  ('hvu',         'EMP00009', 'EMP00009')
     ,  ('thnga',       'EMP00010', 'EMP00010')
GO
