# RebelQuery Project

## Table of contents

<!--ts-->
* [Description](#description)
* [Technical Info](#technical)
* [Install](#install)
* [Running a Rebel Query](#Queryng)
  * [Configure a connection](#Connecting)
  * [Explicit Queries](#Explicit)
  * [Storing args](#Storing)
* [Examples](#Examples)
<!--te-->

## Description

RebelQuery is a powerfull sql lib for C#.

## Technical

Type: Nuget Package  
Version:1.0.3-alpha
Code: C#  
Dependencies: System.Data.SqlClient >= 4.6.1  

## Install

```bash
Install-Package RebelQuery -Version 1.0.3-alpha
```

## Queryng

That`s the base model structure to gets the query result.

```C#
using RebelQuery;

public class Client : RQuery
{
    [PrimaryKey]
    public int id {get; set;}
    public string Name {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
}
```

## Connecting

Setting up a connection.

```C#
static void Main(string[] args)
{
    RQueryResponse myClients;
    Client cli;

    cli = new Client();
    cli.ConnectionString = "YOUR_CONNECTION_STRING_INFO";
}

```

## Explicit

Running the queries

```C#
/*

Explicit queries are the traditional queries syntax. You can use it and to speed up your application`s database requests and run complex queries.

*/
myClients = cli.RQueryExecute<Client>("SELECT * FROM Client");
myClients = cli.RQueryExecute<Client>("SELECT * FROM Client WHERE id=0");

```

## Storing

Passing conditions before run a command.

```C#
/*

The below lines show how to store args before execute a RebelQuery query command.

Note the equivalent query the lines are corresponding to.
*/



/*

corresponds to:
SELECT * FROM Client

*/
cli.PassSelectArgs(new{});
cli.PassSelectArgs(null);
cli.PassSelectArgs();
cli.RQuerySelect<Client>();


/*

corresponds to:
SELECT Name, Email FROM Client

*/
cli
.PassSelectArgs(new{cli.Name, cli.Email})
.RQuerySelect<Client>();


/*

corresponds to:
SELECT Name, Email FROM Client WHERE id='6'

*/
cli
.PassSelectArgs(new{cli.Name, cli.Email})
.PassWhereArgs(new{id = "=6"})
.RQuerySelect<Client>();

/*

corresponds to:
UPDATE Client
SET Name='Rafael', LastName='Rabello',     Email='rafael_rabelo@live.com'
WHERE id=6

*/
cli
.PassWhereArgs(new{id = "=6"})
.RQueryUpdate<Anomalias>(new {
    Name = "Rafael",
    LastName = "Rabello",
    Email = "rafael_rabelo@live.com"
});


/*

Running a full example

*/

myClients = cli.RQuerySelect<Client>();
myClients = cli.RQueryExecute<Client>(DQL.SELECT);

if(myClients.IsSuccessful)
    foreach (var clients in myClients.Content)
        Console.WriteLine(
        " id: " + clients.id
        + "Name: " + clients.Name
        + "LastName: " + clients.LastName
        + "Email: " + clients.Email
        );
else
    Console.WriteLine(addressList.DevMessage);

```

## Examples

Comming...
