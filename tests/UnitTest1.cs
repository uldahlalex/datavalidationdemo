using System.ComponentModel.DataAnnotations;
using api;

namespace tests;

public class UnitTest1
{
    [Fact]
    public void IfDataValidationRulesAreViolated_ServiceMethodThrowsException()
    {
        var db = new PetDatabase();
        var service = new PetService(db);
        var invalidPet = new CreatePetRequestDto()
        {
            Age = -1,
            Name = "asdækjsadjlksad"
        };
        Assert.Throws<ValidationException>(() => service.CreatePet(invalidPet));
    }
    
    [Fact]
    public void IfDataValidationRulesAreViolated_ServiceMethodThrowsException2()
    {
        var db = new PetDatabase();
        var service = new PetService(db);
        var invalidPet = new CreatePetRequestDto()
        {
            Age = 12,
            Name = ""
        };
        Assert.Throws<ValidationException>(() => service.CreatePet(invalidPet));
    }
}
