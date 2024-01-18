using AnnonsApp.Models.ViewModels;

namespace AnnonsApp.Views
{
    public class HomeView
    {
        public HomeViewModel ViewModel { get; set; }

        public HomeView(HomeViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Homepage()
        {
            Console.Clear();;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Välkommen {ViewModel.User.Username}");
            Console.WriteLine();
            Console.WriteLine("1 - Skapa annons");
            Console.WriteLine("2 - Ändra annons");
            Console.WriteLine("3 - Ta bort annons");
            Console.WriteLine("4 - Sök efter annons");
            Console.WriteLine("5 - Visa alla annonser");
            Console.WriteLine("6 - Sortera efter kategori");
            Console.WriteLine("7 - Logga ut");
            Console.WriteLine();
            Console.WriteLine($"Just nu finns det {ViewModel.ItemCount} annonser");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
        }

        public void Adminpage()
        {
            Console.Clear();;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Välkommen {ViewModel.User.Username}");
            Console.WriteLine("Du är inloggad som admin");
            Console.WriteLine();
            Console.WriteLine("1 - Skapa annons");
            Console.WriteLine("2 - Ändra annons");
            Console.WriteLine("3 - Ta bort annons");
            Console.WriteLine("4 - Sök efter annons");
            Console.WriteLine("5 - Visa alla annonser");
            Console.WriteLine("6 - Sortera efter kategori");
            Console.WriteLine("7 - Lägg till kategori");
            Console.WriteLine("8 - Ändra kategori");
            Console.WriteLine("9 - Ta bort kategori");
            Console.WriteLine("10 - Logga ut");
            Console.WriteLine();
            Console.WriteLine($"Just nu finns det {ViewModel.ItemCount} annonser");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
        }
    }
}