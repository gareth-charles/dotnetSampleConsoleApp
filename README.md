# Creating a DotNet project via Command Line Interface

The goal here is to set up a basic project split into three chunks:

- a Library containing shared code (we'll call it `Lib` in our examples)
- a suite of Tests for the library (called `Lib.Tests`)
- an Application that uses the library (called `App`)

All within a solution called `dotnetSampleConsoleApp`

The results of running the commands are shown in this repository, with minor changes (an example of calling `Lib` code from `UnitTest1.cs` and `Program.cs`).

## Install dependencies
```
# install dotnet on ubuntu
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0
```

## Create a Solution file
```
# create solution directory
mkdir dotnetSampleConsoleApp
cd dotnetSampleConsoleApp

# create solution
dotnet new sln
```

## Create the Library

```
# create a library project
dotnet new classlib -o Lib
dotnet sln add ./Lib/Lib.csproj
```

## Create A Unit Test Project

Uses [NUnit](https://nunit.org/) because it has decent documentation, but other suites are also available.

```
# create library unit tests
dotnet new nunit -o Lib.Tests
dotnet sln add ./Lib.Tests/Lib.Tests.csproj

# tests depend on lib they are testing
dotnet add ./Lib.Tests/Lib.Tests.csproj reference ./Lib/Lib.csproj

# run tests
dotnet test
```

## Create the Executable Project

```
# create an executable project
dotnet new console -o App
# add project to solution
dotnet sln ./dotnetSampleConsoleApp.sln add ./App/App.csproj

# executable depends on library
dotnet add ./App/App.csproj reference ./Lib/Lib.csproj

```

## Add Custom Code

At this point we can add in a bit of test code where `App` references `Lib` and `Lib.Tests` tests `Lib`.

Once that is done, we can run the project with:

```
# run project
dotnet run --project App
```