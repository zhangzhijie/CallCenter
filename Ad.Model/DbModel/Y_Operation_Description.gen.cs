using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Operation_Description {
/// <summary>
/// OperationId
/// </summary>
public const string OperationId = "OperationId";
/// <summary>
/// OperationName
/// </summary>
public const string OperationName = "OperationName";
/// <summary>
/// OperationType
/// </summary>
public const string OperationType = "OperationType";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Operation_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(OperationId, "OperationId");
propertyField_Dictionary.Add(OperationName, "OperationName");
propertyField_Dictionary.Add(OperationType, "OperationType");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("OperationId", OperationId);
fieldProperty_Dictionary.Add("OperationName", OperationName);
fieldProperty_Dictionary.Add("OperationType", OperationType);
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
return "Y_Operation";}
public static string[] GetPrimaryProperties()
{
    return new string[] { OperationId };
}
public static string GetTableName()
{
return "Y_Operation";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
