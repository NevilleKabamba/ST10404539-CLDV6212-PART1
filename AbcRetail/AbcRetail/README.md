Here's a revised version of your README for the **Abc Retail WebApp**:

---

# Abc Retail WebApp

## Overview

Abc Retail is a web application built with ASP.NET Core MVC that allows users to interact with Azure Storage Services to manage product images, customer profiles, order processing, and contract files.

## Features

- **Upload Product Images**: Users can upload images to Azure Blob Storage.
- **Add Customer Profiles**: Users can add new customer profiles to Azure Table Storage.
- **Process Orders**: Users can send messages to Azure Queue Storage to process orders.
- **Upload Contracts**: Users can upload contract files to Azure File Storage.

## Prerequisites

- **Azure Subscription**: Required to access Azure Storage Services.
- **Azure Storage Account**: Must be configured with Blob, Table, Queue, and File services.
- **ASP.NET Core SDK**: Should be installed on your development machine.

## Getting Started

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/yourusername/AbcRetail.git
   cd AbcRetail
   ```

2. **Configure Azure Storage Connection**:

   Update the `appsettings.json` file with your Azure Storage connection string:

   ```json
   {
     "AzureStorage": {
       "ConnectionString": "YourAzureStorageConnectionStringHere"
     }
   }
   ```

3. **Restore Dependencies and Build the Project**:

   ```bash
   dotnet restore
   dotnet build
   ```

4. **Run the Application**:

   ```bash
   dotnet run
   ```

5. **Access the Application**:

   Open your web browser and navigate to `https://localhost:5001` (or the specified URL).

## Usage

- **Upload Product Image**: Go to the homepage, select an image, and click "Upload Image" to store the image in Azure Blob Storage.
- **Add Customer Profile**: Enter customer details in the provided form and click "Add Customer" to save the profile in Azure Table Storage.
- **Process Order**: Enter the Order ID and click "Process Order" to send a message to Azure Queue Storage.
- **Upload Contract**: Select a contract file and click "Upload Contract" to store the file in Azure File Storage.

---