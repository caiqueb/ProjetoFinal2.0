﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinal2._0.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "Estado")]
        [Index("State_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

    }
}