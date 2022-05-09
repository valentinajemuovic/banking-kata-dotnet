using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Syntax.Elements.Types;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Optivem.Kata.Banking.Core.UseCases.WithdrawFunds;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Optivem.Kata.Banking.Test.ArchitectureRules;

public static class ArchUnitExtensions
{
    private static readonly Architecture Architecture =
        new ArchLoader()
            .LoadAssemblies(typeof(WithdrawFundsUseCase).Assembly)
            .Build();

    public static GivenTypesConjunction TypesInCore() =>
        Types()
            .That()
            .Are(Architecture.Types);

    public static void Check(this IArchRule rule)
        => rule.Check(Architecture);
}