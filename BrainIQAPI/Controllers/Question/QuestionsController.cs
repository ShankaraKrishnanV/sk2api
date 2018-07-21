using BrainIQAPI.Models.Question;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Question
{
    [RoutePrefix("api/Questions")]
    public class QuestionsController : ApiController
    {

        #region "UploadImage"

        [HttpGet]
        [Route("UploadImage")]
        public IHttpActionResult Image(int ChapterId, string Question_Image)
        {
            bool Status = false;
            try
            {
                QuestionModels chapterExamModels = new QuestionModels();
                chapterExamModels.ChapterId = ChapterId;
                chapterExamModels.Question_Image = Question_Image;
                Status = chapterExamModels.UploadImage();
                return ResponseMessage(Request.CreateResponse(Status));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(Status));
            }
        }

        #endregion

        #region "CreateQuestions"
        
        [HttpPost]
        [Route("CreateQuestions")]
        public IHttpActionResult CreateQuestions([FromBody]QuestionModels questionModels)
        {
            bool Status = false;
            try
            {
                Status = questionModels.CreateQuestion();
                return ResponseMessage(Request.CreateResponse(Status));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(Status));
            }
        }

        #endregion

        #region "Generate Questions"

        [HttpPost]
        [Route("GenerateQuestions")]
        public IHttpActionResult GenerateQuestion([FromBody]QuestionModels Questions)
        {
            bool Status = false;
            try
            {
                Status = Questions.GenerateQuestion();
                return ResponseMessage(Request.CreateResponse(Status));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString().Trim()));
            }
        }

        #endregion

        #region "View Questions

        /// <summary>
        /// Get Chapter Based Exams
        /// </summary>
        /// <param name="ChapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("View")]
        public HttpResponseMessage ViewQuestions(int ExamId, int SubjectId, int ChapterId)
        {
            List<QuestionModels> subjecttModelsList = new List<QuestionModels>();
            subjecttModelsList = this.ViewQuestionList(ExamId, SubjectId, ChapterId);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<QuestionModels> ViewQuestionList(int ExamId, int SubjectId, int ChapterId)
        {
            List<QuestionModels> viewQuestinoModelsList = new List<QuestionModels>();
            QuestionModels questionModels = new QuestionModels();
            questionModels.ExamID = ExamId;
            questionModels.SubjectId = SubjectId;
            questionModels.ChapterId = ChapterId;
            DataTable dtSubjectList = new DataTable();
            dtSubjectList = questionModels.GetQuestionList();
            if (dtSubjectList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubjectList.Rows)
                {
                    QuestionModels questionModelsTypes = new QuestionModels();
                    questionModelsTypes.StandardId = Convert.ToInt32(dr[0]);
                    questionModelsTypes.SubjectId = Convert.ToInt32(dr[1]);
                    questionModelsTypes.ChapterId = Convert.ToInt32(dr[2]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[3]))))
                        questionModelsTypes.Question = Convert.ToString(dr[3]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[4]))))
                        questionModelsTypes.Question_Image = Convert.ToString(dr[4]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[5]))))
                        questionModelsTypes.Question_Image_Description = Convert.ToString(dr[5]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[6]))))
                        questionModelsTypes.OptionA = Convert.ToString(dr[6]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[7]))))
                        questionModelsTypes.OptionA_Image = Convert.ToString(dr[7]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[8]))))
                        questionModelsTypes.OptionB = Convert.ToString(dr[8]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[9]))))
                        questionModelsTypes.OptionB_Image = Convert.ToString(dr[9]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[10]))))
                        questionModelsTypes.OptionC = Convert.ToString(dr[10]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[11]))))
                        questionModelsTypes.OptionC_Image = Convert.ToString(dr[11]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[12]))))
                        questionModelsTypes.OptionD = Convert.ToString(dr[12]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[13]))))
                        questionModelsTypes.OptionD_Image = Convert.ToString(dr[13]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[14]))))
                        questionModelsTypes.Answer = Convert.ToString(dr[14]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[15]))))
                        questionModelsTypes.QuestionId = Convert.ToInt32(dr[15]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[16]))))
                        questionModelsTypes.Subject = Convert.ToString(dr[16]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[17]))))
                        questionModelsTypes.ChapterName = Convert.ToString(dr[17]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[18]))))
                        questionModelsTypes.AnswerDescription = Convert.ToString(dr[18]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[19]))))
                        questionModelsTypes.Format = Convert.ToInt32(dr[19]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[20]))))
                        questionModelsTypes.FillAnswer = Convert.ToString(dr[20]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr[21]))))
                        questionModelsTypes.ExamName = Convert.ToString(dr[21]);
                    viewQuestinoModelsList.Add(questionModelsTypes);
                }

            }
            return viewQuestinoModelsList;
        }

        #endregion

        #region "Get Chapter Based Exam

        /// <summary>
        /// Get Chapter Based Exams
        /// </summary>
        /// <param name="ChapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAnswerToReview")]
        public HttpResponseMessage GetAnswerToReview(int UserId, int ChapterId)
        {
            List<QuestionModels> subjecttModelsList = new List<QuestionModels>();
            subjecttModelsList = this.GetAnswerToReviewList(UserId, ChapterId);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<QuestionModels> GetAnswerToReviewList(int UserId, int ChapterId)
        {
            List<QuestionModels> viewQuestinoModelsList = new List<QuestionModels>();
            QuestionModels questionModels = new QuestionModels();
            questionModels.UserId = UserId;
            questionModels.ChapterId = ChapterId;
            DataTable dtSubjectList = new DataTable();
            dtSubjectList = questionModels.GetReviweList();
            if (dtSubjectList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubjectList.Rows)
                {
                    QuestionModels questionModelsTypes = new QuestionModels();
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["StandardId"]))))
                        questionModelsTypes.StandardId = Convert.ToInt32(dr["StandardId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["SubjectId"]))))
                        questionModelsTypes.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ChapterId"]))))
                        questionModelsTypes.ChapterId = Convert.ToInt32(dr["ChapterId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Question"]))))
                        questionModelsTypes.Question = Convert.ToString(dr["Question"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Question_Image"]))))
                        questionModelsTypes.Question_Image = Convert.ToString(dr["Question_Image"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Question_Description"]))))
                        questionModelsTypes.Question_Image_Description = Convert.ToString(dr["Question_Description"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionA"]))))
                        questionModelsTypes.OptionA = Convert.ToString(dr["OptionA"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionA_Image"]))))
                        questionModelsTypes.OptionA_Image = Convert.ToString(dr["OptionA_Image"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionB"]))))
                        questionModelsTypes.OptionB = Convert.ToString(dr["OptionB"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionB_Image"]))))
                        questionModelsTypes.OptionB_Image = Convert.ToString(dr["OptionB_Image"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionC"]))))
                        questionModelsTypes.OptionC = Convert.ToString(dr["OptionC"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionC_Image"]))))
                        questionModelsTypes.OptionC_Image = Convert.ToString(dr["OptionC_Image"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionD"]))))
                        questionModelsTypes.OptionD = Convert.ToString(dr["OptionD"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["OptionD_Image"]))))
                        questionModelsTypes.OptionD_Image = Convert.ToString(dr["OptionD_Image"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Answer"]))))
                        questionModelsTypes.Answer = Convert.ToString(dr["Answer"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["QuestionId"]))))
                        questionModelsTypes.QuestionId = Convert.ToInt32(dr["QuestionId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Answer_Description"]))))
                        questionModelsTypes.AnswerDescription = Convert.ToString(dr["Answer_Description"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["QuestionId"]))))
                        questionModelsTypes.AnsweredQuestionId = Convert.ToInt32(dr["QuestionId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["UID"]))))
                        questionModelsTypes.UserId = Convert.ToInt32(dr["UID"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["AnswerSelected"]))))
                        questionModelsTypes.AnswerSelected = Convert.ToString(dr["AnswerSelected"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Format"]))))
                        questionModelsTypes.Format = Convert.ToInt32(dr["Format"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Fill_Answer"]))))
                        questionModelsTypes.FillAnswer = Convert.ToString(dr["Fill_Answer"]);
                    viewQuestinoModelsList.Add(questionModelsTypes);
                }

            }
            return viewQuestinoModelsList;
        }

        #endregion


    }
}
