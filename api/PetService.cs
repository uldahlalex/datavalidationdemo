using System.ComponentModel.DataAnnotations;

namespace api;

public class PetService
{
    private readonly PetDatabase _db;

    public PetService(PetDatabase db)
    {
        Console.WriteLine("This petservice has been instantiated");
        _db = db;
    }

    public Pet CreatePet(CreatePetRequestDto dto)
    {
        //Data validation
        Validator.ValidateObject(dto, 
            new ValidationContext(dto),
            true);
        
        //Object instiation
        var pet = new Pet()
        {
Age = dto.Age,
Name = dto.Name,
CreatedAt = DateTime.UtcNow,
 Id = Guid.NewGuid().ToString()
        };
        
        _db.AllPets.Add(pet);
        return pet;
    }
}