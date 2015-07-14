using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Operation : IModel {

/// <summary>
/// OperationId
/// </summary>
public Int32? OperationId { get;set;}
/// <summary>
/// OperationName
/// </summary>
public String OperationName { get;set;}
/// <summary>
/// OperationType
/// </summary>
public Int32? OperationType { get;set;} }
}
