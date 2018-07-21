using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Question
{
    public class QuestionModels
    {

        #region "Property"

        public int QuestionId { get; set; }

        public int SchoolID { get; set; }

        public int AnsweredQuestionId { get; set; }

        public int StandardId { get; set; }

        public int SubjectId { get; set; }

        public int ChapterId { get; set; }

        public string Question { get; set; }

        public string Question_Image { get; set; }

        public string Question_Image_Description { get; set; }

        public string OptionA { get; set; }

        public string OptionA_Image { get; set; }

        public string OptionB { get; set; }

        public string OptionB_Image { get; set; }

        public string OptionC { get; set; }

        public string OptionC_Image { get; set; }

        public string OptionD { get; set; }

        public string OptionD_Image { get; set; }

        public string Answer { get; set; }

        public bool Active { get; set; }

        public string QuestionHidden { get; set; }

        public string OptionAHidden { get; set; }

        public string OptionBHidden { get; set; }

        public string OptionCHidden { get; set; }

        public string OptionDHidden { get; set; }

        public string Subject { get; set; }

        public string ChapterName { get; set; }

        public string AnswerDescription { get; set; }

        public int UserId { get; set; }

        public int TotalCount { get; set; }

        public string AnswerSelected { get; set; }

        public string TimeStart { get; set; }

        public string TimeFinished { get; set; }

        public int Format { get; set; }

        public string FillAnswer { get; set; }

        public string ChapterIDList { get; set; }

        public string ExamTime { get; set; }

        public string NoofQuestions { get; set; }

        public string ExamName { get; set; }

        public int ExamID { get; set; }

        #endregion

        #region "Public Methods"

        public bool CreateQuestion()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_create_question");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@StandardId", this.StandardId);
            sqlCommand.Parameters.AddWithValue("@SubjectId", this.SubjectId);
            sqlCommand.Parameters.AddWithValue("@ChapterId", this.ChapterId);
            if (string.IsNullOrEmpty(Question)) Question = string.Empty;
            sqlCommand.Parameters.AddWithValue("@Question", this.Question);
            if (string.IsNullOrEmpty(Question_Image)) Question_Image = string.Empty;
            sqlCommand.Parameters.AddWithValue("@Question_Image", this.Question_Image);
            if (string.IsNullOrEmpty(Question_Image_Description)) Question_Image_Description = string.Empty;
            sqlCommand.Parameters.AddWithValue("@Question_Image_Description", this.Question_Image_Description);
            if (string.IsNullOrEmpty(OptionA)) OptionA = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionA", this.OptionA);
            if (string.IsNullOrEmpty(OptionA_Image)) OptionA_Image = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionA_Image", this.OptionA_Image);
            if (string.IsNullOrEmpty(OptionB)) OptionB = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionB", this.OptionB);
            if (string.IsNullOrEmpty(OptionB_Image)) OptionB_Image = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionB_Image", this.OptionB_Image);
            if (string.IsNullOrEmpty(OptionC)) OptionC = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionC", this.OptionC);
            if (string.IsNullOrEmpty(OptionC_Image)) OptionC_Image = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionC_Image", this.OptionC_Image);
            if (string.IsNullOrEmpty(OptionD)) OptionD = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionD", this.OptionD);
            if (string.IsNullOrEmpty(OptionD_Image)) OptionD_Image = string.Empty;
            sqlCommand.Parameters.AddWithValue("@OptionD_Image", this.OptionD_Image);
            if (string.IsNullOrEmpty(Answer)) Answer = string.Empty;
            sqlCommand.Parameters.AddWithValue("@Answer", this.Answer);
            if (string.IsNullOrEmpty(FillAnswer)) FillAnswer = string.Empty;
            sqlCommand.Parameters.AddWithValue("@Fill_Answer", this.FillAnswer);
            if (string.IsNullOrEmpty(AnswerDescription)) AnswerDescription = string.Empty;
            sqlCommand.Parameters.AddWithValue("@Answer_Description", this.AnswerDescription);
            sqlCommand.Parameters.AddWithValue("@Formats", this.Format);
            DBOperations dbOperation = new DBOperations();
            string Out = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Out, "");
            return true;
        }

        public bool GenerateQuestion()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_generate_exam_question");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID);
            sqlCommand.Parameters.AddWithValue("@standard_id", this.StandardId);
            sqlCommand.Parameters.AddWithValue("@subject_id", this.SubjectId);
            sqlCommand.Parameters.AddWithValue("@chapter_id_list", this.ChapterIDList);
            sqlCommand.Parameters.AddWithValue("@exam_time", this.ExamTime);
            sqlCommand.Parameters.AddWithValue("@no_of_questions", this.NoofQuestions);
            sqlCommand.Parameters.AddWithValue("@exam_name", this.ExamName);
            sqlCommand.Parameters.AddWithValue("@created_by", this.UserId);
            DBOperations dbOperation = new DBOperations();
            string Out = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Out, "");
            return true;
        }

        public bool UploadImage()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_save_exam_result");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ChapterId", this.ChapterId);
            sqlCommand.Parameters.AddWithValue("@Question_Image", this.Question_Image);
            sqlCommand.Parameters.AddWithValue("@Active", this.Active);
            DBOperations dbOperation = new DBOperations();
            bool status = dbOperation.DeleteData(sqlCommand);
            if (status)
                return true;
            else
                return false;
        }
        #endregion


        #region "Private Methods"

        protected internal DataTable GetQuestionList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_view_questions");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ExamID", this.ExamID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@SubjectId", this.SubjectId.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@ChapterId", this.ChapterId.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        protected internal DataTable GetReviweList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_review_exam_answers");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserId", this.UserId.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@ChapterId", this.ChapterId.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }


        protected internal DataTable GetSubjectTreeList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_subject_tree_list");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", this.SchoolID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        #endregion
    }
}