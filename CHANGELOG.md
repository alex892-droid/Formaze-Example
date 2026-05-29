# Changelog

All notable changes to **Formaze** (`Formaze.Blazor.MudBlazor`) are documented here.
This project follows [Semantic Versioning](https://semver.org/).

## 1.1.0 — 2026-05-29

### Added
- **Custom field renderer** — supply a `CustomFieldRenderer` to override how an individual field is rendered, while falling back to the default renderer for the rest.
- **Conditional fields** — show or hide a field based on another field's value. Configured by an admin in `EditMode` and persisted with the form definition.
- **Wider field-type inference** — `[Url]` (and `DataType.Url`) now render a URL input, `TimeSpan` renders a time picker, `DateTimeOffset` renders a date field, and `long` / `float` are recognised as numeric inputs.

### Fixed
- `DateOnly` and `DateOnly?` properties now render and open the date-picker correctly.
- `EditMode` now works in any consuming app out of the box — the drag-and-drop behaviour ships with the package and no longer requires app-level script.

## 1.0.0 — 2026-05-04

### Added
- Initial release: render a fully-validated Blazor form from a plain C# model with DataAnnotations.
- Live `EditMode` form editor — groups, column layouts, field ordering, import/export.
- Inferred editors for text, email, multiline text, numeric, boolean, date and enum properties.
- Storage backends: JSON files, in-memory, custom `IFormazeStore`, and EF Core (`Formaze.Blazor.MudBlazor.EFCore`).
- Built on MudBlazor 9.x; multi-targets .NET 8, 9 and 10.
