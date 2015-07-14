using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_Call_Log : IModel {

/// <summary>
/// ChannelNo
/// </summary>
public Int32? ChannelNo { get;set;}
/// <summary>
/// SeatPhone
/// </summary>
public String SeatPhone { get;set;}
/// <summary>
/// Phone
/// </summary>
public String Phone { get;set;}
/// <summary>
/// StartTime
/// </summary>
public DateTime? StartTime { get;set;}
/// <summary>
/// TalkTime
/// </summary>
public String TalkTime { get;set;} }
}
