FROM mcr.microsoft.com/dotnet/sdk:6.0 AS Production

WORKDIR /app/api

# Copy everything
COPY *.csproj .
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
COPY . .

RUN dotnet publish -c Release -o out

CMD ASPNETCORE_URLS=http://*:$PORT dotnet theFinale.dll
