# 📌 Projeto MVC .NET 8

Este projeto foi desenvolvido utilizando a **arquitetura MVC** com **.NET 8**, aplicando boas práticas como separação de responsabilidades, uso de **DTOs**, **DataAnnotations** para validação, **injeção de dependência** e **AutoMapper** para conversão entre entidades e objetos de transferência de dados.  

---

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **SQL Server** (ou outro banco configurado via connection string)
- **AutoMapper**
- **Dependency Injection (DI)**
- **Migrations do EF Core**
- **Controllers MVC**
- **DataAnnotations** (validação e restrições de dados)

---

## 📂 Estrutura do Projeto

- **Controllers**  
  - Implementados para operações **CRUD** (Create, Read, Update, Delete)  
  - Suporte a métodos `POST`, `PUT`, `PATCH`, `DELETE` e `GET`

- **DTOs (Data Transfer Objects)**  
  - **CreateDto** → para criação de entidades  
  - **UpdateDto** → para atualização parcial ou completa  
  - **ReadTeamDto** → para leitura segura de dados (sem expor entidades diretamente)

- **Validações com DataAnnotations**  
  - Utilizadas para definir restrições e regras de validação diretamente nos DTOs e Models  
  - Exemplos: `[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]`, etc.

- **Migrations**  
  - Banco de dados versionado via **EF Core Migrations**

- **Injeção de Dependência**  
  - Serviços e contexto do banco de dados registrados no container de DI  
  - Facilita testes e manutenção

- **AutoMapper**  
  - Configurado para mapear automaticamente entre **Models ↔ DTOs**
