﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinal2._0.Models
{
    public class Company
    {
        [Key]

        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido!!")]
        [MaxLength(50, ErrorMessage = "O campo Nome recebe no máximo 50 caracteres")]
        [Display(Name = "Nome")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }



        [Required(ErrorMessage = "O campo Telefone é requerido!!")]
        [MaxLength(50, ErrorMessage = "O campo Nome recebe no máximo 50 caracteres")]
        [Display(Name = "Telefone")]
        //[Index("Departament_Name_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }



        [Required(ErrorMessage = "O campo Endereço é requerido!!")]
        [MaxLength(100, ErrorMessage = "O campo Nome recebe no máximo 50 caracteres")]
        [Display(Name = "Endereço")]

        public string Address { get; set; }




        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }


        [Required(ErrorMessage = "O campo Departamento é requerido!!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }


        [Required(ErrorMessage = "O campo Cidade é requerido!!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }



        public virtual Departaments Departments { get; set; }
        public virtual City Cities { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<Category> Category { get; set; }

        public virtual ICollection<Tax> Taxes { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<WareHouse> WareHouse { get; set; }



        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<CompanyCustomer> CompanyCustomers { get; set; }

    }
}