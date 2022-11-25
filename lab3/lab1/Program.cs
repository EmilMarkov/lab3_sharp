using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab3
{
    class Program
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static public KeyValuePair<Edition, Magazine> generator(int j)
        {
            string value = (j * j * j * j * j * j).ToString();
            List<Person> persons = new List<Person>();
            List<Article> articles = new List<Article>();
            persons.Add(new Person(RandomString(j), RandomString(j), DateTime.Now));
            articles.Add(new Article(persons[0], RandomString(j), random.NextDouble()));
            Edition edition = new Edition(RandomString(j), j, DateTime.Now);
            Magazine magazine = new Magazine(RandomString(j), Frequency.Monthly, DateTime.Now, j, persons, articles);
            return new KeyValuePair<Edition, Magazine>(edition, magazine);
        }

        public static void Main()
        {
            KeySelector<string> keySelector = delegate(Magazine magazine)
            {
                return magazine.GetHashCode().ToString();
            };

            Console.WriteLine("============Task 1============");

            Magazine magazine = Inputs.inputMagazine();
            magazine.sortByTitle();
            Console.WriteLine(magazine.ToString() + "\n" + "\n");
            magazine.sortBySurname();
            Console.WriteLine(magazine.ToString() + "\n" + "\n");
            magazine.sortByRating();
            Console.WriteLine(magazine.ToString() + "\n" + "\n");

            Console.WriteLine("============Task 2============");

            MagazineCollection<string> collection = new MagazineCollection<string>(keySelector);
            collection.AddDefaults(2);
            Console.Write(collection.ToString());

            Console.WriteLine("============Task 3============");
            Console.WriteLine(collection.MaxRatingElement);
            foreach (var item in collection.FrequencyGroup(Frequency.Weekly))
            {
                Console.WriteLine(item.ToString());
            }
            foreach (var item in collection.grouping)
            {
                Console.WriteLine(item.Key);
                foreach (var part in item)
                {
                    Console.WriteLine(part.ToString());
                }
            }

            Console.WriteLine("============Task 4============");
            TestCollections<Edition, Magazine> testCollection = new TestCollections<Edition, Magazine>(1, generator);
            testCollection.searchInKeyList();
            testCollection.searchInKeyDict();
            testCollection.searchInValueList();
            testCollection.searchInStrDict();
        }
    }
}