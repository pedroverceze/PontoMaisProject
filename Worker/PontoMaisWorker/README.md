# PontoMais
Technologies: Sistema de ponto, webApi, worker, Kafka, EF Core, Migrations

# environment

## kafka
Use docker-compose file inside the "Docker" folder to create kafka server (docker folder), you can use localhost:19000 to manage topics.

## SQL
Use docker-compose file inside the "Docker/Sql" folder to create SQL server (docker folder), you can use username: sa password: Pedro123 to connect 
There is a migration inside of PontoMaisInfra Project

## migration
To add another migration you need to be inside the PontoMaisInfra folder and specify the startUp project, follow the command below:
dotnet ef migrations add correcaoChave --startup-project ..\PontoMaisApi\
