using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Position_Description {
/// <summary>
/// PostId
/// </summary>
public const string PostId = "PostId";
/// <summary>
/// PostName
/// </summary>
public const string PostName = "PostName";
/// <summary>
/// IsDelete
/// </summary>
public const string IsDelete = "IsDelete";
/// <summary>
/// IsDistribution
/// </summary>
public const string IsDistribution = "IsDistribution";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Position_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(PostId, "PostId");
propertyField_Dictionary.Add(PostName, "PostName");
propertyField_Dictionary.Add(IsDelete, "IsDelete");
propertyField_Dictionary.Add(IsDistribution, "IsDistribution");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("PostId", PostId);
fieldProperty_Dictionary.Add("PostName", PostName);
fieldProperty_Dictionary.Add("IsDelete", IsDelete);
fieldProperty_Dictionary.Add("IsDistribution", IsDistribution);
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
return "Y_Position";}
public static string[] GetPrimaryProperties()
{
    return new string[] { PostId };
}
public static string GetTableName()
{
return "Y_Position";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
