using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApi.Models.Enuns;

namespace GymApi.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Nivelconta { get; set; }
        public ClasseEnum Classe { get; set; }
    }
}