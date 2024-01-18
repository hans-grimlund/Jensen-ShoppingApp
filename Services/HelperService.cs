namespace AnnonsApp.Services
{
    public class HelperService
    {
        public static string GetUserInput(string? msg = null)
        {
            while (true)
            {
                if (msg != null)
                    System.Console.Write(msg + " ");

                var response = Console.ReadLine();
                
                if (response != null && response != "")
                {
                    return response;
                }
                
                System.Console.WriteLine("Ange en giltig input");
            }

        }
    }
}