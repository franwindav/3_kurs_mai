using System;

namespace laba7_oop
{
    class Server
    {
        public Server()
        {

        }

        public int ServerMethod()
        {
            return 77;
        }
    }

    class Client
    {
        public Client()
        {

        }

        public void ClientMerhod(Server server)
        {
            Console.WriteLine($"Вызов метода сервера через клиента возвращает {server.ServerMethod()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            Client client = new Client();

            client.ClientMerhod(server);

            Console.ReadKey();
        }
    }
}
