using LINQ_Demo;

var preservers = new List<CannedMeat>();
RandomFill(preservers);
foreach (var preserver in preservers)
{
    Console.WriteLine($"{preserver.Name} : {preserver.YearOfProduction}, {preserver.ExpirationDate}");
}
Console.WriteLine();

var expiredGoods = from good in preservers
    let years = DateTime.Now.Year - good.YearOfProduction
    where years > good.ExpirationDate
    select good.Name;
foreach (var good in expiredGoods)
{
    Console.Write($"{good} ");
}
Console.WriteLine();

var maxExpirationDate = preservers.MaxBy(p => p.ExpirationDate).ExpirationDate;
var result = preservers
    .Where(p => p.ExpirationDate >= maxExpirationDate)
    .Select(p => p.Name);
foreach (var good in result)
{
    Console.Write($"{good} ");
}
Console.WriteLine();

var result2 = preservers.FirstOrDefault(p => p.Name == "Meat_30");
if (result2 is null)
{
    Console.WriteLine("ERROR");
}

return;

void RandomFill(List<CannedMeat> list)
{
    var random = new Random();
    for (int i = 0; i < 20; i++)
    {
        list.Add(new CannedMeat
        {
            Name = $"Meat_{random.Next(1, 11)}",
            YearOfProduction = random.Next(1900, 2023),
            ExpirationDate = random.Next(1, 6)
        });
    }
}

/*var persons = new Dictionary<Guid, Person>()
{
    {Guid.NewGuid(), new Person
    {
        FirstName = "Name_1",
        LastName = "Family_1",
        DateOfBirth = new DateTime(1900, 5, 10)
    }},
    {Guid.NewGuid(), new Person
    {
        FirstName = "Name_2",
        LastName = "Family_1",
        DateOfBirth = new DateTime(1950, 5, 10)
    }},
    {Guid.NewGuid(), new Person
    {
        FirstName = "Name_3",
        LastName = "Family_1",
        DateOfBirth = new DateTime(1905, 5, 10)
    }},
    {Guid.NewGuid(), new Person
    {
        FirstName = "Name_11",
        LastName = "Family_2",
        DateOfBirth = new DateTime(1970, 5, 10)
    }},
    {Guid.NewGuid(), new Person
    {
        FirstName = "Name_12",
        LastName = "Family_2",
        DateOfBirth = new DateTime(1975, 7, 10)
    }},
    {Guid.NewGuid(), new Person
    {
        FirstName = "Name_13",
        LastName = "Family_2",
        DateOfBirth = new DateTime(1991, 8, 10)
    }}
};
PrintPersons(persons);

var result = from person in persons
    where person.Value.Age > 100
    select new { Id = person.Key, 
        Name = person.Value.FullName, 
        Age = person.Value.Age };
foreach (var item in result)
{
    Console.WriteLine($"{item.Id:N} : {item.Name} - {item.Age}");
}

return;

void PrintPerson(Person person)
{
    Console.WriteLine($"{person.FullName}, {person.Age}");
}
void PrintPersons(Dictionary<Guid, Person> persons)
{
    foreach (var (guid, person) in persons)
    {
        Console.Write($"{guid} -> ");
        PrintPerson(person);
    }
}*/