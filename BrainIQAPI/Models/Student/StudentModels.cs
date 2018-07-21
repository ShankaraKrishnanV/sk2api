using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Student
{
    public class StudentModels
    {
        #region "Property"

        public int _LOCALID { get; set; }

        public int SchoolID { get; set; }

        public int ExamId { get; set; }

        public int UsertType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public string PhoneNo { get; set; }

        public string ExamName { get; set; }

        public string Description { get; set; }
        
        public int SubjectId { get; set; }

        public string Subject { get; set; }

        public string SubjectDescription { get; set; }

        public int ChapterId { get; set; }

        public string ChapterName { get; set; }

        public string ChapterDescription { get; set; }

        public int LoginUserID { get; set; }

        public bool Active { get; set; }

        public string Email { get; set; }

        public string PostelCode { get; set; }

        public string DOB { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool ChapterCovered { get; set; }

        public string Address { get; set; }

        public string VoterList { get; set; }

        public string MarkedOn { get; set; }

        public string MarkedTime { get; set; }

        #endregion

        /// <summary>
        /// save standard
        /// </summary>
        /// <returns></returns>
        public bool SaveRecord()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_insert_exam");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.ExamId);
            sqlCommand.Parameters.AddWithValue("@Name", this.ExamName);
            sqlCommand.Parameters.AddWithValue("@Description", this.Description);
            sqlCommand.Parameters.AddWithValue("@user_id", this.LoginUserID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Select leader for the class rep
        /// </summary>
        /// <returns></returns>
        public bool EliminateUsers()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_insert_student_eliminated");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID);
            //sqlCommand.Parameters.AddWithValue("@standrad_id", this.StandardId);
            sqlCommand.Parameters.AddWithValue("@valueList", this.VoterList);
            sqlCommand.Parameters.AddWithValue("@created_by", this.LoginUserID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Enable and disable the vote section
        /// </summary>
        /// <returns></returns>
        public bool VoteLeader()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_insert_school_leader");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID);
            //sqlCommand.Parameters.AddWithValue("@standrad_id", this.StandardId);
            //sqlCommand.Parameters.AddWithValue("@login_student_id", this.StudentId);
            sqlCommand.Parameters.AddWithValue("@nominatted_leader_id", this._LOCALID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }

        public bool EnableVoteSection()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_update_standard_voting_section");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID);
            //sqlCommand.Parameters.AddWithValue("@standrad_id", this.StandardId);
            sqlCommand.Parameters.AddWithValue("@mark_as", this._LOCALID);
            sqlCommand.Parameters.AddWithValue("@created_by", this.LoginUserID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Save subject
        /// </summary>
        /// <returns></returns>
        public bool SaveSubject()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_insert_subject");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.ExamId);
            sqlCommand.Parameters.AddWithValue("@SubjectId", this.SubjectId);
            sqlCommand.Parameters.AddWithValue("@Name", this.ExamName);
            sqlCommand.Parameters.AddWithValue("@Description", this.Description);
            sqlCommand.Parameters.AddWithValue("@user_id", this.LoginUserID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Save subject
        /// </summary>
        /// <returns></returns>
        public bool SaveChapter()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_insert_chapter");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ChapterId", this.ChapterId);
            sqlCommand.Parameters.AddWithValue("@SubjectId", this.SubjectId);
            sqlCommand.Parameters.AddWithValue("@Name", this.ExamName);
            sqlCommand.Parameters.AddWithValue("@Description", this.Description);
            sqlCommand.Parameters.AddWithValue("@user_id", this.LoginUserID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Save Student
        /// </summary>
        /// <returns></returns>
        public bool SaveStudent()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_insert_student");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID);   
            //sqlCommand.Parameters.AddWithValue("@student_id", this.StudentId);
            sqlCommand.Parameters.AddWithValue("@first_name", this.FirstName);
            sqlCommand.Parameters.AddWithValue("@last_name", this.LastName);
            //sqlCommand.Parameters.AddWithValue("@standard", this.StandardId);
            sqlCommand.Parameters.AddWithValue("@phone_no", this.PhoneNo);
            sqlCommand.Parameters.AddWithValue("@profile_picture", this.ProfilePicture);
            sqlCommand.Parameters.AddWithValue("@address", this.Address);
            sqlCommand.Parameters.AddWithValue("@postal_code", this.PostelCode);
            sqlCommand.Parameters.AddWithValue("@dob", this.DOB);
            sqlCommand.Parameters.AddWithValue("@country", this.Country);
            sqlCommand.Parameters.AddWithValue("@state", this.State);
            sqlCommand.Parameters.AddWithValue("@user_id", this.LoginUserID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Delete Record
        /// </summary>
        /// <returns></returns>
        public bool DeleteRecord()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_delete_standard");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID);
            //sqlCommand.Parameters.AddWithValue("@StandardId", this.StandardId);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }


        #region "Private Methods"


        protected internal DataTable GetStudentLookup()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_exam_lookup");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }


        protected internal DataTable GetSubjectLookup(int SubjectId, int SchoolID)
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_subject_lookup");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SubjectId", SubjectId.ToString().Trim());
            //sqlCommand.Parameters.AddWithValue("@exam_id", SchoolID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }


        protected internal DataTable GetChapterLookup(int SubjectId, int Params, int SchoolID)
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_chapter_lookup");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SubjectId", SubjectId.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@Params", Params.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@exam_id", SchoolID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        #endregion

    }
}