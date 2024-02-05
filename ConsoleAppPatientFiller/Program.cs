using Bogus;
using DataBasePatient.Data.Dtos;
using System.Net.Http.Json;

Console.WriteLine("Hello, this is console app for add 100 patient to ours API.");
Console.WriteLine("Push any button for start.");
Console.ReadKey();
Console.WriteLine("");

try 
{
    var httpClient = new HttpClient();
    var urlForPostPatient = @"https://localhost:5001/api/Patient";

    for (int i = 0; i < 100; i++)
    {
        var faker = new Faker();
        var patient = new PatientDto
        {
            Name = new NameDto
            {
                Use = $"official{i}",
                Family = faker.Person.LastName
            },
            Gender = i % 2 == 0 ? "Male" : "Female",
            Active = true,
            BirtDate = GetRandomDate(),
        };

        patient.Name.Given.AddRange(new string[] { faker.Person.UserName, faker.Person.FirstName});
        using var responce = await httpClient.PostAsJsonAsync<PatientDto>(urlForPostPatient, patient);
        var answer = await responce.Content.ReadAsStringAsync();
        Console.WriteLine($"{i} - {patient.Name.Family} was added to API, with Id - {answer}");
    }
}
catch(Exception ex)
{
    Console.WriteLine("Error was occured!");
    Console.WriteLine(ex.ToString());
}

static DateTime GetRandomDate()
{
    var randomTest = new Random();
    var startDate = new DateTime(2000, 12, 1);
    var endDate = new DateTime(2023, 12, 1);

    TimeSpan timeSpan = endDate - startDate;
    TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
    return startDate + newSpan;
}
