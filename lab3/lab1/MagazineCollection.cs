using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

//TODO:
//1) Rename dict1 and dict2

namespace lab3
{
    public class MagazineCollection<TKey>
    {
        private Dictionary<TKey, Magazine> collection;
        private KeySelector<TKey> keyGenerator; 

        public MagazineCollection(KeySelector<TKey> method)
        {
            keyGenerator = method;
            collection = new Dictionary<TKey, Magazine>();
        }

        public void AddDefaults(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Magazine magazine = Inputs.inputMagazine();
                collection.Add(keyGenerator(magazine), magazine);
            }
        }
        
        public Double MaxRatingElement
        {
            get
            {
                if (collection == null) return 0.0;
                else
                {
                    return collection.Values.Max(obj => obj.Rating);
                }
            }
        }

        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> grouping
        {
            get
            {
                return collection.GroupBy(obj => obj.Value.Frequency);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return collection.Where(obj => obj.Value.Frequency == value);
        }

        override public string ToString()
        {
            foreach (KeyValuePair<TKey, Magazine> item in collection)
            {
                Console.WriteLine("Key:");
                item.Key.ToString();
                Console.WriteLine("Magazine:");
                item.Value.ToString();
            }

            return "";
        }
        
        public void ToShortString()
        {
            foreach (KeyValuePair<TKey, Magazine> item in collection)
            {
                Console.WriteLine("Key:");
                item.Key.ToString();
                Console.WriteLine("Magazine:");
                item.Value.ToShortString();
            }
        }
    }
}
