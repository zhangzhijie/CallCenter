using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Manager : IModel {

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
public String Channel { get;set;} }
}
