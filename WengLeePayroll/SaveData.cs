using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Data;
using System.Collections;

using System.Configuration;
using System.Data.SqlTypes;
using System.Collections.ObjectModel;
using System.IO;


namespace WengLeePayroll
{

    public class SaveData
    {
        //string conString = @"Data Source=.\BLUMENSOFT;Initial Catalog=TimeCard;Persist Security Info=True;User ID=sa;Password=sql2008; Min Pool Size=5;Max Pool Size=200;Connect Timeout=0;MultipleActiveResultSets=True;";
        //string conString = DB_Base.DB_STR;
        string conString = ConfigurationManager.ConnectionStrings["TimeCardConnectionString"].ConnectionString;
        public void SaveTempData(int EmpID, string Code, string attDate, string attDay,
            string Action, string Start, string Stop, string Hours, string Reg,
            string OT1, string OT2, string Paid, string Unpaid, string DefaultLevel, string EmpName, string DefaultLevelValue, string processDate, string FileName, string strDate_P, int PeriodId)
        {

            string strSQL = @"
                insert into Attendance(EmpID, Code, attDate, attDay, Action, Start, Stop, Hours, Reg, OT1, 
                OT2, Paid, Unpaid, DefaultLevel, EmpName, DefaultLevelValue, ProcessDate, FileName,attendenceDate, PeriodId) values
                ('" + EmpID + "', '" + Code + "', '" + attDate + "', '" + attDay + "', '" + Action + "', '" + Start + "', '" + Stop + @"', 
                " + Hours + ", " + Reg + ", " + OT1 + ", " + OT2 + ", " + Paid + ", " + Unpaid + ", '" + DefaultLevel + "', '" + EmpName + "', " + DefaultLevelValue + @", convert(datetime,'" + processDate + "',101), '" + FileName + @"', '" + strDate_P + @"', " + PeriodId + @")
                ";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
            con.Dispose();
            dbCommand.Dispose();
            adpt.Dispose();
        }
        public void DeleteAttendanceData(string PeriodId)
        {

            string strSQL = @"DELETE FROM Attendance where PeriodId=" + PeriodId + @"
                                DELETE FROM Attendance_Archive where PeriodId=" + PeriodId + @"
                                ";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
            con.Dispose();
            dbCommand.Dispose();
            adpt.Dispose();
        }
        public DataTable ImportEmpFromAttendanceSheetIfNew()
        {

            string strSQL = @"
                select distinct EmpID, EmpName,
                isnull(convert(varchar(12),PeriodFrom, 107),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period , FileName
                from Attendance left join PayPeriod on Attendance.PeriodId =PayPeriod.PeriodId
                where EmpID not in(
	                select TLOID from Employees
                );


                insert into Employees(TLOID, NAME, FirstName, LastName, InsertWhileAttendance, InsertFromPeriodId) 
                select distinct EmpID, EmpName, SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1), SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000), 1, PeriodId
                from Attendance
                where EmpID not in(
	                select TLOID from Employees
                );";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds.Tables[0];
        }
        public void SaveSalariedTemplate(int EmpID, string Reg, string OT1, string OT2)
        {

            string strSQL = @"
                delete from SalariedEmpTimeTemplate where EmpID=" + EmpID + @";
                insert into SalariedEmpTimeTemplate(EmpID, Reg, OT1, OT2) values
                (" + EmpID + ", " + Reg + ", " + OT1 + ", " + OT2 + ");";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void UpdateSalariedTemplate(int TemplateId, int EmpID, string Reg, string OT1, string OT2)
        {
            string strSQL = @"
                update SalariedEmpTimeTemplate set EmpID=" + EmpID + ", Reg=" + Reg + ", OT1=" + OT1 + ",OT2=" + OT2 + " where TemplateAutoiD=" + TemplateId + "";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeleteSalariedTemplate(int TemplateId)
        {

            string strSQL = @"
                delete from SalariedEmpTimeTemplate where TemplateAutoiD=" + TemplateId + "";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeleteUser(int _UserAutoID)
        {

            string strSQL = @"
                delete from Users where UserAutoID=" + _UserAutoID + "";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void SaveUsers(string _UserName, string _Password, string _Status, string _FullName, string _Address1, string _Address2, string _City, string _State, string _Zip, string _Phone, string _Email, string _UserLevel)
        {

            string strSQL = @"
                
                insert into Users(UserName, Password, Status, FullName, Address1, Address2, City, State, Zip, Phone, Email, UserLevel) values
                ('" + _UserName + "', '" + _Password + "', " + _Status + ", '" +  _FullName + "', '" + _Address1 + "', '" +  _Address2 + @"', 
                '" +  _City + "', '" +  _State + "', '" +  _Zip + "', '" +  _Phone + "', '" +  _Email + "', " +  _UserLevel + ");";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }

        public void UpdateUsers(int _UserAutoID, string _UserName, string _Password, string _Status, string _FullName, string _Address1, 
            string _Address2, string _City, string _State, string _Zip, string _Phone, string _Email, string _UserLevel)
        {
            string strSQL = "";
            if (_Password != "")
            {
                strSQL = @"
                update Users set UserName='" + _UserName + "', Password='" + _Password + "', Status=" + _Status + @",
                FullName='" + _FullName + "', Address1='" + _Address1 + "', Address2='" + _Address2 + @"',    
                City='" + _City + "', State='" + _State + "', Zip='" + _Zip + @"', 
                Phone='" + _Phone + "', Email='" + _Email + "', UserLevel=" + _UserLevel + @" 
                where UserAutoID=" + _UserAutoID + "";
            }
            else
            {
                strSQL = @"
                update Users set UserName='" + _UserName + "', Status=" + _Status + @",
                FullName='" + _FullName + "', Address1='" + _Address1 + "', Address2='" + _Address2 + @"',    
                City='" + _City + "', State='" + _State + "', Zip='" + _Zip + @"', 
                Phone='" + _Phone + "', Email='" + _Email + "', UserLevel=" + _UserLevel + @" 
                where UserAutoID=" + _UserAutoID + "";
            }
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }

        public void ChangePassword(int _UserAutoID,string _Password)
        {
            string strSQL = "";
            
                strSQL = @"
                update Users set  Password='" + _Password + @"'
                where UserAutoID=" + _UserAutoID + "";
                SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }

        public void DeleteSalariedTime(int AutoId)
        {

            string strSQL = @"
                delete from SalariedEmpTime where SalAutoiD=" + AutoId + "";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void SaveSalariedData(int EmpID, string Reg, string OT1, string OT2, string processDate)
        {

            string strSQL = @"
                delete from SalariedEmpTime where EmpID=" + EmpID + " and ProcessDate=convert(datetime,'" + processDate + @"',101);
                insert into SalariedEmpTime(EmpID, Reg, OT1, OT2, ProcessDate) values
                (" + EmpID + ", " + Reg + ", " + OT1 + ", " + OT2 + ", convert(datetime,'" + processDate + @"',101) );";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void SaveSalariedDataByPayPeriod(int EmpID, string Reg, string OT1, string OT2, string _periodid)
        {

            string strSQL = @"
                delete from SalariedEmpTime where EmpID=" + EmpID + " and PeriodId=" + _periodid + @";
                insert into SalariedEmpTime(EmpID, Reg, OT1, OT2, PeriodId) values
                (" + EmpID + ", " + Reg + ", " + OT1 + ", " + OT2 + ", " + _periodid + @" );";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void SaveEmployee(string TLOID, string STARTTIME, string HIREDATE, string JOBSTATUS, string GENDER, string DOB, string W4MaritalStatus, string W4Dependents, string FirstName,
            string LastName, string DepartmentId, string DesignationId, string ClockId, string EmploymentType, string strLastDay,
            string HealthInsurance, string HIEligibilityDate, string HIJoinDate, string DriversLicense, string DriversLicenseDateOfExpiration, string SSN)
        {


            string strSQL = @"
                insert into Employees(TLOID, NAME, STARTTIME, HIREDATE, GENDER, DOB, W4MaritalStatus, W4Dependents, FirstName, LastName, DepartmentId, DesignationId, ClockId, 
                         EmploymentType, JobStatusId, LASTDAY, HealthInsurance,HIEligibilityDate,HIJoinDate,DriversLicense,DriversLicenseDateOfExpiration, SSN) values
                
                ('" + TLOID + "', '" + FirstName + " " + LastName + "', '" + STARTTIME + @"', convert(datetime,'" + HIREDATE + @"',101), '" + GENDER + @"', 
            convert(datetime,'" + DOB + @"',101), '" + W4MaritalStatus + "','" + W4Dependents + @"', 
            '" + FirstName + "','" + LastName + "'," + DepartmentId + "," + DesignationId + "," + ClockId + "," + EmploymentType + @"," + JOBSTATUS + ", '" + strLastDay + @"',
            " + HealthInsurance + ",convert(datetime,'" + HIEligibilityDate + @"',101),'" + HIJoinDate + "','" + DriversLicense + "','" + DriversLicenseDateOfExpiration + "','" + SSN + @"');";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
            //('" + TLOID + "', '" + FirstName + " " + LastName + "', convert(datetime,'" + STARTTIME + @"',113), convert(datetime,'" + HIREDATE + @"',101), '" + GENDER + @"', 
        }
        public void UpdateEmployee(string AutoID, string TLOID, string STARTTIME, string HIREDATE, string JOBSTATUS, string GENDER, string DOB, string W4MaritalStatus, string W4Dependents, string FirstName,
                string LastName, string DepartmentId, string DesignationId, string ClockId, string EmploymentType, string strLastDay,
            string HealthInsurance, string HIEligibilityDate, string HIJoinDate, string DriversLicense, string DriversLicenseDateOfExpiration, string SSN)
        {
            string strSQL = @"
                UPDATE Employees SET TLOID='" + TLOID + "', NAME='" + FirstName + " " + LastName + "', STARTTIME='" + STARTTIME + @"', HIREDATE= convert(datetime,'" + HIREDATE + @"',101), 
            GENDER='" + GENDER + @"', DOB=convert(datetime,'" + DOB + @"',101), W4MaritalStatus='" + W4MaritalStatus + "', W4Dependents='" + W4Dependents + @"', 
            FirstName='" + FirstName + "', LastName='" + LastName + "', DepartmentId=" + DepartmentId + ", DesignationId=" + DesignationId + ", ClockId=" + ClockId + @", 
                         EmploymentType=" + EmploymentType + @", JobStatusId=" + JOBSTATUS + ", LASTDAY='" + strLastDay + @"', 
                HealthInsurance=" + HealthInsurance + ", HIEligibilityDate=convert(datetime,'" + HIEligibilityDate + @"',101), HIJoinDate='" + HIJoinDate + @"',
                DriversLicense='" + DriversLicense + "',DriversLicenseDateOfExpiration='" + DriversLicenseDateOfExpiration + "',SSN='" + SSN + @"'
                WHERE EmpAutoID=" + AutoID + ";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
            //('" + TLOID + "', '" + FirstName + " " + LastName + "', convert(datetime,'" + STARTTIME + @"',113), convert(datetime,'" + HIREDATE + @"',101), '" + GENDER + @"', 
        }
        public void DeleteEmployee(string _EmpAutoID)
        {
            string strSQL = @"
                DELETE FROM Employees WHERE EmpAutoID=" + _EmpAutoID + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void SavePayPeriod(string _PeriodFrom, string _PeriodTo, string _payDate, string _payPeriod, string _status)
        {

            string strSQL = @"
                delete from PayPeriod where PayDate=convert(datetime,'" + _payDate + @"',101);
                insert into PayPeriod(PeriodFrom, PeriodTo, Comments, PayDate, Status) values
                (convert(datetime,'" + _PeriodFrom + "',101), convert(datetime,'" + _PeriodTo + "',101), '" + _payPeriod + "', convert(datetime,'" + _payDate + "',101), " + _status + @" );";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void UpdatePayPeriod(string _payId, string _PeriodFrom, string _PeriodTo, string _payDate, string _payPeriod, string _status)
        {

            string strSQL = @"
                UPDATE PayPeriod SET PeriodFrom=convert(datetime,'" + _PeriodFrom + "',101), PeriodTo=convert(datetime,'" + _PeriodTo + "',101), Comments='" + _payPeriod + "', PayDate=convert(datetime,'" + _payDate + "',101), Status=" + _status + " WHERE PeriodId=" + _payId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeletePayPeriod(string _payId)
        {
            string strSQL = @"
                DELETE FROM PayPeriod WHERE PeriodId=" + _payId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void SaveCompanyHolidays(string _HolidayDate, string _Comments)
        {

            string strSQL = @"
                insert into CompanyHolidays(HolidayDate, Comments) values
                (convert(datetime,'" + _HolidayDate + "',101), '" + _Comments + @"' );";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void UpdateCompanyHolidays(string _ChId, string _HolidayDate, string _Comments)
        {

            string strSQL = @"
                UPDATE CompanyHolidays SET HolidayDate=convert(datetime,'" + _HolidayDate + "',101), Comments='" + _Comments + "' WHERE CHId=" + _ChId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeleteCompanyHolidays(string _CHId)
        {
            string strSQL = @"
                DELETE FROM CompanyHolidays WHERE CHId=" + _CHId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void SaveDepartments(string _Department)
        {

            string strSQL = @"
                insert into Department(DepartmentDesc) values
                ('" + _Department.Replace("'","''") + @"' );";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void UpdateDepartments(string _DepartmentId, string _Department)
        {

            string strSQL = @"
                UPDATE Department SET DepartmentDesc='" + _Department.Replace("'", "''") + "' WHERE DepartmentId=" + _DepartmentId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeleteDepartments(string _DepartmentId)
        {
            string strSQL = @"
                DELETE FROM Department WHERE DepartmentId=" + _DepartmentId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }

        public void SaveDesignations(string _DesignationDesc)
        {

            string strSQL = @"
                insert into Designation(DesignationDesc) values
                ('" + _DesignationDesc.Replace("'", "''") + @"' );";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void UpdateDesignations(string _DesignationId, string _DesignationDesc)
        {

            string strSQL = @"
                UPDATE Designation SET DesignationDesc='" + _DesignationDesc.Replace("'", "''") + "' WHERE DesignationId=" + _DesignationId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeleteDesignations(string _DesignationId)
        {
            string strSQL = @"
                DELETE FROM Designation WHERE DesignationId=" + _DesignationId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }

        public void SavePersonalLeave(string _PeriodType, string _RequestDate, string _EmpAutoID, string _LeaveDate, string _LeaveToDate, string _Days, string _Hours, string _LeaveType, string _WC, string _Comments)
        {
            string strSQL = @"
                insert into PersonalLeave(PeriodType, RequestDate, EmpAutoID, LeaveDate, LeaveToDate, LDays, LHours, LeaveType, LWC, Comments) values
                (" + _PeriodType + ",convert(datetime,'" + _RequestDate + "',101)," + _EmpAutoID + ",convert(datetime,'" + _LeaveDate + "',101),convert(datetime,'" + _LeaveToDate + "',101), " + _Days + ", " + _Hours + ", " + _LeaveType + ", " + _WC + ", '" + _Comments + @"' );
            declare @currid int;
            set @currid=(SELECT IDENT_CURRENT('PersonalLeave'));
            insert into LeaveDates(PLId,EmpAutoID,LDate)
            select @currid, " + _EmpAutoID + ", * from dbo.[DateBackbone](convert(datetime,'" + _LeaveDate + "',101), convert(datetime,'" + _LeaveToDate + @"',101))
            ";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void UpdatePersonalLeave(string _PLId, string _PeriodType, string _RequestDate, string _EmpAutoID, string _LeaveDate, string _LeaveToDate, string _Days, string _Hours, string _LeaveType, string _WC, string _Comments)
        {

            string strSQL = @"
            update  PersonalLeave set PeriodType=" + _PeriodType + ", RequestDate=convert(datetime,'" + _RequestDate + "',101), EmpAutoID=" + _EmpAutoID + @", 
            LeaveDate=convert(datetime,'" + _LeaveDate + "',101), LeaveToDate=convert(datetime,'" + _LeaveToDate + "',101), LDays=" + _Days + ", LHours=" + _Hours + @", 
            LeaveType=" + _LeaveType + ", LWC=" + _WC + ", Comments='" + _Comments + @"'
            WHERE PLId=" + _PLId + @";
            
            delete from LeaveDates where PLId=" + _PLId + @";
            insert into LeaveDates(PLId,EmpAutoID,LDate)
            select " + _PLId + ", " + _EmpAutoID + ", * from dbo.[DateBackbone](convert(datetime,'" + _LeaveDate + "',101), convert(datetime,'" + _LeaveToDate + @"',101))

                ";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeletePersonalLeave(string _PLId)
        {
            string strSQL = @"
                DELETE FROM LeaveDates WHERE PLId=" + _PLId + @";
                DELETE FROM PersonalLeave WHERE PLId=" + _PLId + @";";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void DeleteTempData()
        {
            string strSQL = @"delete from Attendance; DBCC CHECKIDENT (Attendance, RESEED, 0);";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
        public void CopyToArchive()
        {
            string strSQL = @"delete from [dbo].[Attendance_Archive] where [FileName] in (select distinct [FileName] from [dbo].[Attendance]);
                    delete from [dbo].[Attendance_Archive] where PeriodId in (select distinct PeriodId from [dbo].[Attendance]);
                    insert into [dbo].[Attendance_Archive] select * from [dbo].[Attendance];
                    update PayPeriod set isImportCompleted = 1 where PeriodId= (select distinct PeriodId from [dbo].[Attendance]);
                    ";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
        }
    }

}
