namespace WhiskyMan.Entities
{
    public record Ownership
    {
        public User Owner { get; set; }
        public int OwnerId { get; set; }

        public Bottle Bottle { get; set; }
        public int BottleId { get; set; }
    }
}
