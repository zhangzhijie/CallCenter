using System;
using System.Collections.Generic;
namespace Ad.Model.DbModel{
 public class Y_KnowledgeBase_Description {
/// <summary>
/// KnowledgeCode
/// </summary>
public const string KnowledgeCode = "KnowledgeCode";
/// <summary>
/// CreateDate
/// </summary>
public const string CreateDate = "CreateDate";
/// <summary>
/// Suffix
/// </summary>
public const string Suffix = "Suffix";
/// <summary>
/// Title
/// </summary>
public const string Title = "Title";
/// <summary>
/// KeyWords
/// </summary>
public const string KeyWords = "KeyWords";
/// <summary>
/// Content
/// </summary>
public const string Content = "Content";
/// <summary>
/// UpdateDate
/// </summary>
public const string UpdateDate = "UpdateDate";
private readonly static Dictionary<string, string> propertyField_Dictionary;
private readonly static Dictionary<string, string> fieldProperty_Dictionary;
static Y_KnowledgeBase_Description(){
propertyField_Dictionary = new Dictionary<string, string>();
propertyField_Dictionary.Add(KnowledgeCode, "KnowledgeCode");
propertyField_Dictionary.Add(CreateDate, "CreateDate");
propertyField_Dictionary.Add(Suffix, "Suffix");
propertyField_Dictionary.Add(Title, "Title");
propertyField_Dictionary.Add(KeyWords, "KeyWords");
propertyField_Dictionary.Add(Content, "Content");
propertyField_Dictionary.Add(UpdateDate, "UpdateDate");
fieldProperty_Dictionary = new Dictionary<string, string>();
fieldProperty_Dictionary.Add("KnowledgeCode", KnowledgeCode);
fieldProperty_Dictionary.Add("CreateDate", CreateDate);
fieldProperty_Dictionary.Add("Suffix", Suffix);
fieldProperty_Dictionary.Add("Title", Title);
fieldProperty_Dictionary.Add("KeyWords", KeyWords);
fieldProperty_Dictionary.Add("Content", Content);
fieldProperty_Dictionary.Add("UpdateDate", UpdateDate);
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
return "Y_KnowledgeBase";}

public static string[] GetPrimaryProperties()
{
    return new string[] { KnowledgeCode };
}
public static string GetTableName()
{
return "Y_KnowledgeBase";}
public static string GetDataAccessString()
{
return Ad.Model.DbModel.Config.ConnectionString;
}
}
}
