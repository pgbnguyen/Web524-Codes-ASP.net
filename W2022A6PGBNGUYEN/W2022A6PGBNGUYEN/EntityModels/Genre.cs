using System.ComponentModel.DataAnnotations;

namespace W2022A6PGBNGUYEN.EntityModels
{
    public class Genre
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}