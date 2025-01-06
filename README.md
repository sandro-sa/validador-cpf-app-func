# Projeto: Validar CPF

Este projeto é uma função do Azure que valida um CPF (Cadastro de Pessoa Física). Ele é criado e gerido usando **Azure Functions** e o **.NET**. A seguir, você encontra as instruções para configurar o ambiente e implantar a função no Azure.

## Requisitos

Antes de começar, verifique se você tem os seguintes itens instalados no seu sistema:

- [x] Conta no **Azure** (crie uma [aqui](https://azure.microsoft.com/))
- [x] **VS Code** (baixe [aqui](https://code.visualstudio.com/download))
- [x] **.NET 8** (baixe [aqui](https://dotnet.microsoft.com/download/dotnet/8.0))
- [x] **Node.js** (baixe [aqui](https://nodejs.org/pt-br/))
- [x] **Postman** (baixe [aqui](https://www.postman.com/downloads/))

### Passos de instalação

1. **Instalar o .NET 8**:
   - Se você ainda não tem o **.NET 8** instalado, faça o download e siga as instruções de instalação.
  
2. **Instalar o VS Code**:
   - Baixe o VS Code e instale a versão mais recente para seu sistema operacional.

3. **Instalar o Node.js**:
   - O **Node.js** é necessário para instalar as ferramentas do Azure Functions. Baixe e instale a versão estável.

4. **Instalar o Postman**:
   - O Postman será utilizado para testar a função localmente após ser criada.

### Configuração no VS Code

1. Abra o **VS Code**.
2. Instale a extensão **Azure Functions**:
   - No VS Code, vá até a seção de **Extensões** (ícone de quadrado no menu lateral esquerdo).
   - Pesquise por "Azure Functions" e instale a extensão oficial da Microsoft.

3. Crie a **Function App** no Azure:
   - Pressione **Ctrl + Shift + P** para abrir a paleta de comandos.
   - Pesquise por **Azure: Create Function** e selecione a opção.
   - Escolha a assinatura do Azure em que você deseja criar a função.
   - Dê um nome para a sua Function App (Exemplo: `fnseunomeappestusdev001`).

---

## Comandos Utilizados

Aqui estão os principais comandos que você precisará para configurar e rodar sua **Azure Function**.

### Instalação das Ferramentas do Azure Functions

Se você ainda não tem o **Azure Functions Core Tools** instalado, use o comando abaixo para instalá-lo via **npm** (Node.js):

```bash
# Instalar as ferramentas do Azure Functions
npm install -g azure-functions-core-tools@4 --unsafe-perm true
```

### Verificação da Instalação

Após a instalação, verifique se a ferramenta foi instalada corretamente executando:

```bash
# Verificar a versão do Azure Functions Core Tools
func --version
```

### Inicializar o Projeto

Crie um novo projeto de **Azure Functions** com **.NET** como o ambiente de execução:

```bash
# Inicializa um novo projeto de Azure Functions com .NET como runtime
func init --worker-runtime dotnet
```

### Criar uma Nova Função

Agora, crie uma nova função dentro do projeto. O comando `func new` permite que você escolha o tipo de trigger (gatilho) para a função.

```bash
# Criar uma nova função no projeto
func new
```

Durante a execução do comando, você será solicitado a escolher o tipo de trigger para a função e o nome da função. Para este exemplo:

- Escolha o tipo de trigger: **HttpTrigger**
- Nome da função: **fnvalidacpf**

### Rodar o Projeto Localmente

Depois de criar a função, você pode rodá-la localmente com o seguinte comando:

```bash
# Rodar a função localmente
func start
```

No **Postman**, faça uma requisição **POST** para testar a função com um **JSON** no corpo, contendo o parâmetro `cpf`:

```json
{
  "cpf": "000.000.000-33"
}
```

### Publicar no Azure

Após testar localmente, você pode publicar sua função no **Azure**. Para isso, execute o comando abaixo:

```bash
# Publicar o projeto no Azure
func azure functionapp publish fnseunomeappestusdev001
```

Substitua `fnseunomeappestusdev001` pelo nome da sua Function App no Azure.

---

## Usando a Função no Azure

Agora que sua função está publicada no Azure, você pode acessá-la por meio de uma URL. Para autenticar e usar a função, você precisará de uma chave de acesso.

### Obter a Chave de Acesso

1. No portal do **Azure**, vá até sua **Function App** (`fnseunomeappestusdev001`).
2. Navegue até a seção **Funções** e clique na função criada (por exemplo, `fnvalidacpf`).
3. Copie a **chave de acesso** padrão (geralmente chamada de `default`).

### Testar a Função no Postman

Agora, no **Postman**, faça uma requisição para a URL da sua função, incluindo a chave de acesso como parâmetro `code`:

- URL: `https://<seu-nome-app>.azurewebsites.net/api/fnvalidacpf?code=<sua-chave>`
- Método: **POST**
- Corpo da requisição (JSON):

```json
{
  "cpf": "000.000.000-33"
}
```

---

## Conclusão

Com os passos acima, você configurou, desenvolveu, testou e publicou sua **Azure Function** para validação de CPF. Agora, você pode integrar essa função em outras aplicações ou utilizá-la em qualquer serviço que suporte requisições HTTP.

Se tiver dúvidas ou problemas, sinta-se à vontade para abrir uma **issue** ou perguntar!

---
