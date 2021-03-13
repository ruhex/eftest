#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NotificationSenderAPI/NotificationSenderAPI.csproj", "NotificationSenderAPI/"]
RUN dotnet restore "NotificationSenderAPI/NotificationSenderAPI.csproj"
COPY . .
WORKDIR "/src/NotificationSenderAPI"
RUN dotnet build "NotificationSenderAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotificationSenderAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationSenderAPI.dll"]