# ClientesAPI

Desenvolvimento de uma API de clientes utilizando boas pr�ticas de desenvolvimento e arquitetura de sistemas.
Como documenta��o optei por utilizar o **Swagger**.
Nessa Api � permitido realizar as opera��es b�sicas de um sistema (Create,Read,Update e Delete).
At� o momento o projeto cont�m:
- Padr�o de Arquitetura Limpa ( Onion Architecture ).
- Endpoints B�sicos da API (CRUD).
- Relacionamento com o Contexto de Dados utilizando Interfaces(Padr�o Repository).
- Design Pattern **Mediator** utilizando **CQRS** e a biblioteca MediatR.
- M�todos Assincronos.
- Valida��es de e-mail e CPF nos EndPoints da API utilizando **Fluent Validation**
- Relacionamento com o banco de dados SQLServer utilizando o **EntityFrameWorkCore**.


### Configurando o SQLServer(Migrations)

Para iniciar usando o banco de dados SQLServer:

```bash
Abra o terminal PowerShell(cmd) na pasta inicial do projeto(ClientesAPI,onde se encontra a solu��o e o Readme).

Execute o comando:

- dotnet ef database update -s Clientes.API

Se houver algum erro na cria��o do banco de dados, execute os comandos:

- dotnet ef migrations remove -s Clientes.API -p Clientes.Infrastructure
- dotnet ef migrations add InitialMigration -s Clientes.API -p Clientes.Infrastructure -o ./Persistence/Migrations
- dotnet ef database update -s Clientes.API

Lembre-se de verificar se o seu servi�o do SQL est� ativo e se a string de conex�o em ./Clientes.API/appsettings.json est� correta.
```
<h1 align="center">
  <img src="./Clientes.API/Assets/SqlConfig.gif" />
</h1>

### Dicas! 
 Exemplos de clientes dispon�veis na pasta ./Clientes.API/Assets/.<br>
 � possivel Executar sem o SQLServer, para isso, Em ./Clientes.API/Program.cs:
 - commente a linha 25 que menciona a op��o <font color="blue">options.UseSqlServer(configuration))</font>
 - Descomente a linha 25 que menciona a op��o <font color="blue">x.UseInMemoryDatabase("ClientesDatabase"))</font>

 <h1 align="center">
  <img src="./Clientes.API/Assets/InMemory.gif" />
</h1>