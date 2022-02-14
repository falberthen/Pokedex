namespace Pokedex.Domain.SeedWork;

public abstract class StronglyTypedId<T> : ValueObject<StronglyTypedId<T>>
{
    private int _id;

    public int Value
    {
        get { return _id; }
        private set
        {
            if (value <= 0)
                throw new DomainException("A valid value must be provided.");

            _id = value;
        }
    }

    protected StronglyTypedId(int value)
    {
        Value = value;
    }

    protected override bool EqualsCore(StronglyTypedId<T> other)
    {
        return this.Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        unchecked
        {
            return Value.GetHashCode();
        }
    }
}