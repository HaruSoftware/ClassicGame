using Projeto_POO.Scripts.Plataform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projeto_POO.Scripts
{
    public static class GameRepository
    {
        private static List<Game> allGames = new List<Game>()
        {
            new SuperNintendo
            {
                Name = "Super Mario World",
                Category = "Aventura",
                Description = "Super Mario World é um clássico do SNES em que Mario e Luigi exploram Dinosaur Land para salvar a Princesa Peach. O jogo introduz Yoshi e traz fases criativas cheias de segredos, sendo um dos plataformas mais influentes e lembrados dos videogames.",
                RunPath = "https://emulatorgamer.com/pt/games/super-mario-world/play",
                Size = "512 KB",
                CoverPath = "UI/Images/Games/SNES/supermarioworld.jpg",
            },
            new SuperNintendo
            {
                Name = "International Superstar Soccer Deluxe",
                Category = "Esportes",
                Description = "Um dos jogos de futebol mais famosos do Super Nintendo, com narração empolgante, vários times internacionais e jogabilidade fluida.",
                RunPath = @"Games\SNES\International Superstar Soccer Deluxe (USA).sfc",
                Size = "2.0 MB",
                CoverPath = "UI/Images/Games/SNES/issdeluxe.jpg"
            },
            new SuperNintendo
            {
                Name = "Mortal Kombat 3",
                Category = "Luta",
                Description = "Clássico jogo de luta da franquia Mortal Kombat, com novos Fatalities, personagens icônicos e muita ação no Super Nintendo.",
                RunPath = @"Games\SNES\Mortal Kombat 3 (USA).sfc",
                Size = "4.0 MB",
                CoverPath = "UI/Images/Games/SNES/mk3.jpg"
            }
        };
        public static ObservableCollection<Game> Get()
        {
            return new ObservableCollection<Game>(allGames);
        }
    }
}
