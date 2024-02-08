FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy csproject and restore as distinct layers
COPY ./projects/Subscriber/*.csproj ../../projects/Subscriber/
COPY ./packages/MessageClient/*.csproj ../../packages/MessageClient/
COPY ./packages/Messages/*.csproj ../../packages/Messages/
COPY ./packages/ClientID/*.csproj ../../packages/ClientID/

WORKDIR /App
RUN dotnet restore ../../projects/Subscriber/Subscriber.csproj

# Copy everything else and build
COPY ./projects/Subscriber ../../projects/Subscriber
COPY ./packages/MessageClient ../../packages/MessageClient
COPY ./packages/Messages ../../packages/Messages
COPY ./packages/ClientID ../../packages/ClientID

WORKDIR /App
RUN dotnet build ../../projects/Subscriber/Subscriber.csproj -c Release -o /App

FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /App
COPY --from=build-env /App .
ENTRYPOINT ["dotnet", "Subscriber.dll"]