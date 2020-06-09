using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFoodCore.Core
{
    public class Restaurant
    {
        //We can inherit :IValidatableObject for advacnce validations:

        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }


        [StringLength(255)]
        [Required]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }
}
