namespace Pokedex.Domain.Pokemon;

public class GenderRatio : ValueObject<GenderRatio>
{
    public decimal? MaleRatio { get; private set; }
    public decimal? FemaleRatio { get; private set; }

    public static GenderRatio From(decimal? maleRatio, decimal? femaleRatio)
    {
        maleRatio ??= 0;
        femaleRatio ??= 0;

        var total = maleRatio + femaleRatio;

        if (maleRatio < 0 || femaleRatio < 0)
            throw new DomainException("Invalid gender ratio.");
        
        if (total < 0 || total > 100)
            throw new DomainException("Invalid gender ratio.");

        if (maleRatio == 0)
            maleRatio = 100 - femaleRatio;

        if (femaleRatio == 0)
            femaleRatio = 100 - maleRatio;

        return new GenderRatio(maleRatio, femaleRatio);
    }

    protected GenderRatio() { }

    protected override bool EqualsCore(GenderRatio other)
    {
        return
            MaleRatio == other.MaleRatio &&
            FemaleRatio == other.FemaleRatio;
    }

    protected override int GetHashCodeCore()
    {
        unchecked
        {
            int hashCode = MaleRatio.GetHashCode();
            hashCode = (hashCode * 397) ^ FemaleRatio.GetHashCode();
            return hashCode;
        }
    }

    private GenderRatio(decimal? maleRatio, decimal? femaleRatio)
    {
        MaleRatio = maleRatio;
        FemaleRatio = femaleRatio;
    }
}
