using System;
using Ad.DA;
namespace Ad.Model.DbModel{
[Serializable]
 public partial class Y_User_Info : IModel {

/// <summary>
/// UserId
/// </summary>
public Int64? UserId { get;set;}
/// <summary>
/// EmailAddr
/// </summary>
public String EmailAddr { get;set;}
/// <summary>
/// EmailPsw
/// </summary>
public String EmailPsw { get;set;}
/// <summary>
/// Smtp
/// </summary>
public String Smtp { get;set;}
/// <summary>
/// SmgAddr
/// </summary>
public String SmgAddr { get;set;}
/// <summary>
/// EmailIsLogin
/// </summary>
public Boolean? EmailIsLogin { get;set;}
/// <summary>
/// Pop3
/// </summary>
public String Pop3 { get;set;}
/// <summary>
/// UserName
/// </summary>
public String UserName { get;set;}
/// <summary>
/// HoldEmailPwd
/// </summary>
public Boolean? HoldEmailPwd { get;set;} }
}
