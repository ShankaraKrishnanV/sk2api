using BrainIQAPI.Models.Student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Student
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {

        #region "Get Chapter Based Exam

        /// <summary>
        /// Get Chapter Based Exams
        /// </summary>
        /// <param name="ChapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("subjectTree")]
        public HttpResponseMessage GetSubjectTree(int SchoolID)
        {
            List<StudentModels> subjecttModelsList = new List<StudentModels>();
            subjecttModelsList = this.GetSubjectTreelist(SchoolID);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<StudentModels> GetSubjectTreelist(int SchoolID)
        {
            List<StudentModels> viewQuestinoModelsList = new List<StudentModels>();
            StudentModels questionModels = new StudentModels();
            questionModels.SchoolID = SchoolID;

            //Standard List
            DataTable dtStandardList = new DataTable();
            dtStandardList = questionModels.GetStudentLookup();
            if (dtStandardList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtStandardList.Rows)
                {
                    StudentModels questionModelsTypes = new StudentModels();
                    questionModelsTypes._LOCALID = 0;
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Exma_Id"]))))
                        questionModelsTypes.ExamId = Convert.ToInt32(dr["Exam_Id"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ExamName"]))))
                        questionModelsTypes.ExamName = Convert.ToString(dr["ExamName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Description"]))))
                        questionModelsTypes.Description = Convert.ToString(dr["Description"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Active"]))))
                        questionModelsTypes.Active = Convert.ToBoolean(dr["Active"]);
                    viewQuestinoModelsList.Add(questionModelsTypes);
                }

            }

            //Subject List
            DataTable dtSubjectList = new DataTable();
            dtSubjectList = questionModels.GetSubjectLookup(0, SchoolID);
            if (dtSubjectList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubjectList.Rows)
                {
                    StudentModels questionModelsTypes = new StudentModels();
                    questionModelsTypes._LOCALID = 1;
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["SubjectId"]))))
                        questionModelsTypes.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Exam_Id"]))))
                        questionModelsTypes.ExamId = Convert.ToInt32(dr["Exam_Id"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Subject"]))))
                        questionModelsTypes.Subject = Convert.ToString(dr["Subject"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Description"]))))
                        questionModelsTypes.Description = Convert.ToString(dr["Description"]);
                    viewQuestinoModelsList.Add(questionModelsTypes);
                }

            }

            //Chapter List
            DataTable dtChapterList = new DataTable();
            dtChapterList = questionModels.GetChapterLookup(0, 1, SchoolID);
            if (dtChapterList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtChapterList.Rows)
                {
                    StudentModels questionModelsTypes = new StudentModels();
                    questionModelsTypes._LOCALID = 2;
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ChapterId"]))))
                        questionModelsTypes.ChapterId = Convert.ToInt32(dr["ChapterId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["SubjectId"]))))
                        questionModelsTypes.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ChapterName"]))))
                        questionModelsTypes.ChapterName = Convert.ToString(dr["ChapterName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Description"]))))
                        questionModelsTypes.Description = Convert.ToString(dr["Description"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Active"]))))
                        questionModelsTypes.Active = Convert.ToBoolean(dr["Active"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ChapterCovered"]))))
                        questionModelsTypes.ChapterCovered = Convert.ToBoolean(dr["ChapterCovered"]);
                    else
                        questionModelsTypes.ChapterCovered = false;
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["user_name"]))))
                        questionModelsTypes.FirstName = Convert.ToString(dr["user_name"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ModifiedOn"]))))
                        questionModelsTypes.MarkedOn = Convert.ToDateTime(dr["ModifiedOn"]).ToShortDateString().Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ModifiedOn"]))))
                        questionModelsTypes.MarkedTime = Convert.ToDateTime(dr["ModifiedOn"]).ToShortTimeString().Trim();
                    viewQuestinoModelsList.Add(questionModelsTypes);
                }

            }

            return viewQuestinoModelsList;
        }

        #endregion


        #region "Get Standard lookup

        [HttpGet]
        [Route("GetExamLookup")]
        public HttpResponseMessage ExamLookup()
        {
            List<StudentModels> subjecttModelsList = new List<StudentModels>();
            subjecttModelsList = this.GetStandarsLookupList();
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<StudentModels> GetStandarsLookupList()
        {
            List<StudentModels> StudentModelsList = new List<StudentModels>();
            StudentModels studentModels = new StudentModels();
            DataTable dtSubjectList = new DataTable();
            dtSubjectList = studentModels.GetStudentLookup();
            if (dtSubjectList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubjectList.Rows)
                {
                    StudentModels StudentModelsTypes = new StudentModels();
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Exam_id"]))))
                        StudentModelsTypes.ExamId = Convert.ToInt32(dr["Exam_id"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ExamName"]))))
                        StudentModelsTypes.ExamName = Convert.ToString(dr["ExamName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Description"]))))
                        StudentModelsTypes.Description = Convert.ToString(dr["Description"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Active"]))))
                        StudentModelsTypes.Active = Convert.ToBoolean(dr["Active"]);
                    StudentModelsList.Add(StudentModelsTypes);
                }
            }

            return StudentModelsList;
        }

        #endregion

        #region "Get Subject lookup

        [HttpGet]
        [Route("GetSubjectLookup")]
        public HttpResponseMessage SubjectLookup(int SubjectId, int SchoolID)
        {
            List<StudentModels> subjecttModelsList = new List<StudentModels>();
            subjecttModelsList = this.GetStandarsLookupList(SubjectId, 0, SchoolID);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<StudentModels> GetStandarsLookupList(int SubjectId, int _Parma, int SchoolID)
        {
            List<StudentModels> StudentModelsList = new List<StudentModels>();

            StudentModels studentModels = new StudentModels();
            DataTable dtSubjectList = new DataTable();
            dtSubjectList = studentModels.GetSubjectLookup(SubjectId, SchoolID);
            if (dtSubjectList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubjectList.Rows)
                {
                    StudentModels StudentModelsTypes = new StudentModels();
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["SubjectId"]))))
                        StudentModelsTypes.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Exam_Id"]))))
                        StudentModelsTypes.ExamId = Convert.ToInt32(dr["Exam_Id"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Subject"]))))
                        StudentModelsTypes.Subject = Convert.ToString(dr["Subject"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Description"]))))
                        StudentModelsTypes.Description = Convert.ToString(dr["Description"]);
                    StudentModelsList.Add(StudentModelsTypes);
                }
            }

            return StudentModelsList;
        }

        #endregion

        #region "Get Chapter lookup

        [HttpGet]
        [Route("GetChapterLookup")]
        public HttpResponseMessage ChapterLookup(int SubjectId, int Params, int SchoolID)
        {
            List<StudentModels> subjecttModelsList = new List<StudentModels>();
            subjecttModelsList = this.GetChapterLookupList(SubjectId, Params, SchoolID);
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<StudentModels> GetChapterLookupList(int SubjectId, int Params, int SchoolID)
        {
            List<StudentModels> chapterModelsList = new List<StudentModels>();

            StudentModels studentModels = new StudentModels();
            DataTable dtChapterList = new DataTable();
            dtChapterList = studentModels.GetChapterLookup(SubjectId, Params, SchoolID);
            if (dtChapterList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtChapterList.Rows)
                {
                    StudentModels StudentModelsTypes = new StudentModels();
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ChapterId"]))))
                        StudentModelsTypes.ChapterId = Convert.ToInt32(dr["ChapterId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["SubjectId"]))))
                        StudentModelsTypes.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["ChapterName"]))))
                        StudentModelsTypes.ChapterName = Convert.ToString(dr["ChapterName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Description"]))))
                        StudentModelsTypes.Description = Convert.ToString(dr["Description"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(Convert.ToString(dr["Active"]))))
                        StudentModelsTypes.Active = Convert.ToBoolean(dr["Active"]);
                    chapterModelsList.Add(StudentModelsTypes);
                }
            }

            return chapterModelsList;
        }

        #endregion

        [HttpGet]
        [Route("insertStd")]
        public IHttpActionResult Save(int ExamID, string Name, string Desc, int UserID)
        {
            bool Status = false;
            StudentModels subjecttModelsList = new StudentModels();
            subjecttModelsList.ExamId = ExamID;
            subjecttModelsList.ExamName = Name;
            subjecttModelsList.Description = Desc;
            subjecttModelsList.LoginUserID = UserID;
            Status = subjecttModelsList.SaveRecord();
            return ResponseMessage(Request.CreateResponse(Status));
        }

        [HttpGet]
        [Route("insertSubject")]
        public IHttpActionResult SaveSubject(int ExamID, int SubjectId, string Name, string Desc, int UserID)
        {
            bool Status = false;
            StudentModels subjecttModelsList = new StudentModels();
            subjecttModelsList.ExamId = ExamID;
            subjecttModelsList.SubjectId = SubjectId;
            subjecttModelsList.ExamName = Name;
            subjecttModelsList.Description = Desc;
            subjecttModelsList.LoginUserID = UserID;
            Status = subjecttModelsList.SaveSubject();
            return ResponseMessage(Request.CreateResponse(Status));
        }

        [HttpGet]
        [Route("insertChapter")]
        public IHttpActionResult SaveChapter(int ChapterId, int SubjectId, string Name, string Desc, int UserID)
        {
            bool Status = false;
            StudentModels subjecttModelsList = new StudentModels();
            subjecttModelsList.ChapterId = ChapterId;
            subjecttModelsList.SubjectId = SubjectId;
            subjecttModelsList.ExamName = Name;
            subjecttModelsList.Description = Desc;
            subjecttModelsList.LoginUserID = UserID;
            Status = subjecttModelsList.SaveChapter();
            return ResponseMessage(Request.CreateResponse(Status));
        }

        [HttpPost]
        [Route("insertStudent")]
        public IHttpActionResult SaveStudent([FromBody]StudentModels studentModels)
        {
            bool Status = false;
            Status = studentModels.SaveStudent();
            return ResponseMessage(Request.CreateResponse(Status));
        }


        [HttpGet]
        [Route("deleteStd")]
        public IHttpActionResult Delete(int SchoolID, int stdID)
        {
            bool Status = false;
            StudentModels subjecttModelsList = new StudentModels();
            subjecttModelsList.SchoolID = SchoolID;
            subjecttModelsList.ExamId = stdID;
            Status = subjecttModelsList.DeleteRecord();
            return ResponseMessage(Request.CreateResponse(Status));
        }

        [HttpGet]
        [Route("ElimatedUserID")]
        public IHttpActionResult ElimatedUser(int SchoolID, int stdID, string UserIDList, int CreatedBy)
        {
            bool Status = false;
            StudentModels subjecttModelsList = new StudentModels();
            subjecttModelsList.SchoolID = SchoolID;
            subjecttModelsList.ExamId = stdID;
            subjecttModelsList.VoterList = UserIDList;
            subjecttModelsList.LoginUserID = CreatedBy;
            Status = subjecttModelsList.EliminateUsers();
            return ResponseMessage(Request.CreateResponse(Status));
        }

        [HttpGet]
        [Route("EnableVoteSection")]
        public IHttpActionResult EnableVoteSections(int SchoolID, int stdID, string IsEnable, int CreatedBy)
        {
            bool Status = false;
            StudentModels subjecttModelsList = new StudentModels();
            subjecttModelsList.SchoolID = SchoolID;
            subjecttModelsList.ExamId = stdID;
            subjecttModelsList._LOCALID = Convert.ToInt32(IsEnable);
            subjecttModelsList.LoginUserID = CreatedBy;
            Status = subjecttModelsList.EnableVoteSection();
            return ResponseMessage(Request.CreateResponse(Status));
        }

        [HttpGet]
        [Route("VoteStudent")]
        public IHttpActionResult VoteStudents(int SchoolID, int stdID, int StudentID, int NominaterID)
        {
            bool Status = false;
            StudentModels subjecttModelsList = new StudentModels();
            subjecttModelsList.SchoolID = SchoolID;
            subjecttModelsList.ExamId = stdID;
            //subjecttModelsList.StudentId = StudentID;
            subjecttModelsList._LOCALID = NominaterID;
            Status = subjecttModelsList.VoteLeader();
            return ResponseMessage(Request.CreateResponse(Status));
        }

    }
}
