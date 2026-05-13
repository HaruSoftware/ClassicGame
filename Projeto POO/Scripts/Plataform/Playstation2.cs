using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Projeto_POO.Scripts
{
    public class Playstation2 : Game
    {
        public override void Run()
        {
            MessageBox.Show($"Executando o jogo {Name}");
        }
        public override void Install()
        {
            this.Installed = true;
        }
        public override void Uninstall()
        {
            this.Installed = false;
        }
    }
}
