﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal2._0.Models
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(256, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "E-Mail")]

        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }


        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Display(Name = "Nome")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }





        public virtual Departaments Department { get; set; }

        public virtual City City { get; set; }



        public virtual ICollection<CompanyProvider> CompanyProviders { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }

    }
}