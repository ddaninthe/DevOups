FROM debian:latest

RUN apt-get update
RUN apt-get install -y dotnet-sdk-2.1

RUN mkdir /docker
COPY . /docker/

RUN dotnet build /docker/AppConsole/
RUN dotnet run /docker/AppConsole/bin/Debug/netcoreapp2.1/AppConsole.dll