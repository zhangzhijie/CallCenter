using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Post_Privilege_Description {
/// <summary>
/// PostId
/// </summary>
public const string PostId = "PostId";
/// <summary>
/// FunctionId
/// </summary>
public const string FunctionId = "FunctionId";
/// <summary>
/// OperationId
/// </summary>
public const string OperationId = "OperationId";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Post_Privilege_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(PostId, "PostId");
propertyField_Dictionary.Add(FunctionId, "FunctionId");
propertyField_Dictionary.Add(OperationId, "OperationId");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("PostId", PostId);
fieldProperty_Dictionary.Add("FunctionId", FunctionId);
fieldProperty_Dictionary.Add("OperationId", OperationId);
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
return "Y_Post_Privilege";}

public static string[] GetPrimaryProperties()
{
    return new string[] { PostId };
}
public static string GetTableName()
{
return "Y_Post_Privilege";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
