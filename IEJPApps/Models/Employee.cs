using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IEJPApps.Models
{
    public partial class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Active", AutoGenerateFilter = false)]
        public bool Active { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Number", AutoGenerateFilter = false)]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "FirstName", AutoGenerateFilter = false)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "LastName", AutoGenerateFilter = false)]
        public string LastName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Rate is required")]
        [Range(0.01, 999.99, ErrorMessage="Rate must be between 0.01 and 999.99")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Rate", AutoGenerateFilter = false)]
        public decimal Rate { get; set; }

        [StringLength(20)]
        [Display(Name = "Mobile", AutoGenerateFilter = false)]
        public string Mobile { get; set; }

        [StringLength(255)]
        //[Required(ErrorMessage = "The email address is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "EMail", AutoGenerateFilter = false)]
        public string Email { get; set; }

        [Display(Name = "TimeTransactions", AutoGenerateFilter = false)]
        public virtual ICollection<TimeTransaction> TimeTransactions { get; set; }

        [Display(Name = "ExpenditureTransactions", AutoGenerateFilter = false)]
        public virtual ICollection<ExpenditureTransaction> ExpenditureTransactions { get; set; }
    }
}