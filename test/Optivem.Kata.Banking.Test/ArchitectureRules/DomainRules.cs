using ArchUnitNET.Fluent.Syntax.Elements.Types;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Optivem.Kata.Banking.Test.ArchitectureRules;

public class DomainRules
{
    private static GivenTypesConjunction DomainTypes() =>
        Types()
            .That()
            .ResideInNamespace(Namespaces.Domain, true);

    [Fact]
    public void DomainCanOnlyAccessDomainItselfAndExceptions() =>
        DomainTypes()
            .Should()
            .OnlyDependOnTypesThat()
            .ResideInNamespace($"{Namespaces.Domain}|{Namespaces.Exceptions}", true)
            .Check();

    [Fact]
    public void DomainTypesShouldStayPure() =>
        DomainTypes()
            .Should()
            .NotHaveAnyAttributesThat()
            .AreNot(Namespaces.CompilerServices, true)
            .Check();

    [Fact]
    public void DomainPropertiesShouldStayPure() =>
        PropertyMembers()
            .That()
            .AreDeclaredIn(DomainTypes())
            .Should()
            .NotHaveAnyAttributesThat()
            .AreNot(Namespaces.CompilerServices, true)
            .Check();

    [Fact]
    public void DomainMethodsShouldStayPure() =>
        MethodMembers()
            .That()
            .AreDeclaredIn(DomainTypes())
            .Should()
            .NotHaveAnyAttributesThat()
            .AreNot(Namespaces.CompilerServices, true)
            .Check();
}