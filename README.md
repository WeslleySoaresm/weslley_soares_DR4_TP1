# Criando Uma Aplicação Razor Pages com ASP.NET Core

Este projeto demonstra a construção de uma aplicação web utilizando **ASP.NET Core Razor Pages**, com foco em recursos como **model binding**, **validações customizadas**, **roteamento com parâmetros**, **manipulação de arquivos** e **uso de tag helpers**.

---

## ✅ Funcionalidades Implementadas

### 1. Criar País

* Página `CreateCountry.cshtml` com formulário para cadastrar nome e código de um país.
* **Validação customizada**: O nome do país e o código devem começar com a mesma letra.

```csharp
if (!CountryCode.StartsWith(CountryName[0]))
    ModelState.AddModelError("CountryCode", "O código do país deve começar com a mesma letra do nome do país.");
```

* Exibição da mensagem de erro vinculada ao campo de código.
* Redirecionamento após o sucesso (ou mensagem, se preferir).

**Exemplo de uso:**

```
Nome: Brasil
Código: BR (válido)
Código: PT (erro: letras diferentes)
```

---

### 2. Lista de Cidades com Links Dinâmicos

* Lista fixa em memória:

```csharp
List<string> Cities = new() { "Rio", "São Paulo", "Brasília" };
```

* Uso de **Tag Helpers** com `asp-page` e `asp-route-cityName` para criar links clicáveis:

```html
<a asp-page="CityDetails" asp-route-cityName="@city">@city</a>
```

**Exemplo de uso:**

```
Cidades:
- Rio → /CityManager/CityDetails/Rio
- São Paulo → /CityManager/CityDetails/São%20Paulo
```

---

### 3. Roteamento com Parâmetros

* Página `CityDetails.cshtml` recebe o nome da cidade via URL:

```
/CityManager/CityDetails/{cityName}
```

* Definida com `@page "{cityName}"` no topo.
* O valor é recebido via método:

```csharp
public void OnGet(string cityName) {
    CityName = cityName;
}
```

**Exemplo de URL acessada:**

```
/CityManager/CityDetails/RioDeJaneiro
```

---

### 4. Escrita de Arquivos `.txt`

* Página `SaveNote.cshtml` com um formulário para digitar um conteúdo.
* Ao submeter, salva em `wwwroot/files/note-{timestamp}.txt`:

```csharp
var path = Path.Combine("wwwroot/files", $"note-{timestamp}.txt");
System.IO.File.WriteAllText(path, Input.Content);
```

* Mostra mensagem de sucesso e link para download do arquivo.

**Exemplo:**

```
Texto digitado: "Minha anotação."
Arquivo salvo: note-20250528000100.txt
Link: /files/note-20250528000100.txt
```

---

### 5. Leitura de Arquivos

* Página `ReadNotes.cshtml` para listar e abrir arquivos `.txt` criados.
* Lista todos os arquivos do diretório `wwwroot/files`:

```csharp
var files = Directory.GetFiles("wwwroot/files");
```

* Cada arquivo possui um link para visualizar o conteúdo.

**Exemplo de listagem:**

```
Arquivos:
- note-20250528000100.txt → Visualizar conteúdo
```

---

## 🗂️ Estrutura de Diretórios

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
/wwwroot
  /files
```

---

## ⚙️ Tecnologias Utilizadas

* ASP.NET Core Razor Pages (.NET 7+)
* C# com PageModel
* Tag Helpers (asp-page, asp-route)
* File I/O com `System.IO`
* Model Binding
* Validação com `ModelState`

---

## 🚀 Executando o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/usuario/repositorio.git
cd repositorio
```

2. Execute com o .NET CLI:

```bash
dotnet run
```

3. Acesse o navegador:

```
https://localhost:5001
```

---

## 📸 Capturas de Tela

### Formulário com Validação

![Formulário de País com Validação](docs/form-validacao.png)

### Leitura de Arquivos

![Leitura de Arquivos](docs/lista-arquivos.png)





---

## 👨‍💻 Autor

Projeto desenvolvido por **Weslley Soares** para prática com ASP.NET Razor Pages, cobrindo tópicos como rotas, validações, formulários, e leitura/escrita de arquivos.

---
