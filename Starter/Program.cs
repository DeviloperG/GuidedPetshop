namespace Starter;

public static class Program
{
    private static string _animalId = "";
    private static string _animalAge = "";
    private static string _animalPhysicalDescription = "";
    private static string _animalPersonalityDescription = "";
    private static string _animalNickname = "";

// variables that support data entry
    private const int MaxPets = 8;

    private static string _menuSelection = "";

// array used to store runtime data, there is no persisted data

    private static List<Animal> _ourAnimalsList = new();

    public static void Main()
    {
        
        SeedDataList();

        do
        {
            // display the top-level menu options

            string? readResult = GetUserInput();


            switch (_menuSelection)
            {
                case "1":
                {
                    //list all current pet information
                    
                    PrintList();
                    break;
                }

                case "2":
                {
                   
                    CreateNewPetObject();
                    break;
                }

                case "3":
                {
                   
                    EnsureAgeAndPhysicalConditionIsFilledObj();
                    Console.WriteLine(
                        "\n\rAge and physical condition fields are complete for all of our friends. \n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                }

                case "4":
                {
                    
                    EnsureNicknameAndPersonalityIsFilledObj();

                    Console.WriteLine(
                        "\n\rNickname and personality fields are complete for all of our friends. \n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                }

                case "5":
                {
                    //TODO - Implement the feature
                    break;
                }

                case "6":
                {
                    //TODO - Implement the feature
                    break;
                }

                case "7":
                {
                    //TODO - Implement the feature
                    break;
                }

                case "8":
                {
                    //TODO - Implement the feature
                    break;
                }

                default:
                {
                    //TODO - Implement the feature
                    break;
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        } while (_menuSelection != "exit");
    }


  

    private static string? GetUserInput()
    {
        Console.Clear();

        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
        Console.WriteLine(" 5. Edit an animal’s age");
        Console.WriteLine(" 6. Edit an animal’s personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");


        string? readResult = Console.ReadLine();
        if (readResult != null)
        {
            _menuSelection = readResult.ToLower();
        }


        Console.WriteLine($"You selected menu option {_menuSelection}.");
        Console.WriteLine("Press the Enter key to continue");
        Console.ReadLine();

        return readResult;
    }



    private static void PrintList()
    {
        foreach (var animal in _ourAnimalsList)
        {
            if (!string.IsNullOrEmpty(animal.Id))
                Console.WriteLine(
                    $"ID:{animal.Id}\n Age:{animal.Age}\n Species: {animal.Species}\n Nickname: {animal.Nickname}\n Personality: {animal.Personality}\n Physical Description: {animal.PhysicalDesc}\n\n");
        }
    }


    private static int CountPets(string[,] array)
    {
        int xDimension = array.GetLength(0);
        int petCount = 0;
        const string emptyId = "ID #: ";
        for (int i = 0; i < xDimension; i++)
        {
            if (array[i, 0] != emptyId)
            {
                petCount++;
            }
        }

        return petCount;
    }

    private static void PrintCapacityStatistics(int petCount)
    {
        if (petCount < MaxPets)
        {
            Console.WriteLine(
                $"We currently have {petCount} pets that need homes. We have space for {(MaxPets - petCount)} more");
        }
    }

    private static Species InputCatOrDog()
    {
        while (true)
        {
            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
            string? readResult = Console.ReadLine();

            //checks input validity

            if (!string.IsNullOrWhiteSpace(readResult))
            {
                string userInput = readResult.ToLower();
                bool success = Species.TryParse(userInput, true, out Species species);
                if (success)
                {
                    return species;
                }
            }
        }
    }

    private static bool TryGetPetAge(out int age)
    {
        while (true)
        {
            Console.WriteLine("Enter the pet's age or enter ? if unknown");
            string? userInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                bool success = int.TryParse(userInput, out age);
                return success;
            }
        }
    }

    private static string GetUserString(string message, string defaultVal = "tbd")
    {
        Console.WriteLine(message);
        string? readResult = Console.ReadLine();

        return !string.IsNullOrWhiteSpace(readResult) ? readResult : defaultVal;
    }

    private static bool AskYesNoQuestion(string message)
    {
        while (true)
        {
            Console.WriteLine($"{message} (y/n)");
            string? userInput = Console.ReadLine()?.ToLower();
            switch (userInput)
            {
                case "y":
                {
                    return true;
                }
                case "n":
                {
                    return false;
                }
                default:
                {
                    continue;
                }
            }
        }
    }

    private static void SeedDataList()
    {
        for (int i = 0; i < 6; i++)
        {
            string animalSpecies;

            switch (i)
            {
                case 0:
                {
                    Animal animal1 = new()
                    {
                        Id = "d1",
                        Species = Species.Dog,
                        Nickname = "lola",
                        Age = 2,
                        Personality =
                            "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.",
                        PhysicalDesc =
                            "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken."
                    };
                    _ourAnimalsList.Add(animal1);
                    break;
                }

                case 1:
                {
                    Animal animal2 = new()
                    {
                        Id = "d2",
                        Species = Species.Dog,
                        Nickname = "loki",
                        Age = null,
                        Personality =
                            "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.",
                        PhysicalDesc =
                            "large reddish-brown male golden retriever weighing about 85 pounds. housebroken."
                    };
                    _ourAnimalsList.Add(animal2);
                    break;
                }

                case 2:
                {
                    Animal animal3 = new()
                    {
                        Id = "c3",
                        Species = Species.Cat,
                        Nickname = "Puss",
                        Age = 1,
                        Personality =
                            "friendly",
                        PhysicalDesc =
                            "small white female weighing about 8 pounds. litter box trained."
                    };
                    _ourAnimalsList.Add(animal3);

                    break;
                }

                case 3:
                {
                    Animal animal4 = new()
                    {
                        Id = "c4",
                        Species = Species.Cat,
                        Nickname = "Puss",
                        Age = 21,
                        Personality =
                            null,
                        PhysicalDesc =
                            null
                    };
                    _ourAnimalsList.Add(animal4);


                    break;
                }


                default:
                {
                    Animal animal5 = new()
                    {
                        Id = null,
                        Species = null,
                        Nickname = null,
                        Age = null,
                        Personality =
                            null,
                        PhysicalDesc =
                            null
                    };
                    _ourAnimalsList.Add(animal5);
                    break;
                }
            }
        }
    }

    private static void CreateNewPetObject()
    {
        int petCount = _ourAnimalsList.Count;
        Console.WriteLine(petCount);

        PrintListCapacityStatistics(petCount);

        while (petCount < MaxPets)
        {
            // get species (cat or dog) - string animalSpecies is a required field 
            //// method here 3
            Species species = InputCatOrDog();

            // builds the animal the ID number
            _animalId = species.ToString().Substring(0, 1) + (petCount + 1);

            //get pets age or ? 

            bool ageIsKnown = TryGetPetAge(out int age);

            string physicalDescription =
                GetUserStringObj(
                    "\"Enter a physical description of the pet (size, color, gender, weight, housebroken)\"");

            string personalityDescription =
                GetUserStringObj(
                    "Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
            string nickname = GetUserStringObj("Enter a nickname for the pet");


            Animal newAnimal = new()
            {
                Id = _animalId,
                Species = species,
                Nickname = nickname,
                Age = (ageIsKnown ? age : null),
                Personality =
                    personalityDescription,
                PhysicalDesc =
                    physicalDescription
            };
            _ourAnimalsList.Add(newAnimal);


            petCount++;

            if (petCount < MaxPets)
            {
                if (!AskYesNoQuestion("Do you want to enter info for another pet?"))
                {
                    break;
                }
            }

            if (petCount >= MaxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                Console.ReadLine();
            }
        }
    }

    private static void PrintListCapacityStatistics(int petCount)
    {
        if (petCount < MaxPets)
        {
            Console.WriteLine(
                $"We currently have {petCount} pets that need homes. We have space for {(MaxPets - petCount)} more");
        }
    }

    private static string GetUserStringObj(string message, string? defaultVal = null)
    {
        Console.WriteLine(message);
        string? readResult = Console.ReadLine();

        return readResult != " " ? readResult : defaultVal;
    }

    private static void EnsureAgeAndPhysicalConditionIsFilledObj()
    {
        foreach (var animal in _ourAnimalsList)
        {
            if (string.IsNullOrEmpty(animal.Id)) continue;

            EnsureAgeIsFilledObj(animal);
            EnsurePhysicalConditionIsFilledObj(animal);
        }
    }

    private static void EnsureAgeIsFilledObj(Animal animal)
    {
        if (animal.Age is null or 0)
        {
            while (true)
            {
                Console.WriteLine($"Enter an age for {animal.Id}");
                string? userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    bool success = int.TryParse(userInput, out int petAge);
                    if (success)
                    {
                        animal.Age = petAge;
                        return;
                    }
                }
            }
        }
    }

    private static void EnsurePhysicalConditionIsFilledObj(Animal animal)
    {
        if (string.IsNullOrEmpty(animal.PhysicalDesc))
        {
            while (true)
            {
                Console.WriteLine(
                    $"Enter a physical description for {animal.Id} (size, color, gender, weight, housebroken)");
                string? userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        animal.PhysicalDesc = userInput.ToLower();
                        return;
                    }
                }
            }
        }
    }

    private static void EnsureNicknameAndPersonalityIsFilledObj()
    {
        foreach (var animal in _ourAnimalsList)
        {
            if (string.IsNullOrEmpty(animal.Id)) continue;

            EnsureNicknameConditionIsFilledObj(animal);
            EnsurePersonalityConditionIsFilledObj(animal);
            ;
        }
    }

    private static void EnsureNicknameConditionIsFilledObj(Animal animal)
    {
        if (string.IsNullOrEmpty(animal.Nickname))
        {
            while (true)
            {
                Console.WriteLine(
                    $"Enter a nickname for {animal.Id}");
                string? userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        animal.Nickname = userInput.ToLower();
                        return;
                    }
                }
            }
        }
    }

    private static void EnsurePersonalityConditionIsFilledObj(Animal animal)
    {
        if (string.IsNullOrEmpty(animal.Personality))
        {
            while (true)
            {
                Console.WriteLine(
                    $"Enter a personality description for {animal.Id}");
                string? userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        animal.Personality = userInput.ToLower();
                        return;
                    }
                }
            }
        }
    }
}