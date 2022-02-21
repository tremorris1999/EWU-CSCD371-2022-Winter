using System;
using System.Collections.Generic;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        private readonly Lazy<IEnumerable<string>>_CSV = new(() =>
        {
                FileStream fileStream = File.OpenRead("People.csv");
                StreamReader reader = new(fileStream);
                List<string> list = new();
                while(!reader.EndOfStream)
                {
                    string? line;
                    if((line = reader.ReadLine()) != null)
                        list.Add(line);
                }
                return list.Skip(1);
        });
        
        public IEnumerable<string> CsvRows { get {return _CSV.Value;} }

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
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            IEnumerable<(string, string)> query = from person in People
                                                  where person.EmailAddress.Equals(filter)
                                                  select (person.FirstName, person.LastName);

            return query;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
