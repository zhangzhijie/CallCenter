using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_KnowledgeBase : IModel {

/// <summary>
/// KnowledgeCode
/// </summary>
public Int64? KnowledgeCode { get;set;}
/// <summary>
/// CreateDate
/// </summary>
public DateTime? CreateDate { get;set;}
/// <summary>
/// Suffix
/// </summary>
public String Suffix { get;set;}
/// <summary>
/// Title
/// </summary>
public String Title { get;set;}
/// <summary>
/// KeyWords
/// </summary>
public String KeyWords { get;set;}
/// <summary>
/// Content
/// </summary>
public Byte[] Content { get;set;}
/// <summary>
/// UpdateDate
/// </summary>
public DateTime? UpdateDate { get;set;} }
}
