# Composição de classe

Toda classe pode ser composta de um conjunto de informações pré-definidas pela linguagem utilizada.

**Atributos**: Correspondem aos dados ou informações da classe. <br/>
Como vimos anteriormente, na classe extrato existe um atributo chamado nome da pessoa, que vai receber a informação do nome da pessoa que esta requisitando aquele extrato.

```csharp
class Extrato {
    string NomePessoa {get;set;}
}
```

> *Obs.:* Atributo é o nome utilizado para UML e de forma genérica em qualquer representação em qualquer linguagem de programação, já em c# o atributo é chamado de campo, porque atributo é utilizado em outras funcionalidades que serão explicadas mais a frente. Para fins de aprendizagem vamos utilizar atributo.

**Métodos**: Correspondem as ações que a instância do objeto daquela classe podem executar, como no caso do extrato, calcular saldo é um método.

```csharp
class Extrato {
    string NomePessoa {get;set;}

    double CalcularSaldo(){
        // Soma todas as entradas e saídas
        // Valor de retorno usado como exemplo para método.
        return 1000.00;
    }
}
```

**Construtor**: Construtor é o primeiro método a ser chamado durante a instancia de classe, ou seja, quando você pede para a aplicação que a classe de extrato seja instanciada para Carlos, a primeira coisa a ser executada é o método de construção.

> *Obs.:* Em c# quando você não define um construtor, em tempo de compilação será criado um "construtor vazio", que nada mais é do que um método vazio, que não tem função pra executar, mas é chamado na criação da instância da classe.

```csharp
class Extrato {
    
    // Será construído normalmente, em tempo de compilação é criado um construtor vazio
    // public Extrato(){}

    string NomePessoa {get;set;}

    double CalcularSaldo(){
        // Soma todas as entradas e saídas
        // Valor de retorno usado como exemplo para método.
        return 1000.00;
    }
}
```

> *Obs.:* Em c# o método construtor é o método que leva o nome da classe.

```csharp
class Extrato {
    
    public Extrato(string cpf){
        // consulta o cpf da pessoa para inicializar o extrato já de Carlos ou Marcos
    }

    string NomePessoa {get;set;}

    double CalcularSaldo(){
        // Soma todas as entradas e saídas
        // Valor de retorno usado como exemplo para método.
        return 1000.00;
    }
}
```


**Visibilidade**

Visibilidade é como você espera que as informações da sua instância de classe sejam acessados, ou seja, o que você espera proteger e o que e como você espera expor seu objeto para quem esta acessando de fora.

Vamos passar pelas principais visibilidades que vocês irão utilizar.

publico (public): acesso publico significa que o método ou atributo esta acessível para todo mundo que precisar acessar.

privado (private): significa que somente acesso interno a classe é possível, o método ou atributo com visibilidade privada não esta visível nem acessível para quem vem de fora.

protegido (protected): protegido significa que ele mantém o comportamento do privado para quem tenta acessar de fora, porém com uma exceção, quando uma classe herda de outra a classe filha tem acesso aos métodos protegidos da classe pai.

> *Obs.:*  Herança será explicada em detalhes mais para frente.

> *Obs.:* Quando você deixa um método sem visibilidade definida em c#, por padrão a visibilidade é privada, para proteger o acesso a informação.
> *Obs.:* Já os tipos de nível superior como classes, que não estão aninhados em outros tipos, podem ter apenas a acessibilidade internal ou public. A acessibilidade de padrão para esses tipos é internal.

```csharp

public class Extrato {
    private string cpfPessoa {get;set;}
    protected string nomePessoa {get;set;}

    public Extrato(string cpf){
        // consulta o cpf da pessoa para inicializar o extrato já de Carlos ou Marcos
    }

    public double CalcularSaldo(){
        // Soma todas as entradas e saídas
        // Valor de retorno usado como exemplo para método.
        return 1000.00;
    }
}

```

## Curiosidades

Lista de níveis de acesso:

| Acessibilidade | Significado |
|--|--|
| public |	O acesso não é restrito|
| protected |	O acesso é limitado à classe que os contém ou aos tipos derivados da classe que os contém|
| internal |	O acesso é limitado ao assembly atual|
| protected | internal	O acesso é limitado ao assembly atual ou aos tipos derivados da classe que os contém|
| private |	O acesso é limitado ao tipo recipiente|
| private | protected	O acesso é limitado à classe que o contém ou a tipos derivados da classe que o contém no assembly atual|

> Somente um modificador de acesso é permitido para um membro ou tipo, exceto quando você usa as combinações protected internal e private protected.

Lista de níveis de acesso para tipos aninhados:

| Membros de | Acessibilidade de membro Padrão | Acessibilidades permitidas |
|--|--|--|
|enum|	public|	Nenhum|
|--|--|--|
|class|	private|	public|
|||protected|
|||internal|
|||private|
|||protected internal|
|||private protected|
|interface|	public|	public|
|||protected|
|||internal|
|||private*|
|||protected internal|
|||private protected|
|--|--|--|
|struct|	private|	public|
|||internal|
|||private|

> Um membro interface com acessibilidade private deve ter uma implementação padrão.

Antes do exercício em tempo de aula explicar (ATENÇÃO QUE EXPLICAÇÃO NÃO ESTA NA DOCUMENTAÇÃO):

- Camadas de aplicação.
- Modelo anêmico vs modelo rico.
- Diferença entre class e struct (opcional);

## Referências:
https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers </br>
https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/accessibility-levels

## Exercício:

Com base nas classes definidas no arquivo exercício.cs vamos:

1- Instanciar uma classe do tipo Extrato onde o construtor deve receber o cpf, o nome da pessoa, o valor inicial e a lista de movimentações com pelo menos 5 dias de movimentação onde ao menos 1 dos dias tenha mais de uma movimentação.

2- O Nome da pessoa deve ser acessível para consulta, mas não pode ser alterado.

3- Crie a lógica para calcular o saldo.

4- Crie um método novo que deve ter acesso público para devolver uma lista de strings com saldo atualizado diariamente.

Dica: Tentem utilizar o conceito de composição com classes aninhadas para calculo de saldo.