using BrainIQAPI.Models.Register;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Subject
{
    [RoutePrefix("api/subject")]
    public class SubjectController : ApiController
    {

        public DataSet dtChapterList;

        #region "Get Subject

        [HttpGet]
        [Route("GetSubject")]
        public HttpResponseMessage SubjectList(int ExamId)
        {
            List<SubjectModels> subjecttModelsList = new List<SubjectModels>();
            subjecttModelsList = this.GetSubjectList(ExamId, 0);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpGet]
        [Route("GetSubjectSTD")]
        public HttpResponseMessage SubjectListSTD(int ExamID)
        {
            List<SubjectModels> subjecttModelsList = new List<SubjectModels>();
            subjecttModelsList = this.GetSubjectList(ExamID, 1);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }


        [HttpPost]
        public List<SubjectModels> GetSubjectList(int ExamId, int _Params)
        {
            List<SubjectModels> subjectModelsList = new List<SubjectModels>();
            SubjectModels subjectModels = new SubjectModels();
            if (_Params == 0)
                subjectModels.ExamID = ExamId;
            else
                subjectModels.ExamID = ExamId;
            if (!string.IsNullOrEmpty(Convert.ToString(subjectModels.UserId)))
            {
                DataTable dtSubjectList = new DataTable();
                dtSubjectList = subjectModels.GetSubjectList(_Params);
                if (dtSubjectList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubjectList.Rows)
                    {
                        SubjectModels subjectModelsTypes = new SubjectModels();
                        subjectModelsTypes.SubjectId = Convert.ToInt32(dr[0]);
                        subjectModelsTypes.ExamID = Convert.ToInt32(dr[1]);
                        subjectModelsTypes.Subject = Convert.ToString(dr[2]);
                        subjectModelsTypes.Description = Convert.ToString(dr[3]);
                        subjectModelsList.Add(subjectModelsTypes);
                    }
                }
            }
            return subjectModelsList;
        }

        #endregion

        #region "Get Chapter

        [HttpGet]
        [Route("GetChapter")]
        public HttpResponseMessage ChapterList(int SubjectId, int UserId)
        {
            List<SubjectModels> subjectModelsList = new List<SubjectModels>();
            subjectModelsList = this.GetChapterList(SubjectId, UserId);
            return Request.CreateResponse(HttpStatusCode.OK, subjectModelsList);
        }

        [HttpPost]
        public List<SubjectModels> GetChapterList(int SubjectId, int UserId)
        {
            List<SubjectModels> subjectModelsList = new List<SubjectModels>();
            SubjectModels subjectModels = new SubjectModels();
            subjectModels.SubjectId = SubjectId;
            subjectModels.UserId = UserId;
            if (!string.IsNullOrEmpty(Convert.ToString(subjectModels.UserId)))
            {
                dtChapterList = subjectModels.GetChapterList();
                if (dtChapterList.Tables[0].Rows.Count > 0)
                {

                    for (int iChapter = 0; iChapter < dtChapterList.Tables[0].Rows.Count; iChapter++)
                    {
                        SubjectModels subjectModelsTypes = new SubjectModels();
                        //subjectModelsTypes.StandardId = Convert.ToInt32(dtChapterList.Tables[0].Rows[iChapter]["StandardId"]);
                        subjectModelsTypes.SubjectId = Convert.ToInt32(dtChapterList.Tables[0].Rows[iChapter]["SubjectId"]);
                        subjectModelsTypes.ExamID = Convert.ToInt32(dtChapterList.Tables[0].Rows[iChapter]["exam_id"]);
                        subjectModelsTypes.ExamName = Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["exam_name"]);
                        subjectModelsTypes.NoOfQuestions = Convert.ToInt32(dtChapterList.Tables[0].Rows[iChapter]["no_of_questions"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["exam_time"])))
                            subjectModelsTypes.ExamTime = Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["exam_time"]);
                        
                        if (!string.IsNullOrEmpty(Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["Marks"])))
                            subjectModelsTypes.Marks = Convert.ToInt32(dtChapterList.Tables[0].Rows[iChapter]["Marks"]);
                       
                        if (!string.IsNullOrEmpty(Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["ExamFinished"])))
                            subjectModelsTypes.TimeFinished = Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["ExamFinished"]).ToString().Trim();
                        else
                            subjectModelsTypes.TimeFinished = string.Empty;

                        if (!string.IsNullOrEmpty(Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["CreatedOn"])))
                            subjectModelsTypes.Date = Convert.ToDateTime(dtChapterList.Tables[0].Rows[iChapter]["CreatedOn"]).ToShortDateString().ToString().Trim();
                        else
                            subjectModelsTypes.Date = string.Empty;

                        if (!string.IsNullOrEmpty(Convert.ToString(dtChapterList.Tables[0].Rows[iChapter]["Total"])))
                            subjectModelsTypes.TotalQuestions = Convert.ToInt32(dtChapterList.Tables[0].Rows[iChapter]["Total"]);
                       
                        subjectModelsList.Add(subjectModelsTypes);
                    }

                }
            }
            return subjectModelsList;
        }

        #endregion

    }
}
