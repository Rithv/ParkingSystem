-- =============================================
-- Author:		SwaroopaRani
-- Create date: 14/07/2021
-- Description:	Inserting vehicle SP
-- =============================================
CREATE PROCEDURE VehicleRegistration
	-- Add the parameters for the stored procedure here
	
	( @registrationNumber nvarchar(450),
	  @make nvarchar(max),
	  @model nvarchar(max),
	  @color nvarchar(max),
	  @dateOfPurchase datetime,
	  @parkingAreaId int)


AS
BEGIN
	INSERT INTO Vehicles (RegistrationNumber,Make,Model,Color,DateOfPurchase,ParkingAreaId)
	VALUES (@registrationNumber,@make,@model,@color,@dateOfPurchase,@parkingAreaId)
END
GO

-- =============================================
-- Author:		SwaroopaRani
-- Create date: 14/07/2021
-- Description:	Get ParkingSlots based on ParkId
-- =============================================

CREATE PROCEDURE GetSlotsByParkArea
(@parkAreaId int)
AS
BEGIN
SELECT * FROM ParkingAreas WHERE ParkingAreaId = @parkAreaId
END
GO
-- =============================================
-- Author:		SwaroopaRani
-- Create date: 14/07/2021
-- Description:	Get vehicle details based on Registration Number
-- =============================================

CREATE PROCEDURE GetVehicleDetails
(@registrationNumber nvarchar(450))
AS
BEGIN
SELECT * FROM Vehicles WHERE RegistrationNumber = @registrationNumber
END
GO

-- =============================================
-- Author:		SwaroopaRani
-- Create date: 14/07/2021
-- Description:	Get parked vehicle details based on Registration Number
-- =============================================

CREATE PROCEDURE GetParkedVehicleDetails
(@registrationNumber nvarchar(450))
AS
BEGIN
SELECT * FROM ParkedVehicles WHERE VehicleRegistrationNumber = @registrationNumber
END
GO

-- =============================================
-- Author:		SwaroopaRani
-- Create date: 14/07/2021
-- Description:	Insert Parked vehicle details 
-- =============================================

CREATE PROCEDURE InsertParkedVehicle
(@vehicleNumber nvarchar(450),
@parkingAreaId int,
@timeArrived datetime
)
AS
BEGIN
INSERT INTO ParkedVehicles (VehicleRegistrationNumber,ParkingAreaId,TimeArrived)
VALUES (@vehicleNumber,@parkingAreaId,@timeArrived)

END
GO




