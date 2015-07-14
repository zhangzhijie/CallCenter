using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Call_Cust_Description {
/// <summary>
/// DeptId
/// </summary>
public const string DeptId = "DeptId";
/// <summary>
/// DeptName
/// </summary>
public const string DeptName = "DeptName";
/// <summary>
/// StuffId
/// </summary>
public const string StuffId = "StuffId";
/// <summary>
/// StuffName
/// </summary>
public const string StuffName = "StuffName";
/// <summary>
/// EntryDate
/// </summary>
public const string EntryDate = "EntryDate";
/// <summary>
/// CustCode
/// </summary>
public const string CustCode = "CustCode";
/// <summary>
/// CustName
/// </summary>
public const string CustName = "CustName";
/// <summary>
/// AreaId
/// </summary>
public const string AreaId = "AreaId";
/// <summary>
/// Area
/// </summary>
public const string Area = "Area";
/// <summary>
/// Province
/// </summary>
public const string Province = "Province";
/// <summary>
/// ProvinceId
/// </summary>
public const string ProvinceId = "ProvinceId";
/// <summary>
/// Sex
/// </summary>
public const string Sex = "Sex";
/// <summary>
/// CustSourceId
/// </summary>
public const string CustSourceId = "CustSourceId";
/// <summary>
/// CustSource
/// </summary>
public const string CustSource = "CustSource";
/// <summary>
/// Phone
/// </summary>
public const string Phone = "Phone";
/// <summary>
/// Tel
/// </summary>
public const string Tel = "Tel";
/// <summary>
/// Email
/// </summary>
public const string Email = "Email";
/// <summary>
/// Job
/// </summary>
public const string Job = "Job";
/// <summary>
/// Product
/// </summary>
public const string Product = "Product";
/// <summary>
/// Question
/// </summary>
public const string Question = "Question";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Call_Cust_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(DeptId, "DeptId");
propertyField_Dictionary.Add(DeptName, "DeptName");
propertyField_Dictionary.Add(StuffId, "StuffId");
propertyField_Dictionary.Add(StuffName, "StuffName");
propertyField_Dictionary.Add(EntryDate, "EntryDate");
propertyField_Dictionary.Add(CustCode, "CustCode");
propertyField_Dictionary.Add(CustName, "CustName");
propertyField_Dictionary.Add(AreaId, "AreaId");
propertyField_Dictionary.Add(Area, "Area");
propertyField_Dictionary.Add(Province, "Province");
propertyField_Dictionary.Add(ProvinceId, "ProvinceId");
propertyField_Dictionary.Add(Sex, "Sex");
propertyField_Dictionary.Add(CustSourceId, "CustSourceId");
propertyField_Dictionary.Add(CustSource, "CustSource");
propertyField_Dictionary.Add(Phone, "Phone");
propertyField_Dictionary.Add(Tel, "Tel");
propertyField_Dictionary.Add(Email, "Email");
propertyField_Dictionary.Add(Job, "Job");
propertyField_Dictionary.Add(Product, "Product");
propertyField_Dictionary.Add(Question, "Question");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("DeptId", DeptId);
fieldProperty_Dictionary.Add("DeptName", DeptName);
fieldProperty_Dictionary.Add("StuffId", StuffId);
fieldProperty_Dictionary.Add("StuffName", StuffName);
fieldProperty_Dictionary.Add("EntryDate", EntryDate);
fieldProperty_Dictionary.Add("CustCode", CustCode);
fieldProperty_Dictionary.Add("CustName", CustName);
fieldProperty_Dictionary.Add("AreaId", AreaId);
fieldProperty_Dictionary.Add("Area", Area);
fieldProperty_Dictionary.Add("Province", Province);
fieldProperty_Dictionary.Add("ProvinceId", ProvinceId);
fieldProperty_Dictionary.Add("Sex", Sex);
fieldProperty_Dictionary.Add("CustSourceId", CustSourceId);
fieldProperty_Dictionary.Add("CustSource", CustSource);
fieldProperty_Dictionary.Add("Phone", Phone);
fieldProperty_Dictionary.Add("Tel", Tel);
fieldProperty_Dictionary.Add("Email", Email);
fieldProperty_Dictionary.Add("Job", Job);
fieldProperty_Dictionary.Add("Product", Product);
fieldProperty_Dictionary.Add("Question", Question);
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
return "Y_Call_Cust";}

public static string[] GetPrimaryProperties()
{
    return new string[] { CustCode };
}
public static string GetTableName()
{
return "Y_Call_Cust";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
