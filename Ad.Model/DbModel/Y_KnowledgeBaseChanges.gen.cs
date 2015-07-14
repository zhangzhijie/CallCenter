using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_KnowledgeBaseChanges : IModel {

/// <summary>
/// Id
/// </summary>
public Int64? Id { get;set;}
/// <summary>
/// KnowledgeCode
/// </summary>
public Int64? KnowledgeCode { get;set;}
/// <summary>
/// StuffId
/// </summary>
public Int64? StuffId { get;set;}
/// <summary>
/// StuffName
/// </summary>
public String StuffName { get;set;}
/// <summary>
/// DeptId
/// </summary>
public Int64? DeptId { get;set;}
/// <summary>
/// DeptName
/// </summary>
public String DeptName { get;set;}
/// <summary>
/// OperateType
/// </summary>
public Int32? OperateType { get;set;}
/// <summary>
/// OperateName
/// </summary>
public String OperateName { get;set;}
/// <summary>
/// OperateDate
/// </summary>
public DateTime? OperateDate { get;set;} }
}
