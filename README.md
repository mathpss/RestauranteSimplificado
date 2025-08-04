# 🛒 Projeto Fullstack - Restaurante Simplificado
Sistema fullstack desenvolvido com **React (frontend)** e **ASP.NET Core (backend)**.

O projeto se trata de um sistema onde o cliente consegue montar o pedido via web, chegando no restaurante o pedido já seria impresso.

## 🧰 Tecnologias Utilizadas

### Front-end (React)

- React
- Typescript
- Axios
- React Router DOM
- Styled Components

### Back-end (.NET)

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger

---

## 📁 Estrutura do Projeto

### /frontend
- src/
  - Components/
  - Pages/
  - Services/
 
### /backend
- Controllers/
- Models/
- Context/
- Middlewares/
- Services/

---

## 🚀 Como Executar o Projeto

### 1. Clone o repositório

``` git clone https://github.com/mathpss/RestauranteSimplificado.git ``` 

``` cd RestauranteSimplificado ```

### 2. Rodando o Back-end (.NET)

``` cd backend ```

### Restaura os pacotes
``` dotnet restore ```

### Atualiza o banco de dados
``` dotnet ef database update ```

### Executa o projeto
``` dotnet run ```

### 3. Rodando o Front-end

``` cd Frontend ```

### Instale as dependências
``` npm install ```

### Execute o projeto
``` npm run dev ```
 
---

