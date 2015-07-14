using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Call_Cust : IModel {

/// <summary>
/// DeptId
/// </summary>
public Int64? DeptId { get;set;}
/// <summary>
/// DeptName
/// </summary>
public String DeptName { get;set;}
/// <summary>
/// StuffId
/// </summary>
public Int64? StuffId { get;set;}
/// <summary>
/// StuffName
/// </summary>
public String StuffName { get;set;}
/// <summary>
/// EntryDate
/// </summary>
public DateTime? EntryDate { get;set;}
/// <summary>
/// CustCode
/// </summary>
public String CustCode { get;set;}
/// <summary>
/// CustName
/// </summary>
public String CustName { get;set;}
/// <summary>
/// AreaId
/// </summary>
public Int64? AreaId { get;set;}
/// <summary>
/// Area
/// </summary>
public String Area { get;set;}
/// <summary>
/// Province
/// </summary>
public String Province { get;set;}
/// <summary>
/// ProvinceId
/// </summary>
public Int64? ProvinceId { get;set;}
/// <summary>
/// Sex
/// </summary>
public Boolean? Sex { get;set;}
/// <summary>
/// CustSourceId
/// </summary>
public Int64? CustSourceId { get;set;}
/// <summary>
/// CustSource
/// </summary>
public String CustSource { get;set;}
/// <summary>
/// Phone
/// </summary>
public String Phone { get;set;}
/// <summary>
/// Tel
/// </summary>
public String Tel { get;set;}
/// <summary>
/// Email
/// </summary>
public String Email { get;set;}
/// <summary>
/// Job
/// </summary>
public String Job { get;set;}
/// <summary>
/// Product
/// </summary>
public String Product { get;set;}
/// <summary>
/// Question
/// </summary>
public String Question { get;set;} }
}
