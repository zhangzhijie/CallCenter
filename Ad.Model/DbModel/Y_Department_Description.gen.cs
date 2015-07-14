using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Department_Description {
/// <summary>
/// DepartId
/// </summary>
public const string DepartId = "DepartId";
/// <summary>
/// DepartName
/// </summary>
public const string DepartName = "DepartName";
/// <summary>
/// Code
/// </summary>
public const string Code = "Code";
/// <summary>
/// IsDelete
/// </summary>
public const string IsDelete = "IsDelete";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Department_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(DepartId, "DepartId");
propertyField_Dictionary.Add(DepartName, "DepartName");
propertyField_Dictionary.Add(Code, "Code");
propertyField_Dictionary.Add(IsDelete, "IsDelete");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("DepartId", DepartId);
fieldProperty_Dictionary.Add("DepartName", DepartName);
fieldProperty_Dictionary.Add("Code", Code);
fieldProperty_Dictionary.Add("IsDelete", IsDelete);
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
return "Y_Department";}
public static string[] GetPrimaryProperties()
{
    return new string[] { DepartId };
}
public static string GetTableName()
{
return "Y_Department";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
