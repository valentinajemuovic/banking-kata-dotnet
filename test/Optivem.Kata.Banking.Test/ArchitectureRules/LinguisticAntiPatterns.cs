using ArchUnitNET.Fluent.Syntax.Elements.Members.MethodMembers;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Optivem.Kata.Banking.Test.ArchitectureRules;

public class LinguisticAntiPatterns
{
    private static GivenMethodMembersThat Methods()
        => MethodMembers()
            .That()
            .AreNoConstructors()
            .And();

    [Fact]
    public void NoGetMethodShouldReturnVoid() =>
        Methods()
            .HaveName("Get[A-Z].*", useRegularExpressions: true).Should()
            .NotHaveReturnType(typeof(void))
            .Check();

    [Fact]
    public void IserAndHaserShouldReturnBooleans() =>
        Methods()
            .HaveName("Is[A-Z].*", useRegularExpressions: true).Or()
            .HaveName("Has[A-Z].*", useRegularExpressions: true).Should()
            .HaveReturnType(typeof(bool))
            .Check();

    [Fact]
    public void SettersShouldNotReturnSomething() =>
        Methods()
            .HaveName("Set[A-Z].*", useRegularExpressions: true).Should()
            .HaveReturnType(typeof(void))
            .Check();
}