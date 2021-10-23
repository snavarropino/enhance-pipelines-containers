FROM ubuntu:20.04

RUN apt-get update
RUN apt-get install sudo
RUN sudo apt-get install -y redis-server
RUN apt-get install -y wget
RUN sudo apt-get update
RUN apt-get install -y curl
RUN sudo apt-get update
RUN sudo apt-get install -y apt-transport-https
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN sudo dpkg -i packages-microsoft-prod.deb
RUN sudo apt-get update
RUN sudo apt-get install -y dotnet-sdk-5.0