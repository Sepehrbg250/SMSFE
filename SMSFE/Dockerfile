FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SMSFE/SMSFE.csproj", "SMSFE/"]
RUN dotnet restore "SMSFE/SMSFE.csproj"
COPY . .
WORKDIR "/src/SMSFE"
RUN dotnet build "SMSFE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SMSFE.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SMSFE.dll"]
