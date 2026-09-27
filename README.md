# Pharmacy Assist

Manages all Pharmacy website and Product data. The C# WinForms suite edits catalogs, products, documents, events, tasks, and recurrences, and can publish files over FTP. Companion projects export SQL tables, import RPM/Corum pricing, browse the document tree, and check recurrence strings. Calendar views include code from Jose Menendez Póo (CodeProject).

**Source last updated:** 2014-06-09  
**Language:** C#  
**Target:** .NET 3.5 (main WinForms exe, Model, EFModel, Pharmacy Docs, RPM Import); .NET 4.0 (DataExport, Recurrance Checker)  
**Output:** WinForms exe

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `Pharmacy Assist` | C# | WinForms exe (.NET 3.5) | Main pharmacy website and product manager (logon, catalogs, documents, events, tasks, FTP) |
| `Model` | C# | class library (.NET 3.5) | Domain types (Product, Store, Document, Task, Role, Condition) |
| `EFModel` | C# | class library (.NET 3.5) | Entity Framework PAModel EDMX against SQL Server |
| `Pharmacy Docs` | C# | WinForms exe (.NET 3.5) | Document-tree browser over the same SQL/FTP settings (in-tree; not listed in the sln) |
| `RPM Import` | C# | WinForms exe (.NET 3.5) | Import RPM data into the Pharmacy Assist database |
| `DataExport` | C# | WinForms exe (.NET 4.0) | Dump SQL Server tables to files |
| `Recurrance Checker` | C# | WinForms exe (.NET 4.0) | Decode recurrence strings via RecurrenceGenerator |
| `Pharmacy Assist Setup` | InstallShield | setup | Installer for Pharmacy Assist |
| `RPM Import Setup` | InstallShield | setup | Installer for RPM Import |

## How to open

Open `Pharmacy Assist.sln` in Visual Studio (VS 2013 solution). The sln also references sibling Historical Dev folders via `..\` that are other repos, not this tree: `Zeta HTML Edit Control`, `i00SpellCheck`, `Linqkit`, `Core`, `System.Windows.Forms.Calendar`, `RecurranceGenerator`, and `File Association`. Connection strings, FTP defaults, and the DataExport designer login fields are gitignored; copy the matching `*.example` files.

## Requirements

- Visual Studio 2013, .NET Framework 3.5, .NET Framework 4.0

## Attribution and provenance

Working copy from my Historical Dev folder.

Dave Robinson / VaderConsulting. Assembly title Pharmacy Assist; assembly company Vader Consulting; assembly copyright 2014 Vader Consulting. Assembly description records calendar code from Jose Menendez Póo (CodeProject, http://www.codeproject.com/Articles/38699/A-Professional-Calendar-Agenda-View-That-You-Will). NuGet packages in `packages/` (including jQuery UI 1.10.3) are gitignored. Source was extracted from a truncated archive zip (central directory cut off; present source imported as-is). See `THIRD_PARTY_NOTICES.md`.

## License

MIT License. Copyright (c) 2026 VaderConsulting. See `LICENSE`.
