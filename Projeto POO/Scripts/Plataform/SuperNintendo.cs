using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Security.Policy;
using System.Text;

namespace Projeto_POO.Scripts.Plataform
{
    public class SuperNintendo : Game
    {
        public override void Install()
        {
            this.Installed = true;
        }

        public override void Run()
        {
            if (string.IsNullOrEmpty(this.RunPath))
                return;

            if (this.RunPath.EndsWith(".sfc") || this.RunPath.EndsWith(".smc"))
            {
                string emulatorPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Emulators\SNES\snes9x-x64.exe");
                string romPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.RunPath);

                if (System.IO.File.Exists(emulatorPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = emulatorPath,
                        Arguments = $"\"{romPath}\"",
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Emulador não encontrado na pasta.");
                }
            }
            else
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = RunPath,
                    UseShellExecute = true
                });
            }
        }

        public override void Uninstall()
        {
            this.Installed = false;
        }
    }
}
