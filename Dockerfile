FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app

#Creating user 
RUN useradd --create-home --shell /bin/bash --user-group --groups sudo appuser && \
echo 'appuser:password' | chpasswd
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src
COPY ["SchoolSystem.csproj", "./"]
RUN dotnet restore
COPY . .
WORKDIR "/src/."
RUN dotnet build "SchoolSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "SchoolSystem.dll" ]
