CREATE DATABASE [SoftTrade];

USE SoftTrade;

CREATE TABLE [Managers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Managers] PRIMARY KEY ([Id])
);

CREATE TABLE [ProductTypes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ProductTypes] PRIMARY KEY ([Id])
);

CREATE TABLE [Statuses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Statuses] PRIMARY KEY ([Id])
);

CREATE TABLE [SubscriptionTimes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_SubscriptionTimes] PRIMARY KEY ([Id])
);

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [ManagerId] int NOT NULL,
    [StatusId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_Managers_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Managers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Clients_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Statuses] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Price] decimal(18,2) NOT NULL,
    [ProductTypeId] int NOT NULL,
    [SubscriptionTimeId] int NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_SubscriptionTimes_SubscriptionTimeId] FOREIGN KEY ([SubscriptionTimeId]) REFERENCES [SubscriptionTimes] ([Id])
);

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);


---
--- Insert Values into Tables
---


INSERT INTO Managers 
VALUES 
('������'),
('������'),
('������');

INSERT INTO Statuses
VALUES
('�������� ������'),
('������� ������');


INSERT INTO ProductTypes
VALUES
('��������'),
('���������� ��������');


INSERT INTO SubscriptionTimes
VALUES
('�����'),
('�������'),
('���');


INSERT INTO Products
VALUES
(1000, 1, 1, '���������'),
(10000, 1, 3, '����������� ��������'),
(700, 2, NULL, '������� ��'),
(500, 1, 2, '�������������� ������'),
(300, 2, NULL, '�����');

INSERT INTO Clients
VALUES
(1, 1, '�����'),
(2, 2, '�������'),
(3, 2,'����'),
(1, 1, '�����'),
(2, 2, '������');

INSERT INTO Orders
VALUES
(1, 1),
(2, 1),
(4, 5),
(2, 3),
(3, 3)
