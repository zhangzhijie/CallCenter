using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Util
{
    public static class ArrayHelper
    {
        /// <summary>
        /// 选择数组中的一系列元素，而是删除它们并用其它值代替(功能同php中的array_splice)
        /// </summary>
        /// <typeparam name="T">数组元素类型</typeparam>
        /// <param name="array">规定数组</param>
        /// <param name="offset">数值。如果 offset 为正，则从输入数组中该值指定的偏移量开始移除。如果 offset 为负，则从输入数组末尾倒数该值指定的偏移量开始移除。</param>
        /// <param name="length">数值。如果省略该参数，则移除数组中从 offset 到 结尾的所有部分。如果指定了 length 并且为正值，则移除这么多元素。如果指定了 length 且为负值，则移除从 offset 到数组末尾倒数 length 为止中间所有的元素。</param>
        /// <param name="replaceArray">被移除的元素由此数组中的元素替代。如果没有移除任何值，则此数组中的元素将插入到指定位置。</param>
        /// <returns>选择数组中的一系列元素，而是删除它们并用其它值代替</returns>
        public static IEnumerable<T> Array_splice<T>(IEnumerable<T> array, int offset, int? length = null, params T[] replaceArray)
        {
           List<T> ls = new List<T>();
           if (array == null || array.Count() == 0)
           {
               return ls;
           }

           int len = length.Value;
           if (length == null)
           {
               len = array.Count() - offset;
           }
           if (offset < 0)
           {
               offset = array.Count() + offset;
           }

           ls.AddRange(array.Take(offset));
           if (replaceArray != null && replaceArray.Count() > 0)
           {
               ls.AddRange(replaceArray);
                  //array.Take(offset) + array.Take(offset + length);
           }
           if (offset + len < array.Count())
           {
               ls.AddRange(array.Skip(offset + len));
           }

           return ls;
       }
    }
}
