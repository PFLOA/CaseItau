FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["A4S.CaseItau.CatsApi/A4S.CaseItau.CatsApi.csproj", "A4S.CaseItau.CatsApi/"]
COPY ["A4S.CaseItau.Application/A4S.CaseItau.Application.csproj", "A4S.CaseItau.Application/"]
COPY ["A4S.CaseItau.Core/A4S.CaseItau.Core.csproj", "A4S.CaseItau.Core/"]
COPY ["A4S.CaseItau.Domain/A4S.CaseItau.Domain.csproj", "A4S.CaseItau.Domain/"]
COPY ["A4S.CaseItau.Infra/A4S.CaseItau.Infra.csproj", "A4S.CaseItau.Infra/"]
COPY ["A4S.CaseItau.Injection/A4S.CaseItau.Injection.csproj", "A4S.CaseItau.Injection/"]
COPY ["A4S.CaseItau.HTTP/A4S.CaseItau.HTTP.csproj", "A4S.CaseItau.HTTP/"]
RUN dotnet restore "A4S.CaseItau.CatsApi/A4S.CaseItau.CatsApi.csproj"
COPY . .
WORKDIR "/src/A4S.CaseItau.CatsApi"
RUN dotnet build "A4S.CaseItau.CatsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "A4S.CaseItau.CatsApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "A4S.CaseItau.CatsApi.dll"]