Para iniciar o projeto é necessario fazer o download da image do sql server
Obs: O container deve rodar em linux

docker pull mcr.microsoft.com/mssql/server:2019-latest
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=eclipse@1234#" -p 1435:1433 --name eclipseDatabase -d mcr.microsoft.com/mssql/server:2019-latest

a connection string ja esta apontada para a porta exposta no docker run
o projeto vai incluir o migrations inicialmente na primeira conexao,
Entao nao é necessario mais nada, instalar o container do sql server e rodar a aplicaçao

a aplicaçao tambem tem uma interfaçe swager para fazer o testes da api
