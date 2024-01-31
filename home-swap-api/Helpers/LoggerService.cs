using System;
namespace home_swap_api.Helpers
{
	public class LoggerService
	{
        public void LogInformation(string message)
        {
            
            Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        }

        public void LogError(string message, Exception ex)
        {
            
            Console.WriteLine($"[ERROR] {DateTime.Now}: {message}\n{ex}");
        }
    }
}

