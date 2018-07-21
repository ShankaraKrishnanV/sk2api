using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Register
{
    public class SubjectModels
    {

        #region "Property"

        public int SID { get; set; }
        /// <summary>
        /// get or set the UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// get or set the SubjectId
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// get or set the StandardId
        /// </summary>
        public int StandardId { get; set; }

        /// <summary>
        /// get or set the Subject
        /// </summary>
        public string Subject { get; set; }


        /// <summary>
        /// get or set the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// get or set the ChapterId
        /// </summary>
        public int ChapterId { get; set; }

        /// <summary>
        /// get or set the Chapter
        /// </summary>
        public string Chapter { get; set; }

        /// <summary>
        /// get or set the Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// get or set the Active
        /// </summary>
        public int MarkedChapterId { get; set; }

        /// <summary>
        /// get or set the Active
        /// </summary>
        public int MarkedSubjectId { get; set; }

        /// <summary>
        /// get or set the Active
        /// </summary>
        public int Marks { get; set; }

        public string Date { get; set; }

        public string TimeStart { get; set; }

        public string TimeFinished { get; set; }

        public int ExamID { get; set; }

        public string ExamName { get; set; }

        public int NoOfQuestions { get; set; }

        public string ExamTime { get; set; }

        public int TotalQuestions { get; set; }

        #endregion  

        #region "Private Methods"

        protected internal DataTable GetSubjectList(int _Params)
        {

            if (_Params == 0)
            {
                SqlCommand sqlCommand = new SqlCommand("usp_get_subject");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Examid", this.ExamID.ToString().Trim());
                DBOperations dbOperations = new DBOperations();
                return dbOperations.GetTableData(sqlCommand);
            }
            else
            {
                SqlCommand sqlCommand = new SqlCommand("usp_get_subject_std");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@stdID", this.StandardId.ToString().Trim());
                DBOperations dbOperations = new DBOperations();
                return dbOperations.GetTableData(sqlCommand);
            }
          
        }


        protected internal DataSet GetChapterList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_chapter");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SubjectId", this.SubjectId);
            sqlCommand.Parameters.AddWithValue("@UserId", this.UserId);
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetDataSet(sqlCommand);
        }

        #endregion  

    }
}