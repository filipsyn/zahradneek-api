# Zahradneek API

Back-end part of *Zahradneek* project, which helps with managing garden settlement.

## Installation

### Prerequisites

- .NET 7
- Entity Framework CLI tool
    - Can be installed with `dotnet tool install --global dotnet-ef` command
- Docker

### Running on UNIX-based systems

```shell
# Step 1: Change into project folder
cd Zahradneek.Api 

# Step 2: Create .env from example file
cp .env.example .env 

# (Optional) Step 2a: Modify values in .env file

# Step 3: Spin-up the database image
docker-compose up -d

# Step 4: Apply database migrations
dotnet ef database update

# Step 5: Install dependencies and run the project
dotnet run
```

### Running on Windows (using PowerShell)

```powershell
# Step 1: Change into project folder
cd Zahradneek.Api 

# Step 2: Create .env from example file
Copy-Item .\.env.example .\.env 

# (Optional) Step 2a: Modify values in .env file

# Step 3: Spin-up the database image
docker-compose up -d

# Step 4: Apply database migrations
dotnet ef database update

# Step 5: Install dependencies and run the project
dotnet run
```

After you are done, you can shut down the Docker containers with

```shell
docker-compose down
```

## Project roadmap

> **Legend:**
>  - (❓) - Optional feature, might not be implemented

- [x] User system
    - [x] Authentication
    - [ ] Role system
    - [ ] Authorization
- [ ] Event calendar
- [ ] Water consumption log for parcels
- [ ] (❓) Batch inserting and updating of parcels even with coordinates