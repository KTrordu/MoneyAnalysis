using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.DTOs
{
    public class ExpenseDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime ExpenseDate { get; set; }
        [Required]
        public int ExpenseCategoryId { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
