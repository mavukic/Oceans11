using System;
using System.Collections.Generic;

#nullable disable

namespace Oceans11.Models
{
    public partial class RequiredSkillsForHeist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int Members { get; set; }
        public int HeistId { get; set; }

        public virtual Heist Heist { get; set; }
    }
}
