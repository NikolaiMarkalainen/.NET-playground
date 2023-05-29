FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /backend

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:7.0 as runtime

WORKDIR /publish

COPY --from=build-env /publish ./

ENTRYPOINT [ "dotnet", "CsharpTest.dll" ]

