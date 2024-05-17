FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copier csproj et restaurer en tant que couches distinctes
COPY *.csproj ./
RUN dotnet restore

# Copier tout le reste et construire
COPY . ./

COPY yolo/labels /App/yolo/labels
COPY yolo/images /App/yolo/images

RUN dotnet publish -c Release -o out

# Générer l'image de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "RetrieveYoloImages.dll"]
