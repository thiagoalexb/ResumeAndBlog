using System;

namespace Resume.Data.Entities.Base
{
    public abstract class Entity
    {
        public Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool Deleted { get; private set; } = false;

        public virtual void SetCreationDate()
        {
            CreationDate = DateTime.Now;
        }

        public virtual void SetDeleted(bool value)
        {
            Deleted = value;
        }
    }
}
