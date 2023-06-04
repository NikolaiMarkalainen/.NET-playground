FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
COPY . .
COPY Directory.Build.props .

#Creating user 
RUN apt-get update && apt-get -y install sudo

FROM base AS build
WORKDIR /src
COPY ["SchoolSystem.csproj", "./"]
RUN dotnet restore
COPY . .
WORKDIR "/src/."
RUN dotnet build "SchoolSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5252
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT dotnet watch run
