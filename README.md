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

Run Build

```
dotnet build Optivem.Kata.Banking.sln
```

Run Tests:

```
dotnet test Optivem.Kata.Banking.sln
```

## Migrations

```
dotnet ef migrations add InitialMigration --project .\src\Optivem.Kata.Banking.Web
```
