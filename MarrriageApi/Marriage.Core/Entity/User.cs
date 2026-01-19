using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string GoogleId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
