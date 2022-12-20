using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Common
{
    public enum ChurchRole
    {
        Pastor = 1,
        Deacon = 2,
        YouthLeader = 3,
        Others = 4
    }
    public enum ActiveStatus
    {
        Active = 1,
        InActive = 2
    }

    public enum UserGroup
    {
        Admin = 1,
        Others = 10
    }

    public enum Relation
    {
        GrandFather = 1,
        GrandMother = 2,
        Father = 3,
        Mother = 4,
        Son = 5,
        Daughter = 6,   
        Self = 19

    }
}
