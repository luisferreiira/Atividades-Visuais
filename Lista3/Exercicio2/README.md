# Exercício 2 — Controle de Energia

Aplicação de console em **C#** para registrar eletrodomésticos e estimar seu consumo de energia elétrica, considerando potência, tempo médio de utilização e tarifa por quilowatt-hora.

## Funcionalidades

- Cadastrar eletrodomésticos.
- Listar os aparelhos cadastrados.
- Buscar um aparelho pelo nome.
- Identificar aparelhos cujo consumo diário ultrapassa um valor informado.
- Calcular o consumo total **diário** e **mensal**, em kWh.
- Estimar os custos diário e mensal em reais a partir da tarifa informada.
- Salvar e carregar os dados em arquivo `.txt`.

## Estrutura de dados

A classe `Eletrodomestico` possui:

| Atributo | Tipo | Descrição |
|---|---|---|
| `nome` | `string` | Nome do aparelho |
| `potencia` | `double` | Potência em kW |
| `tempoMedioAtivoPorDia` | `double` | Tempo médio de uso por dia, em horas |

Os objetos são armazenados em `List<Eletrodomestico>`.

## Cálculos utilizados

O consumo de um aparelho é calculado por:

```text
Consumo diário (kWh) = potência (kW) × horas de uso por dia
```

Para os totais da residência:

```text
Consumo diário total = soma dos consumos diários dos aparelhos
Consumo mensal total = consumo diário total × 30
Custo diário = consumo diário total × tarifa (R$/kWh)
Custo mensal = consumo mensal total × tarifa (R$/kWh)
```

O cálculo mensal considera **30 dias** e um padrão de uso diário constante. Trata-se de uma estimativa, não de uma medição real da conta de energia.

## Organização do programa

O menu reúne as opções de adicionar, listar, buscar por nome, buscar por consumo, calcular totais, carregar dados e salvar ao sair.

Os principais métodos são `adicionarEletrodomestico()`, a função de listagem, `buscarEletrodomesticoPorNome()`, `buscarEletromesticoPorConsumoKw()`, `calcularConsumo()`, `salvarDados()` e `carregarDados()`.

## Exemplo de utilização

Cadastre os aparelhos abaixo:

| Aparelho | Potência | Uso diário | Consumo diário |
|---|---:|---:|---:|
| Geladeira | 0,15 kW | 24 h | 3,60 kWh |
| Televisão | 0,10 kW | 5 h | 0,50 kWh |
| Ventilador | 0,08 kW | 8 h | 0,64 kWh |

Com uma tarifa de **R$ 0,90/kWh**, o resultado esperado é:

- Consumo diário total: **4,74 kWh**.
- Consumo mensal estimado: **142,20 kWh**.
- Custo diário estimado: **R$ 4,27** (arredondado).
- Custo mensal estimado: **R$ 127,98**.

Uma busca por consumo diário acima de `2 kWh` deve encontrar a geladeira.

## Persistência de dados

Os registros são salvos em um arquivo de texto e podem ser carregados em outra execução. Na versão discutida, o separador recomendado foi `;`, para evitar conflito com a vírgula decimal usada no Brasil.

## Como executar

Com o **SDK do .NET** instalado, abra um terminal na pasta do `.csproj` e execute:

```bash
dotnet restore
dotnet run
```

Para compilar sem iniciar:

```bash
dotnet build
```

## Conceitos praticados

Classes, listas, entrada de dados, buscas, `double`, cálculos aritméticos, condicionais, menus com `switch` e persistência em TXT.
