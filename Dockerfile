FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 先复制所有项目文件以便恢复依赖
COPY ["unattended-generator-web.csproj", "./"]
COPY ["Library/UnattendGenerator/UnattendGenerator.csproj", "Library/UnattendGenerator/"]

# 恢复依赖
RUN dotnet restore "unattended-generator-web.csproj"

# 复制所有源代码
COPY . .

# 构建项目
WORKDIR "/src/"
RUN dotnet build "./unattended-generator-web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./unattended-generator-web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "unattended-generator-web.dll"]
