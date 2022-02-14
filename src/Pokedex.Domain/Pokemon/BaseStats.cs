namespace Pokedex.Domain.Pokemon;

public class BaseStats : ValueObject<BaseStats>
{
    public int? HP { get; private set; }
    public int? Attack { get; private set; }
    public int? Defense { get; private set; }
    public int? SpecialAttack { get; private set; }
    public int? SpecialDefense { get; private set; }
    public int? Speed { get; private set; }

    public static BaseStats From(PokemonData data)
    {
        ValidateStat(data.HP);
        ValidateStat(data.Attack);
        ValidateStat(data.Defense);
        ValidateStat(data.SpecialAttack);
        ValidateStat(data.SpecialDefense);
        ValidateStat(data.Speed);

        return new BaseStats(data);
    }

    protected BaseStats() { }

    protected override bool EqualsCore(BaseStats other)
    {
        return
            HP == other.HP &&
            Attack == other.Attack &&
            Defense == other.Defense &&
            SpecialAttack == other.SpecialAttack &&
            Speed == other.Speed;
    }

    protected override int GetHashCodeCore()
    {
        unchecked
        {
            int hashCode = HP.GetHashCode();
            hashCode = (hashCode * 397) ^ Attack.GetHashCode();
            hashCode = (hashCode * 397) ^ Defense.GetHashCode();
            hashCode = (hashCode * 397) ^ SpecialAttack.GetHashCode();
            hashCode = (hashCode * 397) ^ SpecialDefense.GetHashCode();
            hashCode = (hashCode * 397) ^ Speed.GetHashCode();
            return hashCode;
        }
    }

    private static void ValidateStat(int? stat)
    {
        if(stat != null && stat < 0)
            throw new DomainException("Invalid stat value.");
    }

    private BaseStats(PokemonData data)
    {        
        HP = data.HP ??= 0;
        Attack = data.Attack ??= 0;
        Defense = data.Defense ??= 0;
        SpecialAttack = data.SpecialAttack ??= 0;
        SpecialDefense = data.SpecialDefense ??= 0;
        Speed = data.Speed ??= 0;
    }
}