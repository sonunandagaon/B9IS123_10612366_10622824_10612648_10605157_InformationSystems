namespace MusicEquipmentStore.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public long Mobile { get; set; }

        public string Password { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool? IsRemember { get; set; }
    }
}
