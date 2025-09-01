namespace api;

public class PetService
{
    private readonly PetDatabase _db;

    public PetService(PetDatabase db)
    {
        Console.WriteLine("This petservice has been instantiated");
        _db = db;
    }

    public Pet CreatePet(Pet pet)
    {
        _db.AllPets.Add(pet);
        return pet;
    }
}