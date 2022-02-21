FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BBPariuRuleta/BBPariuRuleta.csproj", "BBPariuRuleta/"]
COPY ["ClassLibrary1/ClassLibrary1.csproj", "ClassLibrary1/"]
RUN dotnet restore "BBPariuRuleta/BBPariuRuleta.csproj"
COPY . .
WORKDIR "/src/BBPariuRuleta"
RUN dotnet build "BBPariuRuleta.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBPariuRuleta.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBPariuRuleta.dll"]
