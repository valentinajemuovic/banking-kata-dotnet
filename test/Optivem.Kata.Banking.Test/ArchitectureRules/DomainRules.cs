using ArchUnitNET.Fluent.Syntax.Elements.Members.MethodMembers;
using ArchUnitNET.Fluent.Syntax.Elements.Members.PropertyMembers;
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

    private static GivenMethodMembersConjunction DomainMethods() =>
        MethodMembers()
            .That()
            .AreDeclaredIn(DomainTypes());

    private static GivenPropertyMembersConjunction DomainProperties() =>
        PropertyMembers()
            .That()
            .AreDeclaredIn(DomainTypes());

    [Fact]
    public void CanOnlyAccessDomainItselfAndExceptions() =>
        DomainTypes()
            .Should()
            .OnlyDependOnTypesThat()
            .ResideInNamespace($"{Namespaces.Domain}|{Namespaces.Exceptions}", true)
            .Check();

    [Fact]
    public void TypesShouldStayPure() =>
        DomainTypes()
            .Should()
            .NotHaveAnyAttributesThat()
            .AreNot(Namespaces.CompilerServices, true)
            .Check();

    [Fact]
    public void PropertiesShouldStayPure() =>
        DomainProperties()
            .Should()
            .NotHaveAnyAttributesThat()
            .AreNot(Namespaces.CompilerServices, true)
            .Check();

    [Fact]
    public void MethodsShouldStayPure() =>
        DomainMethods()
            .Should()
            .NotHaveAnyAttributesThat()
            .AreNot(Namespaces.CompilerServices, true)
            .Check();
}