# RebelQuery Project

## Table of contents

<!--ts-->
* [Description](#description)
<!--te-->

## Description

RebelQuery is a powerfull sql lib for C#.

```C#
using RebelQuery;

namespace testApp
{
    public class Client : RebelQuery.RQuery
    {
        public int id {get; set;}
        public string Name {get; set;}
        public string LastName {get; set;}
        public string UserName {get; set;}
        public string Password {get; set;}
        public string Email {get; set;}
    }
}
```

```C#
static void Main(string[] args)
{
    var cli = new Client();
    var dataQuery = cli
    .PassWhereArgs(new{ID ="=0 AND", Name = "='eu' OR", Email = "='r@rab.com'"})
    .PassSelectArgs(new{cli.id, cli.Name, cli.LastName, cli.UserName})
    .RQuerySelect<Client>("");

    Console.WriteLine(sou.UserMessage);

}
```

**Coding Lang:**
C#
