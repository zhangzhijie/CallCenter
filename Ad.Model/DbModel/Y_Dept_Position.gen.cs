using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Dept_Position : IModel {

/// <summary>
/// PermissionId
/// </summary>
public Int64? PermissionId { get;set;}
/// <summary>
/// PostId
/// </summary>
public Int64? PostId { get;set;}
/// <summary>
/// DepartId
/// </summary>
public Int64? DepartId { get;set;} }
}
