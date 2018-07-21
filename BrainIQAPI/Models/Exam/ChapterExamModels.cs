using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Exam
{
    public class ChapterExamModels
    {

        #region "Property"

        /// <summary>
        /// get or set the UserId
        /// </summary>
        public int UserId { get; set; }

        public int SchoolID { get; set; }

        /// <summary>
        /// get or set the QuestionId
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// get or set the ChapterId
        /// </summary>
        public int ChapterId { get; set; }

        /// <summary>
        /// get or set the Question
        /// </summary>
        public string Question { get; set; }

        public string QuestionImage { get; set; }

        public string QuestionDescription { get; set; }

        /// <summary>
        /// get or set the OptionA
        /// </summary>
        public string OptionA { get; set; }

        public string OptionAImage { get; set; }

        /// <summary>
        /// get or set the OptionB
        /// </summary>
        public string OptionB { get; set; }

        public string OptionBImage { get; set; }

        /// <summary>
        /// get or set the OptionC
        /// </summary>
        public string OptionC { get; set; }

        public string OptionCImage { get; set; }

        /// <summary>
        /// get or set the OptionD
        /// </summary>
        public string OptionD { get; set; }

        public string OptionDImage { get; set; }

        /// <summary>
        /// get or set the Answer
        /// </summary>
        public string Answer { get; set; }

        public string FillAnswer { get; set; }

        public string AnswerDescription { get; set; }

        public int SubjectId { get; set; }

        /// <summary>
        /// get or set the Marks
        /// </summary>
        public int Marks { get; set; }

        public int TotalCount { get; set; }

        public string TimeStart { get; set; }

        public string TimeFinished { get; set; }

        public int StandardId { get; set; }

        public string Format { get; set; }

        public int ExamID { get; set; }
        #endregion

        #region "Public Methods"

        public bool UpdateResult()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_save_exam_result");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ExamID", this.ExamID);
            sqlCommand.Parameters.AddWithValue("@QuestionId", this.QuestionId);
            sqlCommand.Parameters.AddWithValue("@SchoolID", this.SchoolID);
            sqlCommand.Parameters.AddWithValue("@ChapterId", this.ChapterId);
            sqlCommand.Parameters.AddWithValue("@UserId", this.UserId);
            sqlCommand.Parameters.AddWithValue("@Answer", this.Answer);
            sqlCommand.Parameters.AddWithValue("@TotalCount", this.TotalCount);
            sqlCommand.Parameters.AddWithValue("@SubjectId", this.SubjectId);
            sqlCommand.Parameters.AddWithValue("@TimeStart", this.TimeStart);
            sqlCommand.Parameters.AddWithValue("@TimeFinished", this.TimeFinished);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }

        public bool MarkStatus()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_update_chapter_covered");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@chapter_id", this.ChapterId);
            sqlCommand.Parameters.AddWithValue("@update", this.Answer);
            sqlCommand.Parameters.AddWithValue("@UserId", this.UserId);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }


        #endregion

        #region "Private Methods"

        protected internal DataTable GetChpaterExamList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_chapter_questions");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ChapterId", this.ChapterId.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        /// <summary>
        /// get chapter list based on standard
        /// </summary>
        /// <returns></returns>
        protected internal DataTable GetStandardChaptersList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_question_based_chapters");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@standard", this.StandardId.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@subjectid", this.SubjectId.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@schoolid", this.SchoolID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        #endregion

    }
}