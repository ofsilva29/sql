# Implementando Abstração

## Classes Abstratas

Classes abstratas são classes que não devem ser implementadas, mas apenas suas filhas.
Classes abstratas podem conter métodos com implementação e métodos abstratos onde apenas existe uma assinatura que será de implementação obrigatória na classe filha.

Exemplo:

```csharp

public abstract class AbstractPix{

    protected string _pessoaEnviadora;
    protected string _pessoaRecebedora;
    protected double _valorOperacao;

    public virtual void ExecutaPix(string pessoaEnviadora, string pessoaRecebedora, double valor){
        this.Validaoperacao();

        // executa a operação de transferência
    }

    public abstract void ValidarOperacao()

}
```

Temos um exemplo muito simplificado e pouco real de uma classe abstrata para executar uma operação de pix.
Mas como ela é abstrata, não pode ser instanciada diretamente, precisamos implementar uma classe filha para poder executar a operação.

```csharp
public class PixPF : AbstractPix{

    public void ValidarOperacao(){
        if(!SolicitanteTemSaldo()){
            throw new Exception("Sem saldo suficiente para operação");
        }
    }

    private void SolicitanteTemSaldo(){

        var servicoDeCalculoDeSaldo = new ServicoDeCalculoDeSaldo();

        if(servicoDeCalculoDeSaldo.TemSaldo(this._pessoaEnviadora))
            return true;
        
        return false;
    }
}
```

Instanciando para uso ficaria assim:

```csharp

class TestClass
{
    static void Main(string[] args)
    {
        AbstractPix operacaoPix = new PixPF();

        operacaoPix.ExecutaPix("cpf do enviador", "cpf do recebedor", 100.00);
    }
}
```

Até aqui tudo ok?

Mas pergunta, porque eu preciso de uma classe abstrata se eu posso ter toda esta execução dentro da classe PixPF???

Bom primeiramente este exemplo é básico para fins de aprendizado sem se preocupar com boas práticas avançadas ou veracidade, porém conseguimos comprovar criando uma nova regra para envio de pix de CNPJ por exemplo:


```csharp
public class PixPJ : AbstractPix{

    public override void ExecutaPix(string pessoaEnviadora, string pessoaRecebedora, double valor){
        base.ExecutaPix(pessoaEnviadora, pessoaRecebedora, valor)
    }

    public void ValidarOperacao(){
        if(!ValorEstaDentroDoLimiteDiario()){
            throw new Exception("Limite diário para Pix foi excedido");
        }
        if(!SolicitanteTemSaldo()){
            throw new Exception("Sem saldo suficiente para operação");
        }
    }

    private void ValorEstaDentroDoLimiteDiario(){
        var servicoDeCalculoDeLimite = new ServicoDeCalculoDeLimite();

        if(servicoDeCalculoDeLimite.TemLimiteDisponivel(this._pessoaEnviadora, this._valorOperacao)){
            return true;
        }
        
        return false;
    }

    private void SolicitanteTemSaldo(){

        var servicoDeCalculoDeSaldo = new ServicoDeCalculoDeSaldo();

        if(servicoDeCalculoDeSaldo.TemSaldo(this._pessoaEnviadora)){
            return true;
        }
        
        return false;
    }
}
```

A implementação se da da mesma forma que no PF.

```csharp
class TestClass
{
    static void Main(string[] args)
    {
        AbstractPix operacaoPix = new PixPJ();

        operacaoPix.ExecutaPix("CNPJ do enviador", "CNPJ do recebedor", 100.00);
    }
}
```

Como pode ser visto, tanto no caso do PF quando no caso do PJ, ambos utilizam o método da classe pai, abstrata, para execução da operação do pix.

Podemos desta forma exemplificar um uso prático para classes abstratas, ao invés de repetir a mesma implementação duas vezes em duas classe, optamos por encapsular o código repetido e programar nas classes especificas apenas o que é especifico.

Bem como também conseguimos mostrar nos exemplos o que queremos com a abstração.

Independente de ser PF ou ser PJ, quem utiliza de fato conhece apenas o que precisa, que neste caso é o método de executar o pix, o que valida, quais são os requisitos, o que é logado, como vai para o extrato, etc, nada disso importa para quem esta querendo apenas executar o pix.


---
</br></br>

# Interfaces

Interfaces não são classes, logo assim como classes abstratas não podem ser instanciadas. Mas mais do que isso ela não tem implementação.
Ela não é uma classe é uma especie de contrato, um acordo. Diferente de uma classe abstrata que é herdada, ou seja, ela recebe uma extensão a interface é implementada.

Vamos tentar utilizar o mesmo exemplo mas com interfaces:

```csharp

public interface IPix{

    void ExecutaPix(string pessoaEnviadora, string pessoaRecebedora, double valor);

    void ValidarOperacao();

}
```

Diferente da classe abstrata, a interface não tem implementação.
Nota-se que não tem visibilidade, quando se trata de interface todo método deve ser implementado de forma pública.


```csharp
public class PixPF : IPix{

    public void ExecutaPix(string pessoaEnviadora, string pessoaRecebedora, double valor){
        this.Validaoperacao();

        // executa a operação de transferência
    }

    public void ValidarOperacao(){
        if(!SolicitanteTemSaldo()){
            throw new Exception("Sem saldo suficiente para operação");
        }
    }

    private void SolicitanteTemSaldo(){

        var servicoDeCalculoDeSaldo = new ServicoDeCalculoDeSaldo();

        if(servicoDeCalculoDeSaldo.TemSaldo(this._pessoaEnviadora))
            return true;
        
        return false;
    }
}
```

O uso se da desta maneira:

```csharp
class TestClass
{
    static void Main(string[] args)
    {
        IPix operacaoPix = new PixPF();

        operacaoPix.ExecutaPix("CNPJ do enviador", "CNPJ do recebedor", 100.00);
    }
}
```

De uma forma diferente a interface também abstrai os detalhes, pois não vai interessar se a implementação se dará por PF ou PJ, enquanto o objeto for do tipo da interface, quem acessa de fora tem acesso apenas aos métodos que a interface expõe.

Assim encerramos a parte de abstração, conforme vocês forem utilizando interfaces e classes abstratas para resolver os problemas do mundo real, mais claro vai ficar quando utilizar cada uma delas.

# Curiosidades

Cada linguagem de programação tem a sua forma de extender e implementar.

Em Java:
```java
public class NomeClasse extends ClasseHerdada implements InterfaceImplementada{

}
```

Em c#:

```csharp
public class NomeClasse : ClasseHerdada, InterfaceImplementada{

}

```

Embora aparentemente seja mais simples em c#, devemos cuidar com a ordem, sempre classe herdada primeiro.


```csharp
// Exemplo com herança de classe
public class NomeClasse : ClasseHerdada{

}

// Exemplo com implementação de interfaces
public class NomeClasse : InterfaceImplementada{

}

// Exemplo com herança e implementação de mais de uma interface
public class NomeClasse : ClasseHerdada, InterfaceImplementada, InterfaceImplementada2{

}
```

---
</br></br>

# Curiosidades 2 

Pouquíssimas linguagens permitem uma coisa chamada herança múltipla, que é quando você pode ter uma classe filha herdando de mais de uma classe pai.
Em c# isso não é possível, você pode herdar apenas de uma classe, mas pode implementar muitas interfaces.

## Antes do exercício
Passar evolução de interfaces

--- 
Exercício no papel:

Vamos desenhar com o que aprendemos até agora uma estrutura de consulta de extratos.

Mas queremos ver em separados os extratos da conta, da poupança e dos investimentos.

Para investimentos e poupança precisamos verificar se o usuário possui o tipo de investimento antes de buscar qualquer informação.

Extrato deve considerar apenas o mês vigente, enquanto poupança sempre os últimos 30 dias do dia atual, e investimentos deve trazer o período de um ano.