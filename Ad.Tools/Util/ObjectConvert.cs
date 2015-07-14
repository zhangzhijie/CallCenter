using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ad.Util
{
    public static class ObjectConvert
    {
        /// <summary>
        /// 对象的属性或字段赋值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性或字段名</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public static bool SetProperyOrFieldValue(object obj, string propertyOrFieldName, object value)
        {
            var p = obj.GetType().GetProperty(propertyOrFieldName);
            if (p != null)
            {
                p.SetValue(obj, value, null);
                return true;
            }

            var f = obj.GetType().GetField(propertyOrFieldName);
            if (f != null)
            {
                f.SetValue(obj, value);
                return true;
            }
            return false;
        }


        /// <summary>
        /// 对象的属性赋值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public static bool SetProperyValue(object obj, string propertyName, object value)
        {
            var p = obj.GetType().GetProperty(propertyName);
            if (p != null)
            {
                p.SetValue(obj, value, null);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 对象的字段赋值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        public static bool SetFieldValue(object obj, string fieldName, object value)
        {
            var f = obj.GetType().GetField(fieldName);
            if (f != null)
            {
                f.SetValue(obj, value);
                return true;
            }
            return false;
        }
 
 
       /// <summary>
       /// 获取对象的属性或字段的值
       /// </summary>
       /// <typeparam name="T">对象类型</typeparam>
       /// <param name="obj">对象</param>
       /// <param name="fieldOrProperytName">属性或字段的名称</param>
       /// <returns>结果对象</returns>
        public static ResultU<T> GetProperytOrFieldValue<T>(object obj, string fieldOrProperytName)
        {
            var p = obj.GetType().GetProperty(fieldOrProperytName);
            if (p != null)
            {
                T val = (T)p.GetValue(obj, null);
                return new ResultU<T>(val, true);
            }

            var f = obj.GetType().GetField(fieldOrProperytName);
            if (f != null)
            {
                T val = (T)f.GetValue(obj);
                return new ResultU<T>(val, true);
            }

            return new ResultU<T>(false);
        }

        /// <summary>
        /// 获取对象的属性的值
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="properytName">属性的名称</param>
        /// <returns>结果对象</returns>
        public static ResultU<T> GetProperyValue<T>(object obj, string propertyName)
        {
            var p = obj.GetType().GetProperty(propertyName);
            if (p != null)
            {
                T val = (T)p.GetValue(obj, null);
                return new ResultU<T>(val, true);
            }

            return new ResultU<T>(false);
        }

        /// <summary>
        /// 获取对象的字段的值
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="fieldName">字段的名称</param>
        /// <returns>结果对象</returns>

        public static ResultU<T> GetFieldValue<T>(object obj, string fieldName)
        {
            var f = obj.GetType().GetField(fieldName);
            if (f != null)
            {
                T val = (T)f.GetValue(obj);
                return new ResultU<T>(val, true);
            }

            return new ResultU<T>(false);
        }

        /// <summary>
        /// 对象赋值
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objectBySet">被赋值对象</param>
        /// <param name="objectOriginal">值</param>
        public static void SetValue<T>(T objectBySet, T objectValue)
        {
            PropertyInfo[] props = objectValue.GetType().GetProperties();
           
            for (int i = 0; i < props.Length; i++)
            {
                object value = props[i].GetValue(objectValue, null);
                props[i].SetValue(objectBySet, value, null);
            }
        }

        /// <summary>
        /// 设置实体所有字符类型属性的字符串值
        /// </summary>
        /// <param name="obj">实体</param>
        /// <param name="str">字符串值</param>
        public static void SetPropertiesStringVal_NullToStr(object obj, string str)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                if (prop.GetValue(obj, null) == null && prop.PropertyType.Equals(typeof(string)))
                {
                    prop.SetValue(obj, str, null);
                }
            }
        }

        /// <summary>
        /// 对象转换方法
        /// </summary>
        /// <typeparam name="A">A类型对象</typeparam>
        /// <typeparam name="B">B类型对象</typeparam>
        /// <param name="objectA">对象A</param>
        /// <param name="objectB">对象B</param>
        public static void ConvertAToB<A, B>(A objectA, ref B objectB)
        {
            PropertyInfo[] propsB = objectB.GetType().GetProperties();
            PropertyInfo[] propsA = objectA.GetType().GetProperties();
            for (int i = 0; i < propsB.Length; i++)
            {
                for (int j = 0; j < propsA.Length; j++)
                {
                    if (propsB[i].Name == propsA[j].Name)
                    {
                        object value = propsA[j].GetValue(objectA, null);
                        if (default(DateTime).Equals(value))
                        {
                            continue;
                        }
                        propsB[i].SetValue(objectB, propsA[j].GetValue(objectA, null), null);
                    }
                }
            }
        }

        /// <summary>
        /// 对象转换方法
        /// </summary>
        /// <typeparam name="A">A类型对象</typeparam>
        /// <typeparam name="B">B类型对象</typeparam>
        /// <param name="objectA">对象A</param>
        /// <returns>转化后的对象</returns>
        public static B ConvertAToB<A, B>(A objectA) where B : new()
        {
            B objectB = new B();
            ConvertAToB<A, B>(objectA, ref objectB);
            return objectB;
        }

        public static int GetIntValue(object obj)
        {
            return GetIntValue(obj, 0);
        }

        public static int GetIntValue(object obj, int defaultValue)
        {
            if (obj == null)
                return defaultValue;
            else if (obj is int)
                return (int)obj;
            else if (obj is long)
                return (int)(long)obj;
            else if (obj is uint)
                return (int)(uint)obj;
            else if (obj is ulong)
                return (int)(ulong)obj;
            else if (obj is short)
                return (int)(short)obj;
            else if (obj is ushort)
                return (int)(ushort)obj;
            else if (obj is float)
                return (int)(float)obj;
            else if (obj is double)
                return (int)(double)obj;
            else if (obj is decimal)
                return (int)(decimal)obj;
            else if (obj is byte)
                return (int)(byte)obj;
            else if (obj is bool)
                return (bool)obj == false ? 0 : 1;
            else if (obj is string)
            {
                string s = obj as string;
                int l;
                if (int.TryParse(s, out l))
                {
                    return l;
                }
            }
            return defaultValue;
        }

        public static long GetLongValue(object obj)
        {
            return GetLongValue(obj, 0);
        }

        public static long GetLongValue(object obj, long defaultValue)
        {
            if (obj == null)
                return defaultValue;
            else if (obj is long)
                return (long)obj;
            else if (obj is int)
                return (long)(int)obj;
            else if (obj is uint)
                return (long)(uint)obj;
            else if (obj is ulong)
                return (long)(ulong)obj;
            else if (obj is short)
                return (long)(short)obj;
            else if (obj is ushort)
                return (long)(ushort)obj;
            else if (obj is float)
                return (long)(float)obj;
            else if (obj is double)
                return (long)(double)obj;
            else if (obj is decimal)
                return (long)(decimal)obj;
            else if (obj is byte)
                return (long)(byte)obj;
            else if (obj is bool)
                return (bool)obj == false ? 0 : 1;
            else if (obj is string)
            {
                string s = obj as string;
                long l;
                if (long.TryParse(s, out l))
                {
                    return l;
                }
            }
                
            return defaultValue;
        }


        public static decimal GetDecimalValue(object obj)
        {
            return GetDecimalValue(obj, 0);
        }

        public static decimal GetDecimalValue(object obj, decimal defaultValue)
        {
            if (obj == null)
                return defaultValue;
            else if (obj is decimal)
                return (decimal)obj;
            else if (obj is long)
                return (decimal)(long)obj;
            else if (obj is int)
                return (decimal)(int)obj;
            else if (obj is uint)
                return (decimal)(uint)obj;
            else if (obj is ulong)
                return (decimal)(ulong)obj;
            else if (obj is short)
                return (decimal)(short)obj;
            else if (obj is ushort)
                return (decimal)(ushort)obj;
            else if (obj is float)
                return (decimal)(float)obj;
            else if (obj is double)
                return (decimal)(double)obj;
            else if (obj is byte)
                return (decimal)(byte)obj;
            else if (obj is bool)
                return (bool)obj == false ? 0 : 1;
            else if (obj is string)
            {
                string s = obj as string;
                decimal l;
                if (decimal.TryParse(s, out l))
                {
                    return l;
                }
            }
            return defaultValue;
        }

        public static float GetFloatValue(object obj)
        {
            return GetFloatValue(obj, 0);
        }

        public static float GetFloatValue(object obj, float defaultValue)
        {
            if (obj == null)
                return defaultValue;
            else if (obj is float)
                return (float)obj;
            else if (obj is long)
                return (float)(long)obj;
            else if (obj is int)
                return (float)(int)obj;
            else if (obj is uint)
                return (float)(uint)obj;
            else if (obj is ulong)
                return (float)(ulong)obj;
            else if (obj is short)
                return (float)(short)obj;
            else if (obj is ushort)
                return (float)(ushort)obj;
            else if (obj is decimal)
                return (float)(decimal)obj;
            else if (obj is double)
                return (float)(double)obj;
            else if (obj is byte)
                return (float)(byte)obj;
            else if (obj is bool)
                return (bool)obj == false ? 0 : 1;
            else if (obj is string)
            {
                string s = obj as string;
                float l;
                if (float.TryParse(s, out l))
                {
                    return l;
                }
            }
            return defaultValue;
        }

        public static double GetDoubleValue(object obj)
        {
            return GetDoubleValue(obj, 0);
        }

        public static double GetDoubleValue(object obj, double defaultValue)
        {
            if (obj == null)
                return defaultValue;
            else if (obj is double)
                return (double)obj;
            else if (obj is long)
                return (double)(long)obj;
            else if (obj is int)
                return (double)(int)obj;
            else if (obj is uint)
                return (double)(uint)obj;
            else if (obj is ulong)
                return (double)(ulong)obj;
            else if (obj is short)
                return (double)(short)obj;
            else if (obj is ushort)
                return (double)(ushort)obj;
            else if (obj is decimal)
                return (double)(decimal)obj;
            else if (obj is double)
                return (double)(float)obj;
            else if (obj is byte)
                return (double)(byte)obj;
            else if (obj is bool)
                return (bool)obj == false ? 0 : 1;
            else if (obj is string)
            {
                string s = obj as string;
                double l;
                if (double.TryParse(s, out l))
                {
                    return l;
                }
            }
            return defaultValue;
        }



        public static uint GetUIntValue(object obj)
        {
            return GetUIntValue(obj, 0);
        }

        public static uint GetUIntValue(object obj, uint defaultValue)
        {
            if (obj == null)
                return defaultValue;
            else if (obj is uint)
                return (uint)obj;
            else if (obj is long)
                return (uint)(long)obj;
            else if (obj is int)
                return (uint)(int)obj;
            else if (obj is ulong)
                return (uint)(ulong)obj;
            else if (obj is short)
                return (uint)(short)obj;
            else if (obj is ushort)
                return (uint)(ushort)obj;
            else if (obj is double)
                return (uint)(double)obj;
            else if (obj is decimal)
                return (uint)(decimal)obj;
            else if (obj is double)
                return (uint)(float)obj;
            else if (obj is byte)
                return (uint)(byte)obj;
            else if (obj is bool)
                return (bool)obj == false ? (uint)0 : 1;
            else if (obj is string)
            {
                string s = obj as string;
                uint l;
                if (uint.TryParse(s, out l))
                {
                    return l;
                }
            }
            return defaultValue;
        }

        public static ulong GetULongValue(object obj)
        {
            return GetULongValue(obj, 0);
        }

        public static ulong GetULongValue(object obj, ulong defaultValue)
        {
            if (obj == null)
                return defaultValue;
            else if (obj is ulong)
                return (ulong)obj;
            else if (obj is long)
                return (ulong)(long)obj;
            else if (obj is int)
                return (ulong)(int)obj;
            else if (obj is uint)
                return (ulong)(uint)obj;
            else if (obj is ulong)
                return (ulong)(ulong)obj;
            else if (obj is short)
                return (ulong)(short)obj;
            else if (obj is ushort)
                return (ulong)(ushort)obj;
            else if (obj is double)
                return (ulong)(double)obj;
            else if (obj is decimal)
                return (ulong)(decimal)obj;
            else if (obj is double)
                return (ulong)(float)obj;
            else if (obj is byte)
                return (ulong)(byte)obj;
            else if (obj is bool)
                return (bool)obj == false ? (ulong)0 : 1;
            else if (obj is string)
            {
                string s = obj as string;
                ulong l;
                if (ulong.TryParse(s, out l))
                {
                    return l;
                }
            }
            return defaultValue;
        }

        public static string GetChinaBoolString(bool? b)
        {
            if (b == null)
            {
                return "";
            }

            return b.Value ? "是" : "否";
        }

        public static string GetDateTimeString(DateTime? datetime, string stringFormat)
        {
            if (datetime == null)
            {
                return "";
            }
            return datetime.Value.ToString(stringFormat);
        }
    }
}