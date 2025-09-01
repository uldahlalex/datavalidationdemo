using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api;

[ApiController]
public class PetController : ControllerBase
{
    private readonly PetService _service;

    public PetController(PetService service)
    {
        Console.WriteLine("controller");
        _service = service;
    }
    
    [HttpPost(nameof(CreatePet))]
    public Pet CreatePet([FromBody]CreatePetRequestDto pet)
    {
        return _service.CreatePet(pet);
    }
}

public record CreatePetRequestDto
{
    [MinLength(3)]
    public string Name { get; set; }
    [Range(0,15)]
    public int Age { get; set; }
}