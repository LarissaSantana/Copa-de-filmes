# Copa-de-filmes


# Backend
- Tecnologias utilizadas: 
  Asp.Net Core 3.1
  
- Como executar: 
  Para executar, basta fazer download/clone do projeto CopaDeFilmes e inicilizar a aplicação através do projeto CopaDeFilmes.API.
  
- Swagger: 
  Para visualizar os endpoints via Swagger, o serviço deve estar em execução e, usando a url https://localhost:<PORTA_DO_SERVICO>/swagger/index.html é possível visualizar a       documentação.
  
- Testes unitários: 
  Para executar os testes unitários no Visual Studio 2019, basta expandir o "TestExplorer" e clicar no botão de "Run".

# Frontend
- Tecnologias utilizadas:
  Angular 11.0.5.
  
- Pré-requisitos para executar:
  - Estar com o projeto de backend em execução
  - Ter o Angular 11.0.5, Angular CLI e o typoscript 4.0.5 instalados no computados

- Como executar:
  - Para executar, é necessário configurar o campo baseUrl que fica no arquivo https://github.com/LarissaSantana/Copa-de filmes/blob/main/CopaDeFilmes.SPA/CopaDeFilmes/src/environments/environment.ts. A configuração é feita alterando a porta da url para a mesma porta HTTPs do serviço do backend.
  - Através do Angular CLI é possível digitar "ng serve" no terminal do visual studio code e uma página vai ser aberta no navegador com a aplicação funcionando.
