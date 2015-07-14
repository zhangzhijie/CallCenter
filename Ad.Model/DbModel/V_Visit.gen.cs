using System;
using Ad.DA;

namespace Ad.Model.DbModel{

/// <summary>
/// 
/// </summary>
[Serializable]
 public partial class V_Visit : IModel {

/// <summary>
/// 
/// </summary>
public int? DateNumber { get;set;}

/// <summary>
/// 
/// </summary>
public int? DateDoctorNumber { get;set;}

/// <summary>
/// 
/// </summary>
public int? State { get;set;}

/// <summary>
/// 
/// </summary>
public int? VisitType { get;set;}

/// <summary>
/// 
/// </summary>
public int? DoctorType { get;set;}

/// <summary>
/// 
/// </summary>
public DateTime? CreateTime { get;set;}

/// <summary>
/// 
/// </summary>
public DateTime? PayTime { get;set;}

/// <summary>
/// 
/// </summary>
public decimal? Pay_MemberCard { get;set;}

/// <summary>
/// 
/// </summary>
public decimal? Pay_Cost { get;set;}

/// <summary>
/// 
/// </summary>
public decimal? Pay_POS { get;set;}

/// <summary>
/// 
/// </summary>
public decimal? TotalPrice { get;set;}

/// <summary>
/// 
/// </summary>
public decimal? RemovePrice_Zero { get;set;}

/// <summary>
/// 
/// </summary>
public decimal? RemovePrice_YouHuiJuan { get;set;}

/// <summary>
/// 
/// </summary>
public decimal? RemovePrice_Discount { get;set;}

/// <summary>
/// 
/// </summary>
public bool? Sex { get;set;}

/// <summary>
/// 
/// </summary>
public long? VisitId { get;set;}

/// <summary>
/// 
/// </summary>
public long? DoctorId { get;set;}

/// <summary>
/// 
/// </summary>
public long? PatientId { get;set;}

/// <summary>
/// 
/// </summary>
public string DoctorName { get;set;}

/// <summary>
/// 
/// </summary>
public string PatientName { get;set;}

/// <summary>
/// 
/// </summary>
public string Memo { get;set;}

/// <summary>
/// 
/// </summary>
public string Record { get;set;}

/// <summary>
/// 
/// </summary>
public string MemberCardId { get;set;}

/// <summary>
/// 
/// </summary>
public string Item_Prices { get;set;}

/// <summary>
/// 
/// </summary>
public string ArchivePlace { get;set;}

/// <summary>
/// 
/// </summary>
public string MemoYouHuiJuan { get;set;}

/// <summary>
/// 
/// </summary>
public string MemoRemovePrice { get;set;}

/// <summary>
/// 
/// </summary>
public string PatientTel { get;set;}

/// <summary>
/// 
/// </summary>
public string PatientPinYin { get;set;}

/// <summary>
/// 
/// </summary>
public string DoctorKey { get;set;}

/// <summary>
/// 
/// </summary>
public string PinYin { get;set;}

 }
}
