namespace Data.Models
{
    public class BoardGame
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public Customer Customer { get; set; }
    }
}