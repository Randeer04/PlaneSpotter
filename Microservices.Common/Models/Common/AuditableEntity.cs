using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservices.Common.Models.Common
{
    public interface IAuditableEntity
    {
        DateTime CreatedDateTime { get; set; }
        string CreatedUser { get; set; }
        DateTime LastUpdatedDateTime { get; set; }
        string LastUpdatedUser { get; set; }
    }
    public abstract class AuditableEntity<T> : Entity, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDateTime { get; set; }
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedUser { get; set; }
        [ScaffoldColumn(false)]
        public DateTime LastUpdatedDateTime { get; set; }
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string LastUpdatedUser { get; set; }

    }
}
