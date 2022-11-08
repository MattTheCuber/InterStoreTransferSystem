CREATE DATABASE InterStoreTransferSystem
GO

USE InterStoreTransferSystem
GO

CREATE TABLE ZipCodes(
	ZipCodeId varchar(10) PRIMARY KEY,
	State char(2) NOT NULL,
	City varchar(100) NOT NULL,
)
GO

CREATE TABLE Stores(
	StoreId int PRIMARY KEY,
	StoreName varchar(200) NOT NULL,
	StorePassword varchar(max) NOT NULL,
	ZipCodeId varchar(10) NOT NULL,
	CONSTRAINT FK_Stores_ZipCodes FOREIGN KEY(ZipCodeId) REFERENCES ZipCodes(ZipCodeId)
)
GO

CREATE TABLE Items(
	ItemId int PRIMARY KEY,
	ItemName varchar(200) NOT NULL,
)
GO

CREATE TABLE StoreItems(
	StoreId int NOT NULL,
	ItemId int NOT NULL,
	Quantity int NOT NULL,
	CONSTRAINT FK_StoreItems_Stores FOREIGN KEY(StoreId) REFERENCES Stores(StoreId),
	CONSTRAINT FK_StoreItems_Items FOREIGN KEY(ItemId) REFERENCES Items(ItemId),
	PRIMARY KEY (StoreId, ItemId)
)
GO

CREATE TABLE Transfers(
	TransferId int IDENTITY(1, 1) PRIMARY KEY,
	OrderDateTime datetime NOT NULL,
	RequestingStoreId int NOT NULL,
	RequestedStoreId int NOT NULL,
	ItemId int NOT NULL,
	Quantity int NOT NULL,
	TransferStatus int NOT NULL,
	CompletedDateTime datetime NULL,
	CONSTRAINT FK_StoreItems_Stores_Requesting FOREIGN KEY(RequestingStoreId) REFERENCES Stores(StoreId),
	CONSTRAINT FK_Transfers_Stores_Requested FOREIGN KEY(RequestedStoreId) REFERENCES Stores(StoreId),
	CONSTRAINT FK_Transfers_Items FOREIGN KEY(ItemId) REFERENCES Items(ItemId)
)
GO

INSERT ZipCodes(City, State, ZipCodeId)
VALUES
	('New York City', 'NY', '10010'),
	('St Louis', 'MO', '63177'),
	('Oberlin', 'OH', '44074'),
	('Los Angeles', 'CA', '90038'),
	('Minneapolis', 'MN', '55439'),
	('Jacksonville', 'FL', '32231'),
	('Fairfield', 'IA', '52556'),
	('Charlotte', 'NC', '28217'),
	('Marion', 'OH', '43305'),
	('Anaheim', 'CA', '92850'),
	('Anaheim', 'CA', '92807'),
	('Chicago', 'IL', '60694'),
	('Philadelphia', 'PA', '19170'),
	('Santa Barbara', 'CA', '93101'),
	('Manhatttan Beach', 'CA', '90266'),
	('New Rochelle', 'NY', '10802'),
	('Tarrytown', 'NY', '10591'),
	('Boston', 'MA', '02107'),
	('Hermon', 'ME', '04496'),
	('Dexter', 'ME', '04930'),
	('Fresno', 'CA', '93728'),
	('Bath', 'ME', '04530')
GO

INSERT Stores(StoreId, StoreName, StorePassword, ZipCodeId)
VALUES
	(16517, 'Hermon Ace Hardware', 'bc547750b92797f955b36112cc9bdd5cddf7d0862151d03a167ada8995aa24a9ad24610b36a68bc02da24141ee51670aea13ed6469099a4453f335cb239db5da', '04496'),
	--									= password1
	(16519, 'Dexter Ace Hardware', '92a891f888e79d1c2e8b82663c0f37cc6d61466c508ec62b8132588afe354712b20bb75429aa20aa3ab7cfcc58836c734306b43efd368080a2250831bf7f363f', '04930'),
	--									= password2
	(85075, 'Rockys Ace Hardware', '2a64d6563d9729493f91bf5b143365c0a7bec4025e1fb0ae67e307a0c3bed1c28cfb259fc6be768ab0a962b1e2c9527c5f21a1090a9b9b2d956487eb97ad4209', '04530')
	--									= password3
GO

INSERT Items(ItemId, ItemName)
VALUES
	(7000001, 'Ego Zero-Turn Lawn Mower'),
	(7000002, 'Ego 630 CFU Leaf Blower'),
	(7000003, 'Ego 16" Chainsaw'),
	(7000004, 'Ego 2-Stage Snow Blower'),
	(50001, '3/8" NAP Roller Cover'),
	(50002, '3pk 3/8" NAP Roller Cover'),
	(50003, '1/2" NAP Roller Cover'),
	(50004, '3pk 1/2" NAP Roller Cover'),
	(50005, '5/8" NAP Roller Cover'),
	(50006, '3pk 5/8" NAP Roller Cover'),
	(50007, '3/4" NAP Roller Cover'),
	(50008, '3pk 3/4" NAP Roller Cover')
GO

INSERT StoreItems(StoreId, ItemId, Quantity)
VALUES
	(16519, 50001, 4),
	(16519, 50002, 3),
	(16519, 50003, 6),
	(16519, 50004, 4),
	(16519, 50005, 2),
	(16519, 50006, 6),
	(16519, 50007, 1),
	(16517, 7000001, 3),
	(16517, 7000002, 4),
	(16517, 7000003, 2),
	(16517, 7000004, 1),
	(16517, 50001, 8),
	(16517, 50002, 6),
	(16517, 50003, 5),
	(16517, 50004, 8),
	(16517, 50005, 4),
	(16517, 50006, 3),
	(16517, 50007, 5),
	(16517, 50008, 12),
	(85075, 50008, 400)
GO

INSERT Transfers(OrderDateTime, RequestingStoreId, RequestedStoreId, ItemId, Quantity, TransferStatus, CompletedDateTime)
VALUES
	(CAST('2022-05-02 12:45:13' AS datetime), 85075, 16517, 7000002, 1, 0, NULL),
	(CAST('2022-04-20 14:04:37' AS datetime), 85075, 16517, 7000002, 1, 4, CAST('2022-04-28 08:34:20' AS datetime))
GO