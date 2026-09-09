# RebelQuery

SQL helper for .NET. Map SQL Server rows to POCOs with parameterized queries. The class name is the table name; the connection string lives on the type.

Supports **netstandard2.0** and **net8.0**.

## Install

```bash
dotnet add package RebelQuery
```

## Quick start

```csharp
using RebelQuery;

public class Client : RQuery
{
    protected override string ConnectionString =>
        "Server=localhost;Database=App;Trusted_Connection=True;";

    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

var db = new Client();

var result = await db.RQueryExecuteAsync<Client>(
    "SELECT Id, Name, Email FROM Client WHERE Id = @id",
    new { id = 6 });

if (result.IsSuccessful)
{
    foreach (var row in result.Content)
        Console.WriteLine($"{row.Id} {row.Name}");
}
```

`@name` values are sent as `SqlParameter`. Do not concatenate user input into the SQL string.

## Fluent select / update

```csharp
var listed = await db
    .PassSelectArgs(new { db.Name, db.Email })
    .PassWhereArgs(new { Id = "=6" })
    .RQuerySelectAsync<Client>();

var updated = await db
    .PassWhereArgs(new { Id = "=6" })
    .RQueryUpdateAsync<Client>(new { Name = "Ada", Email = "ada@example.com" });
```

For `INSERT` and `DELETE`, use explicit SQL.

## Result

Every `*Async` method returns `RQueryResponse<T>`: `IsSuccessful`, `Content`, `RowsAffected`, `DevMessage`, `UserMessage`, `SqlString`.

Export: `result.ToExcell()`.

## More

Docs and source: [github.com/rafaelrabelos/RebelQuery](https://github.com/rafaelrabelos/RebelQuery)

License: [GNU GPL v3](https://github.com/rafaelrabelos/RebelQuery/blob/master/LICENSE.txt)
