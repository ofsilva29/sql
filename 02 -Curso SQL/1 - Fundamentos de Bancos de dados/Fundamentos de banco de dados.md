# Curso de SQL
Vamos agora abordar o tópico **Fundamentos de Banco de Dados** com uma explicação completa, exemplos práticos e algumas curiosidades. Esse conteúdo pode ser utilizado no seu curso de SQL e NoSQL.

---

## Fundamentos de Banco de Dados

Um banco de dados é uma coleção organizada de dados que pode ser acessada, gerenciada e atualizada. Ele permite que grandes volumes de informações sejam armazenados de forma eficiente e estruturada, facilitando o processo de consulta e manipulação de dados por usuários e aplicativos.

Os bancos de dados são fundamentais para quase todas as aplicações modernas, seja um sistema de e-commerce, uma rede social ou um banco. Eles armazenam desde informações de clientes e produtos até dados complexos de transações financeiras.

### 1. O que é um Banco de Dados?

Um banco de dados é uma estrutura que organiza dados de maneira a facilitar seu uso. Pode-se pensar em um banco de dados como uma coleção de tabelas em que cada uma armazena dados sobre uma entidade específica, como clientes, produtos ou pedidos.

### 2. Tipos de Bancos de Dados

Existem diversos tipos de bancos de dados, cada um otimizado para diferentes cenários de uso. Vamos explorar os principais:

- **Bancos de Dados Relacionais (SQL)**: Utilizam um modelo tabular para organizar dados e permitem a criação de relações entre tabelas. São chamados de "relacionais" porque permitem definir relações lógicas entre os dados armazenados. Exemplos populares de bancos de dados relacionais incluem:
  - **MySQL**
  - **PostgreSQL**
  - **Oracle Database**
  - **SQL Server**

> **Curiosidade**: O termo "relacional" nos bancos de dados relacionais refere-se à álgebra relacional, um conjunto de operações matemáticas que podem ser aplicadas às tabelas.

- **Bancos de Dados NoSQL**: Esses bancos de dados foram desenvolvidos para lidar com grandes volumes de dados distribuídos e não utilizam esquemas rígidos. NoSQL significa "Not Only SQL", e esse modelo inclui várias arquiteturas, como:
  - **Chave-Valor** (ex.: Redis)
  - **Documentos** (ex.: MongoDB)
  - **Colunas** (ex.: Cassandra)
  - **Grafos** (ex.: Neo4j)

#### Comparação entre SQL e NoSQL

| Característica            | SQL                                     | NoSQL                                  |
|---------------------------|-----------------------------------------|----------------------------------------|
| Estrutura                  | Esquemático (tabelas e colunas)         | Esquema flexível                       |
| Relacionamento             | Relacionamentos definidos (chaves)      | Pode ou não ter relacionamentos        |
| Escalabilidade             | Vertical (mais poder de máquina)        | Horizontal (mais servidores)           |
| Consistência               | Alta (ACID)                             | Pode priorizar disponibilidade         |
| Linguagem de Consulta      | SQL                                     | Depende do banco, algumas usam APIs    |

![acid](../assets/acid.png) 


> **Curiosidade**: O termo "NoSQL" foi criado em 1998 para descrever um banco de dados simples, mas o movimento como o conhecemos hoje começou por volta de 2009, impulsionado pelas necessidades de escalabilidade em grandes sistemas da web.

### 3. Componentes de um Banco de Dados

Os bancos de dados são compostos por diversos elementos que facilitam a sua operação e manutenção. Os componentes básicos incluem:

- **Tabelas**: Estruturas fundamentais em bancos de dados relacionais, que contêm linhas e colunas. Cada tabela representa uma entidade, e cada linha (ou registro) representa uma instância dessa entidade.
  
  Exemplo de uma tabela de **Clientes**:
  
  | ClienteID | Nome         | Telefone       |
  |-----------|--------------|----------------|
  | 1         | Rory Fry   | 9999-9999      |
  | 2         | Amari Black  | 8888-8888      |

- **Registros (Linhas)**: Cada linha de uma tabela é um registro. No exemplo acima, o registro do cliente "Rory Fry" é uma linha na tabela "Clientes".
  
- **Campos (Colunas)**: Cada coluna de uma tabela armazena um atributo específico da entidade. No exemplo acima, "Nome" e "Telefone" são colunas da tabela "Clientes".
  
- **Chaves Primárias**: São identificadores únicos para cada registro em uma tabela. No exemplo, "ClienteID" é a chave primária que identifica de forma única cada cliente.
  
- **Chaves Estrangeiras**: São usadas para definir relações entre tabelas. Uma chave estrangeira em uma tabela aponta para uma chave primária em outra, ligando dados entre diferentes entidades.

- **Índices**: Servem para otimizar a velocidade das consultas em grandes volumes de dados. Eles funcionam como um índice de um livro, facilitando o acesso a informações específicas.

### 4. Operações em Bancos de Dados (CRUD)

As quatro operações básicas realizadas em bancos de dados são referidas como operações **CRUD**:

- **Create (Criar)**: Inserção de novos dados no banco.
  ```sql
  INSERT INTO Clientes (ClienteID, Nome, Telefone) VALUES (1, 'Rory Fry', '9999-9999');
  ```
- **Read (Ler)**: Consulta de dados existentes.
  ```sql
  SELECT * FROM Clientes;
  ```
- **Update (Atualizar)**: Modificação de dados existentes.
  ```sql
  UPDATE Clientes SET Telefone = '7777-7777' WHERE ClienteID = 1;
  ```
- **Delete (Deletar)**: Exclusão de dados.
  ```sql
  DELETE FROM Clientes WHERE ClienteID = 1;
  ```

> **Curiosidade**: O termo CRUD é amplamente utilizado em todos os sistemas de gerenciamento de banco de dados e também em APIs que interagem com dados.


### 5. Transações e Propriedades ACID

Uma transação é um conjunto de operações que são executadas como uma única unidade. As propriedades **ACID** garantem que as transações sejam processadas de forma confiável:

- **Atomicidade (A)**: Todas as operações de uma transação são completadas com sucesso ou nenhuma delas é.
- **Consistência (C)**: A transação leva o banco de dados de um estado consistente a outro estado consistente.
- **Isolamento (I)**: As transações são executadas de forma independente, sem interferência de outras.
- **Durabilidade (D)**: Uma vez que uma transação é confirmada, as alterações são permanentes, mesmo em caso de falha de sistema.

> **Curiosidade**: Os sistemas de banco de dados distribuídos modernos, como o Google Spanner, conseguem fornecer propriedades ACID em escala global, algo que era considerado impossível há algumas décadas.

### 5. Banco de Dados Distribuídos

Em um banco de dados distribuído, os dados são armazenados em vários locais físicos diferentes, mas parecem ser uma única unidade lógica. Isso é comum em grandes sistemas que precisam de alta disponibilidade e escalabilidade.

Bancos de dados distribuídos utilizam técnicas como **replicação** e **sharding**:

- **Replicação**: Copiar dados para vários servidores para aumentar a disponibilidade e a tolerância a falhas.
- **Sharding**: Dividir os dados entre diferentes servidores, o que melhora o desempenho ao reduzir a carga em cada servidor.
