using Ad.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Util
{
    /// <summary>
    /// 两个对象的泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    public  class TwoObj<T,V>
    {
        public T Text { get; set; }
        public V Value { get; set; }

        public TwoObj(T text, V value)
        {
            Text = text;
            Value = value;
        }

        public TwoObj()
        {
        }

        public  const string Field_Text = "Text";
        public const string Field_Value = "Value";

        public static List<TwoObj<T,V>> CreateList(IEnumerable<IModel> models, string propertyTextName, string propertyValueName){
            List<TwoObj<T, V>> ls = new List<TwoObj<T, V>>();
            foreach (IModel model in models)
            {
                var entity = new TwoObj<T, V>();
                entity.Text =  model.GetPropertyValue<T>(propertyTextName);
                entity.Value = model.GetPropertyValue<V>(propertyValueName);
                ls.Add(entity);
            }
            return ls;
        }

        
    }

    public static class TwoObj
    {
        public  const string Field_Key = "Key";
        public const string Field_Value = "Value";
    }
}
