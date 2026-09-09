# RebelQuery

A small SQL helper for .NET. Map rows to POCOs, run parameterized queries, and keep connection details on the type that represents the table.

[![NuGet](https://img.shields.io/nuget/v/RebelQuery.svg)](https://www.nuget.org/packages/RebelQuery)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](LICENSE.txt)

## Requirements

- SQL Server
- **netstandard2.0** or **net8.0**
- `System.Data.SqlClient`

## Install

```bash
dotnet add package RebelQuery
```

```powershell
Install-Package RebelQuery
```

## Define a model

The class name is the table name. Override `ConnectionString` — it is `protected`, not a public setter.

```csharp
using RebelQuery;

public class Client : RQuery
{
    protected override string ConnectionString =>
        "Server=localhost;Database=App;Trusted_Connection=True;";

    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
```

`[PrimaryKey]` is skipped on generated `UPDATE` `SET` clauses.

## Explicit SQL (recommended)

Use `@name` placeholders. Values go to `SqlParameter` — they are not concatenated into the string.

```csharp
var db = new Client();

var result = await db.RQueryExecuteAsync<Client>(
    "SELECT Id, Name, LastName, Email FROM Client WHERE Id = @id",
    new { id = 6 });

if (result.IsSuccessful)
{
    foreach (var row in result.Content)
        Console.WriteLine($"{row.Id} {row.Name} {row.Email}");
}
else
{
    Console.WriteLine(result.DevMessage);
}
```

`CancellationToken` is optional on every `*Async` method.

```csharp
await db.RQueryExecuteAsync<Client>(
    "SELECT * FROM Client WHERE Email = @email",
    new { email = "user@example.com" },
    cancellationToken);
```

## Fluent select and update

Column names in `PassSelectArgs` become the `SELECT` list. `PassWhereArgs` builds `WHERE` with parameters. String values may include the operator (`=6`, `LIKE %a%`, `IN (1,2,3)`, `IS NULL`). Several conditions are joined with `AND`.

```csharp
var listed = await db
    .PassSelectArgs(new { db.Name, db.Email })
    .PassWhereArgs(new { Id = "=6" })
    .RQuerySelectAsync<Client>();
// SELECT Name, Email FROM Client WHERE Id = @rq_where_Id
```

```csharp
var updated = await db
    .PassWhereArgs(new { Id = "=6" })
    .RQueryUpdateAsync<Client>(new
    {
        Name = "Ada",
        LastName = "Lovelace",
        Email = "ada@example.com"
    });
// UPDATE Client SET Name=@rq_set_Name, LastName=@rq_set_LastName, Email=@rq_set_Email WHERE Id = @rq_where_Id
```

For `INSERT` and `DELETE`, prefer explicit SQL. The generated DML path still follows an `UPDATE`-style template.

## Response

`RQueryResponse<T>` is the return type of every execute method.

| Property | Meaning |
|---|---|
| `IsSuccessful` | Query ran without an exception |
| `Content` | Mapped rows (`List<T>`) |
| `RowsAffected` | Rows reported by the reader |
| `DevMessage` | Exception text for logs |
| `UserMessage` | Safe message for callers |
| `SqlString` | SQL that was sent (placeholders, not values) |

## Excel

```csharp
if (result.IsSuccessful)
{
    using var workbook = result.ToExcell();
    workbook.SaveAs("clients.xlsx");
}
```

## License

[GNU GPL v3](LICENSE.txt)
