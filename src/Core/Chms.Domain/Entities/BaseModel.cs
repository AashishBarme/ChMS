using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chms.Domain.Entities;
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; } = null;
        public long CreatedBy { get; set; }
        public long UpdateBy { get; set; }

    }
