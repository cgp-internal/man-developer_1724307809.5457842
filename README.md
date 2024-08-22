OCPP Charging Station API
=========================

This is a .NET Core web API project for Electric Vehicle Charging Station management. It implements the OCPP 2.0.1 protocol for managing charging stations.

Getting Started
---------------

### Prerequisites

* .NET Core
* SQLite

### Installation

1. Install .NET Core: `sudo apt-get install dotnet-core`
2. Init a new project: `dotnet new webapi -o OCPPChargingStationAPI`
3. Install OCPP library: `dotnet add package ocpp-library`
4. Run the application: `dotnet run`

Configuration
-------------

Application settings and configuration can be found in `appsettings.json`.

OCPP 2.0.1 Protocol Implementation
--------------------------------

This project uses the `ocpp-library` to implement the OCPP 2.0.1 protocol. The library provides the necessary classes and methods to handle OCPP requests and responses.

### Exposed Methods

* `BootNotification`
* `Authorize`
* `StartTransaction`
* `StopTransaction`
* `Heartbeat`
* `MeterValues`
* `StatusNotification`

Business Logic
-------------

The business logic for Electric Vehicle Charging Station management is implemented in `Services/ChargingStationService.cs`. This service provides methods for:

* Boot Notification
* Authorization
* Start Transaction
* Stop Transaction
* Heartbeat
* Meter Values
* Status Notification

Data Access
----------

The data access for Electric Vehicle Charging Station management is abstracted in `DataAccess/ChargingStationRepository.cs`. This repository provides methods for:

* `GetChargingStation`
* `UpdateChargingStationStatus`

It uses the `DataAccess/ChargingStationDBContext.cs` to interact with the SQLite database.

Models
------

The `Models/ChargingStation.cs` represents an Electric Vehicle Charging Station.

Controllers
------------

The `Controllers/ChargingStationController.cs` handles OCPP 2.0.1 protocol requests and responses for Electric Vehicle Charging Station management. It uses the `Services/ChargingStationService.cs` to perform the necessary business logic.

Dependencies
------------

* `Services/ChargingStationService.cs`
* `DataAccess/ChargingStationRepository.cs`
* `DataAccess/ChargingStationDBContext.cs`