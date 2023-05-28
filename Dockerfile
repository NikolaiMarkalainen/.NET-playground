FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /backend/usr/src/app

COPY *.csproj .

RUN dotnet restore

COPY .. ./

RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:7.0 as runtime

WORKDIR /backend

COPY --from=build-env /publish ./

ENTRYPOINT [ "dotnet", "CsharpTest.dll" ]

