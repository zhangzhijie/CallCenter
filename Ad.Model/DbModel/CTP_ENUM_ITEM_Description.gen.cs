using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class CTP_ENUM_ITEM_Description {
/// <summary>
/// ID
/// </summary>
public const string ID = "ID";
/// <summary>
/// REF_ENUMID
/// </summary>
public const string REF_ENUMID = "REF_ENUMID";
/// <summary>
/// SHOWVALUE
/// </summary>
public const string SHOWVALUE = "SHOWVALUE";
/// <summary>
/// ENUMVALUE
/// </summary>
public const string ENUMVALUE = "ENUMVALUE";
/// <summary>
/// SORTNUMBER
/// </summary>
public const string SORTNUMBER = "SORTNUMBER";
/// <summary>
/// STATE
/// </summary>
public const string STATE = "STATE";
/// <summary>
/// OUTPUT_SWITCH
/// </summary>
public const string OUTPUT_SWITCH = "OUTPUT_SWITCH";
/// <summary>
/// ORG_ACCOUNT_ID
/// </summary>
public const string ORG_ACCOUNT_ID = "ORG_ACCOUNT_ID";
/// <summary>
/// PARENT_ID
/// </summary>
public const string PARENT_ID = "PARENT_ID";
/// <summary>
/// ROOT_ID
/// </summary>
public const string ROOT_ID = "ROOT_ID";
/// <summary>
/// LEVEL_NUM
/// </summary>
public const string LEVEL_NUM = "LEVEL_NUM";
/// <summary>
/// DESCRIPTION
/// </summary>
public const string DESCRIPTION = "DESCRIPTION";
/// <summary>
/// IFUSE
/// </summary>
public const string IFUSE = "IFUSE";
/// <summary>
/// I18N
/// </summary>
public const string I18N = "I18N";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static CTP_ENUM_ITEM_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(ID, "ID");
propertyField_Dictionary.Add(REF_ENUMID, "REF_ENUMID");
propertyField_Dictionary.Add(SHOWVALUE, "SHOWVALUE");
propertyField_Dictionary.Add(ENUMVALUE, "ENUMVALUE");
propertyField_Dictionary.Add(SORTNUMBER, "SORTNUMBER");
propertyField_Dictionary.Add(STATE, "STATE");
propertyField_Dictionary.Add(OUTPUT_SWITCH, "OUTPUT_SWITCH");
propertyField_Dictionary.Add(ORG_ACCOUNT_ID, "ORG_ACCOUNT_ID");
propertyField_Dictionary.Add(PARENT_ID, "PARENT_ID");
propertyField_Dictionary.Add(ROOT_ID, "ROOT_ID");
propertyField_Dictionary.Add(LEVEL_NUM, "LEVEL_NUM");
propertyField_Dictionary.Add(DESCRIPTION, "DESCRIPTION");
propertyField_Dictionary.Add(IFUSE, "IFUSE");
propertyField_Dictionary.Add(I18N, "I18N");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("ID", ID);
fieldProperty_Dictionary.Add("REF_ENUMID", REF_ENUMID);
fieldProperty_Dictionary.Add("SHOWVALUE", SHOWVALUE);
fieldProperty_Dictionary.Add("ENUMVALUE", ENUMVALUE);
fieldProperty_Dictionary.Add("SORTNUMBER", SORTNUMBER);
fieldProperty_Dictionary.Add("STATE", STATE);
fieldProperty_Dictionary.Add("OUTPUT_SWITCH", OUTPUT_SWITCH);
fieldProperty_Dictionary.Add("ORG_ACCOUNT_ID", ORG_ACCOUNT_ID);
fieldProperty_Dictionary.Add("PARENT_ID", PARENT_ID);
fieldProperty_Dictionary.Add("ROOT_ID", ROOT_ID);
fieldProperty_Dictionary.Add("LEVEL_NUM", LEVEL_NUM);
fieldProperty_Dictionary.Add("DESCRIPTION", DESCRIPTION);
fieldProperty_Dictionary.Add("IFUSE", IFUSE);
fieldProperty_Dictionary.Add("I18N", I18N);
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
return "CTP_ENUM_ITEM";}
public static string[] GetPrimaryProperties()
{
    return new string[] { ID };
}

public static string GetTableName()
{
return "CTP_ENUM_ITEM";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
