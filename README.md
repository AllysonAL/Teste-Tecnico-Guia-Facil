# 🧩 Projeto Full Stack - Desafio
Este projeto é composto por duas aplicações: **Backend (.NET)** e **Frontend (Angular)**.

## 📄 Estrutura Geral
- Backend: Aplicação ASP.NET Core com Entity Framework Core e camada de dados separada.
- Frontend: Aplicação Angular consumindo a API via HTTP.
- Comunicação: CORS habilitado entre as portas configuradas.

## ⚙️ Backend (.NET)

**Passos para iniciar:**
1. Definir a *connection string* nos *User Secrets* dos projetos **API** e **Dados**. 
```
  {
    "ConnectionStrings": {
      "DefaultConnection": ""
    }
  }
```
2. Executar as *migrations* no projeto **Dados** para criar o banco e registros iniciais.  
3. Iniciar a API — configurada para rodar na **porta 5200**.

## 💻 Frontend (Angular)

**Passos para iniciar:**
1. Instalar os pacotes: npm install.
2. Iniciar ng serve -o — configurado para rodar na **porta 4200**.
