using System;
using System.Collections.Generic;

namespace Ad.Model.DbModel{

/// <summary>
///  的描述
/// </summary>
 public class V_Visit_Description {

/// <summary>
/// 
/// </summary>
public const string DateNumber = "DateNumber";

/// <summary>
/// 
/// </summary>
public const string DateDoctorNumber = "DateDoctorNumber";

/// <summary>
/// 
/// </summary>
public const string State = "State";

/// <summary>
/// 
/// </summary>
public const string VisitType = "VisitType";

/// <summary>
/// 
/// </summary>
public const string DoctorType = "DoctorType";

/// <summary>
/// 
/// </summary>
public const string CreateTime = "CreateTime";

/// <summary>
/// 
/// </summary>
public const string PayTime = "PayTime";

/// <summary>
/// 
/// </summary>
public const string Pay_MemberCard = "Pay_MemberCard";

/// <summary>
/// 
/// </summary>
public const string Pay_Cost = "Pay_Cost";

/// <summary>
/// 
/// </summary>
public const string Pay_POS = "Pay_POS";

/// <summary>
/// 
/// </summary>
public const string TotalPrice = "TotalPrice";

/// <summary>
/// 
/// </summary>
public const string RemovePrice_Zero = "RemovePrice_Zero";

/// <summary>
/// 
/// </summary>
public const string RemovePrice_YouHuiJuan = "RemovePrice_YouHuiJuan";

/// <summary>
/// 
/// </summary>
public const string RemovePrice_Discount = "RemovePrice_Discount";

/// <summary>
/// 
/// </summary>
public const string Sex = "Sex";

/// <summary>
/// 
/// </summary>
public const string VisitId = "VisitId";

/// <summary>
/// 
/// </summary>
public const string DoctorId = "DoctorId";

/// <summary>
/// 
/// </summary>
public const string PatientId = "PatientId";

/// <summary>
/// 
/// </summary>
public const string DoctorName = "DoctorName";

/// <summary>
/// 
/// </summary>
public const string PatientName = "PatientName";

/// <summary>
/// 
/// </summary>
public const string Memo = "Memo";

/// <summary>
/// 
/// </summary>
public const string Record = "Record";

/// <summary>
/// 
/// </summary>
public const string MemberCardId = "MemberCardId";

/// <summary>
/// 
/// </summary>
public const string Item_Prices = "Item_Prices";

/// <summary>
/// 
/// </summary>
public const string ArchivePlace = "ArchivePlace";

/// <summary>
/// 
/// </summary>
public const string MemoYouHuiJuan = "MemoYouHuiJuan";

/// <summary>
/// 
/// </summary>
public const string MemoRemovePrice = "MemoRemovePrice";

/// <summary>
/// 
/// </summary>
public const string PatientTel = "PatientTel";

/// <summary>
/// 
/// </summary>
public const string PatientPinYin = "PatientPinYin";

/// <summary>
/// 
/// </summary>
public const string DoctorKey = "DoctorKey";

/// <summary>
/// 
/// </summary>
public const string PinYin = "PinYin";

private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;

static V_Visit_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(DateNumber, "DateNumber");
propertyField_Dictionary.Add(DateDoctorNumber, "DateDoctorNumber");
propertyField_Dictionary.Add(State, "State");
propertyField_Dictionary.Add(VisitType, "VisitType");
propertyField_Dictionary.Add(DoctorType, "DoctorType");
propertyField_Dictionary.Add(CreateTime, "CreateTime");
propertyField_Dictionary.Add(PayTime, "PayTime");
propertyField_Dictionary.Add(Pay_MemberCard, "Pay_MemberCard");
propertyField_Dictionary.Add(Pay_Cost, "Pay_Cost");
propertyField_Dictionary.Add(Pay_POS, "Pay_POS");
propertyField_Dictionary.Add(TotalPrice, "TotalPrice");
propertyField_Dictionary.Add(RemovePrice_Zero, "RemovePrice_Zero");
propertyField_Dictionary.Add(RemovePrice_YouHuiJuan, "RemovePrice_YouHuiJuan");
propertyField_Dictionary.Add(RemovePrice_Discount, "RemovePrice_Discount");
propertyField_Dictionary.Add(Sex, "Sex");
propertyField_Dictionary.Add(VisitId, "VisitId");
propertyField_Dictionary.Add(DoctorId, "DoctorId");
propertyField_Dictionary.Add(PatientId, "PatientId");
propertyField_Dictionary.Add(DoctorName, "DoctorName");
propertyField_Dictionary.Add(PatientName, "PatientName");
propertyField_Dictionary.Add(Memo, "Memo");
propertyField_Dictionary.Add(Record, "Record");
propertyField_Dictionary.Add(MemberCardId, "MemberCardId");
propertyField_Dictionary.Add(Item_Prices, "Item_Prices");
propertyField_Dictionary.Add(ArchivePlace, "ArchivePlace");
propertyField_Dictionary.Add(MemoYouHuiJuan, "MemoYouHuiJuan");
propertyField_Dictionary.Add(MemoRemovePrice, "MemoRemovePrice");
propertyField_Dictionary.Add(PatientTel, "PatientTel");
propertyField_Dictionary.Add(PatientPinYin, "PatientPinYin");
propertyField_Dictionary.Add(DoctorKey, "DoctorKey");
propertyField_Dictionary.Add(PinYin, "PinYin");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("DateNumber", DateNumber);
fieldProperty_Dictionary.Add("DateDoctorNumber", DateDoctorNumber);
fieldProperty_Dictionary.Add("State", State);
fieldProperty_Dictionary.Add("VisitType", VisitType);
fieldProperty_Dictionary.Add("DoctorType", DoctorType);
fieldProperty_Dictionary.Add("CreateTime", CreateTime);
fieldProperty_Dictionary.Add("PayTime", PayTime);
fieldProperty_Dictionary.Add("Pay_MemberCard", Pay_MemberCard);
fieldProperty_Dictionary.Add("Pay_Cost", Pay_Cost);
fieldProperty_Dictionary.Add("Pay_POS", Pay_POS);
fieldProperty_Dictionary.Add("TotalPrice", TotalPrice);
fieldProperty_Dictionary.Add("RemovePrice_Zero", RemovePrice_Zero);
fieldProperty_Dictionary.Add("RemovePrice_YouHuiJuan", RemovePrice_YouHuiJuan);
fieldProperty_Dictionary.Add("RemovePrice_Discount", RemovePrice_Discount);
fieldProperty_Dictionary.Add("Sex", Sex);
fieldProperty_Dictionary.Add("VisitId", VisitId);
fieldProperty_Dictionary.Add("DoctorId", DoctorId);
fieldProperty_Dictionary.Add("PatientId", PatientId);
fieldProperty_Dictionary.Add("DoctorName", DoctorName);
fieldProperty_Dictionary.Add("PatientName", PatientName);
fieldProperty_Dictionary.Add("Memo", Memo);
fieldProperty_Dictionary.Add("Record", Record);
fieldProperty_Dictionary.Add("MemberCardId", MemberCardId);
fieldProperty_Dictionary.Add("Item_Prices", Item_Prices);
fieldProperty_Dictionary.Add("ArchivePlace", ArchivePlace);
fieldProperty_Dictionary.Add("MemoYouHuiJuan", MemoYouHuiJuan);
fieldProperty_Dictionary.Add("MemoRemovePrice", MemoRemovePrice);
fieldProperty_Dictionary.Add("PatientTel", PatientTel);
fieldProperty_Dictionary.Add("PatientPinYin", PatientPinYin);
fieldProperty_Dictionary.Add("DoctorKey", DoctorKey);
fieldProperty_Dictionary.Add("PinYin", PinYin);
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
return "V_Visit";}

public static string[] GetPrimaryProperties()
{
return new string[] {VisitId};}

public static string GetTableName()
{
return "V_Visit";}

public static string GetDataAccessString()
{
return Config.ConnectionString;
}
}
}
