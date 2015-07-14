using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Generate_Key_Description {
/// <summary>
/// KeyType
/// </summary>
public const string KeyType = "KeyType";
/// <summary>
/// KeyNumber
/// </summary>
public const string KeyNumber = "KeyNumber";
/// <summary>
/// CurrentDate
/// </summary>
public const string CurrentDate = "CurrentDate";
/// <summary>
/// PreValue
/// </summary>
public const string PreValue = "PreValue";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Generate_Key_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(KeyType, "KeyType");
propertyField_Dictionary.Add(KeyNumber, "KeyNumber");
propertyField_Dictionary.Add(CurrentDate, "CurrentDate");
propertyField_Dictionary.Add(PreValue, "PreValue");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("KeyType", KeyType);
fieldProperty_Dictionary.Add("KeyNumber", KeyNumber);
fieldProperty_Dictionary.Add("CurrentDate", CurrentDate);
fieldProperty_Dictionary.Add("PreValue", PreValue);
}
public static Dictionary<string, string> GetPropertyField_Dictionary()
{
     return propertyField_Dictionary;
}
public static Dictionary<string, string> GetFieldProperty_Dictionary()
{
 	return fieldProperty_Dictionary;
}
public static string GetEntityName()
{
return "Y_Generate_Key";}

public static string[] GetPrimaryProperties()
{
    return new string[] { KeyType };
}
public static string GetTableName()
{
return "Y_Generate_Key";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
