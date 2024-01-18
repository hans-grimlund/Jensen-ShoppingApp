using AnnonsApp.Models;
using AnnonsApp.Services;

namespace AnnonsApp.Views
{
    public class StartView
    {
        public int Startpage()
        {
            while (true)
            {
                Console.Clear();;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("1 - Skapa konto");
                Console.WriteLine("2 - Logga in");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------");

                var input = HelperService.GetUserInput();
                if (input.Equals("1"))
                    return 1;
                if (input.Equals("2"))
                    return 2;
            }
        }

        public LoginModel Loginpage(Status status = Status.None)
        {
            LoginModel loginModel = new();
            Console.Clear();;

            if (status != Status.None)
                Console.WriteLine(status);
                
            loginModel.Username = HelperService.GetUserInput("Ange användarnamn:");

            loginModel.Password = HelperService.GetUserInput("Ange lösenord:");

            return loginModel;
        }

        public NewAccountModel CreateAccount(Status status = Status.None)
        {
            NewAccountModel newAccountModel = new();

            Console.Clear();;
            if (status != Status.None)
                Console.WriteLine(status);

            Console.WriteLine();
            Console.Write("Ange ett användarnamn: ");
            newAccountModel.Username = Console.ReadLine()!;

            Console.Write("Ange en mailadress: ");
            newAccountModel.Email = Console.ReadLine()!;

            Console.Write("Ange ett lösenord: ");
            newAccountModel.Password = Console.ReadLine()!;

            Console.Write("Upprepa lösenord: ");
            newAccountModel.PasswordRepeat = Console.ReadLine()!;

            Console.Write("Ange ditt telefonnummer: ");
            newAccountModel.Phone = Console.ReadLine()!;

            Console.Write("(Valfritt) Ange din stad: ");
            newAccountModel.City = Console.ReadLine()!;

            Console.Write("(Valfritt) Ange ditt postnummer: ");
            newAccountModel.Zipcode = Console.ReadLine()!;

            Console.Write("(Valfritt) Ange din adress: ");
            newAccountModel.Address = Console.ReadLine()!;

            return newAccountModel;
        }
    }
}