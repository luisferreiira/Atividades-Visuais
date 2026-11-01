# Sistema de Cadastro de Bandas

Aplicação desktop acadêmica em C# Windows Forms para gerenciar bandas e gêneros musicais, com persistência em MySQL. Este projeto faz parte do repositório **Atividades-Visuais**.

## Funcionalidades implementadas no código

- **Login:** tela inicial com usuário e senha; a senha é convertida em hash SHA-256 antes da consulta ao banco.
- **Cadastro de bandas:** informa nome, quantidade de integrantes, ranking e gênero musical.
- **Listagem:** exibe as bandas e seus gêneros em uma tabela, ocultando o identificador interno.
- **Busca por nome:** filtra a lista enquanto o usuário digita, procurando nomes que começam com o texto informado.
- **Alteração:** carrega os dados da banda selecionada e permite atualizar nome, integrantes, ranking e gênero.
- **Exclusão:** solicita confirmação antes de remover a banda selecionada e atualiza a listagem.
- **Cadastro de gêneros:** formulário próprio para adicionar gêneros musicais.
- **Navegação:** telas de login e cadastro de gêneros, além de abas para cadastro, busca e alteração de bandas.

As operações dependem das tabelas e stored procedures disponíveis no MySQL. Consulte as pendências do script na seção de configuração do banco.

## Baixar somente este projeto

Com o Git instalado, execute os comandos abaixo no terminal:

```powershell
git clone --filter=blob:none --sparse https://github.com/luisferreiira/Atividades-Visuais.git
cd Atividades-Visuais
git sparse-checkout set SistemaCadastroModelo
cd SistemaCadastroModelo
```

O **sparse checkout** deixa disponíveis a pasta `SistemaCadastroModelo` e os arquivos da raiz do repositório. O filtro `--filter=blob:none` evita baixar antecipadamente o conteúdo dos arquivos dos demais projetos. O vínculo e os metadados do Git continuam sendo do repositório `Atividades-Visuais`.

Para receber atualizações depois, execute dentro da pasta clonada:

```powershell
git pull origin main
```

Se preferir baixar todos os projetos, use o clone convencional:

```powershell
git clone https://github.com/luisferreiira/Atividades-Visuais.git
cd Atividades-Visuais/SistemaCadastroModelo
```

## Tecnologias e requisitos

- Windows para executar a aplicação Windows Forms.
- Visual Studio com a carga de trabalho **Desenvolvimento para desktop com .NET**.
- .NET Framework **4.7.2**, versão definida no projeto, e seu Developer Pack para compilação.
- MySQL 8.0 ou compatível com a collation `utf8mb4_0900_ai_ci` usada no script.
- MySQL Workbench ou outro cliente para configurar o banco.
- ADO.NET e pacote NuGet **MySql.Data 8.1.0**; restaure também as dependências de `packages.config`.

## Configuração e execução

### 1. Preparar o banco de dados

No MySQL Workbench, crie e selecione o banco usado pela aplicação:

```sql
CREATE DATABASE IF NOT EXISTS bandas
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE bandas;
```

Depois, abra e execute `DumpBancoCadastro.sql` nesse banco. O script recria as tabelas `generos` e `bandas`, insere dados de exemplo e cria três procedures. Como contém `DROP TABLE`, use um banco de desenvolvimento sem dados que precise preservar.

| Tabela | Campos |
| --- | --- |
| `generos` | `idgenero`, `genero` |
| `bandas` | `idbandas`, `nome`, `integrantes`, `ranking`, `fk_genero` |

O script inclui os gêneros Rock, Metal, Pagode, Gospel e Funk e as bandas Skank e Metallica.

**Pendências do script fornecido:** o código da aplicação está mais completo que o dump SQL. Para executar todas as funcionalidades, o banco precisa atender aos seguintes contratos:

| Procedure usada pelo código | Situação no dump / requisito |
| --- | --- |
| `sp_insereBanda(nome, integrantes, ranking, genero)` | Incluída. Insere a banda. |
| `sp_listaBandas()` | Incluída, mas precisa retornar também a coluna `integrantes`, lida pela tela de alteração. Deve retornar `idbandas`, `nome`, `integrantes`, `ranking` e `genero`. |
| `sp_listaGeneros()` | Incluída. Retorna os gêneros. |
| `sp_removeBanda(idbanda)` | Não incluída. Necessária para excluir a banda pelo identificador. |
| `sp_alteraBanda(idbanda, nome, genero, integrantes, ranking)` | Não incluída. Necessária para atualizar a banda. |
| `sp_insereGenero(nome)` | Não incluída. Necessária para cadastrar gêneros. |
| `sp_consultaLogin(usuario, senha)` | Não incluída. Deve consultar a estrutura de usuários e retornar ao menos uma linha quando as credenciais forem válidas. A senha recebida é um hash SHA-256 hexadecimal de 64 caracteres. |

O dump também não fornece a estrutura de usuários nem um usuário inicial. Não há credenciais de login de demonstração definidas por esse script. Como a aplicação inicia no login, apenas importar o dump não basta para acessar o sistema.

### 2. Configurar a conexão

Abra `SistemaCadastro/Connection.cs` e ajuste as constantes conforme seu MySQL:

```csharp
public const string SERVER = "localhost";
public const int PORT = 3307; // use a porta do seu servidor, por exemplo 3306
public const string DATABASE = "bandas";
public const string USER = "seu_usuario";
public const string PASSWORD = "sua_senha";
```

A classe `Connection` monta a conexão a partir dessas constantes. Alterar somente o `App.config` não altera a conexão utilizada atualmente.

### 3. Abrir e executar

1. Abra `SistemaCadastro.sln` no Visual Studio.
2. Restaure os pacotes NuGet da solução.
3. Conclua a configuração das tabelas, procedures e usuário de login no MySQL.
4. Compile e pressione **F5** para executar.
5. Entre com um usuário cadastrado no seu banco.

## Como usar

1. Faça login para abrir a tela principal.
2. Na aba de cadastro, preencha nome, integrantes, ranking e gênero e confirme o cadastro.
3. Use o botão de adicionar gênero para abrir o formulário de gêneros, se necessário.
4. Na aba de busca, digite o início do nome para filtrar as bandas.
5. Selecione uma banda na tabela para alterar seus dados ou excluí-la com confirmação.

Os campos de integrantes e ranking são convertidos para números inteiros pelo código. Preencha-os com valores inteiros válidos.

## Estrutura do projeto

```text
SistemaCadastroModelo/
├── README.md
├── DumpBancoCadastro.sql
├── SistemaCadastro.sln
└── SistemaCadastro/
    ├── SistemaCadastro.csproj
    ├── Program.cs                 # Inicializa a tela de login
    ├── FormLogin.cs               # Entrada no sistema
    ├── Sistema.cs                 # Cadastro, busca, alteração e exclusão
    ├── FormAddGenero.cs           # Cadastro de gêneros
    ├── Connection.cs              # Conexão e chamadas às procedures
    ├── Biblioteca.cs              # Geração do hash SHA-256
    ├── Banda.cs                   # Modelo de banda
    ├── App.config
    ├── packages.config
    ├── Properties/
    └── Resources/
```

Os formulários também possuem arquivos `.Designer.cs` e `.resx` com a definição visual e os recursos da interface.

## Finalidade

Projeto acadêmico desenvolvido para fins educacionais no curso de Linguagem I.
