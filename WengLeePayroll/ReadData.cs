using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WengLeePayroll
{
    public class ReadData
    {
        //string conString = @"Data Source=.\BLUMENSOFT;Initial Catalog=TimeCard;Persist Security Info=True;User ID=sa;Password=sql2008; Min Pool Size=5;Max Pool Size=200;Connect Timeout=0;MultipleActiveResultSets=True;";
        //string conString = DB_Base.DB_STR;
        string conString = ConfigurationManager.ConnectionStrings["TimeCardConnectionString"].ConnectionString;
        public DataSet GetAttendanceResult(string _EmpID, string _PageOption, string _SortBy, string _SortOption)
        {

            string strSQL = @"
                SELECT * FROM (
                SELECT    EmpTableAutoID, EmpID, 
                ROW_NUMBER() OVER(PARTITION BY EmpID ORDER BY EmpTableAutoID asc) as RowNum,
                Code, attDate, attDay, Action, Start, Stop, Hours, Reg, OT1, OT2, Paid, Unpaid, DefaultLevel, EmpName, DefaultLevelValue,
                SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName,
                (SELECT COUNT(EMPID) FROM Attendance B WHERE B.EMPID=A.EMPID) RCNT,
                convert(varchar(10), ProcessDate, 101) ProcessDate,
				isnull(convert(varchar(12),PeriodFrom, 107),'') + ' - '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period
                FROM         Attendance A
				inner join PayPeriod P on P.PeriodId=A.PeriodId) A 
                where EmpTableAutoID>0 ";
            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";

            }
            else
            {
                if (_PageOption == "1")
                { strSQL += "AND RCNT<=35 "; }

                if (_PageOption == "2")
                { strSQL += "AND RCNT>35 "; }

                if (_SortBy == "0")
                {
                    //strSQL += "ORDER BY RCNT, EmpId, EmpName,EmpTableAutoID ";
                    strSQL += "ORDER BY DefaultLevelValue, EmpId, EmpName,EmpTableAutoID ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc; ";
                }
            }
            //strSQL += "ORDER BY DefaultLevelValue, EmpName ";



            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetAttendanceResultArchive(string _EmpID, string _PageOption, string _SortBy, string _SortOption, string _PayDay)
        {

            string strSQL = @"
                SELECT * FROM (
                SELECT    EmpTableAutoID, EmpID, 
                ROW_NUMBER() OVER(PARTITION BY EmpID ORDER BY EmpTableAutoID asc) as RowNum,
                Code, attDate, attDay, Action, Start, Stop, Hours, Reg, OT1, OT2, Paid, Unpaid, DefaultLevel, EmpName, DefaultLevelValue,
                SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName,
                (SELECT COUNT(EMPID) FROM dbo.Attendance_Archive B WHERE B.EMPID=A.EMPID AND B.PeriodId =A.PeriodId) RCNT,
                convert(varchar(10), ProcessDate, 101) ProcessDate, [FileName],P.PeriodId,
                isnull(convert(varchar(12),PeriodFrom, 107),'') + ' - '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period
                FROM         dbo.Attendance_Archive A 
                inner join PayPeriod P on P.PeriodId=A.PeriodId) A 
                where EmpTableAutoID>0 ";
            if (_PayDay != "0")
            {
                strSQL += "AND PeriodId =" + _PayDay + @" ";
            }
            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";

            }
            else
            {
                if (_PageOption == "1")
                { strSQL += "AND RCNT<=38 "; }

                if (_PageOption == "2")
                { strSQL += "AND RCNT>38 "; }

                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY RCNT, EmpId, EmpName,EmpTableAutoID ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc; ";
                }
            }




            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetAttendanceResultArchiveDateDuration(string _EmpID, string _SortBy, string _SortOption, string _FromDate, string _ToDate)
        {

            string strSQL = @"
                SELECT * FROM (
	                SELECT    EmpTableAutoID, EmpID, 
	                ROW_NUMBER() OVER(PARTITION BY EmpID ORDER BY EmpTableAutoID asc) as RowNum,
	                Code, attDate, attendenceDate, attDay, Action, Start, Stop, Hours, Reg, OT1, OT2, Paid, Unpaid, DefaultLevel, EmpName, DefaultLevelValue,
	                SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
	                SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName,
	                convert(varchar(10), ProcessDate, 101) ProcessDate, [FileName], P.PeriodId,
	                isnull(convert(varchar(12), '" + _FromDate + "',107),'') + ' - '+ isnull(convert(varchar(12), '" + _ToDate + @"',107),'') Period
	                FROM         dbo.Attendance_Archive A 
	                inner join PayPeriod P on P.PeriodId=A.PeriodId) A 
                where EmpTableAutoID>0 
                and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + "',101)) ";

            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";
                strSQL += "order by attendenceDate, EmpTableAutoID";
            }
            else
            {
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY attendenceDate, EmpTableAutoID, EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY attendenceDate, EmpTableAutoID, EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY attendenceDate, EmpTableAutoID, EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY attendenceDate, EmpTableAutoID, FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY attendenceDate, EmpTableAutoID, LastName ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc; ";
                }
               // strSQL += ", attendenceDate, EmpTableAutoID";
            }

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetAttendanceSummaryResult(string _EmpID, string _PageOption, string _SortBy, string _SortOption)
        {

            string strSQL = @"
                SELECT * FROM (
                    select convert(varchar(10), P.PayDate, 101) ProcessDate, EmpID, EmpName, SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                    SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName
                    , sum(Reg) Reg, sum(OT1) OT1, sum(OT2) OT2,

                    (SELECT COUNT(EMPID) FROM Attendance B WHERE B.EMPID=A.EMPID) RCNT
                      from Attendance A
					  inner join PayPeriod P on P.PeriodId=A.PeriodId
                    group by P.PayDate, EmpID, EmpName 
		                union 
	                select convert(varchar(10), P.PayDate, 101) ProcessDate, S.EmpID, E.Name EmpName,E.FirstName, E.LastName,Reg, OT1, OT2 , 1 RCNT
                    from SalariedEmpTime  S inner join Employees E on E.TLOID=S.EmpID
					inner join PayPeriod P on P.PeriodId=S.PeriodId
                    where S.PeriodId in (select top 1 PeriodId from Attendance)
                ) A 
                where EmpID<>'' ";
            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";

            }
            else
            {
                if (_PageOption == "1")
                { strSQL += "AND RCNT<=34 "; }

                if (_PageOption == "2")
                { strSQL += "AND RCNT>34 "; }

                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY RCNT, EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc; ";
                }
            }




            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetImportedFileNames()
        {

            string strSQL = @"
                select distinct [FileName], convert(varchar(12),P.PayDate,107) ProcessDate, convert(varchar(12),A.InsertDate,107) InsertDate,
                convert(varchar(12),convert(datetime,P.PeriodFrom,101),107) FromDate,  convert(varchar(12),convert(datetime,p.PeriodTo,101),107) ToDate, P.PeriodId, convert(varchar(12),P.PayDate,101) xx, 
                case
                 when isnull(isImportCompleted,0)=1 then 'Yes'
                 when isnull(isImportCompleted,0)=0 then 'No'
                 else 'No'
                end isImportCompleted
                from [dbo].[Attendance_Archive] A
                inner join PayPeriod P on P.PeriodId=A.PeriodId
                where attDate<>'' 
                order by convert(varchar(12),P.PayDate,101) desc, convert(varchar(12),A.InsertDate,107) desc;";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataTable GetImportedFileNamesWithPayDate()
        {

            string strSQL = @"
                select distinct P.PeriodId, isnull(convert(varchar(12),PeriodFrom, 107),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period, P.PayDate
                from [dbo].[Attendance_Archive] A
                inner join PayPeriod P on P.PeriodId=A.PeriodId
                where attDate<>''
                order by P.PayDate desc";

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
        public DataTable GetEmployeeList()
        {

            string strSQL = @" select EmpID, EmpName from (
                 select 0 as EmpID, '<All>' EmpName 
                 union all
                 SELECT distinct EmpID, convert(varchar(50),EmpID)  + ' - ' + EmpName as EmpName FROM dbo.Attendance 
                 ) A
                 order by EmpID asc";

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
        public DataSet GetLateArchiveDateDuration(string _EmpID, string _SortBy, string _SortOption, string _FromDate, string _ToDate)
        {

            //LTRIM(RIGHT(CONVERT(VARCHAR(20), start, 100), 7))
            string strSQL = @"
            ;with cte as (
            SELECT *, 
				        case when LateInMinute>15 then
					        CONVERT(varchar(5), DATEADD(minute, LateInMinute, 0), 114) 
				            else '' end LateHour, 
                        CASE WHEN LateInMinute>15 THEN 'Late' else '' end LATEStatus , 
				        CASE WHEN EarlyInMinute>15 THEN 'Early In' else '' end EarlyInStatus, 
				        CASE WHEN EarlyInMinute<-15 THEN 'Late' WHEN EarlyInMinute>15 THEN 'Early In' else '' end AttStatus, 
                        CASE WHEN WorkTotal<3 then 'Early Out' else '' end EarlyExitStatus
                        FROM (
                            SELECT 0 as 'Leave', EmpID, E.NAME as EmpName, attendenceDate,DATENAME(dw,attendenceDate) as WeekDay, LTRIM(RIGHT(min(CONVERT(datetime, start, 100)), 8)) InTime , 
                                            LTRIM(RIGHT(min(CONVERT(datetime, [stop], 100)), 8)) OutTimeMin,
                                            LTRIM(RIGHT(max(CONVERT(datetime, [stop], 100)), 8)) OutTime,
                                            E.FirstName, E.LastName,  STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
				                            DATEDIFF(MINUTE,convert(varchar(10), STARTTIME, 8), min(convert(datetime,start,100))) LateInMinute,
                                            DATEDIFF(MINUTE, min(convert(datetime,start,100)),convert(varchar(10), STARTTIME, 8)) EarlyInMinute
                                            , SUM(Reg) + SUM(OT1) + SUM(OT2) WorkTotal, SUM(Reg) Reg, SUM(OT1) OT1, SUM(OT2) OT2,
                                            '' as LeaveType
                                            FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                            and E.JOBSTATUS='ACTIVE'
				                            group by EmpID, E.NAME, E.FirstName, E.LastName,  attendenceDate, STARTTIME
                            --				order by EmpID, EmpName, attendenceDate
                        union all
			                SELECT 1 as 'Leave', E.TLOID, E.NAME as EmpName, A.LDate, DATENAME(dw,A.LDate) as WeekDay,  '00:01AM' InTime , 
				            '00:01AM' OutTimeMin,
				            '00:01AM' OutTime,
				            E.FirstName, E.LastName,  STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
				            0 LateInMinute,
				            0 EarlyInMinute
				            , 0 WorkTotal, 0 Reg, 0 OT1, 0 OT2,
				            case 
				            when LeaveType=1 then 'Sick/Medical Leave'
				            when LeaveType=2 then 'Casual Leave'
				            when LeaveType=3 then 'Maternity Leave'
				            when LeaveType=4 then 'Parental Leave'
				            when LeaveType=5 then 'Personal Leave'
				            end LeaveType
				            FROM         dbo.PersonalLeave L left join  Employees E on L.EmpAutoID=E.EmpAutoID
				            left join dbo.LeaveDates A on A.PLId=L.PLId and A.EmpAutoID=E.EmpAutoID
				            and E.JOBSTATUS='ACTIVE'
				            group by  E.TLOID, E.NAME, E.FirstName, E.LastName, A.LDate, STARTTIME, LeaveType
                    union all
						SELECT 2 as 'Leave', E.TLOID, E.NAME as EmpName, L.HolidayDate, DATENAME(dw,L.HolidayDate) as WeekDay,  '00:01AM' InTime , 
						'00:01AM' OutTimeMin,
						'00:01AM' OutTime,
						E.FirstName, E.LastName, STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
						0 LateInMinute,
						0 EarlyInMinute
						, 0 WorkTotal, 0 Reg, 0 OT1, 0 OT2,
						'Company Holiday' LeaveType
						FROM         dbo.CompanyHolidays L, Employees E
						where E.JOBSTATUS='ACTIVE'
						group by  E.TLOID, E.NAME, E.FirstName, E.LastName,  L.HolidayDate, STARTTIME
                            ) A
            )

            select *
				    ,(select count(LATEStatus) from cte b where b.EmpID=a.EmpID and LATEStatus='Late'  and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntLATEStatus
                    ,(select count(EarlyInStatus) from cte b where b.EmpID=a.EmpID and EarlyInStatus='Early In'  and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntEarlyInStatus
                    ,(select count(EarlyExitStatus) from cte b where b.EmpID=a.EmpID and EarlyExitStatus='Early Exit'  and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntEarlyExitStatus
                    ,(select count(*) from cte b where b.EmpID=a.EmpID and Leave=0  and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) WorkDays
                    ,(select count(EarlyInStatus) from cte b where b.EmpID=a.EmpID and Leave=1  and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) PersonalLeave
                    ,(select count(EarlyExitStatus) from cte b where b.EmpID=a.EmpID and Leave=2  and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) CompanyLeave
					,DATEDIFF(DAY, convert(datetime, '" + _FromDate + "',101), convert(datetime, '" + _ToDate + @"',101)) TotalDays
				from cte A

                where EmpID>0 
                and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + "',101)) ";

            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";
                strSQL += "order by attendenceDate Asc";

            }
            else
            {
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }
                //Mandatory Sort
                strSQL += ", attendenceDate Asc";
            }
            
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetLongLucnArchiveDateDuration(string _EmpID, string _SortBy, string _SortOption, string _FromDate, string _ToDate, string _Action, int _Minute)
        {

            string strSQL = @"
            ;with cte as (
            SELECT *
                    FROM (
                        SELECT  EmpID, EmpName, attendenceDate,A.Action, start InTime, [stop] OutTime,
                                        SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                        SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, 
				                        DATEDIFF(MINUTE,convert(datetime,start,100), convert(datetime,[stop],100)) LateInMinute
                                        FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                        and E.JOBSTATUS='ACTIVE'
										where A.Action='" + _Action + @"'
				                        --group by EmpID, EmpName, attendenceDate, STARTTIME
                        ) A
            )

            select *, " + _Minute + @" ForMin from CTE 
            where LateInMinute>" + _Minute + @" 
            and EmpID>0 
            and (attendenceDate>=convert(datetime, '" + _FromDate + "',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) 
            --order by EmpID, EmpName, attendenceDate, convert(datetime,InTime,100)
            ";

            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";
                strSQL += "order by attendenceDate Asc, convert(datetime,InTime,100)";
            }
            else
            {
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                else if (_SortBy == "5")
                {
                    strSQL += "ORDER BY attendenceDate Asc, EmpId ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }
                //Mandatory Sort
                if (_SortBy != "5")
                {
                    strSQL += ",attendenceDate Asc, convert(datetime,InTime,100)";
                }
                else
                {
                    strSQL += ", convert(datetime,InTime,100)";
                }
            }




            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetCoverPageArchiveDateDuration(string _EmpID, string _SortBy, string _SortOption, string _FromDate, string _ToDate, int _MinuteLunch, int _MinuteBreak)
        {

            string strSQL = @"
            DECLARE @T1 TABLE (
			EmpID int,
			EmpName VARCHAR(200),
			FirstName VARCHAR(200),
			LastName VARCHAR(200),
			AttDays int,
			LATE int,
			EarlyIn int,
			EarlyExit int,
			LongLunch int,
			LongBreak int,
            Reg numeric(9,2), 
            OT1 numeric(9,2), 
            OT2 numeric(9,2)
			);


            ;with cte2 as (
            SELECT *, 
				        case when LateInMinute>15 then
					        CONVERT(varchar(5), DATEADD(minute, LateInMinute, 0), 114) 
				            else '' end LateHour, 
                        CASE WHEN LateInMinute>15 THEN 'Late' else '' end LATEStatus , 
				        CASE WHEN EarlyInMinute>15 THEN 'Early In' else '' end EarlyInStatus, 
				        CASE WHEN EarlyInMinute<-15 THEN 'Late' WHEN EarlyInMinute>15 THEN 'Early In' else '' end AttStatus, 
                        CASE WHEN WorkTotal<3 then 'Early Out' else '' end EarlyExitStatus
                        FROM (
                            SELECT  EmpID, EmpName, attendenceDate, LTRIM(RIGHT(min(CONVERT(datetime, start, 100)), 8)) InTime, LTRIM(RIGHT(min(CONVERT(datetime, [stop], 100)), 8)) OutTime,
                                            SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                            SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
				                            DATEDIFF(MINUTE,convert(varchar(10), STARTTIME, 8), min(convert(datetime,start,100))) LateInMinute,
                                            DATEDIFF(MINUTE, min(convert(datetime,start,100)),convert(varchar(10), STARTTIME, 8)) EarlyInMinute
                                            , SUM(Reg) + SUM(OT1) + SUM(OT2) WorkTotal, SUM(Reg) Reg, SUM(OT1) OT1, SUM(OT2) OT2
                                            FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                            and E.JOBSTATUS='ACTIVE'
				                            group by EmpID, EmpName, attendenceDate, STARTTIME
                            --				order by EmpID, EmpName, attendenceDate
                            ) A
            )

			insert into @T1 (EmpID, EmpName, FirstName, LastName, AttDays, LATE, EarlyIn, EarlyExit, Reg, OT1, OT2) 
			select EmpID, EmpName, FirstName, LastName, max(cntAttDays) AttDays, max(cntLATEStatus) LATE, max(cntEarlyInStatus) EarlyIn, max(cntEarlyExitStatus) EarlyExit,sum(Reg) Reg, sum(OT1) OT1, sum(OT2) OT2  
			from (
            select *
					,(select count(*) from cte2 b where b.EmpID=a.EmpID and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntAttDays
				    ,(select count(LATEStatus) from cte2 b where b.EmpID=a.EmpID and LATEStatus='Late'  and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntLATEStatus
                    ,(select count(EarlyInStatus) from cte2 b where b.EmpID=a.EmpID and EarlyInStatus='Early In'  and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntEarlyInStatus
                    ,(select count(EarlyExitStatus) from cte2 b where b.EmpID=a.EmpID and EarlyExitStatus='Early Exit'  and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntEarlyExitStatus
				from cte2 A

                where EmpID>0 
                and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) --ORDER BY EmpId, EmpName , attendenceDate Asc
				) A
				GROUP BY EmpID, EmpName, FirstName, LastName
				ORDER BY EmpId, EmpName;
			
			--select * from @T1;
            
			;with cte as (
            SELECT *
                    FROM (
                        SELECT  EmpID, EmpName, attendenceDate,A.Action, start InTime, [stop] OutTime,
                                        SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                        SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, 
				                        DATEDIFF(MINUTE,convert(datetime,start,100), convert(datetime,[stop],100)) LateInMinute
                                        FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                        and E.JOBSTATUS='ACTIVE'
										where A.Action='Lunch'
				                        --group by EmpID, EmpName, attendenceDate, STARTTIME
                        ) A
            )
		
		insert into @T1 (EmpID, EmpName, FirstName, LastName, LongLunch) 
		select EmpID, EmpName, FirstName, LastName,  max(cntLATEStatus) LongLunch
		from (
        select *, 
			(select count(LateInMinute) from cte b where b.EmpID=a.EmpID and LateInMinute>" + _MinuteLunch + @"  and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntLATEStatus
		," + _MinuteLunch + @" ForMin from CTE A
            where LateInMinute>" + _MinuteLunch + @" 
            and EmpID>0 
            and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) 
            --ORDER BY EmpId, EmpName ,attendenceDate Asc, convert(datetime,InTime,100);
			) A
			group by EmpID, EmpName, FirstName, LastName;

  --select * from @T1;

  ;with cte as (
            SELECT *
                    FROM (
                        SELECT  EmpID, EmpName, attendenceDate,A.Action, start InTime, [stop] OutTime,
                                        SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                        SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, 
				                        DATEDIFF(MINUTE,convert(datetime,start,100), convert(datetime,[stop],100)) LateInMinute
                                        FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                        and E.JOBSTATUS='ACTIVE'
										where A.Action='Break'
				                        --group by EmpID, EmpName, attendenceDate, STARTTIME
                        ) A
            )
		
		insert into @T1 (EmpID, EmpName, FirstName, LastName, LongBreak) 
		select EmpID, EmpName, FirstName, LastName,  max(cntLATEStatus) LongBreak
		from (
        select *, 
			(select count(LateInMinute) from cte b where b.EmpID=a.EmpID and LateInMinute>" + _MinuteBreak + @"  and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) ) cntLATEStatus
		," + _MinuteBreak + @" ForMin from CTE A
            where LateInMinute>" + _MinuteBreak + @" 
            and EmpID>0 
            and (attendenceDate>=convert(datetime, '" + _FromDate + @"',101) and attendenceDate<=convert(datetime, '" + _ToDate + @"',101)) 
            --ORDER BY EmpId, EmpName ,attendenceDate Asc, convert(datetime,InTime,100);
			) A
			group by EmpID, EmpName, FirstName, LastName;

	select EmpID,
			EmpName,
			FirstName,
			LastName,
			case when SUM(ISNULL(AttDays,0))=0 then null else SUM(ISNULL(AttDays,0)) end AttDays,
			case when SUM(ISNULL(LATE,0))=0 then null else SUM(ISNULL(LATE,0)) end LATE,
			case when SUM(ISNULL(EarlyIn,0))=0 then null else SUM(ISNULL(EarlyIn,0)) end EarlyIn,
			case when SUM(ISNULL(EarlyExit,0))=0 then null else SUM(ISNULL(EarlyExit,0)) end EarlyExit,
			case when SUM(ISNULL(LongLunch,0))=0 then null else SUM(ISNULL(LongLunch,0)) end LongLunch,
			case when SUM(ISNULL(LongBreak,0))=0 then null else SUM(ISNULL(LongBreak,0)) end LongBreak,
            case when SUM(ISNULL(Reg,0))=0 then null else SUM(ISNULL(Reg,0)) end Reg,
			case when SUM(ISNULL(OT1,0))=0 then null else SUM(ISNULL(OT1,0)) end OT1,
			case when SUM(ISNULL(OT2,0))=0 then null else SUM(ISNULL(OT2,0)) end OT2
	from @T1 ";



            if (_EmpID != "0")
            {
                strSQL += "where empid in (" + _EmpID + ") ";
                strSQL += @"GROUP BY EmpID, EmpName, FirstName, LastName ";
            }
            else
            {
                strSQL += @"GROUP BY EmpID, EmpName, FirstName, LastName ";
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                else if (_SortBy == "5")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }

            }





            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataTable GetEmployeeListArchieve()
        {

            string strSQL = @" select EmpID, EmpName from (
                 select 0 as EmpID, '<All>' EmpName 
                 union all
                 SELECT distinct EmpID, convert(varchar(50),EmpID)  + ' - ' + EmpName as EmpName FROM dbo.Attendance_Archive 
                 ) A
                 order by EmpID asc";

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
        public DataTable GetgetPayperiodForLeave(string _FromDate, string _ToDate)
        {

            string strSQL = @" DECLARE @Table1 TABLE(ID int, Value varchar(50))
            INSERT INTO @Table1 
            select 1, isnull(convert(varchar(12),PeriodFrom, 101),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 101),'') Period
            from PayPeriod
            where ((convert(datetime, '" + _FromDate + @"',101) between PeriodFrom and PeriodTo) or (convert(datetime, '" + _ToDate + @"',101) between PeriodFrom and PeriodTo)  )
            --where ((PeriodFrom>=convert(datetime, '" + _FromDate + @"',101) and PeriodFrom<=convert(datetime, '" + _ToDate + @"',101)) 
            --or (PeriodTo>=convert(datetime, '" + _FromDate + @"',101) and PeriodTo<=convert(datetime, '" + _ToDate + @"',101)) )
            order by PayDate;

            --select * from @Table1;

            SELECT  ID
                   ,STUFF((SELECT ', ' + CAST(Value AS VARCHAR(25)) [text()]
                     FROM @Table1 
                     WHERE ID = t.ID
                     FOR XML PATH(''), TYPE)
                    .value('.','NVARCHAR(MAX)'),1,2,' ') Period
            FROM @Table1 t
            GROUP BY ID
            ";

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
        public DataTable GetMasterEmployeeList()
        {

            string strSQL = @"                 
                 select TLOID EmpID, convert(varchar(50),TLOID)  + ' - ' + Name as EmpName
                 from Employees
                where jobstatus='Active' --and EmploymentType=1
                 order by TLOID asc";

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
        public DataTable GetMasterEmployeeListForLeave()
        {

            string strSQL = @"                 
                 select EmpAutoID EmpID, convert(varchar(50),TLOID)  + ' - ' + Name as EmpName
                 from Employees
                where jobstatus='Active' --and EmploymentType=1
                 order by TLOID asc";

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
        public DataTable GetSalariedTemplate()
        {
            string strSQL = @"                 
                 select  [TemplateAutoiD],[EmpID], E.Name,[Reg],[OT1],[OT2], S.InsertDate 
                    from  SalariedEmpTimeTemplate S inner join Employees E on E.TLOID=S.EmpID
                    order by E.Name, S.InsertDate Desc";

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
        public DataTable GetUsers()
        {
            string strSQL = @"                 
                SELECT UserAutoID, 
                case 
                when UserLevel=1 then 'Admin'
                when UserLevel=2 then 'Data Entry'
                when UserLevel=3 then 'Report Viewer'
                end 'User Level',
                case 
                when Status=1 then 'Active'
                when Status=0 then 'Inactive'
                end Status,
                UserName as 'User Name', FullName as 'Full Name', Address1, Address2, City, State, Zip, Phone, Email
                FROM Users
                order by UserLevel, UserName";

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
        public DataTable GetSalariedTemplateActiveEmp()
        {
            string strSQL = @"                 
                 select  [TemplateAutoiD],[EmpID], E.Name,[Reg],[OT1],[OT2], S.InsertDate 
                    from  SalariedEmpTimeTemplate S inner join Employees E on E.TLOID=S.EmpID
                    where E.JobStatusId=1
                    order by E.Name, S.InsertDate Desc";

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
        public DataTable GetEmployees()
        {
            string strSQL = @"                 
                 SELECT  EmpAutoID, TLOID 'EMP Id', FirstName 'First Name', LastName 'Last Name',  
	                case 
	                   when GENDER='M' then 'Male'
	                   else 'Female' End Gender,
	                   case 
	                   when W4MaritalStatus='M' then 'Married'
	                   else 'Single' End 'Marital Status',DOB 'Date of Birth',D.DepartmentDesc 'Department', G.DesignationDesc 'Designation', --C.ClockDesc 'Clock',
		                HIREDATE 'Date of Hire', LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 8))  'Start Time', --W4Dependents 'Dependents', 
	                   case 
	                   when JobStatusId=1 then 'Active'
	                   else 'Inactive' END 'Job Status' ,
	                   case 
	                   when EmploymentType=0 then 'Hourly'
	                   else 'Fixed' END 'Payroll Hours Type', LASTDAY,
                    case 
	                   when HealthInsurance=1 then 'Enrolled'
	                   else 'Declined' END 'HealthInsurance' ,
                HIEligibilityDate,HIJoinDate,DriversLicense,DriversLicenseDateOfExpiration, SSN
                FROM Employees E 
	                   LEFT JOIN Department D on D.DepartmentId=E.DepartmentId
	                   LEFT JOIN Designation G on G.DesignationId=E.DesignationId
	                   LEFT JOIN Clock C on C.ClockId=E.ClockId
                where isnull(JobStatusId,0)=1
                order by JobStatusId desc";

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
        public DataTable SearchEmployees(string txt, string status)
        {
            string strSQL = @"      SELECT * FROM (           
                 SELECT  EmpAutoID, TLOID 'EMP Id', FirstName 'First Name', LastName 'Last Name',  
	                case 
	                   when GENDER='M' then 'Male'
	                   else 'Female' End Gender,
	                   case 
	                   when W4MaritalStatus='M' then 'Married'
	                   else 'Single' End 'Marital Status',DOB 'Date of Birth',D.DepartmentDesc 'Department', G.DesignationDesc 'Designation', --C.ClockDesc 'Clock',
		                HIREDATE 'Date of Join', STARTTIME 'Start Time', --W4Dependents 'Dependents', 
	                   case 
	                   when JobStatusId=1 then 'Active'
	                   else 'Inactive' END 'Job Status' ,
	                   case 
	                   when EmploymentType=0 then 'Time Rated'
	                   else 'Fixed' END 'Employment Type', LASTDAY,
                        case 
	                   when HealthInsurance=1 then 'Enrolled'
	                   else 'Declined' END 'JHealthInsurance' ,
                    HIEligibilityDate,HIJoinDate,DriversLicense,DriversLicenseDateOfExpiration, SSN
                FROM Employees E 
	                   LEFT JOIN Department D on D.DepartmentId=E.DepartmentId
	                   LEFT JOIN Designation G on G.DesignationId=E.DesignationId
	                   LEFT JOIN Clock C on C.ClockId=E.ClockId ) A
                where ([EMP Id] like '%" + txt + @"%' 
                or [First Name] like '%" + txt + @"%' or [Last Name] like '%" + txt + @"%' 
                or [Department] like '%" + txt + @"%'                
                or [Designation] like '%" + txt + @"%'                
                or [Job Status] like '%" + txt + @"%'
                or [Employment Type] like '%" + txt + @"%') ";
            if (status == "1")
            {
                strSQL += "and [Job Status] = 'Active' ";
            }
            else if (status == "0")
            {
                strSQL += "and [Job Status] = 'Inactive' ";
            }
            strSQL += "order by [Job Status] Asc, [Employment Type] Asc";

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
        public DataTable GetSalariedData()
        {

            string strSQL = @"                 
                select S.*, E.Name, E.FirstName, E.LastName,
                convert(varchar(12), S.ProcessDate, 107) PayDate, S.InsertDate 
                from  SalariedEmpTime S inner join Employees E on E.TLOID=S.EmpID
                order by S.ProcessDate Desc, S.InsertDate Desc";

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
        public DataTable GetSalariedDataByPayPeriod(string _PayPeriod)
        {

            string strSQL = @"
                select S.SalAutoiD,
                isnull(convert(varchar(12),PeriodFrom, 107),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period, E.TLOID 'Emp Id', 
                E.Name, S.Reg 'Regular', S.OT1, S.OT2,
                S.InsertDate 
                from  SalariedEmpTime S inner join Employees E on E.TLOID=S.EmpID
                inner join PayPeriod P on P.PeriodId=S.PeriodId
                where P.PeriodId=" + _PayPeriod + @"
                order by S.ProcessDate Desc, S.InsertDate Desc";

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
        public DataTable GetPayPeriod()
        {

            string strSQL = @"
            SELECT        PeriodId, convert(varchar(10),PeriodFrom,101) PeriodFrom, convert(varchar(10),PeriodTo,101) PeriodTo, convert(varchar(10),PayDate,101) PayDate, 
            isnull(convert(varchar(12),PeriodFrom, 107),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period,
             Comments,case when Status=1 then 'Active' else 'Inactive' end Status, InsertDate
            FROM           PayPeriod
            order by PayDate desc                 
                ";

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
        public DataTable GetCompanyHolidays()
        {

            string strSQL = @"select CHId, convert(varchar(10),HolidayDate,101) HolidayDate, Comments from CompanyHolidays order by HolidayDate desc";

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
        public DataTable GetDepartments()
        {

            string strSQL = @"select DepartmentId, DepartmentDesc Department from Department order by DepartmentDesc asc";

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
        public DataTable GetDesignations()
        {

            string strSQL = @"select DesignationId, DesignationDesc Designation from Designation order by DesignationDesc asc";

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
        public DataTable GetDesignationsCount(string _id)
        {
            string strSQL = @"select COUNT(EmpAutoID) cnt from Employees E where E.DesignationId = " + _id + "";

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
        public DataTable GetPayPeriodCount(string _id)
        {
            string strSQL = @"select COUNT(PeriodId) cnt from Attendance_Archive E where E.PeriodId = " + _id + "";

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
        public DataTable GetDepartmentCount(string _id)
        {

            string strSQL = @"select COUNT(EmpAutoID) cnt from Employees E where E.DepartmentId = " + _id + "";

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
        public DataTable GetPersonalLeave()
        {

            string strSQL = @"
            select PLId,P.EmpAutoID,PeriodType, E.NAME, 
            convert(varchar(10),LeaveDate,101) 'From Date',
            case when PeriodType=2 then ''
            else convert(varchar(10),LeaveToDate,101) end 'To Date',
            LDays '#Days', LHours '#Hours',
            convert(varchar(10),RequestDate,101) 'Request Date',
            case 
            when LeaveType=1 then 'Sick/Medical Leave'
            when LeaveType=2 then 'Casual Leave'
            when LeaveType=3 then 'Maternity Leave'
            when LeaveType=4 then 'Parental Leave'
            when LeaveType=5 then 'Personal Leave'
            end LeaveType,
            case when LWC=0 then ''
            else 'WC' end 'WC',
	            (SELECT STUFF(
                         (SELECT ',' + isnull(convert(varchar(12),PeriodFrom, 101),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 101),'')
                          FROM  PayPeriod
                        where ((convert(datetime, LeaveDate,101) between PeriodFrom and PeriodTo) 
                        or (convert(datetime, LeaveToDate,101) between PeriodFrom and PeriodTo)  )
                        --where ((PeriodFrom>=convert(varchar(10),LeaveDate,101) and PeriodFrom<=convert(varchar(10),LeaveToDate,101)) 
                        --or (PeriodTo>=convert(varchar(10),LeaveDate,101) and PeriodTo<=convert(varchar(10),LeaveToDate,101)) )
                          FOR XML PATH (''))
                         , 1, 1, '')) as 'Pay Period', Comments
            from 
            PersonalLeave P
            inner join Employees E on E.EmpAutoID=P.EmpAutoID
            order by LeaveDate desc";

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
        public DataTable GetPayPeriodForCombo()
        {
            string strSQL = @"SELECT PeriodId, isnull(convert(varchar(12),PeriodFrom, 107),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period
                FROM PayPeriod
                where PeriodId not in (select distinct isnull(PeriodId,0) PeriodId from Attendance_Archive)
                order by PayDate desc ";
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
        public DataTable GetPayPeriodForComboForSalaried()
        {

            string strSQL = @"SELECT PeriodId, isnull(convert(varchar(12),PeriodFrom, 107),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period
                FROM PayPeriod
                where PeriodId not in (select distinct isnull(PeriodId,0) PeriodId from SalariedEmpTime)
                order by PayDate desc ";
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
        public DataTable GetPayPeriodTitleToProcess()
        {

            string strSQL = @"SELECT PeriodId, convert(varchar(12),PayDate, 107) as PayDate,  isnull(convert(varchar(12),PeriodFrom, 107),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 107),'') Period
                FROM PayPeriod
                where PeriodId in (select distinct isnull(PeriodId,0) PeriodId from Attendance) ";
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

        public DataTable GetDegination()
        {

            string strSQL = @" SELECT DesignationId, DesignationDesc
                FROM           Designation
                order by DesignationDesc";
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

        public DataTable GetDepartment()
        {
            string strSQL = @" SELECT DepartmentId, DepartmentDesc
                FROM           Department
                order by DepartmentDesc";
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
        public DataTable GetClock()
        {
            string strSQL = @" SELECT ClockId, ClockDesc
                FROM           Clock
                order by ClockDesc";
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
        public DataSet GetLeaveDataDateDuration(string _EmpID, string _SortBy, string _SortOption, string _FromDate, string _ToDate)
        {

            string strSQL = @"
            select TLOID PLId ,P.EmpAutoID,PeriodType, E.NAME, 
            case when PeriodType=2 then 'Hourly'
            else 'Datewise' end 'PeriodTypeText',
            convert(varchar(10),LeaveDate,101) 'From Date',
            case when PeriodType=2 then ''
            else convert(varchar(10),LeaveToDate,101) end 'To Date',
            LDays '#Days', LHours '#Hours',
            convert(varchar(10),RequestDate,101) 'Request Date',
            case 
            when LeaveType=1 then 'Sick/Medical Leave'
            when LeaveType=2 then 'Casual Leave'
            when LeaveType=3 then 'Maternity Leave'
            when LeaveType=4 then 'Parental Leave'
            when LeaveType=5 then 'Personal Leave'
            end LeaveType,
            case when LWC=0 then ''
            else 'WC' end 'WC',
	            (SELECT STUFF(
                         (SELECT ',' + isnull(convert(varchar(12),PeriodFrom, 101),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 101),'')
                          FROM  PayPeriod
                        where ((convert(datetime, LeaveDate,101) between PeriodFrom and PeriodTo) 
                        or (convert(datetime, LeaveToDate,101) between PeriodFrom and PeriodTo)  )
                          FOR XML PATH (''))
                         , 1, 1, '')) as 'Pay Period', Comments
            from 
            PersonalLeave P
            inner join Employees E on E.EmpAutoID=P.EmpAutoID
            where (LeaveDate>=convert(datetime, '" + _FromDate + @"',101) and LeaveToDate<=convert(datetime, '" + _ToDate + @"',101)) 
            --where ((convert(datetime, '" + _FromDate + @"',101) between LeaveDate and LeaveToDate) 
            --or (convert(datetime, '" + _ToDate + @"',101) between LeaveDate and LeaveToDate)  )
            --order by LeaveDate desc

            
            ";

            if (_EmpID != "0")
            {
                strSQL += "AND TLOID in (" + _EmpID + ") ";
                strSQL += "order by LeaveDate Asc";
            }
            else
            {
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY TLOID, E.NAME ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY TLOID ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY E.NAME ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                else if (_SortBy == "5")
                {
                    strSQL += "ORDER BY LeaveDate Asc, TLOID ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }
                //Mandatory Sort
                if (_SortBy != "5")
                {
                    strSQL += ",LeaveDate Asc";
                }
                else
                {
                    strSQL += "";
                }
            }




            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }

        public DataSet GetLateArchiveByPayPeriod(string _EmpID, string _SortBy, string _SortOption, string _PayDay)
        {

            //LTRIM(RIGHT(CONVERT(VARCHAR(20), start, 100), 7))
            string strSQL = @"
            ;with cte as (
            SELECT *, 
				        case when LateInMinute>15 then
					        CONVERT(varchar(5), DATEADD(minute, LateInMinute, 0), 114) 
				            else '' end LateHour, 
                        CASE WHEN LateInMinute>15 THEN 'Late' else '' end LATEStatus , 
				        CASE WHEN EarlyInMinute>15 THEN 'Early In' else '' end EarlyInStatus, 
				        CASE WHEN EarlyInMinute<-15 THEN 'Late' WHEN EarlyInMinute>15 THEN 'Early In' else '' end AttStatus, 
                        CASE WHEN WorkTotal<3 then 'Early Out' else '' end EarlyExitStatus
                        FROM (
                            SELECT 0 as 'Leave', EmpID, E.NAME as EmpName, attendenceDate,DATENAME(dw,attendenceDate) as WeekDay, LTRIM(RIGHT(min(CONVERT(datetime, start, 100)), 8)) InTime , 
                                            LTRIM(RIGHT(min(CONVERT(datetime, [stop], 100)), 8)) OutTimeMin,
                                            LTRIM(RIGHT(max(CONVERT(datetime, [stop], 100)), 8)) OutTime,
                                            E.FirstName, E.LastName,  STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
				                            DATEDIFF(MINUTE,convert(varchar(10), STARTTIME, 8), min(convert(datetime,start,100))) LateInMinute,
                                            DATEDIFF(MINUTE, min(convert(datetime,start,100)),convert(varchar(10), STARTTIME, 8)) EarlyInMinute
                                            , SUM(Reg) + SUM(OT1) + SUM(OT2) WorkTotal, SUM(Reg) Reg, SUM(OT1) OT1, SUM(OT2) OT2,
                                            '' as LeaveType, A.PeriodId
                                            FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                            and E.JOBSTATUS='ACTIVE'
				                            group by EmpID, E.NAME, E.FirstName, E.LastName,  attendenceDate, STARTTIME, A.PeriodId
                            --				order by EmpID, EmpName, attendenceDate
                        union all
			                SELECT 1 as 'Leave', E.TLOID, E.NAME as EmpName, A.LDate, DATENAME(dw,A.LDate) as WeekDay,  '00:01AM' InTime , 
				            '00:01AM' OutTimeMin,
				            '00:01AM' OutTime,
				            E.FirstName, E.LastName,  STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
				            0 LateInMinute,
				            0 EarlyInMinute
				            , 0 WorkTotal, 0 Reg, 0 OT1, 0 OT2,
				            case 
				            when LeaveType=1 then 'Sick/Medical Leave'
				            when LeaveType=2 then 'Casual Leave'
				            when LeaveType=3 then 'Maternity Leave'
				            when LeaveType=4 then 'Parental Leave'
				            when LeaveType=5 then 'Personal Leave'
				            end LeaveType,
							(SELECT  max(PeriodId)
								FROM  PayPeriod
								where ((convert(datetime, LeaveDate,101) between PeriodFrom and PeriodTo) 
								or (convert(datetime, LeaveToDate,101) between PeriodFrom and PeriodTo)  )) PeriodId
				            FROM         dbo.PersonalLeave L left join  Employees E on L.EmpAutoID=E.EmpAutoID
				            left join dbo.LeaveDates A on A.PLId=L.PLId and A.EmpAutoID=E.EmpAutoID
				            and E.JOBSTATUS='ACTIVE'
				            group by  E.TLOID, E.NAME, E.FirstName, E.LastName, A.LDate, STARTTIME, LeaveType, LeaveDate, LeaveToDate               
                    union all
						SELECT 2 as 'Leave', E.TLOID, E.NAME as EmpName, L.HolidayDate, DATENAME(dw,L.HolidayDate) as WeekDay,  '00:01AM' InTime , 
						'00:01AM' OutTimeMin,
						'00:01AM' OutTime,
						E.FirstName, E.LastName, STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
						0 LateInMinute,
						0 EarlyInMinute
						, 0 WorkTotal, 0 Reg, 0 OT1, 0 OT2,
						'Company Holiday' LeaveType,
							(SELECT  max(PeriodId)
								FROM  PayPeriod
								where ((convert(datetime, HolidayDate,101) between PeriodFrom and PeriodTo) 
								or (convert(datetime, HolidayDate,101) between PeriodFrom and PeriodTo)  )) PeriodId
						FROM         dbo.CompanyHolidays L, Employees E
						where E.JOBSTATUS='ACTIVE'
						group by  E.TLOID, E.NAME, E.FirstName, E.LastName,  L.HolidayDate, STARTTIME
                            ) A
            )

            select *
				    ,(select count(LATEStatus) from cte b where b.EmpID=a.EmpID and LATEStatus='Late' and PeriodId=" + _PayDay + @" ) cntLATEStatus
                    ,(select count(EarlyInStatus) from cte b where b.EmpID=a.EmpID and EarlyInStatus='Early In'  and PeriodId=" + _PayDay + @" ) cntEarlyInStatus
                    ,(select count(EarlyExitStatus) from cte b where b.EmpID=a.EmpID and EarlyExitStatus='Early Exit'  and PeriodId=" + _PayDay + @" ) cntEarlyExitStatus
                    ,(select count(*) from cte b where b.EmpID=a.EmpID and Leave=0 and PeriodId=" + _PayDay + @" ) WorkDays
                    ,(select count(EarlyInStatus) from cte b where b.EmpID=a.EmpID and Leave=1 and PeriodId=" + _PayDay + @" ) PersonalLeave
                    ,(select count(EarlyExitStatus) from cte b where b.EmpID=a.EmpID and Leave=2 and PeriodId=" + _PayDay + @" ) CompanyLeave
					,(select DATEDIFF(DAY, PeriodFrom, PeriodTo) from PayPeriod where PeriodId=" + _PayDay + @") TotalDays
				from cte A

                where EmpID>0 
                and PeriodId=" + _PayDay + @" ";

            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";
                strSQL += "order by attendenceDate Asc";

            }
            else
            {
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }
                //Mandatory Sort
                strSQL += ", attendenceDate Asc";
            }

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetCoverPageArchiveByPayPeriod(string _EmpID, string _SortBy, string _SortOption, string _PayDay, int _MinuteLunch, int _MinuteBreak)
        {

            string strSQL = @"
            DECLARE @T1 TABLE (
			EmpID int,
			EmpName VARCHAR(200),
			FirstName VARCHAR(200),
			LastName VARCHAR(200),
			AttDays int,
			LATE int,
			EarlyIn int,
			EarlyExit int,
			LongLunch int,
			LongBreak int,
            Reg numeric(9,2), 
            OT1 numeric(9,2), 
            OT2 numeric(9,2),
            PeriodId int
			);


            ;with cte2 as (
            SELECT *, 
				        case when LateInMinute>15 then
					        CONVERT(varchar(5), DATEADD(minute, LateInMinute, 0), 114) 
				            else '' end LateHour, 
                        CASE WHEN LateInMinute>15 THEN 'Late' else '' end LATEStatus , 
				        CASE WHEN EarlyInMinute>15 THEN 'Early In' else '' end EarlyInStatus, 
				        CASE WHEN EarlyInMinute<-15 THEN 'Late' WHEN EarlyInMinute>15 THEN 'Early In' else '' end AttStatus, 
                        CASE WHEN WorkTotal<3 then 'Early Out' else '' end EarlyExitStatus
                        FROM (
                            SELECT  EmpID, EmpName, attendenceDate, LTRIM(RIGHT(min(CONVERT(datetime, start, 100)), 8)) InTime, LTRIM(RIGHT(min(CONVERT(datetime, [stop], 100)), 8)) OutTime,
                                            SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                            SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, STARTTIME, LTRIM(RIGHT(CONVERT(datetime, STARTTIME, 100), 7)) OfficeStartTime,
				                            DATEDIFF(MINUTE,convert(varchar(10), STARTTIME, 8), min(convert(datetime,start,100))) LateInMinute,
                                            DATEDIFF(MINUTE, min(convert(datetime,start,100)),convert(varchar(10), STARTTIME, 8)) EarlyInMinute
                                            , SUM(Reg) + SUM(OT1) + SUM(OT2) WorkTotal, SUM(Reg) Reg, SUM(OT1) OT1, SUM(OT2) OT2, A.PeriodId
                                            FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                            and E.JOBSTATUS='ACTIVE'
				                            group by EmpID, EmpName, attendenceDate, STARTTIME, A.PeriodId
                            --				order by EmpID, EmpName, attendenceDate
                            ) A
            )

			insert into @T1 (EmpID, EmpName, FirstName, LastName, AttDays, LATE, EarlyIn, EarlyExit, Reg, OT1, OT2, PeriodId) 
			select EmpID, EmpName, FirstName, LastName, max(cntAttDays) AttDays, max(cntLATEStatus) LATE, max(cntEarlyInStatus) EarlyIn, max(cntEarlyExitStatus) EarlyExit,sum(Reg) Reg, sum(OT1) OT1, sum(OT2) OT2, PeriodId  
			from (
            select *
					,(select count(*) from cte2 b where b.EmpID=a.EmpID and PeriodId=" + _PayDay + @" ) cntAttDays
				    ,(select count(LATEStatus) from cte2 b where b.EmpID=a.EmpID and LATEStatus='Late' and PeriodId=" + _PayDay + @") cntLATEStatus
                    ,(select count(EarlyInStatus) from cte2 b where b.EmpID=a.EmpID and EarlyInStatus='Early In' and PeriodId=" + _PayDay + @") cntEarlyInStatus
                    ,(select count(EarlyExitStatus) from cte2 b where b.EmpID=a.EmpID and EarlyExitStatus='Early Exit' and PeriodId=" + _PayDay + @") cntEarlyExitStatus
				from cte2 A

                where EmpID>0 
                and PeriodId=" + _PayDay + @" --ORDER BY EmpId, EmpName , attendenceDate Asc
				) A
				GROUP BY EmpID, EmpName, FirstName, LastName, PeriodId
				ORDER BY EmpId, EmpName;
			
			--select * from @T1;
            
			;with cte as (
            SELECT *
                    FROM (
                        SELECT  EmpID, EmpName, attendenceDate,A.Action, start InTime, [stop] OutTime,
                                        SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                        SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, 
				                        DATEDIFF(MINUTE,convert(datetime,start,100), convert(datetime,[stop],100)) LateInMinute, PeriodId
                                        FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                        and E.JOBSTATUS='ACTIVE'
										where A.Action='Lunch'
				                        --group by EmpID, EmpName, attendenceDate, STARTTIME
                        ) A
            )
		
		insert into @T1 (EmpID, EmpName, FirstName, LastName, LongLunch, PeriodId) 
		select EmpID, EmpName, FirstName, LastName,  max(cntLATEStatus) LongLunch, PeriodId
		from (
        select *, 
			(select count(LateInMinute) from cte b where b.EmpID=a.EmpID and LateInMinute>" + _MinuteLunch + @" and PeriodId=" + _PayDay + @") cntLATEStatus
		," + _MinuteLunch + @" ForMin from CTE A
            where LateInMinute>" + _MinuteLunch + @" 
            and EmpID>0 
            and PeriodId=" + _PayDay + @" 
            --ORDER BY EmpId, EmpName ,attendenceDate Asc, convert(datetime,InTime,100);
			) A
			group by EmpID, EmpName, FirstName, LastName, PeriodId;

  --select * from @T1;

  ;with cte as (
            SELECT *
                    FROM (
                        SELECT  EmpID, EmpName, attendenceDate,A.Action, start InTime, [stop] OutTime,
                                        SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                        SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, 
				                        DATEDIFF(MINUTE,convert(datetime,start,100), convert(datetime,[stop],100)) LateInMinute, PeriodId
                                        FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                        and E.JOBSTATUS='ACTIVE'
										where A.Action='Break'
				                        --group by EmpID, EmpName, attendenceDate, STARTTIME
                        ) A
            )
		
		insert into @T1 (EmpID, EmpName, FirstName, LastName, LongBreak, PeriodId) 
		select EmpID, EmpName, FirstName, LastName,  max(cntLATEStatus) LongBreak, PeriodId
		from (
        select *, 
			(select count(LateInMinute) from cte b where b.EmpID=a.EmpID and LateInMinute>" + _MinuteBreak + @" and PeriodId=" + _PayDay + @") cntLATEStatus
		," + _MinuteBreak + @" ForMin from CTE A
            where LateInMinute>" + _MinuteBreak + @" 
            and EmpID>0 
            and PeriodId=" + _PayDay + @"
            --ORDER BY EmpId, EmpName ,attendenceDate Asc, convert(datetime,InTime,100);
			) A
			group by EmpID, EmpName, FirstName, LastName, PeriodId;

	select EmpID,
			EmpName,
			FirstName,
			LastName,
			case when SUM(ISNULL(AttDays,0))=0 then null else SUM(ISNULL(AttDays,0)) end AttDays,
			case when SUM(ISNULL(LATE,0))=0 then null else SUM(ISNULL(LATE,0)) end LATE,
			case when SUM(ISNULL(EarlyIn,0))=0 then null else SUM(ISNULL(EarlyIn,0)) end EarlyIn,
			case when SUM(ISNULL(EarlyExit,0))=0 then null else SUM(ISNULL(EarlyExit,0)) end EarlyExit,
			case when SUM(ISNULL(LongLunch,0))=0 then null else SUM(ISNULL(LongLunch,0)) end LongLunch,
			case when SUM(ISNULL(LongBreak,0))=0 then null else SUM(ISNULL(LongBreak,0)) end LongBreak,
            case when SUM(ISNULL(Reg,0))=0 then null else SUM(ISNULL(Reg,0)) end Reg,
			case when SUM(ISNULL(OT1,0))=0 then null else SUM(ISNULL(OT1,0)) end OT1,
			case when SUM(ISNULL(OT2,0))=0 then null else SUM(ISNULL(OT2,0)) end OT2, PeriodId
	from @T1 ";



            if (_EmpID != "0")
            {
                strSQL += "where empid in (" + _EmpID + ") ";
                strSQL += @"GROUP BY EmpID, EmpName, FirstName, LastName, PeriodId ";
            }
            else
            {
                strSQL += @"GROUP BY EmpID, EmpName, FirstName, LastName, PeriodId ";
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                else if (_SortBy == "5")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }

            }

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetLongLucnArchiveByPayPeriod(string _EmpID, string _SortBy, string _SortOption, string _PayDay, string _Action, int _Minute)
        {

            string strSQL = @"
            ;with cte as (
            SELECT *
                    FROM (
                        SELECT  EmpID, EmpName, attendenceDate,A.Action, start InTime, [stop] OutTime,
                                        SUBSTRING(EmpName, 1, CHARINDEX(', ', EmpName) - 1) AS FirstName,
                                        SUBSTRING(EmpName, CHARINDEX(', ', EmpName) + 1, 8000) AS LastName, 
				                        DATEDIFF(MINUTE,convert(datetime,start,100), convert(datetime,[stop],100)) LateInMinute, A.PeriodId
                                        FROM         dbo.Attendance_Archive A left join  Employees E on A.EmpID=E.TLOID
				                        and E.JOBSTATUS='ACTIVE'
										where A.Action='" + _Action + @"'
				                        --group by EmpID, EmpName, attendenceDate, STARTTIME
                        ) A
            )

            select *, " + _Minute + @" ForMin from CTE 
            where LateInMinute>" + _Minute + @" 
            and EmpID>0 
            and PeriodId=" + _PayDay + @"
            --order by EmpID, EmpName, attendenceDate, convert(datetime,InTime,100)
            ";

            if (_EmpID != "0")
            {
                strSQL += "AND empid in (" + _EmpID + ") ";
                strSQL += "order by attendenceDate Asc, convert(datetime,InTime,100)";
            }
            else
            {
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY EmpId, EmpName ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY EmpId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY EmpName ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                else if (_SortBy == "5")
                {
                    strSQL += "ORDER BY attendenceDate Asc, EmpId ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }
                //Mandatory Sort
                if (_SortBy != "5")
                {
                    strSQL += ",attendenceDate Asc, convert(datetime,InTime,100)";
                }
                else
                {
                    strSQL += ", convert(datetime,InTime,100)";
                }
            }




            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
        public DataSet GetLeaveDataByPayPeriod(string _EmpID, string _SortBy, string _SortOption, string _PayDay)
        {
            string strSQL = @"
            select * from(
            select TLOID PLId ,P.EmpAutoID,PeriodType, E.NAME, FirstName, LastName,
            case when PeriodType=2 then 'Hourly'
            else 'Datewise' end 'PeriodTypeText',
            convert(varchar(10),LeaveDate,101) 'From Date',
            case when PeriodType=2 then ''
            else convert(varchar(10),LeaveToDate,101) end 'To Date',
            LDays '#Days', LHours '#Hours',
            convert(varchar(10),RequestDate,101) 'Request Date',
            case 
            when LeaveType=1 then 'Sick/Medical Leave'
            when LeaveType=2 then 'Casual Leave'
            when LeaveType=3 then 'Maternity Leave'
            when LeaveType=4 then 'Parental Leave'
            when LeaveType=5 then 'Personal Leave'
            end LeaveType,
            case when LWC=0 then ''
            else 'WC' end 'WC',
	            (SELECT STUFF(
                         (SELECT ',' + isnull(convert(varchar(12),PeriodFrom, 101),'') + ' to '+ isnull(convert(varchar(12),PeriodTo, 101),'')
                          FROM  PayPeriod
                        where ((convert(datetime, LeaveDate,101) between PeriodFrom and PeriodTo) 
                        or (convert(datetime, LeaveToDate,101) between PeriodFrom and PeriodTo)  )
                          FOR XML PATH (''))
                         , 1, 1, '')) as 'Pay Period', Comments,
						 (SELECT  max(PeriodId)
								FROM  PayPeriod
								where ((convert(datetime, LeaveDate,101) between PeriodFrom and PeriodTo) 
								or (convert(datetime, LeaveToDate,101) between PeriodFrom and PeriodTo)  )) PeriodId
            from 
            PersonalLeave P
            inner join Employees E on E.EmpAutoID=P.EmpAutoID ) A            
            ";
            if (_PayDay != "0")
            {
                strSQL += " where PeriodId=" + _PayDay + @" ";
            }

            if (_EmpID != "0")
            {
                strSQL += "AND PLId in (" + _EmpID + ") ";
                strSQL += "order by [From Date] Asc";
            }
            else
            {
                if (_SortBy == "0")
                {
                    strSQL += "ORDER BY PLId, NAME ";
                }
                else if (_SortBy == "1")
                {
                    strSQL += "ORDER BY PLId ";
                }
                else if (_SortBy == "2")
                {
                    strSQL += "ORDER BY NAME ";
                }
                else if (_SortBy == "3")
                {
                    strSQL += "ORDER BY FirstName ";
                }
                else if (_SortBy == "4")
                {
                    strSQL += "ORDER BY LastName ";
                }
                else if (_SortBy == "5")
                {
                    strSQL += "ORDER BY [From Date] Asc, PLId ";
                }
                if (_SortOption == "1")
                {
                    strSQL += "Desc ";
                }
                //Mandatory Sort
                if (_SortBy != "5")
                {
                    strSQL += ",[From Date] Asc";
                }
                else
                {
                    strSQL += "";
                }
            }
            
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return ds;

        }
    }
}
