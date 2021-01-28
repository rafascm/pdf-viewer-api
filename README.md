# PDF Viewer Api

### Em construção... 🚀

<div style="text-align: center">
<br>

  ![Badge](https://img.shields.io/badge/.NET-5.0-%237159c1?style=flat&logo=.net)
  ![Badge](https://img.shields.io/badge/SQL-SERVER-DB7093?style=flat&logo=microsoft-sql-server)

<br>
</div>

## Funcionalidades

- Transformar o arquivo em `bytes` e criar um `MemoryStream`
- Enviar o arquivo por `http request`
- Armazenar a instância do arquivo `PDF` no contexto do `DB`
- Rota `GET` que retorna um array com os arquivos disponíveis
- Rota `GET /{id}` que retorna o arquivo `PDF`

## Pendências

- Popular o contexto na inicialização da aplicação. Atualmente ele é populado no construtor do controller, o que faz com que ele readicione ao contexto toda vez que uma rota é chamada.

