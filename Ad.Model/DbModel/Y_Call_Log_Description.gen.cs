using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_Call_Log_Description {
/// <summary>
/// ChannelNo
/// </summary>
public const string ChannelNo = "ChannelNo";
/// <summary>
/// SeatPhone
/// </summary>
public const string SeatPhone = "SeatPhone";
/// <summary>
/// Phone
/// </summary>
public const string Phone = "Phone";
/// <summary>
/// StartTime
/// </summary>
public const string StartTime = "StartTime";
/// <summary>
/// TalkTime
/// </summary>
public const string TalkTime = "TalkTime";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_Call_Log_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(ChannelNo, "ChannelNo");
propertyField_Dictionary.Add(SeatPhone, "SeatPhone");
propertyField_Dictionary.Add(Phone, "Phone");
propertyField_Dictionary.Add(StartTime, "StartTime");
propertyField_Dictionary.Add(TalkTime, "TalkTime");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("ChannelNo", ChannelNo);
fieldProperty_Dictionary.Add("SeatPhone", SeatPhone);
fieldProperty_Dictionary.Add("Phone", Phone);
fieldProperty_Dictionary.Add("StartTime", StartTime);
fieldProperty_Dictionary.Add("TalkTime", TalkTime);
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
return "Y_Call_Log";}
public static string[] GetPrimaryProperties()
{
    return new string[] { StartTime };
}
public static string GetTableName()
{
return "Y_Call_Log";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
