using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Application.Groups
{
    public class Group
    {
        public int Id { get; set; } = 0;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FellowshipRoutine { get; set; }
    }
}
