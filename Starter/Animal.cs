namespace Starter;

public class Animal
{
    public required string? Id { get; set; } 
    public required Species? Species { get; set; }
    public int? Age { get; set; }
    public string? Nickname { get; set; }
    public string? PhysicalDesc { get; set; }
    public string? Personality { get; set; }
    
}

// animalArray[i, 0] = $"ID #: {animalID}";
// animalArray[i, 1] = $"Species: {animalSpecies}";
// animalArray[i, 2] = $"Age: {animalAge}";
// animalArray[i, 3] = $"Nickname: {animalNickname}";
// animalArray[i, 4] = $"Physical description: {animalPhysicalDescription}";
// animalArray[i, 5] = $"Personality: {animalPersonalityDescription}";