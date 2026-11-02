# Exercício 5 — Controle de Fazenda de Gado

Aplicação de console em **C#** para cadastrar animais de uma fazenda, calcular totais semanais de produção e consumo e identificar automaticamente quais animais atendem aos critérios de abate estabelecidos no exercício.

## Funcionalidades

- Cadastrar animais com código, produção de leite, consumo de alimento e mês/ano de nascimento.
- Calcular automaticamente a situação de abate de cada animal.
- Listar todos os animais cadastrados.
- Calcular o total de leite produzido por semana na fazenda.
- Calcular o total de alimento consumido por semana.
- Listar os animais classificados para abate.
- Salvar e carregar os registros em arquivo `.txt`.
- Encerrar o programa pelo menu.

## Estrutura de dados

### Classe `Gado`

| Atributo | Tipo | Descrição |
|---|---|---|
| `codigo` | `int` | Identificador do animal |
| `leite` | `double` | Litros de leite por semana |
| `alim` | `double` | Quilogramas de alimento por semana |
| `nasc` | `Nascimento` | Objeto com mês e ano de nascimento |
| `abate` | `bool` | `true` = S; `false` = N |

### Classe `Nascimento`

| Atributo | Tipo | Descrição |
|---|---|---|
| `mes` | `int` | Mês de nascimento |
| `ano` | `int` | Ano de nascimento |

Os registros são mantidos em `List<Gado>`. A composição entre `Gado` e `Nascimento` permite acessar `g.nasc.mes` e `g.nasc.ano`.

## Regras de classificação para abate

O animal é classificado para abate se atender a **pelo menos uma** destas condições:

- Ter **mais de 5 anos** de idade; **ou**
- Produzir **menos de 40 litros** de leite por semana.

A condição em C# é:

```csharp
if (idade > 5 || g.leite < 40)
```

A função `verificarAbate()` calcula a idade considerando o mês e o ano de nascimento e a data atual. Como não há dia de nascimento, a idade muda no mês de aniversário. A função `atualizarAbates()` reaplica a regra aos animais cadastrados, inclusive antes de listar e salvar.

## Menu e principais métodos

O menu reúne cadastro, listagem de todos os animais, cálculo do leite total, cálculo do alimento total, listagem para abate, carregamento de dados e opção de salvar e sair.

Principais métodos:

- `adicionarGado()`: cadastra um animal e calcula sua situação de abate.
- `verificarAbate()`: aplica as condições de idade e produção.
- `atualizarAbates()`: atualiza a classificação da lista.
- `calcularTotalLeite()`: soma os litros de leite produzidos semanalmente.
- `calcularTotalAlimento()`: soma os quilogramas de alimento consumidos semanalmente.
- `mostrarGadosParaAbate()`: exibe somente os animais classificados para abate.
- `mostrarGados()`: exibe todos os registros.
- `salvarDados()` e `carregarDados()`: realizam a persistência.

## Exemplo de utilização

Considere os seguintes animais, usando a data de referência **02/11/2026**:

| Código | Leite/semana | Alimento/semana | Nascimento | Abate? |
|---|---:|---:|---|---|
| 101 | 60 L | 120 kg | 03/2023 | N |
| 102 | 30 L | 100 kg | 06/2024 | S — leite abaixo de 40 L |
| 103 | 70 L | 150 kg | 01/2018 | S — mais de 5 anos |

Resultados esperados:

```text
Leite total por semana: 160,00 litros
Alimento total por semana: 370,00 kg
Animais para abate: 102 e 103
```

A classificação depende da data em que o programa for executado; por isso, a tabela informa a data de referência.

## Persistência de dados

Os registros são salvos em `Gados.txt`, separados por `;`:

```text
101;60;120;3;2023;False
102;30;100;6;2024;True
103;70;150;1;2018;True
```

Ao carregar, o programa lê os dados e **recalcula a classificação de abate** com base na data atual. O arquivo pode conter a situação gravada anteriormente, mas a regra é reaplicada.

## Como executar

Com o **SDK do .NET** instalado, entre na pasta do `.csproj` e execute:

```bash
dotnet restore
dotnet run
```

Para conferir a compilação:

```bash
dotnet build
```

## Conceitos praticados

Classes compostas, listas, `DateTime`, operadores lógicos (`||`), cálculo de idade, acumulação com `foreach`, filtros, menus com `switch` e leitura/escrita em arquivos TXT.
