using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api;

[ApiController]
public class PetController : ControllerBase
{
    private readonly IPetService _service;

    public PetController(IPetService service)
    {
        Console.WriteLine("controller");
        _service = service;
    }
    
    [HttpPost(nameof(CreatePet))]
    public Pet CreatePet([FromBody]CreateOrUpdatePetRequestDto orUpdatePet)
    {
        return _service.CreatePet(orUpdatePet);
    }

    [HttpPatch(nameof(UpdatePet))]
    public Pet UpdatePet(
        [FromQuery]string id,
        [FromBody]CreateOrUpdatePetRequestDto dto)
    {
        return _service.UpdatePet(id, dto);
    }

    [HttpDelete(nameof(DeletePet))]
    public Pet DeletePet(string id)
    {
        return _service.DeletePet(id);
    }

    [HttpGet(nameof(GetPets))]
    public List<PetResponseDto> GetPets() => _service.GetAllPets();

}

public record CreateOrUpdatePetRequestDto
{
    [MinLength(3)]
    public string Name { get; set; }
    [Range(0,15)]
    public int Age { get; set; }
}

