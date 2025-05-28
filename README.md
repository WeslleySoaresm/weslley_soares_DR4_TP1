# Criando Uma Aplicação Razor Pages com ASP.NET Core

Este projeto demonstra a construção de uma aplicação web utilizando **ASP.NET Core Razor Pages**, com foco em recursos como **model binding**, **validações customizadas**, **roteamento com parâmetros**, **manipulação de arquivos** e **uso de tag helpers**.

---

## ✅ Funcionalidades Implementadas

### 1. Criar Cidade com PageModel

Criação de uma página chamada `CreateCity.cshtml` com um `PageModel` que utiliza `[BindProperty]` para vincular o nome da cidade enviado via POST.

* Página: `/Pages/CityManager/CreateCity.cshtml`
* Recebe `CityName` com validação obrigatória.
* Exibe o nome da cidade após o envio.

```csharp
[BindProperty]
[Required(ErrorMessage = "O nome da cidade é obrigatório")]
public string CityName { get; set; }
```

---

### 2. Handler com Parâmetro no OnPost

Substituição do `[BindProperty]` por um parâmetro direto no método `OnPost(string cityName)`.

```csharp
public void OnPost(string cityName)
{
    CityName = cityName;
}
```

Exibe dinamicamente: `Cidade cadastrada com sucesso: {cityName}`

---

### 3. Validação com Data Annotations

Utilização de `ModelState.IsValid` e atributos `[Required]` e `[MinLength(3)]` para validar entradas no servidor.

```csharp
public class InputModel {
    [Required]
    [MinLength(3)]
    public string CityName { get; set; }
}
```

---

### 4. Validação do Lado do Cliente

Uso de Tag Helpers `asp-for` e `asp-validation-for` com inclusão de `_ValidationScriptsPartial`.

```razor
<input asp-for="Input.CityName" />
<span asp-validation-for="Input.CityName"></span>
```

---

### 5. Objeto Complexo: CreateCountry

Formulário que utiliza um `InputModel` com os campos `CountryName` e `CountryCode`, que posteriormente são usados para instanciar um objeto `Country`.

```csharp
public class Country {
    public string CountryName { get; set; }
    public string CountryCode { get; set; }
}
```

---

### 6. Validação ISO de Código do País

Adição de `[StringLength(2, MinimumLength = 2)]` para validar códigos como "BR".

```csharp
[StringLength(2, MinimumLength = 2)]
public string CountryCode { get; set; }
```

---

### 7. Cadastro de Vários Países

Criação de uma lista `List<InputModel>` com 5 entradas via `for`, e formulário que envia os dados de todos os países.

```csharp
[BindProperty]
public List<InputModel> Countries { get; set; } = new();
```

---

### 8. Roteamento com Parâmetros na URL

Página `CityDetails.cshtml` que recebe o nome da cidade via URL usando `@page "{cityName}"`.

```csharp
public void OnGet(string cityName) {
    CityName = cityName;
}
```

---

### 9. URLs com Tag Helpers

Lista de cidades com links gerados via Tag Helpers:

```razor
<a asp-page="/CityManager/CityDetails" asp-route-cityName="@city">@city</a>
```

Lista utilizada:

```csharp
List<string> Cities = new() { "Rio", "São Paulo", "Brasília" };
```

---

### 10. Escrita de Arquivos

Formulário que salva um conteúdo como `.txt` com nome `note-{timestamp}.txt` no diretório `wwwroot/files`.

```csharp
await System.IO.File.WriteAllTextAsync(path, Input.Content);
```

Link de download exibido após submissão:

```razor
<a href="~/files/@Model.FileName" download>Clique aqui para baixar</a>
```

---

### 11. Leitura de Arquivos

Lista todos os arquivos `.txt` e permite visualização de seu conteúdo.

```csharp
FileNames = Directory.GetFiles(filesDir, "*.txt")
    .Select(Path.GetFileName)
    .ToList();
```

Exibe conteúdo com `@Model.SelectedContent`

---

### 12. Validação Customizada com `ModelState`

Validação onde `CountryCode` deve começar com a mesma letra de `CountryName`. Caso contrário, adiciona erro manual:

```csharp
if (char.ToUpper(Input.CountryName[0]) != char.ToUpper(Input.CountryCode[0])) {
    ModelState.AddModelError("Input.CountryCode", "O código do país deve começar com a mesma letra do nome do país.");
}
```

---

## 📁 Estrutura de Pastas

```
/Pages
  /CityManager
    - CreateCity.cshtml
    - CityDetails.cshtml
    - CityList.cshtml
  /CountryManager
    - CreateCountry.cshtml
    - CreateMultipleCountries.cshtml
  /NoteManager
    - SaveNote.cshtml
    - ReadNotes.cshtml
/Models
  - Country.cs
  - Note.cs
/wwwroot
  /files
```

---

## 🧪 Tecnologias Utilizadas

* ASP.NET Core Razor Pages (.NET 7/8)
* C#
* HTML + Tag Helpers
* Model Binding
* Data Annotations
* Validação do lado do servidor e cliente
* File I/O com System.IO

---

## 🛠️ Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/usuario/repositorio.git
cd repositorio
```

2. Execute:

```bash
dotnet run
```

3. Acesse no navegador:

```
https://localhost:5001
```


---

## 👤 Autor

**Weslley Wallace Castro Soares**
Estudante da disciplina: Desenvolvimento Web com .NET e Bases de Dados \[25E2\_4]
Trabalho prático completo com foco em aplicações interativas Razor Pages

---
