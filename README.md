# LifeEngine

[![CI](https://github.com/AlexiPaps/LifeEngine/actions/workflows/ci.yml/badge.svg)](https://github.com/AlexiPaps/LifeEngine/actions/workflows/ci.yml)

A small calculation engine for **disability insurance (TAE, tab af erhvervsevne)**.

## Tech stack

- **.NET 10 / C#** — the engine.
- **xUnit** and **GitHub Actions** for tests and CI.

## Repository layout

```
src/LifeEngine.Core/
tests/LifeEngine.Tests/
DECISIONS.md
```

Design decisions and conventions are listed in [DECISIONS.md](DECISIONS.md).

## Run

Requires the .NET 10 SDK.

```
dotnet test
```

## License

[MIT](LICENSE)
