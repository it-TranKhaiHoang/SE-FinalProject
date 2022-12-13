CREATE DATABASE	SE_test

USE SE_test

/* TABLES */
CREATE TABLE Accountant 
(
	UserID varchar(10),
	fullname nvarchar(50),
	username varchar(50),
	password varchar(50),
	PRIMARY KEY (UserID)
)

CREATE TABLE Agency
(
	AgencyID varchar(10) NOT NULL UNIQUE,
	Username varchar(50) NULL,
	Password varchar(50) NULL,
	Agency_Name nvarchar(50) NULL,
	Phone varchar(10) NOT NULL UNIQUE,
	PRIMARY KEY (AgencyID)
)

CREATE TABLE Goods 
(
	GoodsID varchar(10) NOT NULL,
	Goods_Name nvarchar(50) NULL,
	Unit nvarchar(10) NULL,
	Quantity int NULL,
	Price money NULL,
	Goods_Img nvarchar(255) NULL, 
	PRIMARY KEY (GoodsID)
)

CREATE TABLE Goods_Received_Note
(
	NoteID varchar(10) NOT NULL,
	AccountantID varchar(10) NULL ,
	Received_Date Date DEFAULT GETDATE(),
	Received_Reason nvarchar(255) NULL,
	Total_amount money,
	PRIMARY KEY(NoteID),
	CONSTRAINT FK_GoodsReceivedNote_Accountant FOREIGN KEY (AccountantID)
	REFERENCES Accountant(UserID)
)

CREATE TABLE Goods_Received_Detail 
(
	NoteID varchar(10) NOT NULL,
	GoodsID varchar(10) NOT NULL,
	Ordinal int NULL,
	Unit nvarchar(50)NULL,
	Price money NULL,
	Quantity int NULL,
	Into_Money money NULL,
	PRIMARY KEY (NoteID,GoodsID),
	CONSTRAINT FK_GoodsReceivedDetail_GoodsReceivedDetail FOREIGN KEY (NoteID)
	REFERENCES Goods_Received_Note(NoteID),
	CONSTRAINT FK_GoodsReceivedDetail_Goods FOREIGN KEY (GoodsID)
	REFERENCES Goods(GoodsID)
)



CREATE TABLE Goods_Delivery_Note 
(
	NoteID varchar(10) NOT NULL,
	AgencyID varchar(10) NOT NULL,
	AccountantID varchar(10) NOT NULL,
	Delivery_Date Date DEFAULT GETDATE(),
	Total_amount money NULL,
	PRIMARY KEY (NoteID),
	CONSTRAINT FK_GoodsDeliveryNote_Agency FOREIGN KEY (AgencyID)
	REFERENCES Agency(AgencyID),
	CONSTRAINT FK_GoodsDeliveryNote_Accountant FOREIGN KEY (AccountantID)
	REFERENCES Accountant(UserID)
)

CREATE TABLE Goods_Delivery_Detail 
(
	NoteID varchar(10) NOT NULL,
	GoodsID varchar(10) NOT NULL,
	Ordinal int NULL,
	Unit nvarchar(50)NULL,
	Price money NULL,
	Quantity int NULL,
	Into_Money money NULL,
	PRIMARY KEY (NoteID,GoodsID),
	CONSTRAINT FK_GoodsDeliveryDetail_GoodsDeliveryNote FOREIGN KEY (NoteID)
	REFERENCES Goods_Delivery_Note(NoteID),
	CONSTRAINT FK_GoodsDeliveryDetail_Goods FOREIGN KEY (GoodsID)
	REFERENCES Goods(GoodsID)
)

CREATE TABLE Orders
(
	OrdersID varchar(10) NOT NULL,
	AgencyID varchar(10) NOT NULL,
	Orders_Date Date DEFAULT GETDATE(),
	Total_amount money NULL,
	Status nvarchar(50) Default 'Spending',
	Payments nvarchar(50) Null,
	PRIMARY KEY (OrdersID),
	CONSTRAINT FK_Orders_Agency FOREIGN KEY (AgencyID)
	REFERENCES Agency(AgencyID)
)

INSERT INTO Orders
values('O-001', 'AGC-001', '12/12/2022', 1200000, 'spending', 'banking')

CREATE TABLE Orders_Detail 
(
	OrdersID varchar(10) NOT NULL,
	GoodsID varchar(10) NOT NULL,
	Unit nvarchar(50)NULL,
	Price money NULL,
	Quantity int NULL,
	Into_Money money NULL,
	PRIMARY KEY (OrdersID),
	CONSTRAINT FK_Orders_Detail_Orders FOREIGN KEY (OrdersID)
	REFERENCES Orders(OrdersID),
	CONSTRAINT FK_Orders_Detail_Goods FOREIGN KEY (GoodsID)
	REFERENCES Goods(GoodsID)
)


/* INSERT */
INSERT INTO Accountant
VALUES('ACT-001', 'Trần Khải Hoàng', 'hoang', '9999')
INSERT INTO Accountant
VALUES('ACT-002', 'Robert Lewandowski', 'lewan09', '123456')
INSERT INTO Accountant
VALUES('ACT-003', 'Lionel Messi', 'messi10', '123456')
INSERT INTO Accountant
VALUES('ACT-004', 'Luca Modric', 'modric', '123456')
INSERT INTO Accountant
VALUES('ACT-005', 'Hakimi', 'hakimi', '123456')

INSERT INTO Agency
VALUES('AGC-001', 'longchau', '123456', 'Long Châu', '19006067')
INSERT INTO Agency
VALUES('AGC-002', 'xuanthanh', '123456', 'Hiệu thuốc Xuân Thành', '0763234234')
INSERT INTO Agency
VALUES('AGC-003', 'pharmacity', '123456', 'Pharmacity', '0311770883')
INSERT INTO Agency
VALUES('AGC-004', 'Thanhsang', '123456', 'Thanh Sang', '1234567890')
INSERT INTO Agency
VALUES('AGC-005', 'Namthinh', '123456', 'Nam Thịnh', '0673577823')
INSERT INTO Agency
VALUES('AGC-006', 'haiyen008', '123456', 'Hải Yến', '0673867823')
INSERT INTO Agency
VALUES('AGC-007', 'tatdatchanel', '123456', 'Tất Đạt and Co', '0273877823')
INSERT INTO Agency
VALUES('AGC-008', 'hellool', '123456', 'Hello', '0173877823')

INSERT INTO Goods 
VALUES ('GS-001', 'DOCTOR PLUS', 'Box', 30, 1150000, 'GS-001')
INSERT INTO Goods 
VALUES ('GS-002', 'NATURES BOUNTY', 'Box', 30, 214000, 'GS-002')
INSERT INTO Goods 
VALUES ('GS-003', 'COLLAGEN GILAA', 'Box', 30, 459000, 'GS-003')
INSERT INTO Goods 
VALUES ('GS-004', 'Vitamin C Hard Capsules', 'Box', 30, 205000, 'GS-004')
INSERT INTO Goods 
VALUES ('GS-005', 'Premium Saffron Collagen', 'Box', 30, 452000, 'GS-005')
INSERT INTO Goods 
VALUES ('GS-006', 'DHC Collagen', 'package', 30, 205000, 'GS-006')
INSERT INTO Goods 
VALUES ('GS-007', 'Whitening Supplement', 'package', 30, 748000, 'GS-007')
INSERT INTO Goods 
VALUES ('GS-008', 'White Plus Nucos', 'package', 30, 480000, 'GS-008')
INSERT INTO Goods 
VALUES ('GS-009', 'Perfect Vegetable', 'package', 30, 851000, 'GS-009')
INSERT INTO Goods 
VALUES ('GS-010', 'Itoh kanpo', 'package', 30, 287000, 'GS-010')

/* Trigger */

CREATE TRIGGER TG_Update_Quantity_Create_Received_Detail
ON Goods_Received_Detail
	FOR insert
AS 
	Update Goods
	SET Goods.Quantity = Goods.Quantity + inserted.Quantity
	FROM Goods inner join inserted ON Goods.GoodsID = inserted.GoodsID

CREATE TRIGGER TG_Update_Quantity_Create_Delivery_Note
ON Goods_Delivery_Detail
	FOR INSERT
AS
	UPDATE Goods
	SET Goods.Quantity = Goods.Quantity - inserted.Quantity
	FROM Goods inner join inserted ON Goods.GoodsID = inserted.GoodsID
	