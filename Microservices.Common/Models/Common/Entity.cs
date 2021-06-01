using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Common.Models.Common
{
    public interface IEntity
    {
        int Id { get; set; }

    }
    public class Entity : BaseEntity, IEntity
    {
        public virtual int Id { get; set; }
    }
    public abstract class BaseEntity
    {

    }
}
