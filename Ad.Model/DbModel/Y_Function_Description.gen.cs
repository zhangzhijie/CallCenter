using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Function_Description {
/// <summary>
/// FunctionId
/// </summary>
public const string FunctionId = "FunctionId";
/// <summary>
/// FunctionName
/// </summary>
public const string FunctionName = "FunctionName";
/// <summary>
/// FunctionType
/// </summary>
public const string FunctionType = "FunctionType";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Function_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(FunctionId, "FunctionId");
propertyField_Dictionary.Add(FunctionName, "FunctionName");
propertyField_Dictionary.Add(FunctionType, "FunctionType");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("FunctionId", FunctionId);
fieldProperty_Dictionary.Add("FunctionName", FunctionName);
fieldProperty_Dictionary.Add("FunctionType", FunctionType);
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
return "Y_Function";}
public static string[] GetPrimaryProperties()
{
    return new string[] { FunctionId };
}
public static string GetTableName()
{
return "Y_Function";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
