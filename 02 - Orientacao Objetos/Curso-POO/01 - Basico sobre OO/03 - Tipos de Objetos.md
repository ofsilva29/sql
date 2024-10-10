# Mas o que seriam tipos de objetos / classes.

Vamos abordar brevemente uma parte do conteúdo que será necessária mais para frente, de forma simples apenas para o entendimento das diferenças.

## Classe

Bom, a primeira é a classe mesmo, já temos exemplos do que é, é uma definição de algo do mundo real em código, esta classe pode ser instanciada para se tornar um objeto em uso pela aplicação.

Apenas um breve resumo do que já vimos porque sim, classe é um dos tipos de classes.

## Classe Abstrata

A classe abstrata é uma classe que não pode ser instanciada diretamente.
Ela tem por objetivo representar algo do mundo real também, porém como um tipo mais genérico ou padronizado que para ser usada deve receber uma classe filha, que herda dela, e esta classe filha poderá ser instanciada.

Também um breve resumo, nos aprofundaremos mais para frente.

## Interfaces

Interfaces, diferente das classes abstratas não são classes, mas sim um tipo de contrato.
Funciona muito semelhante ao uso das classes abstratas, porém em classes abstratas você pode eventualmente ter alguma implementação.
Já em interfaces você deve ter apenas a definição.

Exemplificando, uma classe abstrata pode ter um método que faz alguma coisa, a classe filha da classe abstrata pode fazer uso deste método ou pode sobrescrever ele. Já na interface temos apenas uma declaração que significa o seguinte: "Meu amigo, vamos fazer um acordo, você precisa ao implementar a minha interface, de um método que faz isso, retorna aquilo, recebe X parâmetros."

O importante aqui é entender a diferença, mais para frente com o uso naturalmente estes conceitos irão ficar mais claros.
</br></br></br>
## Curiosidades

***Linguagens dinâmicas tendem a não ter o conceito de classe abstrata.***