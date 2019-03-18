namespace Domain.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; }

        void SetId(T id);
    }
}