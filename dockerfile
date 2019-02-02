FROM ubuntu
RUN apt-get update
RUN apt-get -y install wget
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get install -y software-properties-common
RUN add-apt-repository universe
RUN apt-get update
RUN apt-get -y install dotnet-sdk-2.2