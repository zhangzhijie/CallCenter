using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class ORG_UNIT_Description {
/// <summary>
/// ID
/// </summary>
public const string ID = "ID";
/// <summary>
/// NAME
/// </summary>
public const string NAME = "NAME";
/// <summary>
/// SECOND_NAME
/// </summary>
public const string SECOND_NAME = "SECOND_NAME";
/// <summary>
/// CODE
/// </summary>
public const string CODE = "CODE";
/// <summary>
/// SHORT_NAME
/// </summary>
public const string SHORT_NAME = "SHORT_NAME";
/// <summary>
/// TYPE
/// </summary>
public const string TYPE = "TYPE";
/// <summary>
/// IS_GROUP
/// </summary>
public const string IS_GROUP = "IS_GROUP";
/// <summary>
/// PATH
/// </summary>
public const string PATH = "PATH";
/// <summary>
/// IS_INTERNAL
/// </summary>
public const string IS_INTERNAL = "IS_INTERNAL";
/// <summary>
/// SORT_ID
/// </summary>
public const string SORT_ID = "SORT_ID";
/// <summary>
/// IS_ENABLE
/// </summary>
public const string IS_ENABLE = "IS_ENABLE";
/// <summary>
/// IS_DELETED
/// </summary>
public const string IS_DELETED = "IS_DELETED";
/// <summary>
/// STATUS
/// </summary>
public const string STATUS = "STATUS";
/// <summary>
/// LEVEL_SCOPE
/// </summary>
public const string LEVEL_SCOPE = "LEVEL_SCOPE";
/// <summary>
/// ORG_ACCOUNT_ID
/// </summary>
public const string ORG_ACCOUNT_ID = "ORG_ACCOUNT_ID";
/// <summary>
/// CREATE_TIME
/// </summary>
public const string CREATE_TIME = "CREATE_TIME";
/// <summary>
/// UPDATE_TIME
/// </summary>
public const string UPDATE_TIME = "UPDATE_TIME";
/// <summary>
/// DESCRIPTION
/// </summary>
public const string DESCRIPTION = "DESCRIPTION";
/// <summary>
/// EXT_ATTR_1
/// </summary>
public const string EXT_ATTR_1 = "EXT_ATTR_1";
/// <summary>
/// EXT_ATTR_2
/// </summary>
public const string EXT_ATTR_2 = "EXT_ATTR_2";
/// <summary>
/// EXT_ATTR_3
/// </summary>
public const string EXT_ATTR_3 = "EXT_ATTR_3";
/// <summary>
/// EXT_ATTR_4
/// </summary>
public const string EXT_ATTR_4 = "EXT_ATTR_4";
/// <summary>
/// EXT_ATTR_5
/// </summary>
public const string EXT_ATTR_5 = "EXT_ATTR_5";
/// <summary>
/// EXT_ATTR_6
/// </summary>
public const string EXT_ATTR_6 = "EXT_ATTR_6";
/// <summary>
/// EXT_ATTR_7
/// </summary>
public const string EXT_ATTR_7 = "EXT_ATTR_7";
/// <summary>
/// EXT_ATTR_8
/// </summary>
public const string EXT_ATTR_8 = "EXT_ATTR_8";
/// <summary>
/// EXT_ATTR_9
/// </summary>
public const string EXT_ATTR_9 = "EXT_ATTR_9";
/// <summary>
/// EXT_ATTR_10
/// </summary>
public const string EXT_ATTR_10 = "EXT_ATTR_10";
/// <summary>
/// EXT_ATTR_11
/// </summary>
public const string EXT_ATTR_11 = "EXT_ATTR_11";
/// <summary>
/// EXT_ATTR_12
/// </summary>
public const string EXT_ATTR_12 = "EXT_ATTR_12";
/// <summary>
/// EXT_ATTR_13
/// </summary>
public const string EXT_ATTR_13 = "EXT_ATTR_13";
/// <summary>
/// EXT_ATTR_14
/// </summary>
public const string EXT_ATTR_14 = "EXT_ATTR_14";
/// <summary>
/// EXT_ATTR_15
/// </summary>
public const string EXT_ATTR_15 = "EXT_ATTR_15";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static ORG_UNIT_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(ID, "ID");
propertyField_Dictionary.Add(NAME, "NAME");
propertyField_Dictionary.Add(SECOND_NAME, "SECOND_NAME");
propertyField_Dictionary.Add(CODE, "CODE");
propertyField_Dictionary.Add(SHORT_NAME, "SHORT_NAME");
propertyField_Dictionary.Add(TYPE, "TYPE");
propertyField_Dictionary.Add(IS_GROUP, "IS_GROUP");
propertyField_Dictionary.Add(PATH, "PATH");
propertyField_Dictionary.Add(IS_INTERNAL, "IS_INTERNAL");
propertyField_Dictionary.Add(SORT_ID, "SORT_ID");
propertyField_Dictionary.Add(IS_ENABLE, "IS_ENABLE");
propertyField_Dictionary.Add(IS_DELETED, "IS_DELETED");
propertyField_Dictionary.Add(STATUS, "STATUS");
propertyField_Dictionary.Add(LEVEL_SCOPE, "LEVEL_SCOPE");
propertyField_Dictionary.Add(ORG_ACCOUNT_ID, "ORG_ACCOUNT_ID");
propertyField_Dictionary.Add(CREATE_TIME, "CREATE_TIME");
propertyField_Dictionary.Add(UPDATE_TIME, "UPDATE_TIME");
propertyField_Dictionary.Add(DESCRIPTION, "DESCRIPTION");
propertyField_Dictionary.Add(EXT_ATTR_1, "EXT_ATTR_1");
propertyField_Dictionary.Add(EXT_ATTR_2, "EXT_ATTR_2");
propertyField_Dictionary.Add(EXT_ATTR_3, "EXT_ATTR_3");
propertyField_Dictionary.Add(EXT_ATTR_4, "EXT_ATTR_4");
propertyField_Dictionary.Add(EXT_ATTR_5, "EXT_ATTR_5");
propertyField_Dictionary.Add(EXT_ATTR_6, "EXT_ATTR_6");
propertyField_Dictionary.Add(EXT_ATTR_7, "EXT_ATTR_7");
propertyField_Dictionary.Add(EXT_ATTR_8, "EXT_ATTR_8");
propertyField_Dictionary.Add(EXT_ATTR_9, "EXT_ATTR_9");
propertyField_Dictionary.Add(EXT_ATTR_10, "EXT_ATTR_10");
propertyField_Dictionary.Add(EXT_ATTR_11, "EXT_ATTR_11");
propertyField_Dictionary.Add(EXT_ATTR_12, "EXT_ATTR_12");
propertyField_Dictionary.Add(EXT_ATTR_13, "EXT_ATTR_13");
propertyField_Dictionary.Add(EXT_ATTR_14, "EXT_ATTR_14");
propertyField_Dictionary.Add(EXT_ATTR_15, "EXT_ATTR_15");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("ID", ID);
fieldProperty_Dictionary.Add("NAME", NAME);
fieldProperty_Dictionary.Add("SECOND_NAME", SECOND_NAME);
fieldProperty_Dictionary.Add("CODE", CODE);
fieldProperty_Dictionary.Add("SHORT_NAME", SHORT_NAME);
fieldProperty_Dictionary.Add("TYPE", TYPE);
fieldProperty_Dictionary.Add("IS_GROUP", IS_GROUP);
fieldProperty_Dictionary.Add("PATH", PATH);
fieldProperty_Dictionary.Add("IS_INTERNAL", IS_INTERNAL);
fieldProperty_Dictionary.Add("SORT_ID", SORT_ID);
fieldProperty_Dictionary.Add("IS_ENABLE", IS_ENABLE);
fieldProperty_Dictionary.Add("IS_DELETED", IS_DELETED);
fieldProperty_Dictionary.Add("STATUS", STATUS);
fieldProperty_Dictionary.Add("LEVEL_SCOPE", LEVEL_SCOPE);
fieldProperty_Dictionary.Add("ORG_ACCOUNT_ID", ORG_ACCOUNT_ID);
fieldProperty_Dictionary.Add("CREATE_TIME", CREATE_TIME);
fieldProperty_Dictionary.Add("UPDATE_TIME", UPDATE_TIME);
fieldProperty_Dictionary.Add("DESCRIPTION", DESCRIPTION);
fieldProperty_Dictionary.Add("EXT_ATTR_1", EXT_ATTR_1);
fieldProperty_Dictionary.Add("EXT_ATTR_2", EXT_ATTR_2);
fieldProperty_Dictionary.Add("EXT_ATTR_3", EXT_ATTR_3);
fieldProperty_Dictionary.Add("EXT_ATTR_4", EXT_ATTR_4);
fieldProperty_Dictionary.Add("EXT_ATTR_5", EXT_ATTR_5);
fieldProperty_Dictionary.Add("EXT_ATTR_6", EXT_ATTR_6);
fieldProperty_Dictionary.Add("EXT_ATTR_7", EXT_ATTR_7);
fieldProperty_Dictionary.Add("EXT_ATTR_8", EXT_ATTR_8);
fieldProperty_Dictionary.Add("EXT_ATTR_9", EXT_ATTR_9);
fieldProperty_Dictionary.Add("EXT_ATTR_10", EXT_ATTR_10);
fieldProperty_Dictionary.Add("EXT_ATTR_11", EXT_ATTR_11);
fieldProperty_Dictionary.Add("EXT_ATTR_12", EXT_ATTR_12);
fieldProperty_Dictionary.Add("EXT_ATTR_13", EXT_ATTR_13);
fieldProperty_Dictionary.Add("EXT_ATTR_14", EXT_ATTR_14);
fieldProperty_Dictionary.Add("EXT_ATTR_15", EXT_ATTR_15);
}
public static Dictionary<string, string> GetPropertyField_Dictionary()
{
     return propertyField_Dictionary;
}
public static Dictionary<string, string> GetFieldProperty_Dictionary()
{
 	return fieldProperty_Dictionary;
}
public static string GetEntityName()
{
return "ORG_UNIT";}
public static string[] GetPrimaryProperties()
{
    return new string[] { ID };
}

public static string GetTableName()
{
return "ORG_UNIT";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
