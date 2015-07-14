using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Ad.Util;

namespace Ad.Tools.Util
{
    public static class RuleCompile
    {
        public static ResultU GetKey(string diagnosisKey)
        {
            Log.Log log = new Log.Log("Rule");
            string dllPath = Environment.CurrentDirectory + "\\" + "WGuaHao.Rule.Diagnosis.Rule.dll";
            if (!System.IO.File.Exists(dllPath))
            {
                System.CodeDom.Compiler.CodeDomProvider provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("cs");
                System.CodeDom.Compiler.CompilerParameters parameters = new System.CodeDom.Compiler.CompilerParameters();
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.GenerateInMemory = false;
                parameters.GenerateExecutable = false;
                parameters.OutputAssembly = dllPath;
                System.CodeDom.Compiler.CompilerResults compilerResult = provider.CompileAssemblyFromFile(parameters, new string[] { "Rule.txt" });
                if (compilerResult.Errors.HasErrors)
                {
                    string errorStr = "";
                    for (int i = 0; i < compilerResult.Errors.Count; i++)
                    {
                        errorStr += compilerResult.Errors[i].Line + "-- " + compilerResult.Errors[i].ErrorText + "\n";
                    }
                    log.Error("规则编译失败！\nError: " + errorStr);
                    return new ResultU(false, 0, errorStr);
                }
                try
                {
                    System.Reflection.Assembly objAssembly = compilerResult.CompiledAssembly;
                    Type type = objAssembly.GetType("WGuaHao.Rule.Diagnosis.Rule");

                    System.Reflection.MethodInfo mInfo = type.GetMethod("GetKey", new Type[] { typeof(string) });
                    if (mInfo != null)
                    {
                        object result = mInfo.Invoke(null, new object[] { diagnosisKey });
                        return new ResultU(true, 0, result.ToString());
                    }
                    else
                    {
                        return new ResultU(false, 0, "方法取得为空");
                    }
                }
                catch (Exception e)
                {
                    log.Error(e.StackTrace);
                    return new ResultU(false, 0, e.StackTrace);
                }
            }
            else
            {
                try
                {
                    System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFrom(dllPath);
                    Type type = ass.GetType("WGuaHao.Rule.Diagnosis.Rule");
                    System.Reflection.MethodInfo methodInfo = type.GetMethod("GetKey", new Type[] { typeof(string) });
                    if (methodInfo != null)
                    {
                        object result = methodInfo.Invoke(null, new object[] { diagnosisKey });
                        return new ResultU(true, 0, result.ToString());
                    }
                    else
                    {
                        return new ResultU(false, 0, "方法取得为空");
                    }
                }
                catch (Exception e)
                {
                    log.Error(e.StackTrace);
                    return new ResultU(false, 0, e.StackTrace);
                }

            }
        }
    }
}
