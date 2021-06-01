using Microservices.Common.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microservices.Common.Models.PlaneSpotter
{
    [Table("Sighting")]
    public class Sighting :AuditableEntity<long>
    {
        [MaxLength(128)]
        public string Make { get; set; }

        [MaxLength(128)]
        public string Model { get; set; }
        [MaxLength(7)]
        public string Registration { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }
        public DateTime SightingDate { get; set; }

    }
}
