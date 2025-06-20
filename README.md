# 🩺 CheckHealthNet

[![CheckHealthNet - CI](https://github.com/daniloopinheiro/CheckHealthNet/actions/workflows/dotnet-ci.yml/badge.svg)](https://github.com/daniloopinheiro/CheckHealthNet/actions/workflows/dotnet-ci.yml)

Este é um projeto de software que tem como objetivo **monitorar a integridade de recursos de sistema e serviços** em aplicações ASP.NET Core utilizando a API `HealthChecks` integrada e a poderosa biblioteca `AspNetCore.HealthChecks.System`. Ele foi desenvolvido utilizando **.NET 8**, **Docker** e segue uma arquitetura **modular e extensível**, garantindo **observabilidade, manutenibilidade e escalabilidade**.

---

## 📚 Índice

* [Visão Geral](#visão-geral)
* [Tecnologias Utilizadas](#tecnologias-utilizadas)
* [Instalação](#instalação)
* [Como Usar](#como-usar)
* [Estrutura de Diretórios](#estrutura-de-diretórios)
* [Configuração](#configuração)
* [Contribuições](#contribuições)
* [Licença](#licença)
* [Contato](#contato)

---

## 👀 Visão Geral

O **CheckHealthNet** fornece endpoints HTTP para monitoramento em tempo real da saúde de serviços e recursos do sistema, como:

* **CPU**
* **Memória**
* **Espaço em disco**
* **Tempo de atividade (uptime)**

Principais funcionalidades:

* **Health check configurável** com limites de uso por recurso
* **Pronto para Prometheus/Kubernetes**
* **Arquitetura limpa e extensível**

---

## 🛠 Tecnologias Utilizadas

* **.NET 8** – Plataforma principal de desenvolvimento
* **AspNetCore.HealthChecks.System** – Biblioteca para monitoramento de sistema
* **Docker** – Containerização e execução local/padrão para nuvem
* **Swagger** – Documentação interativa da API (opcional)
* **Visual Studio Code / Rider / Visual Studio** – Ambientes recomendados

---

## 💾 Instalação

### Pré-requisitos

* [.NET SDK 8+](https://dotnet.microsoft.com/en-us/download)
* [Docker](https://www.docker.com/) (opcional)
* [Git](https://git-scm.com/)

### Instalar pacote NuGet

Antes de rodar o projeto ou usar as funcionalidades de verificação de integridade do sistema, instale o pacote necessário:

```bash
dotnet add package AspNetCore.HealthChecks.System
dotnet add package AspNetCore.HealthChecks.UI
dotnet add package AspNetCore.HealthChecks.UI.Client
dotnet add package AspNetCore.HealthChecks.UI.InMemory.Storage
```

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/CheckHealthNet.git
   cd CheckHealthNet
   ```

2. Restaure os pacotes NuGet:

   ```bash
   dotnet restore
   ```

3. Execute localmente:

   ```bash
   dotnet run
   ```

4. Ou usando Docker:

   ```bash
   docker build -t checkhealthnet .
   docker run -p 5000:80 checkhealthnet
   ```

---

## 🚀 Como Usar

### Endpoint Principal

* **GET** `/health`

Retorna o status geral da aplicação e dos recursos monitorados.

#### Exemplo com `curl`:

```bash
curl http://localhost:5000/health
```

#### Exemplo de resposta JSON:

```json
{
  "status": "Healthy",
  "entries": {
    "cpu": { "status": "Healthy", "description": "CPU usage is under 90%" },
    "memory": { "status": "Healthy", "description": "Memory usage is under 85%" },
    "disk": { "status": "Healthy", "description": "Disk usage is under 90%" },
    "uptime": { "status": "Healthy", "description": "System uptime is above 10 minutes" }
  }
}
```

---

## 📂 Estrutura de Diretórios

```
CheckHealthNet/
├── Program.cs             # Configuração principal da aplicação
├── HealthChecks/          # Classe com registro dos checks do sistema
├── appsettings.json       # Configurações gerais
├── Dockerfile             # Imagem da aplicação
└── README.md              # Documentação do projeto
```

---

## ⚙️ Configuração

A configuração dos limites de CPU, memória, disco e uptime pode ser feita diretamente no `Program.cs`:

```csharp
options.AddCpuHealthCheck("cpu", 0.90);
options.AddMemoryHealthCheck("memory", 0.85);
options.AddDiskStorageHealthCheck("disk", "C:\\", 0.90);
options.AddSystemUptimeHealthCheck("uptime", TimeSpan.FromMinutes(10));
```

---

## 🤝 Contribuições

Contribuições são bem-vindas!

1. Fork este repositório
2. Crie uma branch: `git checkout -b feature/nome-da-sua-feature`
3. Commit suas alterações: `git commit -m 'Adiciona nova funcionalidade'`
4. Push: `git push origin feature/nome-da-sua-feature`
5. Abra um Pull Request

---

## 📄 Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo [LICENSE](LICENSE) para mais informações.

---

## 📬 Contato

Caso tenha dúvidas, sugestões ou deseje colaborar:

* **Email**: [contato@dopme.io](mailto:contato@dopme.io)
* **LinkedIn**: [Danilo O. Pinheiro](https://www.linkedin.com/in/daniloopinheiro)
* **Dev.to**: [@daniloopinheiro](https://dev.to/daniloopinheiro)
* **Medium**: [@daniloopinheiro](https://medium.com/@daniloopinheiro)
