FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FitnessApp/FitnessApp.csproj", "FitnessApp/"]
COPY ["FitnessApp.BLL/FitnessApp.BLL.csproj", "FitnessApp.BLL/"]
COPY ["FitnessApp.DAL/FitnessApp.DAL.csproj", "FitnessApp.DAL/"]
RUN dotnet restore "FitnessApp/FitnessApp.csproj"
COPY . .
WORKDIR "/src/FitnessApp"
RUN dotnet build "FitnessApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitnessApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessApp.dll"]