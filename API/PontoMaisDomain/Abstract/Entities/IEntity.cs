using System;

namespace PontoMaisDomain.Abstract.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}