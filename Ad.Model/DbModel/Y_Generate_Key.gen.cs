using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Generate_Key : IModel {

/// <summary>
/// KeyType
/// </summary>
public Int32? KeyType { get;set;}
/// <summary>
/// KeyNumber
/// </summary>
public Int32? KeyNumber { get;set;}
/// <summary>
/// CurrentDate
/// </summary>
public DateTime? CurrentDate { get;set;}
/// <summary>
/// PreValue
/// </summary>
public String PreValue { get;set;} }
}
