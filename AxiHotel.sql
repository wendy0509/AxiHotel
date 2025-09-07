-- Borra DB si existe y la recrea (útil para pruebas)
IF DB_ID('AxiHotel') IS NOT NULL
BEGIN
    ALTER DATABASE AxiHotel SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE AxiHotel;
END
CREATE DATABASE AxiHotel;
GO

USE AxiHotel;
GO

CREATE TABLE Worker(
    IdWorker INT PRIMARY KEY IDENTITY(1,1),
    LastName VARCHAR(50) NOT NULL,
    IdentifyWorker VARCHAR(20),
    AddressWorker VARCHAR(100),
    PhoneWorker VARCHAR(20),
    UserWorker VARCHAR(50),
    PasswordWorker VARCHAR(255),
    JobTitle VARCHAR(50)
);
GO

INSERT INTO Worker (LastName, IdentifyWorker, AddressWorker, PhoneWorker, UserWorker, PasswordWorker, JobTitle)
VALUES ('Wendy','1021804772','km 4 via santa elena','3045307912','wen','1234','Administrador');
GO
INSERT INTO Worker (LastName, IdentifyWorker, AddressWorker, PhoneWorker, UserWorker, PasswordWorker, JobTitle)
VALUES ('david','102345677','copacabana','3216789899','david','4321','Recepcionista');
go
INSERT INTO Worker (LastName, IdentifyWorker, AddressWorker, PhoneWorker, UserWorker, PasswordWorker, JobTitle)
VALUES ('lili','123456789','Belen','3224566778','lilo','0101','Servicio');
go
CREATE TABLE Admin(
    IdWorker INT PRIMARY KEY,
    FOREIGN KEY (IdWorker) REFERENCES Worker(IdWorker)
);
GO

CREATE TABLE Recepcionist(
    IdWorker INT PRIMARY KEY,
    FOREIGN KEY (IdWorker) REFERENCES Worker(IdWorker)
);
GO

CREATE TABLE Service(
    IdWorker INT PRIMARY KEY,
    FOREIGN KEY (IdWorker) REFERENCES Worker(IdWorker)
);
GO

CREATE TABLE Customer(
    IdCustomer INT PRIMARY KEY IDENTITY(1,1),
    NameCustomer VARCHAR(50),
    LastCustomer VARCHAR(50),
    IdentifyCustomer VARCHAR(20),
    AddressCustomer VARCHAR(100),
    PhoneCustomer VARCHAR(20),
    IdWorker INT,
    FOREIGN KEY (IdWorker) REFERENCES Recepcionist(IdWorker)
);
GO

CREATE TABLE Room(
    IdRoom INT PRIMARY KEY IDENTITY(1,1),
    DescriptionRoom VARCHAR(200),
    RoomStatus VARCHAR(50),
    HousekeepingStatus VARCHAR(50),
    TypeRoom VARCHAR(50),
    IdWorker INT,
    FOREIGN KEY (IdWorker) REFERENCES Service(IdWorker)
);
GO

CREATE TABLE Promotions(
    IdPromotion INT PRIMARY KEY IDENTITY(1,1),
    DateStartPromotions DATE,
    DateEndPromotions DATE,
    DescriptionPromotions VARCHAR(200),
    NamePromotions VARCHAR(50),
    IdWorker INT,
    FOREIGN KEY (IdWorker) REFERENCES Admin(IdWorker)
);
GO

CREATE TABLE HotelPlans(
    IdPlan INT PRIMARY KEY IDENTITY(1,1),
    HowManyPeoplePlan INT,
    DescriptionPlan VARCHAR(200),
    NamePlan VARCHAR(50),
    IdWorker INT,
    FOREIGN KEY (IdWorker) REFERENCES Admin(IdWorker)
);
GO

CREATE TABLE Booking(
    IdBooking INT PRIMARY KEY IDENTITY(1,1),
    DateStartBooking DATE,
    DateEndBooking DATE,
    HowManyPeopleBooking INT,
    DescriptionBooking VARCHAR(200),
    PriceBooking FLOAT,
    StatusPrice VARCHAR(50),
    IdCustomer INT,
    IdRoom INT,
    IdPromotion INT,
    IdPlan INT,
    IdWorker INT,
    FOREIGN KEY (IdCustomer) REFERENCES Customer(IdCustomer),
    FOREIGN KEY (IdRoom) REFERENCES Room(IdRoom),
    FOREIGN KEY (IdPromotion) REFERENCES Promotions(IdPromotion),
    FOREIGN KEY (IdPlan) REFERENCES HotelPlans(IdPlan),
    FOREIGN KEY (IdWorker) REFERENCES Recepcionist(IdWorker)
);
GO
-- Nutrimos base de datos 
-- Asignar Wendy como Administradora
INSERT INTO Admin (IdWorker) VALUES (1);

-- Asignar David como Recepcionista
INSERT INTO Recepcionist (IdWorker) VALUES (2);

-- Asignar Lili como Servicio
INSERT INTO Service (IdWorker) VALUES (3);
GO
INSERT INTO Customer (NameCustomer, LastCustomer, IdentifyCustomer, AddressCustomer, PhoneCustomer, IdWorker)
VALUES 
('Carlos', 'Gomez', '100200300', 'Medellín', '3001112233', 2),
('Ana', 'Martinez', '100200301', 'Envigado', '3012223344', 2),
('Pedro', 'Lopez', '100200302', 'Bello', '3023334455', 2);
GO
INSERT INTO Room (DescriptionRoom, RoomStatus, HousekeepingStatus, TypeRoom, IdWorker)
VALUES 
('Habitación sencilla con vista al jardín', 'Disponible', 'Limpia', 'Sencilla', 3),
('Habitación doble con balcón', 'Disponible', 'Limpia', 'Doble', 3),
('Suite presidencial con jacuzzi', 'Ocupada', 'Limpia', 'Suite', 3);
GO
INSERT INTO Promotions (DateStartPromotions, DateEndPromotions, DescriptionPromotions, NamePromotions, IdWorker)
VALUES 
('2025-01-01', '2025-01-15', 'Descuento de Año Nuevo 20%', 'Promo Año Nuevo', 1),
('2025-02-10', '2025-02-20', 'San Valentín: 2x1 en habitaciones dobles', 'Promo San Valentín', 1);
GO
INSERT INTO HotelPlans (HowManyPeoplePlan, DescriptionPlan, NamePlan, IdWorker)
VALUES 
(1, 'Incluye desayuno buffet', 'Plan Individual', 1),
(2, 'Incluye desayuno y cena buffet', 'Plan Pareja', 1),
(4, 'Incluye todas las comidas + acceso a piscina', 'Plan Familiar', 1);
GO
INSERT INTO Booking (DateStartBooking, DateEndBooking, HowManyPeopleBooking, DescriptionBooking, PriceBooking, StatusPrice, IdCustomer, IdRoom, IdPromotion, IdPlan, IdWorker)
VALUES
('2025-03-01', '2025-03-05', 2, 'Reserva pareja con promo de Año Nuevo', 800000, 'Pagado', 1, 2, 1, 2, 2),
('2025-03-10', '2025-03-12', 1, 'Reserva individual sin promo', 300000, 'Pendiente', 2, 1, NULL, 1, 2),
('2025-04-01', '2025-04-07', 4, 'Reserva familiar con plan completo', 1500000, 'Pagado', 3, 3, 2, 3, 2);
GO


select*from room;
