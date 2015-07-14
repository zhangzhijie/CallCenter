using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_KnowledgeBaseChanges_Description {
/// <summary>
/// Id
/// </summary>
public const string Id = "Id";
/// <summary>
/// KnowledgeCode
/// </summary>
public const string KnowledgeCode = "KnowledgeCode";
/// <summary>
/// StuffId
/// </summary>
public const string StuffId = "StuffId";
/// <summary>
/// StuffName
/// </summary>
public const string StuffName = "StuffName";
/// <summary>
/// DeptId
/// </summary>
public const string DeptId = "DeptId";
/// <summary>
/// DeptName
/// </summary>
public const string DeptName = "DeptName";
/// <summary>
/// OperateType
/// </summary>
public const string OperateType = "OperateType";
/// <summary>
/// OperateName
/// </summary>
public const string OperateName = "OperateName";
/// <summary>
/// OperateDate
/// </summary>
public const string OperateDate = "OperateDate";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_KnowledgeBaseChanges_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(Id, "Id");
propertyField_Dictionary.Add(KnowledgeCode, "KnowledgeCode");
propertyField_Dictionary.Add(StuffId, "StuffId");
propertyField_Dictionary.Add(StuffName, "StuffName");
propertyField_Dictionary.Add(DeptId, "DeptId");
propertyField_Dictionary.Add(DeptName, "DeptName");
propertyField_Dictionary.Add(OperateType, "OperateType");
propertyField_Dictionary.Add(OperateName, "OperateName");
propertyField_Dictionary.Add(OperateDate, "OperateDate");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("Id", Id);
fieldProperty_Dictionary.Add("KnowledgeCode", KnowledgeCode);
fieldProperty_Dictionary.Add("StuffId", StuffId);
fieldProperty_Dictionary.Add("StuffName", StuffName);
fieldProperty_Dictionary.Add("DeptId", DeptId);
fieldProperty_Dictionary.Add("DeptName", DeptName);
fieldProperty_Dictionary.Add("OperateType", OperateType);
fieldProperty_Dictionary.Add("OperateName", OperateName);
fieldProperty_Dictionary.Add("OperateDate", OperateDate);
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
return "Y_KnowledgeBaseChanges";}

public static string[] GetPrimaryProperties()
{
    return new string[] { Id };
}
public static string GetTableName()
{
return "Y_KnowledgeBaseChanges";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
