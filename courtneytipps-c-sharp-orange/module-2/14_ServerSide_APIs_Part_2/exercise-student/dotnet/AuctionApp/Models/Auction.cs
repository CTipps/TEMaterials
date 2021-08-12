using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models
{
    public class Auction
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The field `title` cannot be blank.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field `description` cannot be blank.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field `user` cannot be blank.")]
        public string User { get; set; }

        [Range(1, double.PositiveInfinity, ErrorMessage = "The field `current bid` must be greater than 0.")]
        public double CurrentBid { get; set; }
    }
}
