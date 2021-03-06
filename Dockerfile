FROM debian:latest

RUN apt-get update
RUN apt-get install -y wget
RUN apt-get install -y gnupg2
RUN apt-get install -y apt-transport-https

# Register Microsoft
RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
RUN mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
RUN wget -q https://packages.microsoft.com/config/debian/9/prod.list
RUN mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
RUN chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
RUN chown root:root /etc/apt/sources.list.d/microsoft-prod.list

RUN apt-get update
RUN apt-get install -y dotnet-sdk-2.1

RUN mkdir /docker
COPY ./romans/ /docker/

RUN dotnet build /docker/
RUN dotnet run --project /docker/AppConsole 2019