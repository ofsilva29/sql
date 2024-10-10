# Começando pelo básico

## Definições:

Objeto ou classe é a definição de um tipo de algo que representa dados ou ações em orientação a objetos.
A classe encapsula definições, dados e ações, em alto nível objeto ou classe nos ajuda a "modelar o mundo real".
E a classe para ter finalidade é "instanciada".
Juntando tudo, a classe é a definição que quando nasce, passa a ter uma instância daquele objeto.

## Vamos destrinchar então

### Modelar o mundo real, o que isso significa?

Vamos pensar que, para orientação a objetos precisamos trazer, ou traduzir o mundo real em algo que de para programar ou desenvolver um programa para computador.
Isso significa que queremos, com código, representar um problema ou uma coisa que existe.

Vamos materializar um pouco mais.

Um extrato bancário, sabemos o que é, correto? Um documento que representa as operações que fizemos dentro de um período de tempo.

Em resumo, documento é "uma coisa que existe" que representa todos os saques, depósitos ou pagamentos que executamos em uma instituição bancária.

Temos também o Saldo, que é um problema. 
Ou seja, queremos saber dentre todas as operações de entrada e saída, quando temos ainda disponível para movimentar, que é o saldo.

### Encapsular dados e ações

Cada linha de um extrato é uma operação, e cada operação tem uma data, um valor e um sentido, ou seja, quando ocorreu, de quanto foi a movimentação daquela operação e se foi uma retirada ou um depósito de alguma natureza.

Este conjunto de data, valor e sentido é um dado que esta armazenado em algum banco de dados.

Agora quando queremos saber o saldo, precisamos pegar todos os registros de movimentação e somar todas as entradas e saídas considerado o saldo residual do mês anterior.

Esta é uma ação de calcular o saldo.

Estes dados ou ações estão dentro de uma classe que recebe os dados ou executa a ação de cálculo.
Vamos entender que encapsular é este estar dentro da classe, mais para frente vamos detalhar melhor o conceito para ficar mais claro, mas por enquanto esta definição é suficiente.

### E a classe para ter finalidade é "instanciada".

Antes disso, vamos fazer um exercício, como ficaria a representação das classes necessárias para representar um extrato bancário?

[15-20 minutos para pessoal resolver.]

![instancia](../assets/instancia-0.png) 


Bom, agora vamos pensar que este conjunto de classes sejam utilizadas para representar o extrato de Carlos e de Marcos. As classes chamam classes quando estão descritas em código, quando estão vivas, ou seja alocadas em memória são objetos. Cada objeto tem uma instância de classe.

Fazendo o caminho oposto, os objetos de extrato para Carlos e para Marcos tem a mesma instância de classe. Ambas instâncias de classe de Carlos e Marcos compartilham os mesmos conjuntos de atributos, mas são diferentes quanto ao conteúdo destes atributos.

Detalhando um pouco mais, ambos os objetos são do tipo extrato, porém uma instância deste objeto chama Carlos, a outra instância do mesmo objeto chama Marcos.

Definição trazida do Wikipedia:

> Instância é a concretização de uma classe. Em termos intuitivos, uma classe é como um "molde" que gera instâncias de um certo tipo; um objeto é algo que existe fisicamente e que foi "moldado" na classe.

<a href="https://pt.wikipedia.org/wiki/Inst%C3%A2ncia_(ci%C3%AAncia_da_computa%C3%A7%C3%A3o)#:~:text=Em%20programa%C3%A7%C3%A3o%20orientada%20a%20objetos,igualmente%20usada%20da%20mesma%20forma.">Referência Wikipedia sobre instância</a>

Desta forma espero que tenha ficado claro a última frase da definição que é:

**Juntando tudo, a classe é a definição que quando nasce, passa a ter uma instância daquele objeto.**

</br></br></br>
# Dúvidas?