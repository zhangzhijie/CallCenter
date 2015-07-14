using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Department : IModel {

/// <summary>
/// DepartId
/// </summary>
public Int64? DepartId { get;set;}
/// <summary>
/// DepartName
/// </summary>
public String DepartName { get;set;}
/// <summary>
/// Code
/// </summary>
public String Code { get;set;}
/// <summary>
/// IsDelete
/// </summary>
public Boolean? IsDelete { get;set;} }
}
