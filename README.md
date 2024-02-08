# PubSub Example

## Overview

This is a simple example of messaging using a Publisher and Subscriber patterns in .NET 7 using EasyNetQ. 

## Technologies

- .NET 7, .NET 7 SDK
- EasyNetQ

## Building and Running the Application

The application can be built and run using Docker or .NET 7 SDK. 

### Prerequisites

1. Install [Docker](https://docs.docker.com/engine/install/)
2. Install [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
3. Clone this repository to your local machine

### Local Build

Build the console Subscriber app by running the following command in the terminal:

```bash
dotnet build .\Subscriber\Subscriber.csproj
```

Build the console Publisher app by running the following command in the terminal:

```bash
dotnet build .\Publisher\Publisher.csproj
```

### Docker Build

In order to build and run the Publisher and Subscriber containers, you need a running RabbitMQ instance. 
For compatibility with the docker-compose files in this repository, you can use the following command to run a RabbitMQ container:

```bash
docker run -d --network microservices_net --hostname rabbitmq --name rabbitmq -p 15672:15672 -p 5672:5672
```
It will build and run a RabbitMQ container with the same hostname and network that the Publisher and Subscriber containers will use for connecting.

Build and run the Subscriber container using docker-compose:

```bash
docker-compose -f projects/Subscriber/docker-compose.yml up -d
```
Build and run the Publisher container using docker-compose:

```bash
docker-compose -f projects/Publisher/docker-compose.yml run --rm publisher
```

Using the command above allows you to run the Publisher container with an interactive terminal, so you can send messages to any subscriber.