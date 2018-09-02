# AdminLTE - MVC .Net Core 2

Este modelo é baseado em AdminLTE de [http://almsaeedstudio.com](http://almsaeedstudio.com). Convertido como um projeto .net core.

Neste projeto estarei tentando implementar boas praticas de programação
e arquitetura de software DDD `Domain Driven Design`.

## Arquitetura de software

Definição dos tipo de camadas utilizada no projeto.

### Camada de aplicação

Responsável pelo projeto principal, pois é onde será desenvolvido os controladores e serviços. Tem a função de receber todas as requisições e direcioná-las a algum serviço para executar uma determinada ação.

Possui referências das camadas `Service` e `Domain`.

### Camada de domínio

Responsável pela implementação de classes/modelos, as quais serão mapeadas para o banco de dados, além de obter as declarações de interfaces, constantes, DTOs (Data Transfer Object) e enums.

### Camada de serviço

Seria o "coração" do projeto, pois é nela que é feita todas as regras de negócio e todas as validações, antes de persistir os dados no banco de dados.

Possui referências das camadas `Domain`, `Infra.Data` e `Infra.CrossCutting`.

### Camada de Infraestrutura

Está camada é dividida em duas sub-camadas

#### Data

Realiza a persistência com o banco de dados, utilizando, ou não, algum ORM.

#### Cross-Cutting

Uma camada a parte que não obedece a hierarquia de camada. Como o próprio nome diz, essa camada cruza toda a hierarquia. Contém as funcionalidades que pode ser utilizada em qualquer parte do código, como, por exemplo, validação de CPF/CNPJ, consumo de API externa e utilização de alguma segurança.

Possui referências da camada `Domain`.