# Projeto desenvolvido para o processo seletivo Itau Unibanco

O projeto visa a criação de uma arquitetura limpa, e construida com o objetivo de facilitar manutenção e adição de funcionalidades.

Foi escolhido o Docker como ferramenta para criação de conteiners, criando assim um ambiente com microserviços rodando de forma separada.

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


    
