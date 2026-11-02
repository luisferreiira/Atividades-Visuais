# Exercício 1 — Cadastro de Bandas

Sistema de console desenvolvido em **C#** para cadastrar, consultar e gerenciar bandas musicais. O projeto utiliza uma lista de objetos e armazenamento em arquivo de texto para manter os registros entre execuções.

## Funcionalidades

- Cadastrar bandas com nome, gênero, quantidade de integrantes e ranking.
- Listar as bandas cadastradas.
- Pesquisar bandas por **nome**, **gênero** ou **ranking**, por meio de um submenu de buscas.
- Atualizar os dados de uma banda existente.
- Remover bandas cadastradas.
- Salvar os registros em arquivo `.txt` e carregá-los posteriormente.

## Estrutura de dados

A classe `Banda` reúne os atributos:

| Atributo | Tipo | Descrição |
|---|---|---|
| `nome` | `string` | Nome da banda |
| `genero` | `string` | Gênero musical |
| `integrantes` | `int` | Quantidade de integrantes |
| `ranking` | `int` | Posição da banda no ranking |

Os objetos são armazenados em `List<Banda>`.

## Organização do programa

O `Main()` apresenta um menu com opções para cadastro, listagem, busca, atualização, remoção e persistência. As pesquisas ficam organizadas em um **submenu**.

Entre os métodos utilizados estão `addBanda()`, `mostrarBandas()`, `buscarBandaPorNome()`, `buscarBandaPorGenero()`, `buscarBandaPorRanking()`, `atualizarBanda()`, `removerBanda()`, `salvarDados()` e `carregarDados()`.

A função auxiliar `buscarIndiceBanda()` percorre a lista e retorna o índice de uma banda encontrada pelo nome, ou `-1` quando não existe. Ela é reutilizada nas operações de atualização e remoção, evitando repetir a lógica de busca.

## Exemplo de utilização

1. Cadastre uma banda com nome `Queen`, gênero `Rock`, quatro integrantes e ranking `1`.
2. Abra o submenu de busca e pesquise por `Queen`.
3. Atualize o ranking da banda.
4. Liste os registros para conferir a alteração.
5. Escolha **Salvar e Sair** para gravar os dados.
6. Execute novamente e verifique o carregamento dos registros.

## Persistência de dados

O programa utiliza `StreamWriter` para salvar e leitura de arquivo para carregar os registros. O arquivo `.txt` permite recuperar os dados sem precisar cadastrá-los novamente. O nome e o formato exatos do arquivo devem seguir a implementação presente no projeto.

## Como executar

É necessário ter o **SDK do .NET** instalado.

No terminal, dentro da pasta que contém o arquivo `.csproj`, execute:

```bash
dotnet restore
dotnet run
```

Para verificar apenas a compilação:

```bash
dotnet build
```

## Conceitos praticados

Classes e objetos, `List<T>`, métodos, parâmetros e retornos, laços `for` e `foreach`, condicionais, `switch`, submenu, busca por índice e leitura/escrita em arquivos.
