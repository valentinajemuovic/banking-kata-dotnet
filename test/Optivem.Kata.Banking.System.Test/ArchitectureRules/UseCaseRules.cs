using ArchUnitNET.Fluent.Syntax.Elements.Types;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Optivem.Kata.Banking.Test.ArchitectureRules;

public class UseCasesRules
{
    private static GivenTypesConjunctionWithDescription UseCases() =>
        Types()
            .That()
            .ResideInNamespace(Namespaces.UseCases, true)
            .As("Use Cases");

    [Fact]
    public void ShouldNotDependOnInfrastructure() =>
        UseCases()
            .Should()
            .NotDependOnAny(Namespaces.Infrastructure)
            .Check();

    [Fact]
    public void UseCaseClassesShouldResideInUseCases() =>
        Classes()
            .That()
            .HaveNameEndingWith("UseCase")
            .Should()
            .ResideInNamespace(Namespaces.UseCases, true)
            .Check();

    [Fact]
    public void UseCaseClassesShouldImplementUseCaseInterface() =>
        Classes()
            .That()
            .HaveNameEndingWith("UseCase")
            .Should()
            .ImplementInterface("IRequestHandler", true)
            .Check();
}