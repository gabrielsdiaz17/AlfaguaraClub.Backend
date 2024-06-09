using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class Story: AuditableEntity
    {
        [Key]
        public long StoryId { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        public int PriorityRating { get; set; }
        [MaxLength(500)]
        public string Summary { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTimeOffset StoryPublishDate { get; set; }

        [ForeignKey("SpaceActivity")]
        public long? SpaceActivityId { get; set; }
        public SpaceActivity Activity { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Picture> Pictures { get; set; }

    }
}
