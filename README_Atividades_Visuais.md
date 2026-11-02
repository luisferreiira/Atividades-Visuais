# Atividades Visuais

Este repositório reúne atividades práticas e exercícios de programação desenvolvidos no **Microsoft Visual Studio**, principalmente utilizando **C# e .NET**.

A maior parte dos projetos é voltada ao desenvolvimento de **aplicações visuais com formulários (Windows Forms)**, além de outras atividades realizadas durante os estudos de programação.

## Tecnologias e ferramentas

- **C#**
- **.NET**
- **Microsoft Visual Studio**
- **Windows Forms** (em atividades com interface gráfica)
- **Git e GitHub**

## Como clonar o repositório completo

No terminal, execute:

```bash
git clone https://github.com/luisferreiira/Atividades-Visuais.git
```

Depois, acesse a pasta:

```bash
cd Atividades-Visuais
```

## Como baixar apenas uma pasta específica

Para obter somente uma pasta do repositório, sem baixar os arquivos das demais, utilize o **Git Sparse Checkout**.

**1. Clone o repositório sem fazer o checkout dos arquivos:**

```bash
git clone --filter=blob:none --no-checkout https://github.com/luisferreiira/Atividades-Visuais.git
```

**2. Entre na pasta do repositório:**

```bash
cd Atividades-Visuais
```

**3. Ative o Sparse Checkout e escolha a pasta desejada:**

```bash
git sparse-checkout init --cone
git sparse-checkout set Lista3
```

No exemplo, `Lista3` é a pasta selecionada. Substitua esse nome pelo caminho da pasta que você deseja obter.

**4. Carregue os arquivos da branch principal:**

```bash
git checkout main
```

Agora, os arquivos da pasta escolhida estarão disponíveis localmente. O Git ainda mantém os metadados necessários do repositório; o Sparse Checkout limita os arquivos de trabalho exibidos.

> **Observação:** caso queira selecionar uma subpasta, informe o caminho relativo à raiz do repositório, por exemplo `Lista3/Exercicio1`, se esse caminho existir.

## Como abrir os projetos

Após clonar o repositório ou selecionar a pasta desejada, abra o arquivo de solução (`.sln` ou `.slnx`) ou o arquivo do projeto (`.csproj`) no **Visual Studio**. Em seguida, compile e execute o projeto conforme suas dependências e configurações.

---

**Repositório:** [github.com/luisferreiira/Atividades-Visuais](https://github.com/luisferreiira/Atividades-Visuais)
