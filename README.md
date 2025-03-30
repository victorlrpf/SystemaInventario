# 📦 API de Inventário

## 📌 Visão Geral
Esta é uma API para gestão de inventário, desenvolvida em **C# com ASP.NET Core**.
A API permite adicionar, listar, atualizar e remover produtos, simulando um banco de dados através de arquivos JSON.

## 🚀 Tecnologias Utilizadas
- **C#**
- **ASP.NET Core 7**
- **JSON como banco de dados simulado**
- **Swagger para documentação da API**

## 📂 Estrutura do Projeto
```
SistemaInventario/
│── Controllers/
│   ├── InventoryController.cs
│── Models/
│   ├── Product.cs
│── Services/
│   ├── InventoryService.cs
│   ├── JsonDatabaseService.cs
│── Program.cs
│── database.json  # Simula o banco de dados
│── README.md
```

## 🛠 Configuração e Execução
### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/victorlrpf/sistemaInventario.git
cd sistemaInventario
```

### 2️⃣ Instalar dependências
```bash
dotnet restore
```

### 3️⃣ Executar a API
```bash
dotnet run
```
A API estará disponível em `https://localhost:7280`.

### 4️⃣ Acessar a documentação
Abra o navegador e acesse:
```
https://localhost:7280/swagger/index.html
```

## 🔥 Endpoints da API

### 📌 **Listar todos os produtos**
**GET** `/api/inventory`
```json
[
  {
    "id": 1,
    "name": "Teclado Mecânico",
    "quantity": 10,
    "price": 199.99,
    "category": "Periféricos"
  }
]
```

### 📌 **Buscar um produto por ID**
**GET** `/api/inventory/{id}`

### 📌 **Adicionar um novo produto**
**POST** `/api/inventory`
```json
{
  "name": "Mouse Gamer",
  "quantity": 5,
  "price": 129.99,
  "category": "Periféricos"
}
```

### 📌 **Atualizar a quantidade de um produto**
**PUT** `/api/inventory/{id}`
```json
{
  "newQuantity": 15
}
```

### 📌 **Remover um produto**
**DELETE** `/api/inventory/{id}`

### 📌 **Buscar produtos por categoria**
**GET** `/api/inventory/category/{category}`

### 📌 **Buscar produtos dentro de uma faixa de preço**
**GET** `/api/inventory/price-range?minPrice=100&maxPrice=500`

### 📌 **Obter o total de itens em estoque**
**GET** `/api/inventory/total-items`

### 📌 **Obter o valor total do inventário**
**GET** `/api/inventory/total-value`

## 📜 Licença
Este projeto está sob a MIT License. Sinta-se livre para usá-lo e modificá-lo!

---
