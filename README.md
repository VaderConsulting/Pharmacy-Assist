# Pharmacy Assist

This is a Visual Studio 2012 C# Windows Forms suite that manages Savemor pharmacy website and product data. The main Pharmacy Assist exe (assembly 1.3.16.0, .NET 3.5) logs on against SQL Server, then edits catalogs, products, documents, events, tasks, and recurrences, and can publish files over FTP. Helper WinExe projects export SQL tables (DataExport), import RPM pricing, browse document trees, and check recurrence strings. Open `Pharmacy Assist.sln` in Visual Studio 2012. This is a historical working copy from Dave Robinson / VaderConsulting.

**Source last updated:** 2014-06-09  
**Language:** C#  
**Target:** .NET 3.5 (main, Model, EFModel, Pharmacy Docs, RPM Import); .NET 4.0 (DataExport, Recurrance Checker)  
**Output:** WinForms exe, class libraries, InstallShield setups

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `Pharmacy Assist` | C# | WinForms exe (.NET 3.5) | Main Savemor product/website manager (logon, catalogs, documents, events, tasks, FTP) |
| `Model` | C# | class library (.NET 3.5) | Domain types (Product, Store, Document, Task, Role, Condition) |
| `EFModel` | C# | class library (.NET 3.5) | Entity Framework PAModel EDMX against SQL Server |
| `Pharmacy Docs` | C# | WinForms exe (.NET 3.5) | Document-tree browser over the same SQL/FTP settings |
| `RPM Import` | C# | WinForms exe (.NET 3.5) | Import RPM/Corum pricing and catalogues into Pharmacy Assist SQL |
| `DataExport` | C# | WinForms exe (.NET 4.0) | Dump SQL Server tables to files |
| `Recurrance Checker` | C# | WinForms exe (.NET 4.0) | Decode recurrence strings via RecurrenceGenerator |
| `Pharmacy Assist Setup` | InstallShield | setup | Installer for Pharmacy Assist |
| `RPM Import Setup` | InstallShield | setup | Installer for RPM Import |

## How to open

Open `Pharmacy Assist.sln` in Visual Studio 2012. The solution also references sibling Historical Dev projects that are not in this folder (`Core`, `i00SpellCheck`, `Linqkit`, `File Association`, `System.Windows.Forms.Calendar`, `RecurranceGenerator`, `Zeta HTML Edit Control`). Connection strings and FTP defaults are gitignored; copy the matching `*.example` files.

## Attribution and provenance

From Dave Robinson's Historical Dev archive (OneDrive folder `Pharmacy Assist`). Assembly company Vader Consulting; assembly copyright 2014 Vader Consulting; assembly description notes calendar code from Jose Menendez Póo (CodeProject). NuGet packages (Entity Framework 5, jQuery UI 1.10.3, Microsoft.Data.OData) lived under `packages/` and are not committed.

## License

MIT License. Copyright (c) 2026 VaderConsulting.
