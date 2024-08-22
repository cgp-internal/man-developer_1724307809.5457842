#!/bin/bash

# Install .NET Core
sudo apt-get update
sudo apt-get install -y dotnet-sdk-3.1

# Init a project
dotnet new webapi -o OCPPChargingStationAPI
cd OCPPChargingStationAPI

# Install OCPP library
dotnet add package BootNotification
dotnet add package Authorize
dotnet add package StartTransaction
dotnet add package StopTransaction
dotnet add package Heartbeat
dotnet add package MeterValues
dotnet add package StatusNotification
dotnet add package GetChargingStation
dotnet add package UpdateChargingStationStatus
dotnet add package ChargingStations