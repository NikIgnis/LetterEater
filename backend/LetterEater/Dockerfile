FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LetterEater.csproj", "."]
RUN dotnet restore "LetterEater.csproj"
COPY . .
RUN dotnet build "LetterEater.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LetterEater.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LetterEater.dll"]