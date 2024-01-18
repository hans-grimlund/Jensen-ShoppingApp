using AnnonsApp.Models;
using AnnonsApp.Models.DTOs;
using AnnonsApp.Models.ViewModels;
using AnnonsApp.Services;

namespace AnnonsApp.Views
{
    public class ItemView
    {
        public ItemDTO NewItem(NewItemViewModel viewModel)
        {
            ItemDTO item = new();
            Console.Clear();;

            item.Title = HelperService.GetUserInput("Rubrik:");
            item.Description = HelperService.GetUserInput("Beskrivning:");
            item.Price = Convert.ToDecimal(HelperService.GetUserInput("Pris:"));

            while (true)
            {
                Console.Clear();;
                foreach (var Category in viewModel.Categories)
                {
                    Console.WriteLine($"{Category.Id} - {Category.Name}");
                }

                
                item.Category = HelperService.GetUserInput("Kategori:");

                if (viewModel.Categories.FirstOrDefault(category => category.Id == Convert.ToInt32(item.Category)) != null)
                {
                    break;
                }

                Console.WriteLine($"Välj kategori mellan {viewModel.Categories.Min(category => category.Id)} och {viewModel.Categories.Max(category => category.Id)}");
            }

            return item;
        }

        public bool ConfirmItemUpload(ItemDTO item)
        {
            Console.Clear();
            Console.WriteLine($"Rubrik: {item.Title}");
            Console.WriteLine($"Beskrivning: {item.Description}");
            Console.WriteLine($"Pris: {item.Price}kr");
            Console.WriteLine($"Kategori: {item.Category}");

            while (true)
            {
                var input = HelperService.GetUserInput("Vill du ladda upp din annons? y/n");
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Console.WriteLine("Din annons har nu laddats upp.");
                    Console.ReadLine();
                    return true;
                }
                if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
        }

        public int DeleteItem(DeleteItemViewModel viewModel, bool admin = false)
        {
            while (true)
            {
                var index = 0;

                int i = 0;
                i++;
                if (i == 4)
                    return 0;

                Console.Clear();

                foreach (var item in viewModel.Items)
                {
                    var itemString = $"{index += 1} - {item.Title}";
                    if (admin)
                    {
                        itemString += $" - {item.Username}";
                    }

                    Console.WriteLine(itemString);
                }

                Console.WriteLine();
                Console.WriteLine("Skriv 'back' för att gå tillbaka");
                Console.WriteLine();
                var input = HelperService.GetUserInput("Välj en annons att ta bort:");

                if (input.Equals("back", StringComparison.CurrentCultureIgnoreCase))
                    return 0;

                if (int.TryParse(input, out int indexOfItem) && indexOfItem <= index && indexOfItem > 0)
                {
                    return viewModel.Items[indexOfItem - 1].Id;
                }

                Console.WriteLine($"Välj en annons mellan {viewModel.Items.Min(item => item.Id)} och {viewModel.Items.Max(item => item.Id)}");
            }
        }

        public bool ConfirmItemDelete(ItemDTO item)
        {
            Console.Clear();

            while (true)
            {
                var input = HelperService.GetUserInput($"Är du säker på att du vill ta bort '{item.Title}'? y/n");
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Console.WriteLine("Annons borttagen");
                    Console.ReadLine();
                    return true;
                }
                if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
        }

        public int GetEditItem(EditItemViewModel viewModel, bool admin = false)
        {
            while (true)
            {
                var index = 0;

                int i = 0;
                i++;
                if (i == 4)
                    return 0;

                Console.Clear();

                foreach (var item in viewModel.Items)
                {
                    var itemString = $"{index += 1} - {item.Title}";
                    if (admin)
                    {
                        itemString += $" - {item.Username}";
                    }

                    Console.WriteLine(itemString);
                }

                Console.WriteLine();
                Console.WriteLine("Skriv 'back' för att gå tillbaka");
                Console.WriteLine();
                var input = HelperService.GetUserInput("Välj en annons att ändra:");

                if (input.Equals("back", StringComparison.CurrentCultureIgnoreCase))
                    return 0;

                if (int.TryParse(input, out int indexOfItem) && indexOfItem <= index && indexOfItem > 0)
                {
                    return viewModel.Items[indexOfItem - 1].Id;
                }

                Console.WriteLine($"Välj en annons mellan {viewModel.Items.Min(item => item.Id)} och {viewModel.Items.Max(item => item.Id)}");
            }
        }

        public ItemDTO EditItem(ItemDTO item)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"1 - {item.Title}");
                Console.WriteLine();
                Console.WriteLine($"2 - {item.Description}");
                Console.WriteLine();
                Console.WriteLine($"3 - {Decimal.ToInt32(item.Price)}kr");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();
                
                Console.WriteLine("Skriv 'apply' för att verkställa ändringar");
                Console.WriteLine("Skriv 'back' för att gå tillbaka");
                Console.WriteLine();
                var input = HelperService.GetUserInput("Vad vill du ändra?");

                if (input.Equals("apply", StringComparison.CurrentCultureIgnoreCase))
                    return item;
                if (input.Equals("back", StringComparison.CurrentCultureIgnoreCase))
                    return new();

                if (int.TryParse(input, out int indexOfItem) && indexOfItem <= 3 && indexOfItem >= 1)
                {
                    switch (indexOfItem)
                    {
                        case 1:
                            item.Title = ChangeTitle();
                            break;
                        case 2:
                            item.Description = ChangeDescription();
                            break;
                        case 3:
                            item.Price = ChangePrice();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private string ChangeTitle()
        {
            Console.Clear();
            return HelperService.GetUserInput("Ange en ny rubrik:");
        }

        private string ChangeDescription()
        {
            Console.Clear();
            return HelperService.GetUserInput("Ange en ny beskrivning:");
        }

        private decimal ChangePrice()
        {
            while (true)
            {
                Console.Clear();
                var input = HelperService.GetUserInput("Ange ett nytt pris:");
                if (decimal.TryParse(input, out decimal result))
                    return result;

                Console.Clear();
                Console.WriteLine("Ej giltigt pris");
                Console.ReadLine();
            }
        }

        public void EditItemSuccessfull()
        {
            Console.Clear();
            Console.WriteLine("Annons uppdaterad");
            Console.ReadLine();
        }

        public void NoUploadedItems()
        {
            Console.Clear();
            Console.WriteLine("Du har inte några annonser.");
            Console.ReadLine();
        }

        public int ShowItems(ShowItemsViewModel viewModel)
        {
            while (true)
            {
                Console.Clear();
                var index = 0;

                foreach (var item in viewModel.Items)
                {
                    Console.WriteLine($"{index += 1} - {item.Title}");
                }

                Console.WriteLine();
                Console.WriteLine("Skriv 'back' för att gå tillbaka");
                Console.WriteLine();

                var userInput = HelperService.GetUserInput();

                if (userInput!.Equals("back", StringComparison.CurrentCultureIgnoreCase))
                    return 0;

                if (int.TryParse(userInput, out int indexOfItem) && indexOfItem <= index && indexOfItem > 0)
                {
                    var selectedItem = viewModel.Items.ElementAtOrDefault(indexOfItem - 1)!;
                    if (selectedItem != null)
                        return selectedItem.Id;
                }
            }
        }

        public void ShowItem(ShowItemViewModel viewModel)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{viewModel.Item.Title}");
            Console.WriteLine();
            Console.WriteLine($"{viewModel.Item.Description}");
            Console.WriteLine();
            Console.WriteLine($"{Decimal.ToInt32(viewModel.Item.Price)}kr");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            Console.ReadLine();
        }

        public string GetSearchTerm()
        {
            Console.Clear();
            return HelperService.GetUserInput("Sök:");
        }

        public void NoSearchResults()
        {
            Console.Clear();
            Console.WriteLine("Inga annonser hittades");
            Console.ReadLine();
        }

        public int GetCategory(GetCategoryViewModel viewModel)
        {
            while (true)
            {
                var index = 0;

                Console.Clear();
                
                foreach (var category in viewModel.Categories)
                {
                    Console.WriteLine($"{index += 1} - {category.Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Skriv 'back' för att gå tillbaka");
                Console.WriteLine();

                var userInput = HelperService.GetUserInput();

                if (userInput.Equals("back", StringComparison.CurrentCultureIgnoreCase))
                    return 0;

                if (int.TryParse(userInput, out int indexOfItem) && indexOfItem <= index && indexOfItem > 0)
                {
                var selectedItem = viewModel.Categories.ElementAtOrDefault(indexOfItem - 1)!;
                    if (selectedItem != null)
                        return selectedItem.Id;
                }               
            }
        }

        public Category AddCategory()
        {
            Console.Clear();
            Category category = new();
            category.Name = HelperService.GetUserInput("Ange namn på kategori:");
            return category;
        }

        public bool ConfirmAddCategory(Category category)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Vill du lägga till kategorin '{category.Name}'? y/n");
                var input = HelperService.GetUserInput();
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine("Kategori tillagd.");
                        Console.ReadLine();
                        return true;
                    }
                if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
        }

        public Category EditCategory(Category category)
        {
            Console.Clear();
            var newName = HelperService.GetUserInput("Ange nytt namn:");
            category.Name = newName;
            return category;
        }

        public bool ConfirmEditCategory(Category category)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Nytt namn: {category.Name}. Vill du tillämpa? y/n");
                var input = HelperService.GetUserInput();
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine("Kategori ändrad.");
                        Console.ReadLine();
                        return true;
                    }
                if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
        }

        public bool ConfirmDeleteCategory(Category category)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Vill du ta bort kategorin '{category.Name}'? y/n");
                var input = HelperService.GetUserInput();
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine("Kategori borttagen.");
                        Console.ReadLine();
                        return true;
                    }
                if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
        }
    }
}