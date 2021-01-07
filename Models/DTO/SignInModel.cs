using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.DTO
{
    public class SignInModel
    {
        [Required]
        public string Mail { get; set; }
    }
}
