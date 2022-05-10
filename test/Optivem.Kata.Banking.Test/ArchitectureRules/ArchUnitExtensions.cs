using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Optivem.Kata.Banking.Core.UseCases.WithdrawFunds;

namespace Optivem.Kata.Banking.Test.ArchitectureRules;

public static class ArchUnitExtensions
{
    private static readonly Architecture Architecture =
        new ArchLoader()
            .LoadAssemblies(typeof(WithdrawFundsUseCase).Assembly)
            .Build();

    public static void Check(this IArchRule rule)
        => rule.Check(Architecture);
}