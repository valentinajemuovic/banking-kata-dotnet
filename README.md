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

Installing Stryker:

```
dotnet tool install -g dotnet-stryker
```

Set Environment variables in Visual Studio for Optivem.Kata.Banking.Web:
1. Right-hand click the project Optivem.Kata.Banking.Web
2. Click on "Properties"
3. Select "Debug" from the left-hand side menu
4. Inside "General" click on "Open debug launch profiles UI"
5. In the section "Environment variables" input the following (feel free to adapt the SQL_SERVER_CONNECTION_STRING based on your local machine):

```
ASPNETCORE_ENVIRONMENT=Development,SQL_SERVER_CONNECTION_STRING=Data Source/=localhost;Initial Catalog/=BankingKata;Integrated Security/=True;MultipleActiveResultSets/=True;
```

For running the tests, the environment variable `SQL_SERVER_CONNECTION_STRING` needs to be configered in Solution Items > `test.runsettings`.

Inside Visual Studio, click on Test > Configure Run Settings > Select Solution Wide runsettings File, then select `test.runsettings` (note: this is temporary since I saw that Autodetect wasn't working, but I will try again to find a solution for Autodetect).


## Instructions

Environment Variables

```
$env:SQL_SERVER_CONNECTION_STRING='Data Source=localhost;Initial Catalog=BankingKata;Integrated Security=True;MultipleActiveResultSets=True;'
```

Update Database:

```
dotnet ef database update --project .\src\Optivem.Kata.Banking.Infrastructure
```

Run Build

```
dotnet build
```

Run Tests:

```
dotnet test
```

Run Mutation Testing:

```
cd .\test\Optivem.Kata.Banking.Core.Test
PM> dotnet stryker
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

## Contributing

If you'd like to contribute, see instructions here https://github.com/valentinacupac/banking-kata-dotnet/blob/main/CONTRIBUTING.md
