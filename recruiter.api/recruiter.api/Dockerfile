FROM microsoft/dotnet:2.1-sdk AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY recruiter.api/recruiter.api.csproj recruiter.api/
RUN dotnet restore recruiter.api/recruiter.api.csproj
COPY . .
WORKDIR /src/recruiter.api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "recruiter.api.dll"]
