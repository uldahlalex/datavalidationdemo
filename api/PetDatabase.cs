namespace api;

public class PetDatabase
{
    
    public List<Pet> AllPets { get; set; } = new List<Pet>();
}

public class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Id { get; set; }
    
}

public class PetResponseDto
{
    public string PetName { get; set; }
    
    public PetResponseDto(Pet p)
    {
        PetName = p.Name;
    }
}