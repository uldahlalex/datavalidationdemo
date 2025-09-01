using Microsoft.AspNetCore.Mvc;

namespace api;

public class PetController : ControllerBase
{
    private readonly PetService _service;

    public PetController(PetService service)
    {
        _service = service;
    }
    
    [HttpPost(nameof(CreatePet))]
    public Pet CreatePet([FromBody]Pet pet)
    {
        return _service.CreatePet(pet);
    }
}