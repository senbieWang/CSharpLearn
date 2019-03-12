FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DockerUseTest/DockerUseTest.csproj", "DockerUseTest/"]
RUN dotnet restore "DockerUseTest/DockerUseTest.csproj"
COPY . .
WORKDIR "/src/DockerUseTest"
RUN dotnet build "DockerUseTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerUseTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerUseTest.dll"]