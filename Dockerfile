FROM ubuntu:latest


##VOLUME /assets
##WORKDIR /assets/Publish
##上传服务器的时候要把下面打开,不用的时候调试可以把上面打开
COPY ./Bin/publish /assets/bin
COPY ./Bin/Server.Hotfix.dll /assets/bin
COPY ./Bin/Server.Hotfix.pdb /assets/bin
COPY ./Config /assets/Config

WORKDIR /assets/bin
RUN chmod +x Server.App
ENV IsDevelop=1
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1 
RUN apt-get update -y
RUN apt-get install -y libssl1.1
RUN apt-get install -y wget
RUN apt-get install -y apt-transport-https
##RUN apt-get install -y libc6
##RUN apt-get install -y libgcc1
##RUN apt-get install -y libgssapi-krb5-2
##RUN apt-get install -y libicu66
##RUN apt-get install -y libstdc++6
##RUN apt-get install -y zlib1g
##CMD ["--Develop","1"]
ENTRYPOINT ["./Server.App"]