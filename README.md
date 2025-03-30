# Sistema de Inventário - API

Este é um projeto de **API RESTful** para o gerenciamento de um sistema de inventário. A API permite que os usuários adicionem, removam e atualizem produtos no inventário, bem como realizem consultas e relatórios sobre os itens disponíveis.

## Funcionalidades

- **Gerenciamento de Produtos**: Adicionar, remover e atualizar produtos no inventário.
- **Filtros de Busca**: Filtrar produtos por categoria ou faixa de preço.
- **Atualização de Preço**: Alterar o preço de um produto.
- **Relatórios**: Obter o total de itens em estoque e o valor total do inventário.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação principal.
- **ASP.NET Core**: Framework para construção de APIs.
- **In-Memory Data Storage**: Armazenamento de dados em memória (sem banco de dados).
- **Swagger**: Interface para testar as APIs diretamente no navegador.

## Endpoints

### 1. **GET /api/inventory**
Retorna todos os produtos no inventário.

**Exemplo de resposta**:

```json
[
    {
        "id": 1,
        "name": "Produto A",
        "quantity": 100,
        "price": 10.99,
        "category": "Categoria 1"
    },
    {
        "id": 2,
        "name": "Produto B",
        "quantity": 50,
        "price": 5.49,
        "category": "Categoria 2"
    }
]
```

### 2. **GET /api/inventory/{id}**
Retorna um produto específico pelo **id**.

**Exemplo de resposta**:

```json
{
    "id": 1,
    "name": "Produto A",
    "quantity": 100,
    "price": 10.99,
    "category": "Categoria 1"
}
```

### 3. **POST /api/inventory**
Adiciona um novo produto ao inventário.

**Exemplo de corpo de requisição**:

```json
{
    "id": 3,
    "name": "Produto C",
    "quantity": 200,
    "price": 15.99,
    "category": "Categoria 3"
}
```

### 3. **POST /api/inventory**
Adiciona um novo produto ao inventário.

**Exemplo de corpo de requisição**:

```json
{
    "id": 3,
    "name": "Produto C",
    "quantity": 200,
    "price": 15.99,
    "category": "Categoria 3"
}
```

### 4. **PUT /api/inventory/{id}**
Atualiza a quantidade de um produto.

**Exemplo de corpo de requisição**:

```json
{
    "newQuantity": 150
}
```

### 5. **PUT /api/inventory/price/{id}**
Atualiza o preço de um produto.

**Exemplo de corpo de requisição**:

```json
{
    "newPrice": 12.99
}
```

### 6. **DELETE /api/inventory/{id}**
Remove um produto do inventário pelo id.

### 7. **GET /api/inventory/category/{category}**
Filtra produtos por categoria.

**Exemplo de resposta**:

```json
[
    {
        "id": 1,
        "name": "Produto A",
        "quantity": 100,
        "price": 10.99,
        "category": "Categoria 1"
    }
]
```

### 8. **GET /api/inventory/price-range?minPrice=10&maxPrice=100**
Filtra produtos por faixa de preço.

**Exemplo de resposta**:

```json
[
    {
        "id": 1,
        "name": "Produto A",
        "quantity": 100,
        "price": 10.99,
        "category": "Categoria 1"
    }
]
```

### 9. **GET /api/inventory/total-items**
Retorna o total de itens em estoque.

**Exemplo de resposta**:

```json
{
    "TotalItems": 350
}
```

### 10. **GET /api/inventory/total-value**
Retorna o valor total do inventário.

**Exemplo de resposta**:

```json
{
    "TotalValue": 1234.50
}
```
