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

# (Optional) Step 4: If you don't already have it installed
# Install entity framework tool


# Step 5: Apply database migrations
dotnet ef database update

# Step 6: Install dependencies and run the project
dotnet run
```

After you are done, you can shut down the Docker containers with
```shell
docker-compose down
```