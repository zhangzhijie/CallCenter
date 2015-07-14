using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class ORG_MEMBER_Description {
/// <summary>
/// ID
/// </summary>
public const string ID = "ID";
/// <summary>
/// NAME
/// </summary>
public const string NAME = "NAME";
/// <summary>
/// CODE
/// </summary>
public const string CODE = "CODE";
/// <summary>
/// IS_INTERNAL
/// </summary>
public const string IS_INTERNAL = "IS_INTERNAL";
/// <summary>
/// IS_LOGINABLE
/// </summary>
public const string IS_LOGINABLE = "IS_LOGINABLE";
/// <summary>
/// IS_VIRTUAL
/// </summary>
public const string IS_VIRTUAL = "IS_VIRTUAL";
/// <summary>
/// IS_ADMIN
/// </summary>
public const string IS_ADMIN = "IS_ADMIN";
/// <summary>
/// IS_ASSIGNED
/// </summary>
public const string IS_ASSIGNED = "IS_ASSIGNED";
/// <summary>
/// TYPE
/// </summary>
public const string TYPE = "TYPE";
/// <summary>
/// STATE
/// </summary>
public const string STATE = "STATE";
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
/// SORT_ID
/// </summary>
public const string SORT_ID = "SORT_ID";
/// <summary>
/// ORG_DEPARTMENT_ID
/// </summary>
public const string ORG_DEPARTMENT_ID = "ORG_DEPARTMENT_ID";
/// <summary>
/// ORG_POST_ID
/// </summary>
public const string ORG_POST_ID = "ORG_POST_ID";
/// <summary>
/// ORG_LEVEL_ID
/// </summary>
public const string ORG_LEVEL_ID = "ORG_LEVEL_ID";
/// <summary>
/// ORG_ACCOUNT_ID
/// </summary>
public const string ORG_ACCOUNT_ID = "ORG_ACCOUNT_ID";
/// <summary>
/// DESCRIPTION
/// </summary>
public const string DESCRIPTION = "DESCRIPTION";
/// <summary>
/// CREATE_TIME
/// </summary>
public const string CREATE_TIME = "CREATE_TIME";
/// <summary>
/// UPDATE_TIME
/// </summary>
public const string UPDATE_TIME = "UPDATE_TIME";
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
/// <summary>
/// EXT_ATTR_16
/// </summary>
public const string EXT_ATTR_16 = "EXT_ATTR_16";
/// <summary>
/// EXT_ATTR_17
/// </summary>
public const string EXT_ATTR_17 = "EXT_ATTR_17";
/// <summary>
/// EXT_ATTR_18
/// </summary>
public const string EXT_ATTR_18 = "EXT_ATTR_18";
/// <summary>
/// EXT_ATTR_19
/// </summary>
public const string EXT_ATTR_19 = "EXT_ATTR_19";
/// <summary>
/// EXT_ATTR_20
/// </summary>
public const string EXT_ATTR_20 = "EXT_ATTR_20";
/// <summary>
/// EXT_ATTR_21
/// </summary>
public const string EXT_ATTR_21 = "EXT_ATTR_21";
/// <summary>
/// EXT_ATTR_22
/// </summary>
public const string EXT_ATTR_22 = "EXT_ATTR_22";
/// <summary>
/// EXT_ATTR_23
/// </summary>
public const string EXT_ATTR_23 = "EXT_ATTR_23";
/// <summary>
/// EXT_ATTR_24
/// </summary>
public const string EXT_ATTR_24 = "EXT_ATTR_24";
/// <summary>
/// EXT_ATTR_25
/// </summary>
public const string EXT_ATTR_25 = "EXT_ATTR_25";
/// <summary>
/// EXT_ATTR_26
/// </summary>
public const string EXT_ATTR_26 = "EXT_ATTR_26";
/// <summary>
/// EXT_ATTR_27
/// </summary>
public const string EXT_ATTR_27 = "EXT_ATTR_27";
/// <summary>
/// EXT_ATTR_28
/// </summary>
public const string EXT_ATTR_28 = "EXT_ATTR_28";
/// <summary>
/// EXT_ATTR_29
/// </summary>
public const string EXT_ATTR_29 = "EXT_ATTR_29";
/// <summary>
/// EXT_ATTR_30
/// </summary>
public const string EXT_ATTR_30 = "EXT_ATTR_30";
/// <summary>
/// EXT_ATTR_31
/// </summary>
public const string EXT_ATTR_31 = "EXT_ATTR_31";
/// <summary>
/// EXT_ATTR_32
/// </summary>
public const string EXT_ATTR_32 = "EXT_ATTR_32";
/// <summary>
/// EXT_ATTR_33
/// </summary>
public const string EXT_ATTR_33 = "EXT_ATTR_33";
/// <summary>
/// EXT_ATTR_34
/// </summary>
public const string EXT_ATTR_34 = "EXT_ATTR_34";
/// <summary>
/// EXT_ATTR_35
/// </summary>
public const string EXT_ATTR_35 = "EXT_ATTR_35";
/// <summary>
/// EXT_ATTR_36
/// </summary>
public const string EXT_ATTR_36 = "EXT_ATTR_36";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static ORG_MEMBER_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(ID, "ID");
propertyField_Dictionary.Add(NAME, "NAME");
propertyField_Dictionary.Add(CODE, "CODE");
propertyField_Dictionary.Add(IS_INTERNAL, "IS_INTERNAL");
propertyField_Dictionary.Add(IS_LOGINABLE, "IS_LOGINABLE");
propertyField_Dictionary.Add(IS_VIRTUAL, "IS_VIRTUAL");
propertyField_Dictionary.Add(IS_ADMIN, "IS_ADMIN");
propertyField_Dictionary.Add(IS_ASSIGNED, "IS_ASSIGNED");
propertyField_Dictionary.Add(TYPE, "TYPE");
propertyField_Dictionary.Add(STATE, "STATE");
propertyField_Dictionary.Add(IS_ENABLE, "IS_ENABLE");
propertyField_Dictionary.Add(IS_DELETED, "IS_DELETED");
propertyField_Dictionary.Add(STATUS, "STATUS");
propertyField_Dictionary.Add(SORT_ID, "SORT_ID");
propertyField_Dictionary.Add(ORG_DEPARTMENT_ID, "ORG_DEPARTMENT_ID");
propertyField_Dictionary.Add(ORG_POST_ID, "ORG_POST_ID");
propertyField_Dictionary.Add(ORG_LEVEL_ID, "ORG_LEVEL_ID");
propertyField_Dictionary.Add(ORG_ACCOUNT_ID, "ORG_ACCOUNT_ID");
propertyField_Dictionary.Add(DESCRIPTION, "DESCRIPTION");
propertyField_Dictionary.Add(CREATE_TIME, "CREATE_TIME");
propertyField_Dictionary.Add(UPDATE_TIME, "UPDATE_TIME");
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
propertyField_Dictionary.Add(EXT_ATTR_16, "EXT_ATTR_16");
propertyField_Dictionary.Add(EXT_ATTR_17, "EXT_ATTR_17");
propertyField_Dictionary.Add(EXT_ATTR_18, "EXT_ATTR_18");
propertyField_Dictionary.Add(EXT_ATTR_19, "EXT_ATTR_19");
propertyField_Dictionary.Add(EXT_ATTR_20, "EXT_ATTR_20");
propertyField_Dictionary.Add(EXT_ATTR_21, "EXT_ATTR_21");
propertyField_Dictionary.Add(EXT_ATTR_22, "EXT_ATTR_22");
propertyField_Dictionary.Add(EXT_ATTR_23, "EXT_ATTR_23");
propertyField_Dictionary.Add(EXT_ATTR_24, "EXT_ATTR_24");
propertyField_Dictionary.Add(EXT_ATTR_25, "EXT_ATTR_25");
propertyField_Dictionary.Add(EXT_ATTR_26, "EXT_ATTR_26");
propertyField_Dictionary.Add(EXT_ATTR_27, "EXT_ATTR_27");
propertyField_Dictionary.Add(EXT_ATTR_28, "EXT_ATTR_28");
propertyField_Dictionary.Add(EXT_ATTR_29, "EXT_ATTR_29");
propertyField_Dictionary.Add(EXT_ATTR_30, "EXT_ATTR_30");
propertyField_Dictionary.Add(EXT_ATTR_31, "EXT_ATTR_31");
propertyField_Dictionary.Add(EXT_ATTR_32, "EXT_ATTR_32");
propertyField_Dictionary.Add(EXT_ATTR_33, "EXT_ATTR_33");
propertyField_Dictionary.Add(EXT_ATTR_34, "EXT_ATTR_34");
propertyField_Dictionary.Add(EXT_ATTR_35, "EXT_ATTR_35");
propertyField_Dictionary.Add(EXT_ATTR_36, "EXT_ATTR_36");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("ID", ID);
fieldProperty_Dictionary.Add("NAME", NAME);
fieldProperty_Dictionary.Add("CODE", CODE);
fieldProperty_Dictionary.Add("IS_INTERNAL", IS_INTERNAL);
fieldProperty_Dictionary.Add("IS_LOGINABLE", IS_LOGINABLE);
fieldProperty_Dictionary.Add("IS_VIRTUAL", IS_VIRTUAL);
fieldProperty_Dictionary.Add("IS_ADMIN", IS_ADMIN);
fieldProperty_Dictionary.Add("IS_ASSIGNED", IS_ASSIGNED);
fieldProperty_Dictionary.Add("TYPE", TYPE);
fieldProperty_Dictionary.Add("STATE", STATE);
fieldProperty_Dictionary.Add("IS_ENABLE", IS_ENABLE);
fieldProperty_Dictionary.Add("IS_DELETED", IS_DELETED);
fieldProperty_Dictionary.Add("STATUS", STATUS);
fieldProperty_Dictionary.Add("SORT_ID", SORT_ID);
fieldProperty_Dictionary.Add("ORG_DEPARTMENT_ID", ORG_DEPARTMENT_ID);
fieldProperty_Dictionary.Add("ORG_POST_ID", ORG_POST_ID);
fieldProperty_Dictionary.Add("ORG_LEVEL_ID", ORG_LEVEL_ID);
fieldProperty_Dictionary.Add("ORG_ACCOUNT_ID", ORG_ACCOUNT_ID);
fieldProperty_Dictionary.Add("DESCRIPTION", DESCRIPTION);
fieldProperty_Dictionary.Add("CREATE_TIME", CREATE_TIME);
fieldProperty_Dictionary.Add("UPDATE_TIME", UPDATE_TIME);
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
fieldProperty_Dictionary.Add("EXT_ATTR_16", EXT_ATTR_16);
fieldProperty_Dictionary.Add("EXT_ATTR_17", EXT_ATTR_17);
fieldProperty_Dictionary.Add("EXT_ATTR_18", EXT_ATTR_18);
fieldProperty_Dictionary.Add("EXT_ATTR_19", EXT_ATTR_19);
fieldProperty_Dictionary.Add("EXT_ATTR_20", EXT_ATTR_20);
fieldProperty_Dictionary.Add("EXT_ATTR_21", EXT_ATTR_21);
fieldProperty_Dictionary.Add("EXT_ATTR_22", EXT_ATTR_22);
fieldProperty_Dictionary.Add("EXT_ATTR_23", EXT_ATTR_23);
fieldProperty_Dictionary.Add("EXT_ATTR_24", EXT_ATTR_24);
fieldProperty_Dictionary.Add("EXT_ATTR_25", EXT_ATTR_25);
fieldProperty_Dictionary.Add("EXT_ATTR_26", EXT_ATTR_26);
fieldProperty_Dictionary.Add("EXT_ATTR_27", EXT_ATTR_27);
fieldProperty_Dictionary.Add("EXT_ATTR_28", EXT_ATTR_28);
fieldProperty_Dictionary.Add("EXT_ATTR_29", EXT_ATTR_29);
fieldProperty_Dictionary.Add("EXT_ATTR_30", EXT_ATTR_30);
fieldProperty_Dictionary.Add("EXT_ATTR_31", EXT_ATTR_31);
fieldProperty_Dictionary.Add("EXT_ATTR_32", EXT_ATTR_32);
fieldProperty_Dictionary.Add("EXT_ATTR_33", EXT_ATTR_33);
fieldProperty_Dictionary.Add("EXT_ATTR_34", EXT_ATTR_34);
fieldProperty_Dictionary.Add("EXT_ATTR_35", EXT_ATTR_35);
fieldProperty_Dictionary.Add("EXT_ATTR_36", EXT_ATTR_36);
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
return "ORG_MEMBER";}

public static string[] GetPrimaryProperties()
{
    return new string[] { ID };
}
public static string GetTableName()
{
return "ORG_MEMBER";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
