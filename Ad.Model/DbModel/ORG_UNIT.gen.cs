using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class ORG_UNIT : IModel {

/// <summary>
/// ID
/// </summary>
public Int64? ID { get;set;}
/// <summary>
/// NAME
/// </summary>
public String NAME { get;set;}
/// <summary>
/// SECOND_NAME
/// </summary>
public String SECOND_NAME { get;set;}
/// <summary>
/// CODE
/// </summary>
public String CODE { get;set;}
/// <summary>
/// SHORT_NAME
/// </summary>
public String SHORT_NAME { get;set;}
/// <summary>
/// TYPE
/// </summary>
public String TYPE { get;set;}
/// <summary>
/// IS_GROUP
/// </summary>
public Int16? IS_GROUP { get;set;}
/// <summary>
/// PATH
/// </summary>
public String PATH { get;set;}
/// <summary>
/// IS_INTERNAL
/// </summary>
public Int16? IS_INTERNAL { get;set;}
/// <summary>
/// SORT_ID
/// </summary>
public Int32? SORT_ID { get;set;}
/// <summary>
/// IS_ENABLE
/// </summary>
public Int16? IS_ENABLE { get;set;}
/// <summary>
/// IS_DELETED
/// </summary>
public Int16? IS_DELETED { get;set;}
/// <summary>
/// STATUS
/// </summary>
public Int16? STATUS { get;set;}
/// <summary>
/// LEVEL_SCOPE
/// </summary>
public Int32? LEVEL_SCOPE { get;set;}
/// <summary>
/// ORG_ACCOUNT_ID
/// </summary>
public Int64? ORG_ACCOUNT_ID { get;set;}
/// <summary>
/// CREATE_TIME
/// </summary>
public DateTime? CREATE_TIME { get;set;}
/// <summary>
/// UPDATE_TIME
/// </summary>
public DateTime? UPDATE_TIME { get;set;}
/// <summary>
/// DESCRIPTION
/// </summary>
public String DESCRIPTION { get;set;}
/// <summary>
/// EXT_ATTR_1
/// </summary>
public String EXT_ATTR_1 { get;set;}
/// <summary>
/// EXT_ATTR_2
/// </summary>
public String EXT_ATTR_2 { get;set;}
/// <summary>
/// EXT_ATTR_3
/// </summary>
public String EXT_ATTR_3 { get;set;}
/// <summary>
/// EXT_ATTR_4
/// </summary>
public String EXT_ATTR_4 { get;set;}
/// <summary>
/// EXT_ATTR_5
/// </summary>
public String EXT_ATTR_5 { get;set;}
/// <summary>
/// EXT_ATTR_6
/// </summary>
public String EXT_ATTR_6 { get;set;}
/// <summary>
/// EXT_ATTR_7
/// </summary>
public String EXT_ATTR_7 { get;set;}
/// <summary>
/// EXT_ATTR_8
/// </summary>
public String EXT_ATTR_8 { get;set;}
/// <summary>
/// EXT_ATTR_9
/// </summary>
public String EXT_ATTR_9 { get;set;}
/// <summary>
/// EXT_ATTR_10
/// </summary>
public String EXT_ATTR_10 { get;set;}
/// <summary>
/// EXT_ATTR_11
/// </summary>
public Int32? EXT_ATTR_11 { get;set;}
/// <summary>
/// EXT_ATTR_12
/// </summary>
public Int32? EXT_ATTR_12 { get;set;}
/// <summary>
/// EXT_ATTR_13
/// </summary>
public Int32? EXT_ATTR_13 { get;set;}
/// <summary>
/// EXT_ATTR_14
/// </summary>
public Int32? EXT_ATTR_14 { get;set;}
/// <summary>
/// EXT_ATTR_15
/// </summary>
public Int32? EXT_ATTR_15 { get;set;} }
}
