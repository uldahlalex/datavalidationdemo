namespace api;

public class PetDatabase
{
    public PetDatabase()
    {
        Console.WriteLine("This pet DB has been instantiated");
    }
    
    public List<Pet> AllPets { get; set; } = new List<Pet>();
}

public class Pet
{
    
}