using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Picture: AuditableEntity
    {
        [Key]
        public long PictureId { get; set; }
        [Column(TypeName = "text")]
        public string PictureData { get; set; }
        public PictureType PictureType { get; set; }
        public long? StoryId { get; set; }
        public Story Story { get; set; }
        public long? SpaceId { get; set; }
        public Space Space { get; set; }
        public bool IsActive { get; set; }

    }
}
