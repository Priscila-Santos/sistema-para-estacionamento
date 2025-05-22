# 🚗 Sistema de Estacionamento em C# 🚗

Projeto desenvolvido como parte de um desafio de fundamentos da linguagem **C#**. Ele simula o funcionamento básico de um estacionamento, permitindo:

- Cadastro de veículos
- Remoção de veículos com cálculo de tarifa
- Listagem de veículos estacionados

---

##  Funcionalidades

- ✅ Cadastro de placa de veículo (com verificação de duplicidade)
- ✅ Remoção de veículo com cálculo de preço
- ✅ Geração de **comprovante de pagamento** formatado
- ✅ Armazenamento persistente em arquivo `data.csv`
- ✅ Menu interativo com layout estético no terminal
- ✅ Exibição de veículos estacionados com visual elegante

---

##  Tecnologias utilizadas

- [.NET Core / .NET 6+](https://dotnet.microsoft.com/en-us/)
- C# (linguagem principal)
- Sistema de arquivos (`System.IO`)

---

## Diagrama do Projeto

```mermaid
flowchart TD
    Start([Início do Programa])
    Menu{{Exibir Menu Principal}}
    
    option1[Cadastrar Veículo]
    option2[Remover Veículo]
    option3[Listar Veículos]
    option4[Encerrar Programa]

    checkPlaca[Verifica se placa já existe (memória/arquivo)]
    addPlaca[Adiciona placa à memória e ao arquivo CSV]
    sucessoAdd[Placa cadastrada com sucesso!]

    digitarPlacaRemover[Usuário digita placa]
    verificarExistencia[Verifica se a placa existe no arquivo]
    digitarHoras[Usuário digita horas]
    calcularPreco[Calcula o valor: precoInicial + precoPorHora * horas]
    removerVeiculo[Remove placa da memória e do arquivo CSV]
    exibirComprovante[Exibe comprovante formatado]

    listarVeiculos[Lê todas as placas do arquivo CSV e exibe]

    fim([Fim do Programa])

    Start --> Menu

    Menu -->|1| option1
    option1 --> checkPlaca
    checkPlaca -->|Não existe| addPlaca --> sucessoAdd --> Menu
    checkPlaca -->|Já existe| Menu

    Menu -->|2| option2
    option2 --> digitarPlacaRemover --> verificarExistencia
    verificarExistencia -->|Existe| digitarHoras --> calcularPreco --> removerVeiculo --> exibirComprovante --> Menu
    verificarExistencia -->|Não existe| Menu

    Menu -->|3| option3 --> listarVeiculos --> Menu

    Menu -->|4| option4 --> fim

```
---

##  Como executar o projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/sistema-estacionamento-csharp.git
   cd sistema-estacionamento-csharp
   ```
2. No terminal escreva o comando
```bash
  dotnet run
  ```

## Exemplo de uso
```plaintext
╔══════════════════════════════════════════════╗
║      SISTEMA DE ESTACIONAMENTO - MENU        ║
╠══════════════════════════════════════════════╣
║  1 - Cadastrar veículo                       ║
║  2 - Remover veículo                         ║
║  3 - Listar veículos                         ║
║  4 - Encerrar                                ║
╚══════════════════════════════════════════════╝
Escolha uma opção: 2

Digite a placa do veículo para remover:
ABC1234
Digite a quantidade de horas que o veículo permaneceu estacionado:
3

╔═══════════════════════════════════════╗
║       COMPROVANTE DE PAGAMENTO        ║
╠═══════════════════════════════════════╣
║ Placa do veículo: ABC1234             ║
║ Horas estacionado: 3                  ║
║ Preço inicial:     R$ 5,00            ║
║ Preço por hora:    R$ 2,00            ║
╠═══════════════════════════════════════╣
║ TOTAL A PAGAR:     R$ 11,00           ║
╚═══════════════════════════════════════╝
```
## Persistência de Dados
As placas são salvas no arquivo `data.csv`. Cada linha representa uma placa de veículo estacionado.

O arquivo é atualizado automaticamente ao adicionar ou remover veículos.

## Melhorias futuras (to-do)
 - Registrar data/hora de entrada e saída

 - Exportar comprovante para .txt

 - Suporte a múltiplos estacionamentos

 - Interface gráfica (WPF ou WinForms)


