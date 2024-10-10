### Boas Práticas para Consultas de Dados em Estruturas Relacionais

Ao trabalhar com bancos de dados relacionais, seguir boas práticas nas consultas SQL é essencial para garantir eficiência, legibilidade e manutenção do código. Aqui estão algumas recomendações:

---

### 1. **Use Nomes Descritivos para Tabelas e Colunas**

- **Clareza**: Os nomes devem refletir o conteúdo da tabela ou da coluna. Por exemplo, use `EXTRATO` em vez de `T1` ou `dados1`.
- **Consistência**: Mantenha um padrão de nomenclatura (camelCase, snake_case, etc.) em todo o banco de dados.

### 2. **Selecione Apenas as Colunas Necessárias**

- **Performance**: Em vez de usar `SELECT *`, especifique apenas as colunas necessárias na consulta. Isso reduz a quantidade de dados transferidos e melhora o desempenho.

```sql
SELECT NUMEROCONTA, NOMETITULAR FROM EXTRATO;
```

### 3. **Utilize Filtragem Adequada com WHERE**

- **Eficiência**: Use a cláusula `WHERE` para filtrar registros desnecessários. Isso não só melhora a performance, mas também torna os resultados mais relevantes.

```sql
SELECT * FROM REGISTRO WHERE VALOR > 1000;
```

### 4. **Evite Funções em Colunas da Cláusula WHERE**

- **Performance**: Quando possível, evite aplicar funções nas colunas da cláusula `WHERE`, pois isso pode impedir o uso de índices.

```sql
-- Evite isso
SELECT * FROM REGISTRO WHERE YEAR(DATA) = 2024;

-- Prefira
SELECT * FROM REGISTRO WHERE DATA >= '2024-01-01' AND DATA < '2025-01-01';
```

### 5. **Use JOINs de Forma Eficiente**

- **Relacionamentos**: Ao usar `JOIN`, especifique o tipo de junção (INNER, LEFT, RIGHT, etc.) e sempre forneça condições de junção claras.

```sql
SELECT E.NOMETITULAR, R.VALOR
FROM EXTRATO E
JOIN REGISTRO R ON E.ID = R.EXTRATOID;
```

### 6. **Use Alias para Tabelas e Colunas**

- **Legibilidade**: Use aliases (`AS`) para tornar a consulta mais legível, especialmente em consultas complexas.

```sql
SELECT E.NUMEROCONTA AS Conta, R.VALOR AS Montante
FROM EXTRATO E
JOIN REGISTRO R ON E.ID = R.EXTRATOID;
```

### 7. **Documente Suas Consultas**

- **Comentários**: Use comentários para explicar partes complexas da consulta. Isso ajuda na manutenção futura e na compreensão por outros desenvolvedores.

```sql
-- Seleciona os titulares com movimentações acima de 1000
SELECT NOMETITULAR
FROM EXTRATO E
JOIN REGISTRO R ON E.ID = R.EXTRATOID
WHERE R.VALOR > 1000;
```

### 8. **Limite Resultados com LIMIT ou TOP**

- **Desempenho**: Ao trabalhar com grandes conjuntos de dados, utilize `LIMIT` (MySQL, PostgreSQL) ou `TOP` (SQL Server) para limitar o número de resultados retornados, especialmente em situações de teste.

```sql
SELECT * FROM REGISTRO LIMIT 10;
```

### 9. **Teste e Otimize Consultas**

- **Análise de Performance**: Utilize ferramentas de análise de consultas (como `EXPLAIN` no MySQL/PostgreSQL) para entender como a consulta é executada e identifique gargalos.

```sql
EXPLAIN SELECT NOMETITULAR FROM EXTRATO;
```

### 10. **Use Transações Quando Necessário**

- **Consistência**: Utilize transações para garantir a consistência dos dados em operações que envolvem múltiplas instruções SQL. Isso garante que todas as operações sejam executadas com sucesso ou que nenhuma delas seja aplicada.

```sql
BEGIN TRANSACTION;
INSERT INTO EXTRATO (NUMEROCONTA, NOMETITULAR) VALUES (915201, 'Rory Fry');
UPDATE REGISTRO SET VALOR = VALOR + 100 WHERE EXTRATOID = 1;
COMMIT;
```

### 11. **Evite Subconsultas Desnecessárias**

- **Performance**: Sempre que possível, substitua subconsultas por junções, pois as junções tendem a ter melhor desempenho.

```sql
-- Evite isso
SELECT * FROM EXTRATO WHERE ID IN (SELECT EXTRATOID FROM REGISTRO WHERE VALOR > 1000);

-- Prefira
SELECT E.*
FROM EXTRATO E
JOIN REGISTRO R ON E.ID = R.EXTRATOID
WHERE R.VALOR > 1000;
```

### 12. **Utilize Índices Apropriadamente**

- **Desempenho**: Crie índices em colunas frequentemente usadas em `WHERE`, `JOIN`, e `ORDER BY`. No entanto, evite sobrecarregar o banco de dados com muitos índices, pois isso pode afetar a performance de inserções e atualizações.

```sql
CREATE INDEX idx_numero_conta ON EXTRATO(NUMEROCONTA);
```

### 13. **Manutenção Regular do Banco de Dados**

- **Rotina de Manutenção**: Realize rotinas de manutenção, como reorganização de índices e análise de estatísticas, para garantir que o banco de dados opere de maneira eficiente.

### 14. **Cuidado com Consultas Dinâmicas**

- **Segurança**: Ao usar consultas dinâmicas, utilize **prepared statements** para evitar injeções SQL.

```sql
-- Usando prepared statement
PREPARE stmt FROM 'SELECT * FROM EXTRATO WHERE NUMEROCONTA = ?';
SET @numConta = '915201';
EXECUTE stmt USING @numConta;
```

---