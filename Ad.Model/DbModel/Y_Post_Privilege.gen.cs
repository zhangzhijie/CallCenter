using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Post_Privilege : IModel {

/// <summary>
/// PostId
/// </summary>
public Int64? PostId { get;set;}
/// <summary>
/// FunctionId
/// </summary>
public Int32? FunctionId { get;set;}
/// <summary>
/// OperationId
/// </summary>
public Int32? OperationId { get;set;} }
}
