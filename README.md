# Criando Uma Aplicação Razor Pages com ASP.NET Core

Este projeto demonstra a construção de uma aplicação web utilizando **ASP.NET Core Razor Pages**, abordando conceitos como **model binding**, **validações customizadas**, **roteamento com parâmetros**, **manipulação de arquivos** e **uso de tag helpers**.

## Funcionalidades Implementadas

### ✅ 1. Criar País

* Formulário para cadastro de país com nome e código.
* Validação customizada: o **nome e o código devem começar com a mesma letra**.
* Exibição de mensagens de erro com `ModelState.AddModelError`.

### ✅ 2. Lista de Cidades com Links Dinâmicos

* Lista estática de cidades: `Rio`, `São Paulo`, `Brasília`.
* Uso de **Tag Helpers** para gerar links com `asp-page` e `asp-route-cityName`.

### ✅ 3. Roteamento com Parâmetro na URL

* Página `CityDetails.cshtml` acessada via URL com o nome da cidade:
  Ex: `/CityManager/CityDetails/RioDeJaneiro`
* Uso de diretiva `@page "{cityName}"`.
* Parâmetro capturado usando `OnGet(string cityName)`.

### ✅ 4. Escrita de Arquivos

* Página `SaveNote.cshtml` permite ao usuário escrever um texto.
* Texto é salvo como `.txt` no diretório `wwwroot/files` com o nome `note-{timestamp}.txt`.
* Após o envio, exibe link para download do arquivo criado.

### ✅ 5. Leitura de Arquivos

* Lista todos os arquivos `.txt` da pasta `wwwroot/files`.
* Cada item tem um link para exibir o conteúdo do arquivo.

---

## Estrutura de Pastas

```
/Pages
  /CityManager
    - CityDetails.cshtml
    - CityList.cshtml
    - SaveNote.cshtml
    - ReadNotes.cshtml
  /CountryManager
    - CreateCountry.cshtml
/Models
  - Country.cs
  - NoteManager.cs
```

---

## Tecnologias Utilizadas

* .NET 7 / 8
* Razor Pages (PageModel)
* C#
* HTML + Tag Helpers
* File I/O (`System.IO`)
* Model Binding e validação com `ModelState`

---

## Execução do Projeto

1. Clone o repositório.
2. Execute via Visual Studio Code ou terminal com:

   ```bash
   dotnet run
   ```
3. Acesse o navegador em:

   ```
   https://localhost:5001
   ```

---

## Autor

> Projeto desenvolvido por **Weslley Soares** como prática de criação de páginas Razor com funcionalidades completas de CRUD, validações e manipulação de arquivos.
