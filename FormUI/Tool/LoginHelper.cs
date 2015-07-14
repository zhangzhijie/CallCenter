using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ad.Model.DbModel;
using Ad.Util;
using Ad.Fw;

namespace FormUI.Tool
{
    public class LoginHelper
    {
        private static Y_V_Manager Employee = new Y_V_Manager();

        private static List<Y_Function> FunctionList = new List<Y_Function>();

        private static List<Y_Operation> OperationList = new List<Y_Operation>();

        private static IList<Y_Post_Privilege> PrivilegeList;

        private static Y_V_ORG_MEMBER OrgMember;

        private static string[] Channels;

        private static bool isGodUser = false;

        private static bool PositionPrivilegeInit(long? positionId)
        {
            try
            {
                if (positionId != null)
                {
                    var allFunctions = BllFunction.Select();
                    if (allFunctions == null || allFunctions.Count == 0)
                        return false;
                    var allOperations = BllOperation.Select();
                    if (allOperations == null || allOperations.Count == 0)
                        return false;


                    PrivilegeList = BllPositionPrivilege.Select(new Y_Post_Privilege() { PostId = positionId.Value });
                    if (PrivilegeList == null || PrivilegeList.Count == 0)
                        return false;

                    foreach (var privilegeEn in PrivilegeList)
                    {
                        var funIEnum = allFunctions.Where(m => m.FunctionId == privilegeEn.FunctionId);
                        if (funIEnum.Any() && !FunctionList.Where(m=>m.FunctionId == privilegeEn.FunctionId).Any())
                        {
                            FunctionList.Add(funIEnum.First());
                        }

                        var operIEnum = allOperations.Where(m => m.OperationId == privilegeEn.OperationId);
                        if (operIEnum.Any() && !OperationList.Where(m=>m.OperationId == privilegeEn.OperationId).Any())
                        {
                            OperationList.Add(operIEnum.First());
                        }
                    }
                    if (FunctionList.Count == 0 || OperationList.Count == 0)
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static ResultU ValidateLogin(string loginName,string password)
        {
            if (loginName.Equals(Const.GodUserName) && password.Equals(Const.GodUserPwd))
            {
                isGodUser = true;
                return new ResultU(true);
            }
            Employee = BllManager.Login(loginName, Ad.Security.MD5.Instance.BuildFingerprint(password));
            if (Employee == null)
            {
                return new ResultU{ IsOK = false, Msg = "登陆失败，用户名或密码错误" };
            }
            if (Employee.PostId == null)
            {
                return new ResultU{ IsOK = false, Msg = "用户职位为空，请联系管理员" };
            }
            if (!PositionPrivilegeInit(Employee.PostId))
            {
                return new ResultU{ IsOK =false,Msg="读取用户权限发生错误"};
            }
            OrgMember = BllORG_MEMBER.SelectByManagerId(Employee.ManagerId.GetValueOrDefault());
            if (OrgMember == null)
            {
                return new ResultU { IsOK=false,Msg="读取原系统员工资料错误"};
            }
            return new ResultU(true);
        }

        public static long GetManagerId()
        {
            return Employee.ManagerId.Value;
        }

        public static string GetManagerName()
        {
            return Employee.NAME;
        }

        public static string[] GetChannels()
        {
            if (Channels != null && Channels.Length > 0)
            {
                return Channels;
            }
            if (string.IsNullOrWhiteSpace(Employee.Channel))
            {
                return null;
            }
            return Employee.Channel.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static long GetDeptId()
        {
            return Employee.DepartId.Value;
        }

        public static string GetDetpName()
        {
            return Employee.DepartName;
        }

        // 原有系统部门ID
        public static long GetOrgDeptId()
        {
            return OrgMember.ORG_DEPARTMENT_ID.Value;
        }

        // 原有系统部门名称
        public static string GetOrgDeptName()
        {
            return OrgMember.DEPARTMENTNAME;
        }

        public static long GetPositionId()
        {
            return Employee.PostId.Value;
        }

        public static string GetPositionName()
        {
            return Employee.PostName;
        }

        public static bool IsHasFunction(EnumHelper.FunctionEnum fenum)
        {
            return FunctionList.Where(m => m.FunctionType == (int)fenum).Any();
        }

        public static bool FunIsHasOper(EnumHelper.FunctionEnum fenum,EnumHelper.OperationEnum oenum)
        {
            var funIEnum = FunctionList.Where(m => m.FunctionType == (int)fenum);
            if (!funIEnum.Any())
                return false;

            var operIEnum = OperationList.Where(m => m.OperationType == (int)oenum);
            if (!operIEnum.Any())
                return false;

            return PrivilegeList.Where(m => m.FunctionId == funIEnum.First().FunctionId && m.OperationId == operIEnum.First().OperationId).Any();
        }

        public static bool IsGodUser { get { return isGodUser; } }
       
    }
}
