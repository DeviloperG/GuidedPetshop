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
    private static string[,] _ourAnimals = new string[MaxPets, 6];

    private static List<Animal> _ourAnimalsList = new();
    public static void Main()
    {
        SeedData(_ourAnimals);
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
                    PrintArray(_ourAnimals);
                    
                    Console.WriteLine("PrintList() Runs");
                    PrintList();
                    break;
                }

                case "2":
                {
                    CreateNewPet(_ourAnimals);
                    break;
                }

                case "3":
                {
                    EnsureAgeAndPhysicalConditionIsFilled(_ourAnimals);
                    Console.WriteLine(
                        "\n\rAge and physical condition fields are complete for all of our friends. \n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                }

                case "4":
                {
                    EnsureNicknameAndPersonalityIsFilled(_ourAnimals);

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


    private static void SeedData(string[,] animalArray)
    {
        for (int i = 0; i < MaxPets; i++)
        {
            string animalSpecies;
            switch (i)
            {
                case 0:
                {
                    animalSpecies = "dog";
                    _animalId = "d1";
                    _animalAge = "2";
                    _animalPhysicalDescription =
                        "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                    _animalPersonalityDescription =
                        "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    _animalNickname = "lola";
                    break;
                }

                case 1:
                {
                    animalSpecies = "dog";
                    _animalId = "d2";
                    _animalAge = "?";
                    _animalPhysicalDescription =
                        "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    _animalPersonalityDescription =
                        "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    _animalNickname = "loki";
                    break;
                }

                case 2:
                {
                    animalSpecies = "cat";
                    _animalId = "c3";
                    _animalAge = "1";
                    _animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    _animalPersonalityDescription = "friendly";
                    _animalNickname = "Puss";
                    break;
                }

                case 3:
                {
                    animalSpecies = "cat";
                    _animalId = "c4";
                    _animalAge = "21";
                    _animalPhysicalDescription = "";
                    _animalPersonalityDescription = "";
                    _animalNickname = "";
                    break;
                }


                default:
                {
                    animalSpecies = "";
                    _animalId = "";
                    _animalAge = "";
                    _animalPhysicalDescription = "";
                    _animalPersonalityDescription = "";
                    _animalNickname = "";
                    break;
                }
            }

            animalArray[i, 0] = $"ID #: {_animalId}";
            animalArray[i, 1] = $"Species: {animalSpecies}";
            animalArray[i, 2] = $"Age: {_animalAge}";
            animalArray[i, 3] = $"Nickname: {_animalNickname}";
            animalArray[i, 4] = $"Physical description: {_animalPhysicalDescription}";
            animalArray[i, 5] = $"Personality: {_animalPersonalityDescription}";
        }
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

    private static void PrintArray(string[,] array)
    {
        int xDimension = array.GetLength(0);
        int yDimension = array.GetLength(1);


        for (int i = 0; i < xDimension; i++)
        {
            Console.WriteLine(); //Creates a line break to make output easy to read
            if (array[i, 0] != "ID #: ")
            {
                for (int j = 0; j < yDimension; j++)
                {
                    Console.WriteLine(array[i, j]);
                }
            }
        }
    }
    
    private static void PrintList()
    {
        foreach (var animal in _ourAnimalsList)
        {
            if (!string.IsNullOrEmpty(animal.Id))
                Console.WriteLine($"ID:{animal.Id}\n Age:{animal.Age}\n Nickname: {animal.Nickname}\n Personality: {animal.Personality}\n Physical Description: {animal.PhysicalDesc}\n\n");
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

    private static void CreateNewPet(string[,] animalArray)
    {
        int petCount = CountPets(animalArray);


        PrintCapacityStatistics(petCount);

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
                GetUserString(
                    "\"Enter a physical description of the pet (size, color, gender, weight, housebroken)\"");

            string personalityDescription =
                GetUserString(
                    "Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
            string nickname = GetUserString("Enter a nickname for the pet");


            // store the pet information in the ourAnimals array
            animalArray[petCount, 0] = $"ID #: {_animalId}";
            animalArray[petCount, 1] = $"Species: {species}";
            animalArray[petCount, 2] = $"Age: {(ageIsKnown ? age : "?")}";
            animalArray[petCount, 3] = $"Nickname: {nickname}";
            animalArray[petCount, 4] = $"Physical description: {physicalDescription}";
            animalArray[petCount, 5] = $"Personality: {personalityDescription}";

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

    private static void EnsureAgeAndPhysicalConditionIsFilled(string[,] animalArray)
    {
        for (int i = 0; i < MaxPets; i++)
        {
            if (animalArray[i, 0] == "ID #: ") continue;

            EnsureAgeIsFilled(animalArray, i);

            EnsurePhysicalConditionIsFilled(animalArray, i);
        }
    }

    private static void EnsureAgeIsFilled(string[,] animalArray, int animalNumber)
    {
        if (animalArray[animalNumber, (int)AnimalProperty.Age] == "Age: ?")
        {
            while (true)
            {
                Console.WriteLine($"Enter an age for {animalArray[animalNumber, 0]}");
                string? userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    bool success = int.TryParse(userInput, out int petAge);
                    if (success)
                    {
                        animalArray[animalNumber, 2] = $"Age: {petAge}";
                        return;
                    }
                }
            }
        }
    }

    private static void EnsurePhysicalConditionIsFilled(string[,] animalArray, int animalNumber)
    {
        if (animalArray[animalNumber, (int)AnimalProperty.PhysicalCondition] == "Physical description: ")
        {
            while (true)
            {
                Console.WriteLine(
                    $"Enter a physical description for {animalArray[animalNumber, 0]} (size, color, gender, weight, housebroken)");
                string? userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        animalArray[animalNumber, (int)AnimalProperty.PhysicalCondition] =
                            $"Physical description: {userInput.ToLower()}";
                        return;
                    }
                }
            }
        }
    }

    private static void EnsureNicknameAndPersonalityIsFilled(string[,] animalArray)
    {
        for (int i = 0; i < MaxPets; i++)
        {
            if (animalArray[i, 0] == "ID #: ") continue;

            EnsureNicknameConditionIsFilled(animalArray, i);

            EnsurePersonalityConditionIsFilled(animalArray, i);
        }
    }

    private static void EnsureNicknameConditionIsFilled(string[,] animalArray, int animalNumber)
    {
        if (animalArray[animalNumber, (int)AnimalProperty.Nickname] == "Nickname: " ||
            animalArray[animalNumber, (int)AnimalProperty.Nickname] == "Nickname: tbd")
        {
            while (true)
            {
                Console.WriteLine(
                    $"Enter a nickname for {animalArray[animalNumber, 0]}");
                string? userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        animalArray[animalNumber, (int)AnimalProperty.Nickname] = $"Nickname: {userInput.ToLower()}";
                        return;
                    }
                }
            }
        }
    }

    private static void EnsurePersonalityConditionIsFilled(string[,] animalArray, int animalNumber)
    {
        if (animalArray[animalNumber, (int)AnimalProperty.Personality] == "Personality: " ||
            animalArray[animalNumber, (int)AnimalProperty.Personality] == "Personality: tbd")
        {
            while (true)
            {
                Console.WriteLine(
                    $"Enter a personality description for {animalArray[animalNumber, 0]}");
                string? userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        animalArray[animalNumber, (int)AnimalProperty.Personality] =
                            $"Personality: {userInput.ToLower()}";
                        return;
                    }
                }
            }
        }
    }
    private static void SeedDataList()
    {
        for (int i = 0; i < MaxPets; i++)
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
                        Personality = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.",
                        PhysicalDesc = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken."
                        
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
}