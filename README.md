Este documento explica como configurar e executar a aplicação ToDo API em seu ambiente local.  

Pré-requisitos
.NET 6 ou superior  
SQL Server  
Visual Studio 2022 ou VS Code  
(NuGet)  

Configuração Inicial
1. Clone o repositório
2. Configure o banco de dados 
- Crie um banco chamado `TarefasToDo.dbo`.  
- Atualize a connection string em `appsettings.json`:  
3. Aplique as Migrations 

Executando a Aplicação
Opção 1: Visual Studio
1. Abra o projeto no Visual Studio 2022.  
2. Pressione F5 ou clique em IIS Express para iniciar.  
Opção 2: Terminal (VS Code ou CLI)  
- A API estará disponível em:  
  - https://localhost:5001 (HTTPS)  
  - http://localhost:5000 (HTTP)  

Dependências Principais
Microsoft.EntityFrameworkCore - ORM para banco de dados, MediatR - Padrão CQRS,
FluentValidation - Validação de requests 
