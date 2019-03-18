# Banco Digital Movi
> Solicite emprestimos enquanto tiverem limites
> Relatorios detalhados de sua movimentação

![NPM Version][npm-image]

![](../header.png)

## ## Configuração para Desenvolvimento (Front-end)

No diretorio "1 - Presentation\vue-app" inicie o "cmd" ou equivalente, e execute o seguinte comando

```sh
npm install
```

Após execute o comando "npm run dev" para subir sua aplicação.

```sh
npm run dev
```

## ## Configuração para Desenvolvimento (Back-end)

Basta executar o projeto WebApi.

## Obtendo relatorio de emprestimos diarios (bash)

É necessário buildar o projeto, "GerarArquivo" que esta na camada de "1 - Presentation".

Após o build basta execute o "cmd" ou equivalente na pasta do projeto "1 - Presentation\GerarArquivo"

```sh
dotnet run
```

Seu arquivo estará disponível na pasta "c:\emprestimos"

## Contributing

1. Faça o _fork_ do projeto (<https://github.com/yourname/yourproject/fork>)
2. Crie uma _branch_ para sua modificação (`git checkout -b feature/fooBar`)
3. Faça o _commit_ (`git commit -am 'Add some fooBar'`)
4. _Push_ (`git push origin feature/fooBar`)
5. Crie um novo _Pull Request_

[npm-image]: https://img.shields.io/npm/v/datadog-metrics.svg?style=flat-square
[npm-url]: https://npmjs.org/package/datadog-metrics
[npm-downloads]: https://img.shields.io/npm/dm/datadog-metrics.svg?style=flat-square
[travis-image]: https://img.shields.io/travis/dbader/node-datadog-metrics/master.svg?style=flat-square
