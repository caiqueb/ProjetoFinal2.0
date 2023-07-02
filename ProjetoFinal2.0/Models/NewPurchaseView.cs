﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal2._0.Models
{
    public class NewPurchaseView
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Fornecedor")]
        public int ProviderId { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [Display(Name = "Comentários")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Detalhes")]
        public List<PurchaseDetailTmp> Details { get; set; }

        // [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double TotalQuantity { get { return Details == null ? 0 : Details.Sum(d => d.Quantity); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal TotalValue { get { return Details == null ? 0 : Details.Sum(d => d.Value); } }

    }
}