Esse projeto tem o propósito simples de funcionar como um CRUD para Pedidos.

Desta forma criei uma simples arquitetura com separação de responsabilidades para facilitar uma hipotética manutenção do código.

Utilizei um SQL Server para o projeto criado em Docker para hospedar os dados.
Para erguer o ambiente docker apenas rode o comando:

$ docker-compose up -d

Migrations iniciais estão criadas no projeto com o propósito de criar as tabelas iniciais, basta rodar:

$ dotnet ef database update --context PedidoContext

Com esses passos você pode apenas rodar:

$ dotnet run

Sua aplicação deve estar rodando na porta [5209](http://localhost:5209/api/') e aceitando requisições da porta 3000.