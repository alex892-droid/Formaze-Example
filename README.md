# Formaze Examples

Sample projects, documentation and issue tracker for **[Formaze](https://formaze.dev)** — the no-code form builder for Blazor (MudBlazor).

[![NuGet](https://img.shields.io/nuget/v/Formaze.Blazor.MudBlazor.svg?label=NuGet)](https://www.nuget.org/packages/Formaze.Blazor.MudBlazor)
[![Downloads](https://img.shields.io/nuget/dt/Formaze.Blazor.MudBlazor.svg?label=Downloads)](https://www.nuget.org/packages/Formaze.Blazor.MudBlazor)
[![License: MIT](https://img.shields.io/badge/Examples-MIT-blue.svg)](LICENSE)

> **What this repo is:** examples, docs and an issue tracker only.
> **What it is not:** the Formaze source. The `Formaze.Blazor.MudBlazor` package is a **commercial, closed-source** product. The code in *this* repository (the example projects) is MIT-licensed — see [LICENSE](LICENSE) for the exact scope.

- **Live demo:** https://formaze.dev/demo
- **Buy a license:** https://formaze.dev/checkout
- **Package on NuGet:** https://www.nuget.org/packages/Formaze.Blazor.MudBlazor

## Install

```sh
dotnet add package Formaze.Blazor.MudBlazor
```

## Quick start

Formaze builds on top of MudBlazor, so register MudBlazor first, then Formaze:

```csharp
// Program.cs
using Formaze.Blazor.Mudblazor.Tools;

builder.Services.AddMudServices();
builder.Services.AddFormazeJson(options =>
{
    options.LicenseKey = "YOUR_LICENSE_KEY"; // omit for the Free tier
});
```

Drop a form into any page by pointing the component at your model (the component lives in
`Formaze.Blazor.Mudblazor.Components` — add it to `_Imports.razor`):

```razor
@using Formaze.Blazor.Mudblazor.Components

<FormazeComponent T="ContactForm"
                  Key="contact"
                  Model="_model"
                  EditMode="_isAdmin"
                  OnValidSubmit="HandleSubmit" />

@code {
    private ContactForm _model = new();
    private bool _isAdmin;

    private Task HandleSubmit(EditContext context)
    {
        // _model is populated and valid here
        return Task.CompletedTask;
    }
}
```

`Key` and `Model` are required. `EditMode="true"` lets an admin configure the form live; `OnValidSubmit` is an `EventCallback<EditContext>`.

## Storage backends

Pick how form definitions are persisted when you register Formaze:

| Method | Use case |
| --- | --- |
| `AddFormazeJson(...)` | JSON files on disk (default) |
| `AddFormazeInMemory(...)` | Prototyping and tests |
| `AddFormaze<TStore>()` | Your own store implementation |
| `AddFormaze(factory)` | Store built from a factory |
| `AddFormazeEfCore<TDbContext>()` | EF Core — needs the `Formaze.Blazor.MudBlazor.EFCore` companion package |

## Supported field types

Field editors are inferred from your model's property types and DataAnnotations:

| Property | Rendered as |
| --- | --- |
| `string` | Text input |
| `string` + `[EmailAddress]` | Email input |
| `string` + `[Url]` | URL input |
| `string` + `[DataType(DataType.MultilineText)]` | Textarea |
| `int` / `long` / `decimal` / `double` / `float` | Numeric input |
| `bool` | Checkbox |
| `DateTime` / `DateOnly` / `DateTimeOffset` | Date picker |
| `TimeSpan` | Time picker |
| `enum` | Dropdown |

Nullable variants of the above are supported as well (use `DateTime?` or `DateOnly?` for an optional date).

## Examples

Most examples live in a single runnable gallery app — `dotnet run` it and browse one page per feature:

```sh
cd samples/Formaze.Examples.Gallery
dotnet run
```

| Sample | Page | Shows |
| --- | --- | --- |
| Contact form | [BasicForm.razor](samples/Formaze.Examples.Gallery/Components/Pages/BasicForm.razor) | `string` / email / textarea fields with DataAnnotations validation |
| Multi-field form | [MultiField.razor](samples/Formaze.Examples.Gallery/Components/Pages/MultiField.razor) | enum, bool, date and numeric fields |
| Admin mode | [AdminMode.razor](samples/Formaze.Examples.Gallery/Components/Pages/AdminMode.razor) | `EditMode` live form configuration |
| All field types | [FieldTypes.razor](samples/Formaze.Examples.Gallery/Components/Pages/FieldTypes.razor) | Every inferred editor (text, email, url, textarea, number, checkbox, date, time, enum) in one model |
| Submission handling | [SubmissionHandling.razor](samples/Formaze.Examples.Gallery/Components/Pages/SubmissionHandling.razor) | Custom `SubmitLabel` and reading the bound model in `OnValidSubmit` |
| Custom field renderer | [CustomRenderer.razor](samples/Formaze.Examples.Gallery/Components/Pages/CustomRenderer.razor) | Overriding the rendering of a field (new in 1.1.0) |
| Conditional fields | [ConditionalFields.razor](samples/Formaze.Examples.Gallery/Components/Pages/ConditionalFields.razor) | Show a field based on another field's value, configured in the editor (new in 1.1.0) |

Storage backends that register a different store live in their own projects:

```sh
cd samples/Formaze.Examples.EfCore     # or Formaze.Examples.CustomStore
dotnet run
```

| Sample | Shows |
| --- | --- |
| [EF Core store](samples/Formaze.Examples.EfCore) | Persisting definitions in SQLite via `AddFormazeEfCore<TDbContext>()` + `modelBuilder.UseFormaze()` |
| [Custom store](samples/Formaze.Examples.CustomStore) | Implementing `IFormazeStore` by hand and registering it with `AddFormaze<TStore>()` |

## Support

Found a bug or have a question about the examples? [Open an issue](https://github.com/alex892-droid/Formaze-Examples/issues). For licensing and product questions, see [formaze.dev](https://formaze.dev).
