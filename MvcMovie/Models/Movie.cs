using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {

        public int Id { get; set; }

        //[Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //[Required]
        //[StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Genre { get; set; }

        //[Range(1, 100)]
        [DataType(DataType.Currency), Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        //[Required]
        //[StringLength(5)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string Rating { get; set; }
    }
}