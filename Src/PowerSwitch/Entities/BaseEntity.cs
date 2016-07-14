using System;

namespace PowerSwitch.Entities
{
    public class BaseEntity
    {
        public BaseEntity( )
        {
            this.Id = Guid.NewGuid( ).ToString("N");
        }
        public string Id { get; set; }
    }
}