# Encapsulamento


Algumas definições:
1. Encapsulamento é o processo de esconder todos os detalhes de um objeto que não contribuem para as suas características essenciais.

2. Encapsulamento é um princípio, utilizado quando se está desenvolvendo a estrutura de um programa, no qual cada componente de um programa deve encapsular ou esconder o seu funcionamento. A interface com cada módulo é definida de forma a revelar o mínimo possível sobre o seu funcionamento interno.

O Encapsulamento corresponde à uma proteção adicional aos dados de um objeto contra modificações impróprias. 

Devemos garantir que modificadores de acesso sejam aplicados adequadamente nas declarações de classes, permitindo visibilidade externa, apenas através de determinados métodos que queiramos. O conceito de encapsulamento está intimamente ligado ao conceito de ocultamento da informação (information hiding).

Vamos mostrar na prática um pouco:

```csharp

public class ContaCorrente{
    public string cpfTitular;
}


class TestClass
{
    static void Main(string[] args)
    {
        var conta = new ContaCorrente();

        conta.cpfTitular = "novo cpf";
    }
}
```

Qual o problema que temos aqui?

Faz sentido uma conta corrente ter um titular, mas faz sentido alterar o documento do titular de uma conta corrente assim, de forma direta?

Entendemos que não, correto? Se for possível alterar um cpf de um titular de conta corrente, deve ser feito de uma forma segura.

Vamos tentar novamente

```csharp

public class ContaCorrente{
    private string _cpfTitular;

    public string GetCpfTitular(){
        return this._cpfTitular;
    }

    public void AlterarCpfTitularConformeRegra(string novoCpfTitular){
        // Regra aplicada
        if(servicoDeValidacao.RegraAplicada()){
            this._cpfTitular = novoCpfTitular;
        }else{
            throw new Exception("Regra de alteração de cpf não satisfeita.");
        }
    }
}


class TestClass
{
    static void Main(string[] args)
    {
        var conta = new ContaCorrente();
        conta.AlterarCpfTitularConformeRegra("novo cpf");
    }
}
```

Desta forma conseguimos proteger o atributo cpf do titular para alterações diretas.

Vamos pensar em outra metáfora para o entendimento:
> Pensaremos em algo colocado em uma capsula mesmo, como um remédio. Você sabe que é um remédio, sabe que esta dentro de uma capsula para sua segurança e a dele e você não sabe como ele funciona. Um remédio serve para resolver ou amenizar um problema de saúde. Logo qualquer remédio para qualquer problema de saúde pode vir protegido em uma capsula.

Ok, tudo entendido?

Mas uma dúvida, isto me parece muito com Abstração que vimos anteriormente.

A abstração, o primeiro pilar, é implementado através de classes, que contém propriedades e métodos, de forma bastante simples. Já o encapsulamento é realizado através de propriedades privadas, auxiliadas por métodos especiais getters e setters.

Simplificando um pouco nosso exemplo para demostração de getters e setters:

```csharp

public class ContaCorrente{
    private DateTime _dataAbertura;

    public string GetDataAbertura(){
        return this._dataAbertura;
    }
    
    public void SetDataAbertura(DateTime value){
        return this._dataAbertura;
    }
}


class TestClass
{
    static void Main(string[] args)
    {
        var conta = new ContaCorrente();
        var dataAbertura = conta.GetDataAbertura();
        conta.SetDataAbertura(DateTime.Now());
    }
}
```

Agora, em c# temos uma forma mais facilitada de fazer isso:

```csharp

public class ContaCorrente{
    public DateTime DataAbertura{
        get
        {
            return this.DataAbertura;
        }
        set
        {
            this.DataAbertura = value;
        }
    }
}

class TestClass
{
    static void Main(string[] args)
    {
        var conta = new ContaCorrente();
        var dataAbertura = conta.DataAbertura;
        conta.DataAbertura = DateTime.Now();
    }
}
```

Da para simplificar um pouco mais ...

```csharp

public class ContaCorrente{
    public DateTime DataAbertura { get; set; }
}

class TestClass
{
    static void Main(string[] args)
    {
        var conta = new ContaCorrente();
        var dataAbertura = conta.DataAbertura;
        conta.DataAbertura = DateTime.Now();
    }
}
```

Bom, nas duas ultimas simplificações, a diferença é que na primeira você ainda consegue validar algo se precisar, como por exemplo:

```csharp

public class ContaCorrente{
    public DateTime DataAbertura{
        get
        {
            return this.DataAbertura;
        }
        set
        {
            if(NaoPodeAlterar()){
                throw new Exception("Não pode alterar a Data da Abertura.")
            }
            this.DataAbertura = value;
        }
    }
}

class TestClass
{
    static void Main(string[] args)
    {
        var conta = new ContaCorrente();
        var dataAbertura = conta.DataAbertura;
        conta.DataAbertura = DateTime.Now();
    }
}
```

E por último mais uma curiosidade, você pode alterar a visibilidade internamente.

```csharp

public class ContaCorrente{
    public DateTime DataAbertura { get; private set; }
}

class TestClass
{
    static void Main(string[] args)
    {
        var conta = new ContaCorrente();
        var dataAbertura = conta.DataAbertura;
        conta.DataAbertura = DateTime.Now(); // Aqui vai dar erro porque não tem acesso.
    }
}
```

