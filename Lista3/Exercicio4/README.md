# Exercício 4 — Catálogo e Controle de Jogos

Sistema de console em **C#** para organizar uma coleção de jogos e controlar empréstimos e devoluções. O exercício trabalha com **uma classe associada a outra classe** para representar os dados de empréstimo.

## Funcionalidades

- Cadastrar jogos com título, console, ano e ranking.
- Listar todos os jogos cadastrados.
- Acessar um **submenu de busca** por título ou por console.
- Emprestar um jogo disponível, registrando a pessoa e a data atual.
- Impedir o empréstimo de um jogo que já esteja emprestado.
- Registrar a devolução de um jogo.
- Listar apenas os jogos emprestados e seus responsáveis.
- Salvar e carregar os dados em arquivo `.txt`.

## Estrutura de dados

### Classe `Jogo`

| Atributo | Tipo | Descrição |
|---|---|---|
| `titulo` | `string` | Título do jogo |
| `console` | `string` | Plataforma do jogo |
| `ano` | `int` | Ano do jogo |
| `ranking` | `int` | Posição no ranking |
| `emprestimo` | `Emprestimo` | Objeto com informações do empréstimo |

### Classe `Emprestimo`

| Atributo | Tipo | Descrição |
|---|---|---|
| `nomePessoa` | `string` | Pessoa que recebeu o jogo |
| `dataEmprestimo` | `DateTime` | Data em que o empréstimo ocorreu |
| `emprestado` | `bool` | `true` = S; `false` = N |

A inicialização `public Emprestimo emprestimo = new Emprestimo();` cria um objeto de empréstimo vazio para cada jogo. **Isso não significa que o jogo já esteja emprestado**: o campo booleano começa com `false`.

O enunciado informa limites de 30 caracteres para o título e 15 para o console; esses limites exigem validação adicional no cadastro, pois o tipo `string` não os aplica automaticamente.

## Menu e principais métodos

O menu principal contém cadastro, listagem, busca, empréstimo, devolução, listagem de emprestados, carregamento e salvamento ao sair.

O **submenu de busca** permite:

1. Buscar jogo por título, aceitando parte do texto pesquisado.
2. Listar jogos de um console específico.
3. Voltar ao menu principal.

Os métodos incluem `adicionarJogo()`, `mostrarJogos()`, `buscarJogoPorTitulo()`, `buscarJogosPorConsole()`, `emprestarJogo()`, `devolverJogo()`, `mostrarJogosEmprestados()`, `salvarDados()` e `carregarDados()`.

A função auxiliar `buscarIndiceJogo()` encontra um jogo pelo título e retorna sua posição na lista ou `-1`. Ela é reutilizada para emprestar e devolver jogos.

## Regras de empréstimo e devolução

- **Empréstimo:** localizar o jogo, verificar se está disponível, registrar `nomePessoa`, definir `dataEmprestimo = DateTime.Today` e marcar `emprestado = true`.
- **Devolução:** localizar o jogo, verificar se está emprestado e marcar `emprestado = false`.
- **Consulta:** exibir apenas jogos cujo campo `emprestado` seja `true`, incluindo o nome da pessoa responsável.

A busca auxiliar considera o título como identificador. Caso haja jogos diferentes com o mesmo título, ela encontra apenas o primeiro; títulos únicos evitam essa ambiguidade na implementação atual.

## Exemplo de utilização

1. Cadastre `Minecraft` para `PC` e `God of War` para `PS4`.
2. Abra o submenu e busque por `PC`: o programa deve mostrar `Minecraft`.
3. Empreste `Minecraft` para `Pedro`.
4. Consulte os jogos emprestados: `Minecraft` deve aparecer associado a `Pedro`.
5. Tente emprestar `Minecraft` novamente: a operação deve ser recusada.
6. Devolva `Minecraft` e confira que ele não aparece mais entre os emprestados.

## Persistência de dados

O arquivo `Jogos.txt` pode armazenar, em cada linha, os campos do jogo e do empréstimo separados por `;`:

```text
Minecraft;PC;2011;1;Pedro;2026-11-02;True
```

Para que o estado dos empréstimos seja preservado após reiniciar o programa, **as funções de salvar e carregar precisam incluir os campos de `Emprestimo`**. A versão inicial que gravava apenas os quatro atributos do jogo não preservava os empréstimos.

## Como executar

Com o **SDK do .NET** instalado, no terminal da pasta do `.csproj`:

```bash
dotnet restore
dotnet run
```

Para testar a compilação:

```bash
dotnet build
```

## Conceitos praticados

Composição de classes, listas, busca por índice, reutilização de métodos, `DateTime`, estados booleanos, submenu com `switch` e persistência de dados.
