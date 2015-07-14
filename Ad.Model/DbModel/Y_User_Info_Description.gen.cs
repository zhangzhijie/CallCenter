using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_User_Info_Description {
/// <summary>
/// UserId
/// </summary>
public const string UserId = "UserId";
/// <summary>
/// EmailAddr
/// </summary>
public const string EmailAddr = "EmailAddr";
/// <summary>
/// EmailPsw
/// </summary>
public const string EmailPsw = "EmailPsw";
/// <summary>
/// Smtp
/// </summary>
public const string Smtp = "Smtp";
/// <summary>
/// SmgAddr
/// </summary>
public const string SmgAddr = "SmgAddr";
/// <summary>
/// EmailIsLogin
/// </summary>
public const string EmailIsLogin = "EmailIsLogin";
/// <summary>
/// Pop3
/// </summary>
public const string Pop3 = "Pop3";
/// <summary>
/// UserName
/// </summary>
public const string UserName = "UserName";
/// <summary>
/// HoldEmailPwd
/// </summary>
public const string HoldEmailPwd = "HoldEmailPwd";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_User_Info_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(UserId, "UserId");
propertyField_Dictionary.Add(EmailAddr, "EmailAddr");
propertyField_Dictionary.Add(EmailPsw, "EmailPsw");
propertyField_Dictionary.Add(Smtp, "Smtp");
propertyField_Dictionary.Add(SmgAddr, "SmgAddr");
propertyField_Dictionary.Add(EmailIsLogin, "EmailIsLogin");
propertyField_Dictionary.Add(Pop3, "Pop3");
propertyField_Dictionary.Add(UserName, "UserName");
propertyField_Dictionary.Add(HoldEmailPwd, "HoldEmailPwd");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("UserId", UserId);
fieldProperty_Dictionary.Add("EmailAddr", EmailAddr);
fieldProperty_Dictionary.Add("EmailPsw", EmailPsw);
fieldProperty_Dictionary.Add("Smtp", Smtp);
fieldProperty_Dictionary.Add("SmgAddr", SmgAddr);
fieldProperty_Dictionary.Add("EmailIsLogin", EmailIsLogin);
fieldProperty_Dictionary.Add("Pop3", Pop3);
fieldProperty_Dictionary.Add("UserName", UserName);
fieldProperty_Dictionary.Add("HoldEmailPwd", HoldEmailPwd);
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
return "Y_User_Info";}
public static string[] GetPrimaryProperties()
{
    return new string[] { UserId };
}
public static string GetTableName()
{
return "Y_User_Info";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
