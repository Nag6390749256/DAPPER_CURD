using Dapper;
using DAPPER_CURD.AppCode.Hellper;
using DAPPER_CURD.Models;
using System.Collections.Generic;

namespace DAPPER_CURD.AppCode
{
    public class BL
    {
        public ErrorViewModel CreateEmp(EmployeeModel req)
        {
            var ress = new ErrorViewModel();
            string Proc_name = "Proc_AddAndUpdateEmp";
            var param = new DynamicParameters();
            param.Add("@Id",req.Id);
            param.Add("@Name", req.Name);
            param.Add("@Age", req.Age);
            param.Add("@Salary",req.Salary);
            param.Add("@Position", req.Position);
            param.Add("@Department", req.Department);
            var res = DB_Helper.ExecuteProc<int>(Proc_name, param);
            if(res == 1)
            {
                ress.Statuscode = 1;
                ress.Msg = "Record insert successfully!";
            }
            else
            {
                ress.Statuscode = -1;
                ress.Msg = "Record insert failed!";
            }
            return ress;
        }
        public IEnumerable<EmployeeModel> GetEmp(int id)
        {
            string Proc_name = "Proc_GetEmp";
            var param = new DynamicParameters();
            param.Add("@Id", id);
            var res = DB_Helper.ExecuteProcList<EmployeeModel>(Proc_name, param);
            return res;
        }
        public ErrorViewModel DeleteEmp(int Id)
        {
            var ress = new ErrorViewModel();
            string query = "Delete from tbl_Employee where Id = @Id";
            var param = new DynamicParameters();
            param.Add("@Id", Id);
            var res = DB_Helper.ExecuteQuery<int>(query, param);
            if (res == 1)
            {
                ress.Statuscode = 1;
                ress.Msg = "Record Delete successfully!";
            }
            else
            {
                ress.Statuscode = -1;
                ress.Msg = "Record Delete failed!";
            }
            return ress;
        }
        public LoginResponse Dologin(LoginModel req)
        {
            var ress = new LoginResponse();
            string Proc_name = "proc_login";
            var param = new DynamicParameters();
            param.Add("@Username", req.Username);
            param.Add("@Password", req.Password);
            ress = (LoginResponse)DB_Helper.ExecuteQueryFirst<LoginResponse>(Proc_name, param);
            return ress;
        }
    }
}
