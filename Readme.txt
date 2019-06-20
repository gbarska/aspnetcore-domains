dotnet new sln -n PaymentContext

mkdir PaymentContext.Domain
mkdir PaymentContext.Shared
mkdir PaymentContext.Tests

cd PaymentContext.Domain
dotnet new classlib

cd PaymentContext.Shared
dotnet new classlib

cd PaymentContext.Tests
dotnet new mstest

dotnet sln add PaymentContext.Domain/PaymentContext.Domain.csproj
dotnet sln add PaymentContext.Shared/PaymentContext.Shared.csproj
dotnet sln add PaymentContext.Tests/PaymentContext.Tests.csproj

//Domain
dotnet add reference ../PaymentContext.Shared/PaymentContext.Shared.csproj


//Tests

dotnet add reference ../PaymentContext.Shared/PaymentContext.Shared.csproj
dotnet add reference ../PaymentContext.Domain/PaymentContext.Domain.csproj

