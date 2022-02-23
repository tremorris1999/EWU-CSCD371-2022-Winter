using System;
using System.Collections.Generic;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        // This is included for testing hardcoded lists. Nothing else.
        public static IEnumerable<string>? TestList { get; set; }

        private readonly Lazy<IEnumerable<string>> _CSV = new(() =>
        {
            if (TestList == null)
            {
                FileStream fileStream = File.OpenRead("People.csv");
                StreamReader reader = new(fileStream);
                List<string> list = new();
                while (!reader.EndOfStream)
                {
                    string? line;
                    if ((line = reader.ReadLine()) != null)
                        list.Add(line);
                }
                return list.Skip(1);
            }

            return TestList;
        });
        
        public IEnumerable<string> CsvRows { get { return _CSV.Value; } }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {

            /**
             * Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
             * 0  1         2        3     4             5    6     7
             */
            return CsvRows.Select(item => item.Split(',')[6]).Distinct().OrderBy(item => item);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] statesList = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            string aggList = String.Join(", ", statesList);
            return aggList;
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            /**
             * Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
             * 0  1         2        3     4             5    6     7
             */
            get { return CsvRows.Select(item => item.Split(',')).OrderBy(item => item[6]).ThenBy(item => item[5]).ThenBy(item => item[7]).Select(item => new Person(item[1], item[2], new Address(item[4], item[5], item[6], item[7]), item[3])); }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            return people.Select(item => item.Address.State).Distinct().Aggregate((aggregate, next) => aggregate + "," + next);
        }

    }
}
