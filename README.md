# DesafioBank
 Estudando desafio de um bank digital

 ---
* Program Class:
  
Define a classe Program com o método Main como ponto de entrada do programa.

Cria instâncias de UsuarioComum e Lojista para testar as funcionalidades do sistema.

Realiza testes de transferência de dinheiro entre usuários e para lojistas, considerando diferentes cenários.

* Lojista Class:
  
Define uma classe Lojista que herda da classe UsuarioComum. 

Significa que os lojistas têm todas as propriedades e métodos de UsuarioComum e podem adicionar comportamentos específicos se necessário.

* EnviarNotificacao Method:
  
Método privado assíncrono que simula o envio de notificação para um usuário.

Utiliza HttpClient para fazer uma requisição à URL fornecida no mock.

* AutorizadorExterno Method:
  
Método privado assíncrono que consulta um serviço externo para autorização.

Utiliza HttpClient para fazer uma requisição à URL fornecida no mock.

* TransferirDinheiro Method:
  
Um método assíncrono que permite transferir dinheiro de um usuário para outro.

Realiza verificações de saldo, autorização externa e, em seguida, realiza a transferência.

Utiliza métodos privados AutorizadorExterno e EnviarNotificacao para lógica específica.

* UsuarioComum Class:
  
Define uma classe chamada UsuarioComum para representar os usuários no sistema.

Possui propriedades como NomeCompleto, CPF, Email, Senha e Saldo para armazenar informações sobre o usuário.

* Imports:
  
using System;: Importa o namespace System, que contém tipos fundamentais e funcionalidades básicas do C#.

using System.Net.Http;: Importa o namespace System.Net.Http, que fornece classes para interagir com serviços HTTP.
