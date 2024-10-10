# O que é polimorfismo?

Polimorfismo é o principio que diz que as classes derivadas são capazes de invocar os métodos da classe pai, mas também podem sobrescrever a assinatura do método da classe pai para o que método possa se comportar de forma diferente.


Vamos pensar um uma classe de extrato, que é utilizado para mostrar o extrato para o titular da conta, tem um método publico que devolve uma lista dados para o extrato recebendo inicio e fim.

```csharp

public class Extrato{

    public List<string> RegistrosDoExtrato(DateTime dataInicio, DateTime dataFim){

        if(!PeriodoEstaValido(dataInicio, dataFim)){
            throw new Exception("Período de consulta inválido");
        }

        // se passou
        return this.ObterDadosExtrato(dataInicio, dataFim);
    }

    protected List<string> ObterDadosExtrato(DateTime           dataInicio, DateTime dataFim){
        // retorna a lista de registros conforme a data de inicio e fim
        return new List<string>();
    }

    private bool PeriodoEstaValido(DateTime dataInicio, DateTime dataFim){
        // verifica se o inicio e fim estão dentro de um mesmo mês

        return true;
    }
}

```

Agora vamos pensar que o gerente também precisa ter uma visão deste extrato, porém o período pode avançar para mais meses para trás, sem restrição de ser o mês selecionado. E agora, como fazemos?

Esta é fácil, só alterar a classe e criar 2 métodos um novo para o gerente.... não, pera ae.

Temos um princípio ou boa prática que chama principio do aberto / fechado.

Ele nos trás o seguinte:

> Entidades de software (classes, módulos, funções, etc) devem estar abertas para para extensão, porém fechadas para modificação.

Isto significa que uma entidade de software que esta em produção deve ter seu comportamento estendido sem modificar seu código fonte.

Então, vamos tentar resolver com polimorfismo?

```csharp

public class Extrato{

    public virtual List<string> RegistrosDoExtrato(DateTime dataInicio, DateTime dataFim){

        if(!PeriodoEstaValido(dataInicio, dataFim)){
            throw new Exception("Período de consulta inválido");
        }

        // se passou
        return this.ObterDadosExtrato(dataInicio, dataFim);
    }

    protected List<string> ObterDadosExtrato(DateTime           dataInicio, DateTime dataFim){
        // retorna a lista de registros conforme a data de inicio e fim
        return new List<string>();
    }

    private bool PeriodoEstaValido(DateTime dataInicio, DateTime dataFim){
        // verifica se o inicio e fim estão dentro de um mesmo mês

        return true;
    }
}

public class ExtratoGerente: Extrato{

    public override List<string> RegistrosDoExtrato(DateTime dataInicio, DateTime dataFim){
        // se passou
        return this.ObterDadosExtrato(dataInicio, dataFim);
    }
}

```

Desta forma você mantém a coerência do tipo extrato, estende o comportamento para que o extrato para gerente consiga resolver o problema de negócio e não altera a entidade que esta em ambiente produtivo funcionando.


----


# Veja mais referências e exemplos 

[Polimorfismo](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/polymorphism)


[Visão geral sobre o polimorfismo](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/polymorphism#polymorphism-overview)


[Ocultar membros da classe base com novos membros](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/object-oriented/polymorphism#hide-base-class-members-with-new-members)

[base (Referência de C#)](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/base#example-2)