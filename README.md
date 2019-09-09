# RebelQuery Project

## Table of contents

<!--ts-->
* [Description](#description)
<!--te-->

## Description

RebelQuery is a powerfull sql lib for C#.

```C#
	using RebelQuery;

    public class Client : RQuery
    {
        public int id {get; set;}
        public string Name {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
    }

```


```C#
static void Main(string[] args)
{
	RQueryResponse myClients;
    Client cli;
	
	cli = new Client();
	cli.ConnectionString = "YOUR_CONNECTION_STRING_INFO";
	
}
```


```C#

	//Explicit query
	myClients = cli.RQueryExecute<Client>("SELECT * FROM Client");
	myClients = cli.RQueryExecute<Client>("SELECT * FROM Client WHERE id=0");

```


```C#

	//SELECT * FROM Client
    cli.PassSelectArgs(new{});
	cli.PassSelectArgs(null);
	cli.PassSelectArgs();
	cli.RQuerySelect<Client>();
	
	
	//SELECT Name, Email FROM Client
	cli.PassSelectArgs(new{cli.Name, cli.Email});
	
```


````C#
	
	//Running a query
	myClients = cli.RQuerySelect<Client>();
	myClients = cli.RQueryExecute<Client>(DQL.SELECT);

	if(myClients.IsSuccessful)
			foreach (var clients in myClients.Content)
				Console.WriteLine(
				" id: " + clients.id
				+ "Name: " + clients. Name
				+ "LastName: " + clients. LastName
				+ "Email: " + clients. Email
				);
		else
			Console.WriteLine(addressList.DevMessage);
```

**Coding Lang:**
C#
