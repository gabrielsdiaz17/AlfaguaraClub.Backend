using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Enums
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
    public enum PictureType
    {
        Space =1,
        Story = 2,
        Product = 3,
    }
    public enum ActivityVisibility
    {
        PrivateMembresy=1,
        Public = 2,
    }
    public enum StatusRequest
    {
        Opened=1,
        Closed=2,
    }
}
