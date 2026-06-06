# Changelog

All notable changes to **Formaze** (`Formaze.Blazor.MudBlazor`) are documented here.
This project follows [Semantic Versioning](https://semver.org/).

## 1.3.0 — 2026-06-06

### Added
- **Many new field types**, all inferred from your C# model and configurable in the editor: **phone** (`[Phone]`), **password** (`[DataType(DataType.Password)]`), **slider** (`[FormazeSlider]` on a numeric), **rating** stars (`[FormazeRating]` on an `int`), **file upload** (`byte[]`, or a `string` / `[DataType(DataType.Upload)]`), **searchable select** (autocomplete for enums, via `[FormazeSearchable]` or an editor toggle), **multi-select** (`List<enum>`), **tags** (`List<string>`), and **radio groups** (toggle a single-select enum to radio buttons in the editor).
- **`TimeOnly` / `TimeOnly?`** properties now render as a time picker.
- **Streaming file uploads** — a new `OnFileUpload` callback lets you stream the selected file straight to your own storage and keep only a reference (URL / id) in the model, instead of buffering it in memory.
- **`OnInvalidSubmit`** callback on `FormazeComponent` / `FormazeRenderComponent`, raised when a submit attempt fails validation (mirrors `OnValidSubmit`).
- **Multi-step forms (wizard)** — turn a form into a step-by-step wizard (one section per step) with a progress bar, Back/Next navigation and per-step validation, all from the editor.
- **Repeating sections** — a `List<T>` of a complex type renders as a repeatable sub-form (e.g. order line items) with Add/Remove, min/max rows and per-row validation.
- **Editor-driven validation** — admins can add validation rules per field without touching the model (regex, min/max value, length, text format, whole-numbers-only, date-in-future/past, item counts), plus **cross-field validation** (e.g. an end date that must be after a start date).
- **Richer conditional logic** — visibility conditions now support operators (`=`, `≠`, `>`, `<`, contains), multiple conditions combined with AND/OR, and conditional-required. Forms saved with the old single-condition format migrate automatically.
- **Section settings** — a per-section description and conditional visibility ("show this whole section only when…").
- **Field width** — a per-field "Full width" toggle and a "Width (columns)" setting to span 2–4 of the section's columns.
- **Dynamic fields reach parity** with model-backed fields — the "Create dynamic field" dialog now covers text, text area, email, URL, phone, password, number, date, time, checkbox, dropdown, radio, multi-select, tags, slider, file and rating.
- **Localization (i18n)** — Formaze's own UI strings and the entire editor ship in **English, French, Spanish and German**, following `CultureInfo.CurrentUICulture` automatically (English fallback). No host DI setup required.

### Changed
- **Redesigned field-configuration dialog** — organised into General / Options / Validation / Logic tabs, with a live, interactive preview pane that updates as you edit.

### Fixed
- The field-configuration dialog's **"Cancel" now discards edits** instead of keeping them (it edits a detached copy and commits only on Save).
- Text-rendered non-string properties (`Guid`, `Uri`) no longer throw at render.
- Editor validation rules now run on **dynamic fields** too.
- The rendered form submits through a single handler, so `OnValidSubmit` can no longer fire twice.

## 1.2.2 — 2026-05-29

### Fixed
- **Mixed-language validation messages** — the rendered form no longer triggers the browser's native validation bubble (which appeared in the visitor's browser language) on top of the app's own messages. Only the library's validation messages are shown now.

### Changed
- **Editor's conditional-field marker** — a field shown conditionally is now flagged with a discreet "Conditional" label above it, instead of a full-width line that made the editor preview taller than the actual form. The field toolbar icons are also correctly aligned.

## 1.2.0 — 2026-05-29

### Changed
- **Free tier is now unlimited on forms** — the previous 3-form cap has been removed. The "Powered by Formaze" watermark remains the Free-tier marker.
- **JSON configuration import/export is now Pro** — the editor's import/export buttons are reserved for Pro and Enterprise licenses.

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
