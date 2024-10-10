# Exercícios

1 - Implemente uma classe chamada “Banco” que represente uma instituição financeira. Essa classe deve conter métodos para cadastrar clientes, abrir contas bancárias e realizar operações como saques, depósitos e transferências via TED e via DOC entre o mesmo banco e bancos diferentes. Preciso conseguir cobrar taxas de transferência com as seguintes regras:
- Transferências com Ted entre contas do banco principal não devem ter cobrança.
- Transferências com Ted para bancos diferentes deve cobrar uma taxa de R$10,00.
- Transferências com DOC devem cobrar uma taxa de R$15,00.

2 - Agora, com o que aprendemos com programação orientada a objetos, vamos melhorar este código estruturando melhor, dividindo as responsabilidades entre mais classes com relacionamentos entre sí.

3 - Crie uma classe PIX, que envia o pix selecionando o tipo de chave cpf, telefone, email e favorito. Crie também uma classe Favorito, que pode adicionar, editar e remover Favoritos, Favorito é um contato para envio de pix que contem uma chave, que pode ser cpf, telefone ou email.
- Transferências com PIX não devem cobrar taxa.