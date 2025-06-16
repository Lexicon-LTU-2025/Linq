using System;
using System.Diagnostics;
using System.Threading.Channels;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = GetPersons().ToArray();
            //persons.ForEach(p =>
            //    {
            //        Console.WriteLine(p);
            //        Debug.WriteLine(p);
            //        //....
            //    });

            //persons.ToList().ForEach(Console.WriteLine);
            //persons.ForEach(p => Console.WriteLine(p));
            //persons.ForEach(Do);
            //persons.ForEach(p => Do(p));
            Person? p = persons[0];
            var e = p switch
            {
                not null and { Age: > 12 } => true,
                _ => false
            };
           

            var res = persons.CustomWhere(p => p.Age > 30)
                             .Where(p => p.Name.Length > 0);

            foreach ( var person in res)
            {
                Console.WriteLine(person);
            }

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, };
            var res2 = numbers.CustomWhere(x => x < 5);


            var res3 = persons.Where(p => p.Age > 30 /*&& p.Name.Length > 2*/);

            //...

             res3 = res3.Where(p => p.Name.Length > 2);
                              
            //.Sum();
            //...

            var newRes = res3.Select(p => p.Age);


            var res4 = persons.Where(IsOver30)
                              .Select(p => new PersonDto
                              {
                                  FirstName = p.Name,
                                  NamesLength = p.Name.Length
                              }).ToList();


            foreach (var person in res4)
            {
                Console.WriteLine(person.NamesLength);
                Console.WriteLine(person.GetType().Name);
            }

        }

        private static void Do(Person p)
        {
            //.....
        }

        private static bool IsOver30(Person p)
        {
            return p.Age > 30;
        }

        private static List<Person> GetPersons()
        {
            return new List<Person>
                {
                new("Nisse", 20),
                new("Nisse", 21),
                new("Nisse", 22),
                new("Nisse", 23),
                new("Nisse", 24),
                new("Nisse", 24),
                new("Nisse", 26),
                new("Pelle" ,65),
                new("Pelle" ,60),
                new("Pelle" ,62),
                new("Olle" , 66),
                new("Sara" , 54),
                new("Ida" ,  36),
                new("Fia",   45),
                new("Lisa",   45),
                new("Sophia-Magdalena", 32),
            };
        }
    }
}

