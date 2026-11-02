# Exercício 3 — Controle de Livros

Programa de console desenvolvido em **C#** para cadastrar e consultar livros de uma biblioteca, com identificação de prateleiras e filtros por ano de publicação.

## Funcionalidades

- Cadastrar livros informando título, autor, ano e prateleira.
- Buscar livros pelo título e exibir a prateleira correspondente.
- Listar todos os livros cadastrados.
- Mostrar os livros publicados **depois** de um ano informado.
- Salvar e carregar os registros em arquivo `.txt`.

## Estrutura de dados

A classe `Livro` contém:

| Atributo | Tipo | Descrição |
|---|---|---|
| `titulo` | `string` | Título do livro |
| `autor` | `string` | Nome do autor |
| `ano` | `int` | Ano de publicação |
| `prateleira` | `string` | Localização do livro |

Os livros são mantidos em `List<Livro>`.

## Organização do programa

O menu permite adicionar livros, mostrar todos, buscar por título, buscar por ano mínimo, carregar os registros e salvar ao sair.

Os métodos principais são `adicionarLivro()`, `buscarLivroPorTitulo()`, `mostrarLivros()`, `buscarLivroPorAnoMinimo()`, `salvarDados()` e `carregarDados()`.

A busca por título utiliza `Contains()` em comparação sem diferenciação de maiúsculas e minúsculas. Assim, pesquisar `Harry Potter` pode encontrar um livro com título maior que contenha essa expressão.

Na busca por ano, a condição esperada pelo enunciado é:

```csharp
if (listaLivros[i].ano > ano)
```

Isso inclui somente os livros **mais novos** que o ano informado, sem incluir livros daquele mesmo ano.

## Exemplo de utilização

Cadastre os seguintes livros:

| Título | Autor | Ano | Prateleira |
|---|---|---:|---|
| Dom Casmurro | Machado de Assis | 1899 | A1 |
| O Hobbit | J. R. R. Tolkien | 1937 | B2 |
| Harry Potter e a Pedra Filosofal | J. K. Rowling | 1997 | C3 |
| Jogos Vorazes | Suzanne Collins | 2008 | D4 |

- Ao buscar `Harry Potter`, o programa deve informar a prateleira `C3`.
- Ao informar o ano `1990`, devem aparecer os livros de **1997** e **2008**.
- Ao listar todos, devem ser exibidos título, autor, ano e prateleira.

## Persistência de dados

O arquivo utilizado é `Livros.txt`, com campos separados por ponto e vírgula:

```text
Dom Casmurro;Machado de Assis;1899;A1
O Hobbit;J. R. R. Tolkien;1937;B2
```

A opção de carregamento substitui os itens atualmente em memória pelos registros do arquivo. Por isso, alterações ainda não salvas podem ser perdidas ao recarregar.

## Como executar

Com o **SDK do .NET** instalado, entre na pasta do projeto e execute:

```bash
dotnet restore
dotnet run
```

Para conferir a compilação:

```bash
dotnet build
```

## Conceitos praticados

Classes, `List<T>`, laços, busca textual com `Contains()`, comparação de números, métodos com retorno `bool`, menu com `switch` e arquivos TXT.
