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
- Implementa��o de login na API utilizando **Jason Web Token** e **Bearer**

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

### Como Logar na Aplica��o Utilizando o Bearer!

- Com a aplica��o executando, na area de usu�rios execute o m�todo Post(api/Usuarios) Preenchendo os campos de Login e Senha conforme a imagem abaixo:
<h1 align="center">
  <img src="./Clientes.API/Assets/Bearer part1.gif" />
</h1>

- Em seguida, no m�todo Put(api/Usuarios/login), preencha os dados de email e senha conforme a imagem abaixo:
<h1 align="center">
  <img src="./Clientes.API/Assets/Bearer part2.gif" />
</h1>

- No resultado da opera��o, Copie o Token sem as aspas("")  no retorno da API.
- Em seguida, basta abrir o bot�o *Authorize* no in�cio da p�gina e digitar Bearer seguido de um espa�o ' ' e colar o token gerado anteriormente.
EX: ***Bearer eyJhbGciOiJIUzI1NiIs.......OiJhbG***
<h1 align="center">
  <img src="./Clientes.API/Assets/Bearer part3.gif" />
</h1>

#### - E pronto! Est� liberado todos os Endpoints da API! 

### Dicas! 
 Exemplos de clientes dispon�veis na pasta ./Clientes.API/Assets/.<br>
 � possivel Executar sem o SQLServer, para isso, Em ./Clientes.API/Program.cs:
 - commente a linha 55 que menciona a op��o: _**options.UseSqlServer(configuration))**_
 - Descomente a linha 54 que menciona a op��o: _**x.UseInMemoryDatabase("ClientesDatabase"))**_

 <h1 align="center">
  <img src="./Clientes.API/Assets/InMemory.gif" />
</h1>