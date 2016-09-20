using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WengLeePayroll.appcode
{

    public class VersionControl
    {
        string conString = ConfigurationManager.ConnectionStrings["TimeCardConnectionString"].ConnectionString;

        public void VersionCheck()
        {
            int updateToVersion = 0;
            string version = System.Windows.Forms.Application.ProductVersion;
            int VersionNumber = Int32.Parse(version.Replace(".", ""));

            //if (VersionNumber == 1000)
            if (VersionNumber == 1001)
            {
                updateToVersion = 1000;
                Version1000(updateToVersion);
            }

            int ExisitingVersion = CheckExistingVersion();
            if (VersionNumber > ExisitingVersion)
            {
                updateToVersion = 1001;
                if ((VersionNumber > ExisitingVersion))
                {
                    if (updateToVersion > ExisitingVersion)
                    {
                        Version1001(updateToVersion);
                        ExisitingVersion = updateToVersion;
                    }
                }
                //ExisitingVersion = updateToVersion;
                updateToVersion = 1002;
                if ( (VersionNumber > ExisitingVersion))
                {
                    if (updateToVersion > ExisitingVersion)
                    {
                        Version1002(updateToVersion);
                        ExisitingVersion = updateToVersion;
                    }
                }
                //ExisitingVersion = updateToVersion;
                updateToVersion = 1003;
                if ((VersionNumber > ExisitingVersion))
                {
                    if (updateToVersion > ExisitingVersion)
                    {
                        Version1003(updateToVersion);
                        ExisitingVersion = updateToVersion;
                    }
                }
                //ExisitingVersion = updateToVersion;
                updateToVersion = 1004;
                if ((VersionNumber > ExisitingVersion))
                {
                    if (updateToVersion > ExisitingVersion)
                    {
                        Version1004(updateToVersion);
                        ExisitingVersion = updateToVersion;
                    }
                }
                updateToVersion = 1005;
                if ((VersionNumber > ExisitingVersion))
                {
                    if (updateToVersion > ExisitingVersion)
                    {
                        Version1005(updateToVersion);
                        ExisitingVersion = updateToVersion;
                    }
                }
            }
        }
        private void Version1000(int version)
        {
            string strSQL = @" 
            IF object_id('App_Version') is null
            begin
                CREATE TABLE [dbo].[App_Version]
                (
	                [VersionAutoId] [int] IDENTITY(1,1) NOT NULL primary key,
	                [VersionNumber] [int] NULL,
	                [InsertDate] [datetime] NULL default getdate()
                );
                insert into App_Version(VersionNumber) values (1000);
            end
            ";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;

            objResult = dbCommand.ExecuteScalar();
            
            dbCommand.Dispose();
            con.Close();
            con.Dispose();

            //UpdateVersion(version);
        }
        private void Version1001(int version)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            
            object objResult = null;
            
            string strSQL = @"
                alter TABLE [dbo].[Employees] add
	            [HealthInsurance] [tinyint] NULL,
	            [HIEligibilityDate] [datetime] NULL,
	            [HIJoinDate] [varchar](50) NULL,
	            [DriversLicense] [varchar](50) NULL,
	            [DriversLicenseDateOfExpiration] [varchar](50) NULL,
	            [SSN] [varchar](50) NULL;
             ";
            
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

             strSQL = @"
               ALTER TABLE [dbo].[PayPeriod] ADD
	            [isImportCompleted] [tinyint]  default 0;
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand =adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            strSQL = @"
               UPDATE [dbo].[PayPeriod] SET [isImportCompleted]=1;
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            dbCommand.Dispose();
            con.Close();
            con.Dispose();
            
            UpdateVersion(version);
        }
        private void Version1002(int version)
        {
            UpdateVersion(version);
        }
        private void Version1003(int version)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            object objResult = null;
            string strSQL = @"
                
                alter table PersonalLeave 
                alter column Comments nvarchar(500) null
                
             
             ";

            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            objResult = null;
            strSQL = @"
                
                alter table Users add
	                FullName nvarchar(100),
	                Address1 nvarchar(200),
	                Address2 nvarchar(200),
	                City nvarchar(100),
	                State nvarchar(100),
	                Zip nvarchar(100),
	                Phone nvarchar(100),
	                Email nvarchar(100)
             
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            objResult = null;
            strSQL = @"
                alter table Users add
	                UserLevel smallint
                
             
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            objResult = null;
            strSQL = @"
                update Users set UserLevel=1
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            objResult = null;
            strSQL = @"
                 alter table PersonalLeave add
             PeriodType int,
             LeaveToDate datetime,
             LDays int,
             LHours numeric(12,3),
             RequestDate datetime,
             LWC int
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();
            
            objResult = null;
            strSQL = @"
                 create table LeaveDates(LDAutoID int identity(1,1) primary key,  PLId int ,EmpAutoID int ,LDate datetime)
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            objResult = null;
            strSQL = @"
                 
                CREATE FUNCTION [dbo].[DateBackbone]
                (
                @StartDate Datetime,
                @EndDate DateTime
                )
                RETURNS
                @Dates TABLE
                (
                Date DateTime
                )
                AS
                BEGIN
                While @StartDate <= @EndDate
                begin
                insert @Dates (Date) Values (@StartDate)
                Set @StartDate = @StartDate + 1
                end
                RETURN
                END
        
             ";

            adpt = new SqlDataAdapter(strSQL, con);
            dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            dbCommand.Dispose();
            con.Close();
            con.Dispose();
            UpdateVersion(version);
        }
        private void Version1004(int version)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            object objResult = null;
            string strSQL = @"
                alter table Employees add InsertWhileAttendance bit, InsertDate datetime default getdate(), InsertFromPeriodId int;
             ";

            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            dbCommand.Dispose();
            con.Close();
            con.Dispose();
            UpdateVersion(version);
        }
        private void Version1005(int version)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            object objResult = null;
            string strSQL = @"
                UPDATE Employees set JOBSTATUS='ACTIVE', JobStatusId=1 WHERE InsertFromPeriodId IS NOT NULL;
             ";

            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            dbCommand.Dispose();
            con.Close();
            con.Dispose();
            UpdateVersion(version);
        }
        private Int32 CheckExistingVersion()
        {

            string strSQL = @" select isnull(max(VersionNumber),0) VersionNumber from App_Version";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            adpt.Dispose();
            con.Close();
            con.Dispose();
            return Int32.Parse(ds.Tables[0].Rows[0]["VersionNumber"].ToString());

        }

        public void UpdateVersion(int version)
        {

            string strSQL = @"update App_Version set VersionNumber=" + version + " ";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
            object objResult = null;

            SqlCommand dbCommand = adpt.SelectCommand;
            dbCommand.CommandText = strSQL;
            dbCommand.CommandType = CommandType.Text;
            objResult = dbCommand.ExecuteScalar();

            dbCommand.Dispose();
            con.Close();
            con.Dispose();
        }
    }
}
