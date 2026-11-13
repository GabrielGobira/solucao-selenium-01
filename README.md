# 🧪 Automação de Testes com Selenium e MSTest

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Selenium](https://img.shields.io/badge/Selenium-WebDriver-43B02A?style=for-the-badge&logo=selenium&logoColor=white)
![MSTest](https://img.shields.io/badge/Testes-MSTest-blue?style=for-the-badge)
![GitHub](https://img.shields.io/badge/GitHub-Repositório-181717?style=for-the-badge&logo=github)

## 📌 Sobre o projeto

Projeto acadêmico desenvolvido em **C# com .NET 10**, utilizando **Selenium WebDriver e MSTest** para automatizar testes funcionais em formulários web.

O objetivo é aplicar conceitos de Garantia da Qualidade de Software, simulando interações de um usuário com uma página web e verificando automaticamente se as funcionalidades apresentam o comportamento esperado.

A automação utiliza o formulário disponibilizado pela documentação oficial do Selenium:

https://www.selenium.dev/selenium/web/web-form.html

## 🎯 Objetivos

- Desenvolver testes automatizados utilizando C#.
- Aplicar conceitos de qualidade e validação de software.
- Automatizar o preenchimento e envio de formulários.
- Interagir com diferentes componentes HTML.
- Validar resultados utilizando asserções.
- Organizar testes utilizando MSTest.
- Praticar versionamento de código com Git e GitHub.

## ⚙️ Tecnologias utilizadas

| Tecnologia | Finalidade |
|---|---|
| C# | Linguagem de programação |
| .NET 10 | Plataforma de desenvolvimento |
| Selenium WebDriver | Automação de navegadores |
| MSTest | Framework de testes |
| ChromeDriver | Controle automatizado do navegador Chrome |
| Visual Studio Code | Ambiente de desenvolvimento |
| Git | Controle de versão |
| GitHub | Hospedagem do código-fonte |

## 🧪 Cenários de testes automatizados

### Exercício 1 — Cadastro completo

Automatiza o preenchimento e envio de um formulário web.

**Validações realizadas:**
- Preenchimento do campo de texto.
- Preenchimento do campo de senha.
- Inserção de uma descrição.
- Verificação de campo somente leitura.
- Envio do formulário.
- Validação da mensagem de sucesso `Received!`.

### Exercício 2 — Dropdown e Datalist

Automatiza a interação com componentes de seleção.

**Validações realizadas:**
- Localização de um dropdown.
- Seleção da opção `Two`.
- Verificação do valor selecionado.
- Preenchimento do datalist com `Seattle`.
- Verificação do valor informado.
- Envio e validação do formulário.

### Exercício 3 — Checkboxes, Radio Buttons e Color Picker

Automatiza a interação com diferentes componentes de formulário.

**Validações realizadas:**
- Verificação do estado inicial de um checkbox.
- Seleção de outro checkbox.
- Seleção de um radio button.
- Alteração do seletor de cores para vermelho (`#ff0000`).
- Verificação da cor selecionada.
- Envio do formulário e confirmação do resultado.

## 📊 Resultados dos testes

Na última execução local, realizada com `dotnet test`, foram obtidos os seguintes resultados:

| Indicador | Resultado |
|---|---|
| Total de testes | 4 |
| Testes aprovados | 4 |
| Testes reprovados | 0 |
| Testes ignorados | 0 |
| Tempo de execução | 17,2 segundos |

**Resultado: todos os testes foram aprovados.**

Os resultados apresentados correspondem à execução local registrada durante o desenvolvimento e podem variar em futuras execuções.

## 📁 Estrutura do projeto

```text
atividadedeautomação/
│
├── Consoleautomação/
│   ├── Script/
│   │   └── PrimeiroScript.cs
│   ├── Program.cs
│   └── Consoleautomação.csproj
│
├── Consoleautomação.Tests/
│   ├── test/
│   │   ├── PrimeiroScriptTest.cs
│   │   └── WebFormularioDesafioTest.cs
│   ├── MSTestSettings.cs
│   └── Consoleautomação.Tests.csproj
│
├── .gitignore
├── README.md
└── atividadedeautomação.slnx
```

## 🚀 Como executar o projeto

### Pré-requisitos

Antes de iniciar, é necessário ter instalado:

- SDK do .NET 10.
- Google Chrome compatível com o ambiente de testes.
- Git.
- Visual Studio Code ou outra IDE compatível com C#.

### 1. Clonar o repositório

Abra o terminal e execute:

```bash
git clone https://github.com/GabrielGobira/solucao-selenium-01.git
```

### 2. Acessar a pasta do projeto

```bash
cd solucao-selenium-01
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Compilar o projeto

```bash
dotnet build
```

### 5. Executar a aplicação de console

```bash
dotnet run --project "Consoleautomação/Consoleautomação.csproj"
```

### 6. Executar todos os testes automatizados

```bash
dotnet test
```

Durante a execução dos testes, o Selenium controla o navegador, realiza as interações programadas e verifica os resultados esperados.

## 🔎 Executar testes específicos

**Exercício 1:**

```bash
dotnet test --filter "FullyQualifiedName~Exercicio1_CadastroCompleto"
```

**Exercício 2:**

```bash
dotnet test --filter "FullyQualifiedName~Exercicio2_DropdownEDatalist"
```

**Exercício 3:**

```bash
dotnet test --filter "FullyQualifiedName~Exercicio3_EstadosEColorPicker"
```

### Exibir resultados detalhados

```bash
dotnet test --logger "console;verbosity=normal"
```

## 🛠️ Boas práticas aplicadas

Durante o desenvolvimento, foram utilizados conceitos importantes para a qualidade dos testes:

- Separação entre aplicação e projeto de testes.
- Reutilização de métodos.
- Validação automatizada com `Assert`.
- Uso de `WebDriverWait` para aguardar elementos.
- Encerramento do navegador com `driver.Quit()`.
- Tratamento de situações em que o clique é interceptado.
- Configuração para evitar execução paralela dos testes de navegador.
- Versionamento com Git e mensagens de commit padronizadas.

## 📚 Aprendizados

O desenvolvimento deste projeto permitiu colocar em prática conhecimentos relacionados à automação de testes e à qualidade de software.

Foi possível compreender melhor como o Selenium interage com elementos HTML, como estruturar cenários automatizados e como identificar e corrigir falhas durante a execução dos testes.

Também foram exercitados o uso do terminal, a organização de projetos C# e o versionamento com Git e GitHub.

## 👨‍💻 Autor

**Gabriel Gobira de Souza**

Estudante de Análise e Desenvolvimento de Sistemas (ADS), com interesse em desenvolvimento de software, automação de testes e garantia da qualidade.

- **GitHub:** https://github.com/GabrielGobira
- **LinkedIn:** https://www.linkedin.com/in/gabriel-gobira-de-souza-506080251/

---

Projeto desenvolvido para fins acadêmicos e de aprendizado em automação de testes de software.
