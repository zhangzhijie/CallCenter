using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class CTP_ENUM_ITEM : IModel {

/// <summary>
/// ID
/// </summary>
public Int64? ID { get;set;}
/// <summary>
/// REF_ENUMID
/// </summary>
public Int64? REF_ENUMID { get;set;}
/// <summary>
/// SHOWVALUE
/// </summary>
public String SHOWVALUE { get;set;}
/// <summary>
/// ENUMVALUE
/// </summary>
public String ENUMVALUE { get;set;}
/// <summary>
/// SORTNUMBER
/// </summary>
public Int32? SORTNUMBER { get;set;}
/// <summary>
/// STATE
/// </summary>
public Int16? STATE { get;set;}
/// <summary>
/// OUTPUT_SWITCH
/// </summary>
public Int16? OUTPUT_SWITCH { get;set;}
/// <summary>
/// ORG_ACCOUNT_ID
/// </summary>
public Int64? ORG_ACCOUNT_ID { get;set;}
/// <summary>
/// PARENT_ID
/// </summary>
public Int64? PARENT_ID { get;set;}
/// <summary>
/// ROOT_ID
/// </summary>
public Int64? ROOT_ID { get;set;}
/// <summary>
/// LEVEL_NUM
/// </summary>
public Int16? LEVEL_NUM { get;set;}
/// <summary>
/// DESCRIPTION
/// </summary>
public String DESCRIPTION { get;set;}
/// <summary>
/// IFUSE
/// </summary>
public String IFUSE { get;set;}
/// <summary>
/// I18N
/// </summary>
public Int16? I18N { get;set;} }
}
