# Banco Digital Movi
> Solicite empréstimos enquanto possuir limite
> Relatórios detalhados de sua movimentação

![NPM Version][npm-image]

![](../header.png)

## ## Configuração para o desenvolvimento (Front-end)

No diretório "1 - Presentation\vue-app" inicie o "cmd" ou equivalente, e execute o seguinte comando

```sh
npm install
```

Após execute o comando "npm run dev" para subir sua aplicação.

```sh
npm run dev
```

Agora basta executar em seu navegador http://localhost:8080/login

## ## Configuração para o desenvolvimento (Back-end)

Basta executar o projeto WebApi.

Será criado automaticamente um cliente padrão com 

**usuário: movidesk**

**senha: admin** 

com um limite de R$ 1000.00.
Verifique que sua instância de banco estará criada.

## ## Obtendo relatório de empréstimos diários (bash)

É necessário buildar o projeto, "GerarArquivo" que está na camada de "1 - Presentation".

Após o build basta executar o "cmd" ou equivalente na pasta do projeto "1 - Presentation\GerarArquivo"

```sh
dotnet run
```

Seu arquivo estará disponível na pasta "c:\emprestimos"

## Contribuições

1. Faça o _fork_ do projeto (<https://github.com/yourname/yourproject/fork>)
2. Crie uma _branch_ para sua modificação (`git checkout -b feature/fooBar`)
3. Faça o _commit_ (`git commit -am 'Add some fooBar'`)
4. _Push_ (`git push origin feature/fooBar`)
5. Crie um novo _Pull Request_

[npm-image]: https://img.shields.io/npm/v/datadog-metrics.svg?style=flat-square
[npm-url]: https://npmjs.org/package/datadog-metrics
[npm-downloads]: https://img.shields.io/npm/dm/datadog-metrics.svg?style=flat-square
[travis-image]: https://img.shields.io/travis/dbader/node-datadog-metrics/master.svg?style=flat-square
