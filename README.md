🎮 Projeto POO – Biblioteca de Jogos (WPF)
📌 Visão Geral do Projeto

Este projeto foi desenvolvido utilizando C# com WPF (Windows Presentation Foundation) e tem como objetivo principal aplicar conceitos de Programação Orientada a Objetos (POO) em uma aplicação gráfica.

A aplicação simula uma biblioteca de jogos, onde o usuário pode visualizar, buscar, filtrar, instalar, desinstalar e executar jogos de diferentes plataformas.

🖥 O que é WPF?
📌 Definição

O Windows Presentation Foundation é uma tecnologia da Microsoft usada para criar interfaces gráficas ricas no Windows utilizando C# e XAML.

🧠 Características principais do WPF
Separação entre interface (XAML) e lógica (C#)
Uso de Data Binding (ligação automática entre dados e interface)
Suporte a MVVM (Model-View-ViewModel) (mesmo que simplificado neste projeto)
Interface altamente personalizável
Atualização dinâmica da UI com coleções como ObservableCollection
🔗 Como o WPF funciona neste projeto

No nosso sistema:

O XAML define a interface (listas, botões, textbox, combobox)
O C# (MainWindow.xaml.cs) controla toda a lógica
O DataContext = this conecta os dados à interface
A ObservableCollection atualiza a tela automaticamente quando os dados mudam
🧱 Estrutura do Projeto
Projeto_POO
│
├── Scripts/
│   ├── Game (classe base)
│   ├── Plataform/
│       ├── GamePlataform (enum)
│       ├── SuperNintendo
│       ├── Playstation2
│
├── MainWindow.xaml (Interface)
├── MainWindow.xaml.cs (Lógica)
🧠 Conceitos de POO Aplicados
🎯 Classe Base: Game

A classe Game representa um jogo genérico e contém:

Nome
Categoria
Plataforma
Descrição
Caminho de execução
Tamanho
Capa
Status de instalação
🔧 Métodos principais:
Run() → Executa o jogo
Install() → Instala o jogo
Uninstall() → Desinstala o jogo

👉 Isso representa o conceito de abstração, pois define o comportamento geral de qualquer jogo.

🧩 Herança

As classes:

SuperNintendo
Playstation2

herdam de Game.

👉 Isso permite reutilizar código e especializar comportamentos.

🎭 Polimorfismo

Os métodos como:

Run()
Install()
Uninstall()

podem ter comportamentos diferentes dependendo da plataforma do jogo.

👉 Isso permite flexibilidade e expansão futura do sistema.

🔒 Encapsulamento

Os dados dos jogos são armazenados dentro das classes e acessados de forma controlada, protegendo o estado interno dos objetos.

🖥 Interface (WPF)

A interface principal está no arquivo:

📄 MainWindow.xaml

Ela contém:

Lista de jogos
Campo de busca
ComboBox de plataformas
Botões de ação
