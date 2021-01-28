using WhiskyMan.Entities.Auth;

namespace WhiskyMan.Entities
{
    public record Ownership
    {
        public User Owner { get; set; }
        public long OwnerId { get; set; }

        public Bottle Bottle { get; set; }
        public long BottleId { get; set; }
    }
}
