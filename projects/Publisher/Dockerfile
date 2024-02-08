FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy csproject and restore as distinct layers
COPY ./projects/Publisher/*.csproj ../../projects/Publisher/
COPY ./packages/MessageClient/*.csproj ../../packages/MessageClient/
COPY ./packages/Messages/*.csproj ../../packages/Messages/
COPY ./packages/ClientID/*.csproj ../../packages/ClientID/

WORKDIR /App
RUN dotnet restore ../../projects/Publisher/Publisher.csproj

# Copy everything else and build
COPY ./projects/Publisher ../../projects/Publisher
COPY ./packages/MessageClient ../../packages/MessageClient
COPY ./packages/Messages ../../packages/Messages
COPY ./packages/ClientID ../../packages/ClientID

WORKDIR /App
RUN dotnet build ../../projects/Publisher/Publisher.csproj -c Release -o /App

FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /App
COPY --from=build-env /App .
ENTRYPOINT ["dotnet", "Publisher.dll"]