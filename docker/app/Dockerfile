FROM ubuntu:20.04

#RUN DEBIAN_FRONTEND=noninteractive apt update -u && apt install -y tzdata
#RUN ln -sf /usr/share/zoneinfo/Europe/Rome /etc/localtime

ENV DEBIAN_FRONTEND=noninteractive
RUN apt-get update && apt-get -y install tzdata 
RUN ln -fs /usr/share/zoneinfo/Europe/Rome /etc/localtime 
RUN dpkg-reconfigure --frontend noninteractive tzdata 

RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb

RUN apt update
RUN apt install -y wget vim apt-transport-https dotnet-sdk-5.0 aspnetcore-runtime-5.0

ENV ASPNETCORE_URLS=http://*:5001
ENV ASPNETCORE_ENVIRONMENT="production"

EXPOSE 5001
WORKDIR /app

ENTRYPOINT ["dotnet", "App.dll"]