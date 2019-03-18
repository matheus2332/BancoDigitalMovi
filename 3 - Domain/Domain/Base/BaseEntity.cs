using System.ComponentModel.DataAnnotations;
using CrossCutting.Base;

namespace Domain.Base
{
    public class BaseEntity<T> : MainError, IBaseEntity<T>
    {
        [Key]
        public T Id { get; private set; }

        public void SetId(T id)
        {
            Id = id;
        }
    }
}