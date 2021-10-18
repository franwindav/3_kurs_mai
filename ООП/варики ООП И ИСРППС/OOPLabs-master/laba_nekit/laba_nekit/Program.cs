using System;

namespace laba_nekit
{
    public class Team
    {
        private string name;
        private static int PlayersCount = 22;
        private int iter = 0;
        private Player[] player = new Player[22];

        public Team(string name)
        {
            this.name = name;
            Console.WriteLine("Создана команда {0}", this.Name);
        }

        public Team(string name, Player player)
        {
            this.name = name;
            this.SetPlayer(player);
            Console.WriteLine("Создана команда {0}, добавлен игрок {1}", this.name, player.Name);
        }

        public void SetPlayer(Player player)
        {
            if (this.iter < PlayersCount)
            {
                this.player[this.iter] = player;
                this.iter += 1;
            }
            else
            {
                Console.WriteLine("Команда переполнена");
                return;
            }
            Console.WriteLine("В команду {0} добавлен игрок {1}", this.Name, player.Name);
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {

            }
        }
    }

    public class Player
    {
        private string name;
        private Team team;

        public Player() { }

        public Player(string name)
        {
            this.name = name;
            Console.WriteLine("Создан игрок {0}", this.Name);
        }

        public Player(string name, Team team)
        {
            this.name = name;
            this.team = team;
            Console.WriteLine("Создан игрок {0}, добавлен в команду {1}", this.Name, team.Name);

        }

        public void SetTeam(Team team)
        {
            this.team = team;
            team.SetPlayer(this);
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {

            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Team Barselona = new Team("Барселона");
            Player Ronaldo = new Player("Роналдо");
            Console.WriteLine();

            Barselona.SetPlayer(Ronaldo);
            Console.WriteLine();

            Player Messy = new Player("Месси");
            Console.WriteLine();

            Barselona.SetPlayer(Messy);
            Console.WriteLine();

            Team Juventus = new Team("Ювентус");
            Console.WriteLine();

            Ronaldo.SetTeam(Juventus);
            Console.WriteLine();

            Player Suarez = new Player("Суарез", Barselona);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
