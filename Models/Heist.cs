using System;
using System.Collections.Generic;

#nullable disable

namespace Oceans11.Models
{
    public partial class Heist
    {
        public Heist()
        {
            MembersInHeists = new HashSet<MembersInHeist>();
            RequiredSkillsForHeists = new HashSet<RequiredSkillsForHeist>();
        }

        public int Id { get; set; }
        public string NameOfHeist { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<MembersInHeist> MembersInHeists { get; set; }
        public virtual ICollection<RequiredSkillsForHeist> RequiredSkillsForHeists { get; set; }
    }
}
