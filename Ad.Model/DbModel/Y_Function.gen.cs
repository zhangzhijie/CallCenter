using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Function : IModel {

/// <summary>
/// FunctionId
/// </summary>
public Int32? FunctionId { get;set;}
/// <summary>
/// FunctionName
/// </summary>
public String FunctionName { get;set;}
/// <summary>
/// FunctionType
/// </summary>
public Int32? FunctionType { get;set;} }
}
