using Xunit;
using FluentAssertions;
using Pokedex.Domain.SeedWork;
using Pokedex.Domain.Pokemon;

namespace Pokedex.Tests;

public class GenderRatioTests
{
    [Fact]
    public void GenderRatio_cannot_have_negative_values()
    {
        var ex = Assert.Throws<DomainException>(() => GenderRatio.From(-50, 50));
        ex.GetType().Should().Be(typeof(DomainException));
    }

    [Fact]
    public void Two_GenderRatios_with_same_values_are_equal()
    {
        var genderRatio1 = GenderRatio.From(40,60);
        var genderRatio2 = GenderRatio.From(40, 60);

        var areEqual = genderRatio1 == genderRatio2;

        areEqual.Should().BeTrue();
        genderRatio1.Should().Be(genderRatio2);
    }

    [Fact]
    public void Ratios_should_be_calculated_when_one_param_is_missing()
    {
        var genderRatio1 = GenderRatio.From(0, 60);
        genderRatio1.MaleRatio.Should().Be(40);

        var genderRatio2 = GenderRatio.From(60, 0);
        genderRatio2.FemaleRatio.Should().Be(40);
    }
}