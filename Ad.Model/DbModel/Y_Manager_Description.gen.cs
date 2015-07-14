using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Manager_Description {
/// <summary>
/// ManagerId
/// </summary>
public const string ManagerId = "ManagerId";
/// <summary>
/// LoginName
/// </summary>
public const string LoginName = "LoginName";
/// <summary>
/// Pwd
/// </summary>
public const string Pwd = "Pwd";
/// <summary>
/// IsUse
/// </summary>
public const string IsUse = "IsUse";
/// <summary>
/// PermissionId
/// </summary>
public const string PermissionId = "PermissionId";
/// <summary>
/// Channel
/// </summary>
public const string Channel = "Channel";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Manager_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(ManagerId, "ManagerId");
propertyField_Dictionary.Add(LoginName, "LoginName");
propertyField_Dictionary.Add(Pwd, "Pwd");
propertyField_Dictionary.Add(IsUse, "IsUse");
propertyField_Dictionary.Add(PermissionId, "PermissionId");
propertyField_Dictionary.Add(Channel, "Channel");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("ManagerId", ManagerId);
fieldProperty_Dictionary.Add("LoginName", LoginName);
fieldProperty_Dictionary.Add("Pwd", Pwd);
fieldProperty_Dictionary.Add("IsUse", IsUse);
fieldProperty_Dictionary.Add("PermissionId", PermissionId);
fieldProperty_Dictionary.Add("Channel", Channel);
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
return "Y_Manager";}

public static string[] GetPrimaryProperties()
{
    return new string[] { ManagerId };
}
public static string GetTableName()
{
return "Y_Manager";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
