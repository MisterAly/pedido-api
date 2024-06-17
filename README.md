# Projeto de Gerenciamento de Pedidos

Este projeto é uma aplicação ASP.NET Core que fornece uma interface de API REST para criar, ler, atualizar e deletar (CRUD) pedidos.

## Arquitetura

O projeto segue os princípios de design de software SOLID para garantir que o código seja fácil de manter e estender. Ele é estruturado em camadas para separar as responsabilidades, tornando o código mais limpo e mais fácil de entender.

## Banco de Dados

O projeto utiliza SQL Server como sistema de gerenciamento de banco de dados. O servidor de banco de dados é hospedado em um container Docker para facilitar a configuração e o isolamento do ambiente.

## Como rodar o projeto

1. Inicie o ambiente Docker com o comando:

```bash
$ docker-compose up -d
```

2. Execute as migrations para criar as tabelas iniciais:

```bash
$ dotnet ef database update --context PedidoContext
```

3. Inicie a aplicação:

```bash
$ dotnet run
```

Após seguir esses passos, a aplicação deve estar rodando na porta 5209 e aceitando requisições da porta 3000. Você pode acessar a aplicação em [http://localhost:5209/api/](http://localhost:5209/api/).

## Recursos

O projeto inclui um CRUD completo para a entidade `Pedido`, que possui uma relação de um para muitos com a entidade `ItemPedido`. Cada `Pedido` pode ter vários `ItemPedido`, mas cada `ItemPedido` pertence a apenas um `Pedido`.

## Tecnologias utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Docker

## Contribuição

Contribuições são bem-vindas. Para contribuir, por favor, faça um fork do projeto, crie uma branch com suas alterações e abra um pull request.
