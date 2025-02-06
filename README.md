
# TTAT-Backend-API

This project is the backend API for the Truck Turn-Around Time (T-TAT) Logistics Automation Solution. It serves as a middleware for communication with various network devices, like RFID readers, parking sensors, and displays, while managing parking data.

## Requirements

### Software & Version:
- **.NET SDK**: Version `8.0`
- **SQL Server**: For the database backend.

### Packages:

The following NuGet packages are required for this project:

1. **BCrypt.Net-Next** (Version: `4.0.3`)
2. **Microsoft.AspNetCore.Authentication.JwtBearer** (Version: `8.0.12`)
3. **Microsoft.AspNetCore.OpenApi** (Version: `8.0.12`)
4. **Microsoft.EntityFrameworkCore.Design** (Version: `8.0.12`)
5. **Microsoft.EntityFrameworkCore.SqlServer** (Version: `8.0.12`)
6. **Serilog.AspNetCore** (Version: `9.0.0`)
7. **Serilog.Enrichers.Process** (Version: `3.0.0`)
8. **Serilog.Enrichers.Thread** (Version: `4.0.0`)
9. **Serilog.Settings.Configuration** (Version: `9.0.0`)
10. **Serilog.Sinks.Console** (Version: `6.0.0`)
11. **Serilog.Sinks.File** (Version: `6.0.0`)
12. **Swashbuckle.AspNetCore** (Version: `7.2.0`)

Ensure these packages are included in your `.csproj` file.

```xml
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.12" />
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.12" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.12" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.12" />
<PackageReference Include="Serilog.AspNetCore" Version="9.0.0" />
<PackageReference Include="Serilog.Enrichers.Process" Version="3.0.0" />
<PackageReference Include="Serilog.Enrichers.Thread" Version="4.0.0" />
<PackageReference Include="Serilog.Settings.Configuration" Version="9.0.0" />
<PackageReference Include="Serilog.Sinks.Console" Version="6.0.0" />
<PackageReference Include="Serilog.Sinks.File" Version="6.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="7.2.0" />
```

---

## Setup Instructions

### Step 1: Clone the Repository

Clone the repository to your local machine:

```bash
git clone https://github.com/TTAT-Backend-API.git
cd your-repository
```

### Step 2: Configure the Database Connection

1. Open the `appsettings.json` file.
2. Update the `ConnectionStrings` section with your SQL Server details:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
}
```

Replace `your_server_name`, `your_database_name`, `your_username`, and `your_password` with the actual credentials of your SQL Server instance.

### Step 3: Install Dependencies

Ensure you have all the required packages installed by running the following command in the project directory:

```bash
dotnet restore
```

### Step 4: Create Migrations and Update the Database

1. **Create Migration**:  
   Run the following command to create the initial migration:

```bash
dotnet ef migrations add InitialCreate
```

2. **Update Database**:  
   After creating the migration, run this command to apply the changes to the database:

```bash
dotnet ef database update
```

### Step 5: Run the Application

Once the database is updated, you can run the application by executing:

```bash
dotnet run
```

The application should now be running, and you can test the API through Swagger UI or other API testing tools.

---

## Default User Credentials

To test the application, use the following default admin credentials:

- **Username**: `Admin`
- **Password**: `Admin@123`

You can log in with these credentials to access the API.

---

## Testing the Application in Swagger UI with Bearer Token

### Step 1: Login to Get the Bearer Token

1. Open the Swagger UI for your running application (usually at `http://localhost:5000/swagger` or a similar URL).
2. Find the **Login** endpoint or a similar endpoint where you can enter the username and password.
3. Enter the following credentials:
   - **Username**: `Admin`
   - **Password**: `Admin@123`
4. Send the request. If successful, you will receive a Bearer token in the response.

### Step 2: Use the Bearer Token

1. In Swagger UI, find the **Authorize** button (usually at the top right corner).
2. Click on **Authorize** and enter the Bearer token you received from the login step.
   - **Format**: `Bearer <your_token_here>`
3. Once authorized, you can now access the API endpoints by passing the token as part of the request headers automatically.

This allows you to test the secured endpoints that require authentication, ensuring that the Bearer token is passed with each API request.
