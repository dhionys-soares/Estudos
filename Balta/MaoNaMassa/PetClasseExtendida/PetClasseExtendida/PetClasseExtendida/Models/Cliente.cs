using Microsoft.AspNetCore.Identity;

namespace PetClasseExtendida.Models
{
    public class Cliente : IdentityUser
    {
        public string Nome { get; set; }
        public string Time { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
