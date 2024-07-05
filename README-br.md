# BCPE API

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README.md)
[![br](https://img.shields.io/badge/lang-br-green.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README-br.md)
[![es](https://img.shields.io/badge/lang-es-orange.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README-es.md)
  
<br />

> FRONT-END: https://github.com/victor-souza-dev/BCPE

<br />

## 🚀 Introdução
Bem-vindo ao projeto BCPE API! Esta é uma aplicação backend desenvolvida em C# usando .NET 8.0.6. A API foi projetada para interagir perfeitamente com o front-end da BCPE, permitindo a extração de valores CSS e sua transformação em JSON. Este projeto utiliza ferramentas e bibliotecas modernas de desenvolvimento para fornecer uma interface robusta e fácil de usar para gerenciar configurações de CSS e upload de arquivos.

## 🌟 Propósito da Aplicação
Imagine que você possui um conjunto de arquivos CSS que seguem um modelo de estilização repetitivo, onde as classes e a estrutura são consistentes, mas os valores variam. Agora, imagine que você precisa extrair valores específicos dessas classes em diversos arquivos CSS. Essa aplicação foi criada exatamente para isso: ela permite que você defina seu modelo através de uma interface gráfica e receba um arquivo zip contendo todos os valores CSS formatados em JSON, de acordo com a estrutura que você especificar.

## ✨ Funcionalidades
- .NET 8.0.6: Plataforma de desenvolvimento para criar aplicativos de alto desempenho.
- Entity Framework: ORM para manipulação eficiente de dados e mapeamento objeto-relacional.
- SQLite: Banco de dados leve e de fácil configuração, ideal para desenvolvimento e testes.

## 🛠️ Começando
Para começar com o projeto BCPE API, siga os passos abaixo:

1. Clonar o repositório:
```csharp
git clone https://github.com/victor-souza-dev/BCPE.git
cd bcpe
```

2. Configurar o banco de dados:
Certifique-se de que o SQLite esteja configurado corretamente. As configurações padrão estão no arquivo appsettings.json.

3. Executar a aplicação:
Você pode executar a aplicação usando o Visual Studio ou a linha de comando:
```csharp
dotnet run
```
Por padrão, a aplicação será executada em http://localhost:5015.

## ⚙️ Configuração
Certifique-se de que você tenha a URL base correta da API configurada em suas variáveis de ambiente ou arquivos de configuração. Você pode ajustar as configurações de CORS no arquivo Program.cs para permitir requisições do servidor de desenvolvimento do front-end.
Exemplo de configuração de CORS no Program.cs:

```csharp
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => {
        var origins = new string[] { "http://localhost:5173", "https://localhost:5173" };
        builder.WithOrigins(origins)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
```

## 📜 Licença
Este projeto está licenciado sob a Licença MIT.

***

Sinta-se à vontade para explorar o código, sugerir melhorias e contribuir para tornar a BCPE API ainda melhor! 🎉
