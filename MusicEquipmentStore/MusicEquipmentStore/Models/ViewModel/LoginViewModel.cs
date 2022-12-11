using System.ComponentModel.DataAnnotations;

namespace MusicEquipmentStore.Models.ViewModel
{
    public class LoginViewModel
    {
        //public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        //public string Email { get; set; }
        //public long Mobile { get; set; }
        [Required]
        public string Password { get; set; }
        //public bool IsActive { get; set; }



        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
