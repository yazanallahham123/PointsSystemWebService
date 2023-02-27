using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Core
{
   internal static class GenericHelpers
   {

      /// <summary>
      /// Generates tree of items from item list
      /// </summary>
      /// 
      /// <typeparam name="T">Type of item in collection</typeparam>
      /// <typeparam name="K">Type of parent_id</typeparam>
      /// 
      /// <param name="collection">Collection of items</param>
      /// <param name="id_selector">Function extracting item's id</param>
      /// <param name="parent_id_selector">Function extracting item's parent_id</param>
      /// <param name="root_id">Root element id</param>
      /// 
      /// <returns>Tree of items</returns>

      public static IEnumerable<CategoryTreeClass<T>> GenerateTree<T, K>(
          this IEnumerable<T> collection,
          Func<T, K> id_selector,
          Func<T, K> parent_id_selector,
          string Language,
          K root_id = default(K))
      {
         string key = string.Empty;
         if (Language == "ar") key = "ArabicName";
         else key = "EnglishName";

            //1 = root, 2 = child
            var cattype = "root";

            foreach (var c in collection.Where(c => parent_id_selector(c).Equals(root_id)))
         {
                if ((int)c.GetType().GetProperty("Type").GetValue(c) == 1)
                    cattype = "root";
                else
                    cattype = "child";
            yield return new CategoryTreeClass<T>
            {
               id = (int)c.GetType().GetProperty("Id").GetValue(c),
               text = (string)c.GetType().GetProperty(key).GetValue(c),
                type = cattype,
                children = collection.GenerateTree(id_selector, parent_id_selector, Language, id_selector(c))
            };
         }
      }
   }
}