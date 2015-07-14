using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Position : IModel {

/// <summary>
/// PostId
/// </summary>
public Int64? PostId { get;set;}
/// <summary>
/// PostName
/// </summary>
public String PostName { get;set;}
/// <summary>
/// IsDelete
/// </summary>
public Boolean? IsDelete { get;set;}
/// <summary>
/// IsDistribution
/// </summary>
public Boolean? IsDistribution { get;set;} }
}
