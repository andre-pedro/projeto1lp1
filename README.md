# Wolf and Sheep - Grupo 09

## Autoria:
[Inês Barradas](https://github.com/kiray96) - a21803669
[André Pedro](https://github.com/andre-pedro) - a21701115  

## Repartição de Tarefas
```Inês Barradas:``` 
* Criação e desenvolvimento do tabueiro
* Desenvolvimento da classe Wolf,
* Criação da classe Sheep
* Desenvolvimento do movimento dos agentes, 
* Verificação da condição de vitória,
* Documentação (README).

```André Pedro:```
* Desenvolvimento do tabuleiro,
* Criação e desenvolvimento da classe Wolf
* Criação do Gameloop
* Criação e desenvolvimento do movimento dos agentes, 
* Criação do menu inicial
* Documentação (Fluxograma).


## Repositório 
O repositório do projeto encontra-se [aqui](https://github.com/andre-pedro/projeto1lp1)

## Arquitetura da Solução

### Descrição da Solução
No início começámos por inserir código dentro da classe ``Program`` mas
decidimos que para melhor organização do programa deveríamos separá-lo por
classes. Seguidamente, para uma melhor organização e implementação das mecânicas
 que queríamos usar, começámos a estruturar as classes que precisávamos, sendo 
 estas as classes  ``Render``, ``Direction``, ``Sheep`` e ``Wolf``. Na classe 
 ``Program`` começámos por instanciar o ``Render``, onde se encontra tudo o que
  vai ser impresso na consola.<br>
O ``Render`` contêm o método ``Draw()`` que desenha a nossa grelha de jogo, o
 método ``SetSymbol()`` para definir todos os símbolos utilizados no jogo,
  métodos mais gerais para mostrar texto e o ``MainMenu()``, que é onde começa
   o nosso jogo. <br>

Quanto às entidades, utilizámos como referido anteriormente as classes ``Sheep``
 e ``Wolf`` mas, para melhor organização do movimento criámos também uma 
 enumeração chamada ``Direction`` com todas as direções possíveis. Na classe 
 ``Sheep`` criámos uma propriedade chamada ``Id`` para que posteriormente o 
 jogador possa escolher a ovelha com que quer jogar. O método ``Move()`` para 
 mover o jogador e o método ``ResetMovement()`` caso o movimento seja inválido e
  o jogador tenha que voltar ao mesmo sítio. A classe ``Wolf`` é igual mas tem 
  mais movimentos disponíveis e não possuí a propriedade ``Id`` visto que só 
  existe um.<br>

Organizámos a classe ``GameManager`` criando primeiramente um ``array`` 
bidimensional do tipo ``object`` para que possam ser utilizado nos como grelha 
do jogo com as variadas entidades.
Para inicializar a ``grid``, fazer o spawn das entidades e o iniciar gameloop 
utilizamos o construtor. No método ``GameLoop()`` organizámos o código de 
maneira a que o lobo comece a jogar (usamos um ``bool`` para verificar qual 
deles é a jogar) escolhendo a direção para que quer ir e depois chamamos o 
método ``CheckValidMovement()`` que verifica se o movimento é válido. Caso o 
movimento não seja válido é chamado o método ``ResetMovement()`` e, caso seja 
válido, acontece a ação de movimento. Verificamos se o lobo ganhou com o método 
``CheckWin()`` que basicamente verifica se o lobo chegou à última linha e ganhou
 ou se está encurralado e perde. Depois vem a vez da ovelha jogar que 
 primeiramente chamamos o método ``SelectPlayingSheep()`` para que o jogador 
 possa escolher a ovelha pretendida e depois é escolhido o movimento para então 
 a ovelha jogar. De seguida, passamos novamente para o ``CheckValidMovement()`` 
 ou para o ``ResetMovement()`` e voltamos a chamar o método ``CheckWin()``.


### Fluxograma

![fluxograma](./img/fluxograma.svg)

## Referências
* [Console.ForegroundColor Property](https://docs.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor?view=netframework-4.8)
* [Two-dimensional Arrays, by Daniel Shiffman](https://processing.org/tutorials/2darray/)
* [StackOverflow - Array initialization with default constructor](https://stackoverflow.com/questions/4839470/array-initialization-with-default-constructor) <br>
* [C# Programming Yellow Book](https://static1.squarespace.com/static/5019271be4b0807297e8f404/t/5824ad58f7e0ab31fc216843/1478798685347/CSharp+Book+2016+Rob+Miles+8.2.pdf) <br>
* [The C# Player's Guide](http://starboundsoftware.com/books/c-sharp/CSharpPlayersGuide-Sample.pdf)
