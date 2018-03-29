FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
ARG FAILTEST
ENV FAILTEST ${FAILTEST:-false}
WORKDIR /src
COPY CalculatorExample.sln ./
COPY CalculatorWeb/CalculatorWeb.csproj CalculatorWeb/
COPY CalculatorLogic/CalculatorLogic.csproj CalculatorLogic/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/CalculatorWeb
RUN dotnet build -c Release -o /app

FROM build AS test
WORKDIR /src/CalculatorUnitTests
RUN dotnet test --filter TestCategory=Unit --logger "trx;LogFileName=UnitTestsResult.trx"

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY --from=test /src/CalculatorUnitTests/TestResults/UnitTestsResult.trx .
ENTRYPOINT ["dotnet", "CalculatorWeb.dll"]