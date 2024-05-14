using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Enums
{
    public enum Genre
    {
        Undefined = 0,
        Male = 1,
        Female = 2
    }
    public enum TypeUser
    {
        Principal = 1,
        Associated = 2
    }
    public enum BillingStatus
    {
        Unknown = 0,
        Pending = 1,
        Confirmed = 2,
        Rejected = 3
    }
    public enum PictureType
    {
        Space =1,
        Story = 2,
    }
}
