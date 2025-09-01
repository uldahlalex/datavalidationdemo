using System.ComponentModel.DataAnnotations;

namespace api;

public interface IPetService
{
    Pet CreatePet(CreateOrUpdatePetRequestDto dto);
    Pet UpdatePet(string id, CreateOrUpdatePetRequestDto dto);
    Pet DeletePet(string id);
    List<PetResponseDto> GetAllPets();
}

public class PetService : IPetService
{
    private readonly PetDatabase _db;

    public PetService(PetDatabase db)
    {
        Console.WriteLine("This petservice has been instantiated");
        _db = db;
    }

    public Pet CreatePet(CreateOrUpdatePetRequestDto dto)
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

    public Pet UpdatePet(string id, CreateOrUpdatePetRequestDto dto)
    {
        var existingPet = _db.AllPets.First(p => p.Id == id);
        existingPet.Name = dto.Name;
        existingPet.Age = dto.Age;
        return existingPet;
    }

    public Pet DeletePet(string id)
    {
        var existingPet = _db.AllPets.FirstOrDefault(p => p.Id == id);
        if (existingPet == null)
            throw new KeyNotFoundException("Could not find the pet");
        var success =_db.AllPets.Remove(existingPet);
        if (!success)
            throw new Exception("Failed to delete the pet");
        return existingPet;
    }

    public List<PetResponseDto> GetAllPets()
    {
        return _db.AllPets
            .Select(p => new PetResponseDto(p))
            .ToList();
    }
}