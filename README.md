# Projeto desenvolvido para o processo seletivo Itau Unibanco

O projeto visa a criação de uma arquitetura limpa, e construida com o objetivo de facilitar manutenção e adição de funcionalidades.

Foi escolhido o Docker como ferramenta para criação de conteiners, criando assim um ambiente com microserviços rodando de forma separada.

Para rodar a aplicação é necessário possuir o docker instalado e configurado, de acordo com cada sistema operacional, em seguida é necessário ir até a pasta A4S.CaseItau e abrir o terminal de sua preferência, e assim rodar o comando "docker-compose up --build", as imagens serão baixadas automaticamente e os conteiners gerados, com suas respectivas configurações.

O projeto possui 7 containers:

### case-itau-server 

Banco de dados SQL Server 2017, utilizado para gerir os bancos de dados para CatApi, e a TwitterApi. Possui dois bancos de dados case_itau_cat_bd e case_itau_twitter_bd.

### graylog

Serviço para a centralização de Log de Erro, as duas api citadas sempre que uma exceção é gerada dispara log para está ferramenta de forma independente.

Determinados prints foram tirados com erros que ocorreram no desenvolvimento da api, e foram coletados por meio do graylog:

![Handler Erro](https://github.com/PFLOA/CaseItau/blob/main/img/HandlerError.png)
![Context Erro](https://github.com/PFLOA/CaseItau/blob/main/img/LogErrorGeral.png)
![Command Erro](https://github.com/PFLOA/CaseItau/blob/main/img/LogPrint.png)

### prometheus

Serviço que faz a captação de metricas geradas pelas api, por meio do endpoint /metrics.

Determinados prints foram tirados de 3 Gráficos, que mostrem em tempo real a quantidade de execução, a latência e quantidade de erros das api criadas.

Através de outra ferramenta chamada Grafana, foram possíveis coletar informações e criar dois Dashboard:

CatApi Métricas:

![Print](https://github.com/PFLOA/CaseItau/blob/main/img/CatApiMetrics.png)

TwitterApi Métricas:

![Print](https://github.com/PFLOA/CaseItau/blob/main/img/TwitterApiMetrics.png)

### case-itau-twitter-api

#### Objetivo

Serviço desenvolvido com o objetivo de coletar informações de postagens do twitter, através da API fornecida pela Rede Social Twitter. As postagens foram coletadas baseando-se em hashtags fornecidas (#opentracing, #remediation, #devops, #sre, #microservices, #observability, #oauth, #metrics, #logmonitoring, #opentracing), foram coletadas centenas de postagens para a retirada de determinadas informações e métricas, . A documentação de cada endpoint está do documenter do postman [**Documenter**](https://documenter.getpostman.com/view/11862082/2s847BUbVz).

Os seguintes requisitos foram alcançados:

- Quais são os cinco usuários da amostra coletada, que possuem mais seguidores.
- Qual o total de postagens, agrupadas por hora do dia, independentemente da hashtag.
- Qual o total de postagens pada cada uma das hashtags por idioma/pais do usuário que postou.  

### case-itau-cat-api

Com o objetivo de coletar informações de Raças de Gatos e Imagens, a Api [https://api.thecatapi.com/](https://api.thecatapi.com/) , possui vasto repositório de raças e imagens de gatos. A documentação de cada endpoint está do documenter do postman **[Documenter](https://documenter.getpostman.com/view/11862082/2s847BVGTs)**.

Os seguintes requisitos foram alcançados:

- Para cada uma das raças de gatos disponíveis, armazenar as informações de origem, temperamento e descrição em uma base de dados.
- Para cada uma das raças acima, salvar o endereço de 3 imagens em uma base de dados.
- Salvar o endereço de 3 imagens de gatos com chapéu.
- Salvar o endereço de 3 imagens de gatos com óculos.
- Api capaz de listar todas as raças.
- Api capaz de listar todas as informações de uma raça.
- Api capaz de a partir de um temperamento listar as raças.
- Api capaz de a partir de uma origem listar as raças.

### Para ambas as api foram utilizadas ferramentas:

Base de dados SqlServer 2017.

Métricas são externadas utilizando a URL [Métricas CatApi](http://localhost:8080/metrics) e [Métricas TwitterApi](http://localhost:8080/metrics) ou pelo [Prometheus](http://localhost:9090/graph)

Foi utilizado GrayLog para a centralização de Log de Erro, disponível pela URL [GrayLog](http://localhost:9000/)

- UserName: admin
- Password: admin

### Estrutura de Pastas e Técnicas utilizadas para desenvolvimento das API

Ambas as API possuem a mesma estrutura de pastas:

- :file_folder: 1 - Api
    - :computer: A4S.CaseItau.Api : Api propriamente dita com todas as controllers possuindo os endpoints necessários para aplicação
- :file_folder: 2 - Application 
    - :books: A4S.CaseItau.Application : Camada de negócio aqui estão abstraidas todas as regras de negócio da aplicação, utilizando Mediator como principal Design Pattern
- :file_folder: 3 - Domain 
    - :books: A4S.CaseItau.Domain : Camada de dominio, na qual possui todas as entidades e interfaces necessárias para o pleno funcionamento da aplicação.
- :file_folder: 4 - Infra 
    - :books: A4S.CaseItau.Infra : Camada de infraestrutura, esta camada possui a responsabilidade de gerir o acesso aos dados, que estão no servidor, utilizando o Entiy Framework Core como ORM e diversos design patterns, dentre eles Repository e Builder.
- :file_folder: 5 - Core 
    - :books: A4S.CaseItau.Core : Camada possuindo classes e métodos genéricos para abstração e prevenção de repetição de código.
    - :books: A4S.CaseItau.Http : Camada que possui acesso a api externa, separada das outras regras.
    - :books: A4S.CaseItau.Logging : Camada que visa a configuração das ferramentas de log
    - :books: A4S.CaseItau.Injection : possui todas as classes responsaveis por gerir a Injeção de Dependencia dos serviços
- :file_folder: 6 - Teste
    - :books: A4S.CaseItau.Teste : Camada de testes unitários da aplicação
    
Todo o projeto seguem o SOLID e POO, para a codificação de sua arquitetura.

