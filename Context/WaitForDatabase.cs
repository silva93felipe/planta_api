using MySql.Data.MySqlClient;

namespace planta_api.Context
{
    public class WaitForDatabase
    {
        public static void WaitFor(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Container");// Substitua pela sua string de conexão com o MySQL
            int maxAttempts = 10;
            int attempt = 1;
            TimeSpan retryDelay = TimeSpan.FromSeconds(10);

            while (attempt <= maxAttempts)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        break; // Conexão bem-sucedida, sair do loop
                    }
                }
                catch (MySqlException)
                {
                    Console.WriteLine($"Tentativa {attempt}/{maxAttempts} - Falha ao conectar ao MySQL. Tentando novamente em {retryDelay.TotalSeconds} segundos...");
                    Thread.Sleep(retryDelay);
                    attempt++;
                }
            }

            if (attempt > maxAttempts)
            {
                Console.WriteLine("Falha ao conectar ao MySQL após várias tentativas. Saindo...");
                Environment.Exit(1);
            }
        }
    }
}