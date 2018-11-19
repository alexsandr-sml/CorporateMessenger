using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ListExtension
    {
        public static List<T> Add<T>(this List<T> items, T element) where T : class
        {
            items.Add(element);
            return items;
        }

        public static List<T> AddRange<T>(this List<T> items, IEnumerable<T> elements) where T : class
        {
            items.AddRange(elements);
            return items;
        }

        public static List<T> AddElementToBegin<T>(this List<T> items, T element) where T : class
        {
            return new List<T>()
                .Add<T>(element)
                .AddRange<T>(items);
        }
    }
}
