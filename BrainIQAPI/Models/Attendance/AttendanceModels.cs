using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Attendance
{
    public class AttendanceModels
    {

        #region "Property"

        public int ID { get; set; }

        public int UID { get; set; }

        public int SchoolID { get; set; }

        public int StandardID { get; set; }

        public int StduentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public bool MarkAttendance { get; set; }

        public DateTime AttedendanceDate { get; set; }

        public string Reason { get; set; }

        public bool GotPermission { get; set; }

        public int UserType { get; set; }
       
        public string Subject { get; set; }

        public string Chapter { get; set; }

        public int Marks { get; set; }

        public string TotalTime { get; set; }

        public string TimeTaken { get; set; }

        public string ExamDate { get; set; }

        public string AttedenceMarkedBy { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        
        public string DateOfBirth { get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public bool IsLeader { get; set; }

        public bool DisplayLeaderSection { get; set; }

        public int NominattedUserID { get; set; }

        public string NominattedUsername { get; set; }

        public int Type { get; set; }

        #endregion

        #region "Public Methods"

        #region "insert attendance"

        /// <summary>
        /// Save attedence detail
        /// </summary>
        /// <returns></returns>
        public string InsertAttendance()
        {
            SqlCommand sqlcommand = new SqlCommand("usp_insert_attendance");
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@SchoolID", this.SchoolID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@StandardID", this.StandardID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@StduentID", this.StduentID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@Reason", this.Reason.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@UID", this.UID.ToString().Trim());
            sqlcommand.Parameters.Add("@IdOut", SqlDbType.Int).Direction = ParameterDirection.Output;
            DBOperations dbOperation = new DBOperations();
            string outputValue = string.Empty;
            bool Status = dbOperation.SaveData(sqlcommand, out outputValue, "@IdOut");
            if (Status)
                return outputValue;
            else
                return outputValue;
        }

        /// <summary>
        /// Save attedence detail
        /// </summary>
        /// <returns></returns>
        public bool DeleteAttendance()
        {
            SqlCommand sqlcommand = new SqlCommand("usp_delete_attendance");
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@UID", this.UID.ToString().Trim());
            DBOperations dbOperation = new DBOperations();
            string outputValue = string.Empty;
            bool Status = dbOperation.DeleteData(sqlcommand);
            if (Status)
                return true;
            else
                return false;
        }


        #endregion

        

        #endregion

        #region "Private Methods"

        /// <summary>
        /// Get the student list to mark daily attedence
        /// </summary>
        /// <returns></returns>
        protected internal DataTable GetStudentList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_student_list");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@std_id", this.StandardID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@Type", this.Type.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@nominator_id", this.NominattedUserID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        /// <summary>
        /// Get the abset student list to view their absent dates
        /// </summary>
        /// <returns></returns>
        protected internal DataTable GetAttedenceList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_student_attendance");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@std_id", this.StandardID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@stud_id", this.StduentID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@type", this.Type.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        protected internal DataTable GetStudentResult()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_student_result");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@UID", this.UID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }


        #endregion

    }
}