# Banking Kata (.NET)

[![CI](https://github.com/valentinacupac/banking-kata-dotnet/actions/workflows/ci.yaml/badge.svg?branch=main)](https://github.com/valentinacupac/banking-kata-dotnet/actions/workflows/ci.yaml)

This Banking Kata illustates the application of TDD and Clean Architecture with a Use Case Driven Approach in .NET.

The Use Cases are:

- Open Account
- Withdraw Funds
- Deposit Funds (pending)
- View Account (pending)

## Prerequisites

.NET 6

Tool dotnet-ef needs to be installed:

```
dotnet tool install --global dotnet-ef
```


## Instructions

Update Database:

```
dotnet ef database update --project .\src\Optivem.Kata.Banking.Infrastructure
```

Run Build

```
dotnet build Optivem.Kata.Banking.sln
```

Run Tests:

```
dotnet test Optivem.Kata.Banking.sln
```

## Migrations

The following instructions are only relevant to contributors who are changing the DB schema.

To add a migration:

```
dotnet ef migrations add NameOfSomeMigration --project .\src\Optivem.Kata.Banking.Infrastructure
```

To remove a migration:

```
dotnet ef migrations remove --project .\src\Optivem.Kata.Banking.Infrastructure
```