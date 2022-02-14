namespace Pokedex.Domain.SeedWork;

public class DomainRuleException : Exception
{
    public DomainRuleException(string message) : base(message) { }
}