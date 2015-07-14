using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_V_Manager : IModel {

/// <summary>
/// ManagerId
/// </summary>
public Int64? ManagerId { get;set;}
/// <summary>
/// LoginName
/// </summary>
public String LoginName { get;set;}
/// <summary>
/// Pwd
/// </summary>
public String Pwd { get;set;}
/// <summary>
/// IsUse
/// </summary>
public Boolean? IsUse { get;set;}
/// <summary>
/// PermissionId
/// </summary>
public Int64? PermissionId { get;set;}
/// <summary>
/// Channel
/// </summary>
public String Channel { get;set;}
/// <summary>
/// NAME
/// </summary>
public String NAME { get;set;}
/// <summary>
/// PostId
/// </summary>
public Int64? PostId { get;set;}
/// <summary>
/// DepartId
/// </summary>
public Int64? DepartId { get;set;}
/// <summary>
/// DepartCode
/// </summary>
public String DepartCode { get;set;}
/// <summary>
/// PostName
/// </summary>
public String PostName { get;set;}
/// <summary>
/// DepartName
/// </summary>
public String DepartName { get;set;} }
}
