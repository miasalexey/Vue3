using System;
using System.Collections.Generic;
using Data.DBEntities;

namespace Data.Utils;

public static class Generator
{
    public static void DataGenerator()
    {
        /*var context = new Context();
        var listPersons = new 
            List<Person>()
        {
            new Person()
            {
                Name = "Алексей", SurName = "Мясниченко", Address = "Москва,пр-кт Ленина , 22/1",
                CountCriminalRecord = 1
            },
            new Person()
            {
                Name = "Степан", SurName = "Наибиулин", Address = "Москва, Московский, татьянин парк, 17/5",
                CountCriminalRecord = 0
            },
            new Person()
            {
                Name = "Петр", SurName = "Ванчинов", Address = "Москва, ул Москвитина, , 228/1",
                CountCriminalRecord = 0
            },
            new Person()
            {
                Name = "Иван", SurName = "Макаров", Address = "Москва,  г Щербинка, Остафьевское ш, 28",
                CountCriminalRecord = 0
            },
            new Person()
            {
                Name = "Дарья", SurName = "Дарьевенко", Address = "Москва, Головинское ш, 312 ",
                CountCriminalRecord = 2
            },
            new Person()
            {
                Name = "Анна", SurName = "Анненко", Address = "Москва,  Грайвороновский 2-й проезд, 4412",
                CountCriminalRecord = 0
            },
            new Person()
            {
                Name = "Ксения", SurName = "Ким", Address = "Москва, Дмитровское ш, 33", CountCriminalRecord = 4
            },
            new Person()
            {
                Name = "Виктор", SurName = "Ляшкин", Address = "Москва, Долгопрудная аллея, 30/1",
                CountCriminalRecord = 0
            },
            new Person()
            {
                Name = "Давид", SurName = "Амарян", Address = "Москва, Долгопрудненское ш, 36/2",
                CountCriminalRecord = 0
            }
        };
        foreach (var item in listPersons)
        {
            context.Persons?.Add(item);
        }

        var listCriminalCases = new List<CriminalCase>()
        {
            new CriminalCase()
            {
                DataRegistration = new DateTime(2020, 12, 31),
                Title = "Мужчина избил на красной площади деда мороза",
                Region = "Москва",
            },
            new CriminalCase()
            {
                DataRegistration = new DateTime(2021, 1, 3),
                Title = "Пьяный мужчина вылетел с ледяной горки",
                Region = "Москва",
            },
            new CriminalCase()
            {
                DataRegistration = new DateTime(2021, 1, 7),
                Title = "Мужчина пустил салют во дворе, попав в окно",
                Region = "Москва",
            },
            new CriminalCase()
            {
                DataRegistration = new DateTime(2021, 2, 14),
                Title = "Девушка обратилась о громких криках соседей," +
                        "ориентировчно не насильственного характера",
                Region = "Москва",
            },
            new CriminalCase()
            {
                DataRegistration = new DateTime(2020, 12, 31),
                Title = "Девушка обратилась о громких криках соседей," +
                        "ориентировчно не насильственного характера",
                Region = "Москва",
            }
        };
        foreach (var item in listCriminalCases)
        {
            context.CriminalCases?.Add(item);
        }


        var personInCriminalCase = new PersonInCriminalCase()
        {
            CriminalCase = listCriminalCases[0],
            Person = listPersons[2],
            Category = Category.Witness
        };


        var personInCriminalCase2 = new PersonInCriminalCase()
        {
            CriminalCase = listCriminalCases[1],
            Person = listPersons[1],
            Category = Category.Accused
        };

        var personInCriminalCase3 = new PersonInCriminalCase()
        {
            CriminalCase = listCriminalCases[2],
            Person = listPersons[3],
            Category = Category.Victim
        };
        context.PersonInCriminalCases?.AddRange(personInCriminalCase, personInCriminalCase2, personInCriminalCase3);
        context.SaveChanges();*/
    }
}