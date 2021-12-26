FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY LemonSharp.VaccinationCore.Infrastructure/LemonSharp.VaccinationCore.Infrastructure.csproj LemonSharp.VaccinationCore.Infrastructure/
COPY LemonSharp.VaccinationCore.Domain/LemonSharp.VaccinationCore.Domain.csproj LemonSharp.VaccinationCore.Domain/
COPY LemonSharp.VaccinationCore.Application/LemonSharp.VaccinationCore.Application.csproj LemonSharp.VaccinationCore.Application/
COPY LemonSharp.VaccinationCore.Query/LemonSharp.VaccinationCore.Query.csproj LemonSharp.VaccinationCore.Query/
COPY LemonSharp.VaccinationCore.API/LemonSharp.VaccinationCore.API.csproj LemonSharp.VaccinationCore.API/
RUN dotnet restore LemonSharp.VaccinationCore.API/LemonSharp.VaccinationCore.API.csproj

# copy everything and build
COPY . .

WORKDIR /app/LemonSharp.VaccinationCore.API
RUN dotnet publish -c Release -o out

# build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build-env /app/LemonSharp.VaccinationCore.API/out .
ENTRYPOINT ["dotnet", "LemonSharp.VaccinationCore.API.dll"]