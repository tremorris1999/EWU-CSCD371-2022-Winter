using System;
using System.Collections.Generic;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        private Lazy<IEnumerable<string>>_CSV = new(() =>
        {
                FileStream fileStream = File.OpenRead("People.csv");
                StreamReader reader = new StreamReader(fileStream);
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
            //call csvrows property for data source
            IEnumerable<string> csv = CsvRows;

            List<string> list = new();
            
            //query the states from the data source
            foreach(string row in csv)
            {
                string[] props = row.Split(',');
                
                //eliminate duplicate results to ensure the list is unique
                if(list.Contains<String>(props[6]))
                {
                    list.Add(props[6]);
                }
            }


            //sort the list alphabetically
            return list.OrderBy(s => s);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
