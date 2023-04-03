FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Zahradneek.Api/Zahradneek.Api.csproj", "Zahradneek.Api/"]
RUN dotnet restore "Zahradneek.Api/Zahradneek.Api.csproj"
COPY . .
WORKDIR "/src/Zahradneek.Api"
RUN dotnet build "Zahradneek.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zahradneek.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zahradneek.Api.dll"]
