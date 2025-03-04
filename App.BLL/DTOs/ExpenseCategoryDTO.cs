using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.DTOs
{
    public class ExpenseCategoryDTO
    {
        public int Id { get; set; }
        public string ExpenseCategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
