using BrainIQAPI.Models.Exam;
using BrainIQAPI.Models.Question;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BrainIQAPI.Controllers.ChapterQuestions
{
    [RoutePrefix("api/chapterExam")]
    public class ChapterExamController : ApiController
    {

        #region "Get Chapter Exam

        /// <summary>
        /// Get Chapter Based Exams
        /// </summary>
        /// <param name="ChapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetChapterExams")]
        public HttpResponseMessage ChapterExamList(int ExamId)
        {
            List<ChapterExamModels> subjecttModelsList = new List<ChapterExamModels>();
            subjecttModelsList = this.GetChapterExamList(ExamId);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<ChapterExamModels> GetChapterExamList(int ExamId)
        {
            List<ChapterExamModels> chapterExamModelsList = new List<ChapterExamModels>();
            ChapterExamModels chapterModels = new ChapterExamModels();
            chapterModels.ChapterId = ExamId;
            if (!string.IsNullOrEmpty(Convert.ToString(chapterModels.ChapterId)))
            {
                DataTable dtSubjectList = new DataTable();
                dtSubjectList = chapterModels.GetChpaterExamList();
                if (dtSubjectList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubjectList.Rows)
                    {
                        ChapterExamModels chapterModelsTypes = new ChapterExamModels();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["QuestionId"])))
                            chapterModelsTypes.QuestionId = Convert.ToInt32(dr["QuestionId"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["StandardId"])))
                            chapterModelsTypes.StandardId = Convert.ToInt32(dr["StandardId"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["SubjectId"])))
                            chapterModelsTypes.SubjectId = Convert.ToInt32(dr["SubjectId"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ChapterId"])))
                            chapterModelsTypes.ChapterId = Convert.ToInt32(dr["ChapterId"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Question"])))
                            chapterModelsTypes.Question = Convert.ToString(dr["Question"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Question_Image"])))
                            chapterModelsTypes.QuestionImage = Convert.ToString(dr["Question_Image"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Question_Description"])))
                            chapterModelsTypes.QuestionDescription = Convert.ToString(dr["Question_Description"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionA"])))
                            chapterModelsTypes.OptionA = Convert.ToString(dr["OptionA"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionA_Image"])))
                            chapterModelsTypes.OptionAImage = Convert.ToString(dr["OptionA_Image"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionB"])))
                            chapterModelsTypes.OptionB = Convert.ToString(dr["OptionB"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionB_Image"])))
                            chapterModelsTypes.OptionBImage = Convert.ToString(dr["OptionB_Image"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionC"])))
                            chapterModelsTypes.OptionC = Convert.ToString(dr["OptionC"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionC_Image"])))
                            chapterModelsTypes.OptionCImage = Convert.ToString(dr["OptionC_Image"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionD"])))
                            chapterModelsTypes.OptionD = Convert.ToString(dr["OptionD"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["OptionD_Image"])))
                            chapterModelsTypes.OptionDImage = Convert.ToString(dr["OptionD_Image"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Answer"])))
                            chapterModelsTypes.Answer = Convert.ToString(dr["Answer"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Fill_Answer"])))
                            chapterModelsTypes.FillAnswer = Convert.ToString(dr["Fill_Answer"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Answer_Description"])))
                            chapterModelsTypes.AnswerDescription = Convert.ToString(dr["Answer_Description"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Format"])))
                            chapterModelsTypes.Format = Convert.ToString(dr["Format"]);

                        chapterExamModelsList.Add(chapterModelsTypes);
                    }
                }
            }
            return chapterExamModelsList;
        }

        #endregion

        #region "Save Result"

        [HttpPost]
        [Route("SaveResult")]
        public IHttpActionResult SaveResult([FromBody]List<QuestionModels> questionModels)
        {
            bool Status = false;
            foreach (var chapterExam in questionModels)
            {
                Status = true;
                ChapterExamModels chapterExamModels = new ChapterExamModels();
                chapterExamModels.QuestionId = chapterExam.QuestionId;
                chapterExamModels.UserId = Convert.ToInt32(ConfigurationManager.AppSettings["UID"]);
                chapterExamModels.ChapterId = chapterExam.ChapterId;
                chapterExamModels.Answer = chapterExam.Answer;
                chapterExamModels.SchoolID = chapterExam.SchoolID;
                chapterExamModels.TotalCount = chapterExam.TotalCount;
                chapterExamModels.SubjectId = chapterExam.SubjectId;
                chapterExamModels.TimeStart = chapterExam.TimeStart;
                chapterExamModels.TimeFinished = chapterExam.TimeFinished;
                chapterExamModels.ExamID = chapterExam.ExamID;
                Status = chapterExamModels.UpdateResult();
            }
            return ResponseMessage(Request.CreateResponse(Status));
        }

        #endregion

        #region "Mark chapter convered"

        [HttpGet]
        [Route("MarkChapter")]
        public HttpResponseMessage MarkChapterCovered(int ChapterID, string StatusIS, int UserID)
        {
            bool Status = false;
            ChapterExamModels chapterExamModels = new ChapterExamModels();
            chapterExamModels.ChapterId = ChapterID;
            chapterExamModels.Answer = StatusIS;
            chapterExamModels.UserId = UserID;
            Status = chapterExamModels.MarkStatus();
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }

        #endregion

        #region "Get Chapter Exam

        /// <summary>
        /// Get Chapter Based Exams
        /// </summary>
        /// <param name="ChapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ChapterList")]
        public HttpResponseMessage StandardChapters(int SchoolID, int StandardID, int SubjectID)
        {
            List<ChapterExamModels> subjecttModelsList = new List<ChapterExamModels>();
            subjecttModelsList = this.GetStandardChapters(SchoolID, StandardID, SubjectID);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<ChapterExamModels> GetStandardChapters(int SchoolID, int StandardID, int SubjectID)
        {
            List<ChapterExamModels> chapterExamModelsList = new List<ChapterExamModels>();
            ChapterExamModels chapterModels = new ChapterExamModels();
            chapterModels.StandardId = StandardID;
            chapterModels.SchoolID = SchoolID;
            chapterModels.SubjectId =SubjectID;
            if (!string.IsNullOrEmpty(Convert.ToString(chapterModels.StandardId)))
            {
                DataTable dtSubjectList = new DataTable();
                dtSubjectList = chapterModels.GetStandardChaptersList();
                if (dtSubjectList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubjectList.Rows)
                    {
                        ChapterExamModels chapterModelsTypes = new ChapterExamModels();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ChapterId"])))
                            chapterModelsTypes.ChapterId = Convert.ToInt32(dr["ChapterId"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ChapterName"])))
                            chapterModelsTypes.Answer = Convert.ToString(dr["ChapterName"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Description"])))
                            chapterModelsTypes.AnswerDescription = Convert.ToString(dr["Description"]);
                        
                        chapterExamModelsList.Add(chapterModelsTypes);
                    }
                }
            }
            return chapterExamModelsList;
        }

        #endregion

    }
}
