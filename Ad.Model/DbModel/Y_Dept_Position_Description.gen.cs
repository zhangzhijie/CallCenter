using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Dept_Position_Description {
/// <summary>
/// PermissionId
/// </summary>
public const string PermissionId = "PermissionId";
/// <summary>
/// PostId
/// </summary>
public const string PostId = "PostId";
/// <summary>
/// DepartId
/// </summary>
public const string DepartId = "DepartId";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Dept_Position_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(PermissionId, "PermissionId");
propertyField_Dictionary.Add(PostId, "PostId");
propertyField_Dictionary.Add(DepartId, "DepartId");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("PermissionId", PermissionId);
fieldProperty_Dictionary.Add("PostId", PostId);
fieldProperty_Dictionary.Add("DepartId", DepartId);
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
return "Y_Dept_Position";}

public static string[] GetPrimaryProperties()
{
    return new string[] { PostId };
}
public static string GetTableName()
{
return "Y_Dept_Position";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
