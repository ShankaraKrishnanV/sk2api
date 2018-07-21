using BrainIQAPI.Models.Attendance;
using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Attendance
{
    [RoutePrefix("api/attendance")]
    public class AttendanceController : ApiController
    {

        #region "Get student list"
        [AllowAnonymous]
        [HttpGet]
        [Route("students")]
        public HttpResponseMessage getStudents(int StdID, int Type, int UserID)
        {
            List<AttendanceModels> attendanceModelsList = new List<AttendanceModels>();
            attendanceModelsList = this.getStudentsL(StdID, Type, UserID);
            return Request.CreateResponse(HttpStatusCode.OK, attendanceModelsList);
        }

        [HttpPost]
        public List<AttendanceModels> getStudentsL(int StdID, int Type,int UserID)
        {
            List<AttendanceModels> attendanceModelsList = new List<AttendanceModels>();
            AttendanceModels attedanceModels = new AttendanceModels();
            attedanceModels.StandardID = StdID;
            attedanceModels.Type = Type;
            attedanceModels.NominattedUserID = UserID;
            if (!string.IsNullOrEmpty(Convert.ToString(attedanceModels.SchoolID)))
            {
                DataTable dtSubjectList = new DataTable();
                dtSubjectList = attedanceModels.GetStudentList();
                if (dtSubjectList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubjectList.Rows)
                    {
                        AttendanceModels attedanceModelsTypes = new AttendanceModels();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["UID"])))
                            attedanceModelsTypes.UID = Convert.ToInt32(dr["UID"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["exam_id"])))
                            attedanceModelsTypes.SchoolID = Convert.ToInt32(dr["exam_id"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["first_name"])))
                            attedanceModelsTypes.FirstName = Convert.ToString(dr["first_name"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["last_name"])))
                            attedanceModelsTypes.LastName = Convert.ToString(dr["last_name"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["standard"])))
                            attedanceModelsTypes.StandardID = Convert.ToInt32(dr["standard"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["phone_no"])))
                            attedanceModelsTypes.PhoneNo = Convert.ToString(dr["phone_no"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["e_mail"])))
                            attedanceModelsTypes.Email = Convert.ToString(dr["e_mail"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["postal_code"])))
                            attedanceModelsTypes.PostalCode = Convert.ToString(dr["postal_code"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["dob"])))
                            attedanceModelsTypes.DateOfBirth = Convert.ToString(dr["dob"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["country"])))
                            attedanceModelsTypes.Country = Convert.ToString(dr["country"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["state"])))
                            attedanceModelsTypes.State = Convert.ToString(dr["state"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["profile_picture"])))
                            attedanceModelsTypes.ProfilePicture = Convert.ToString(dr["profile_picture"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["user_type"])))
                            attedanceModelsTypes.UserType = Convert.ToInt32(dr["user_type"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["user_type"])))
                            attedanceModelsTypes.Address = Convert.ToString(dr["address"]).ToString().Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["leader"])))
                            attedanceModelsTypes.IsLeader = Convert.ToBoolean(dr["leader"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["DisplayLeaderList"])))
                            attedanceModelsTypes.DisplayLeaderSection = Convert.ToBoolean(dr["DisplayLeaderList"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["nominated_student_id"])))
                            attedanceModelsTypes.NominattedUserID = Convert.ToInt32(dr["nominated_student_id"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["nominated_student_name"])))
                            attedanceModelsTypes.NominattedUsername = Convert.ToString(dr["nominated_student_name"]);

                        attendanceModelsList.Add(attedanceModelsTypes);
                    }
                }
            }
            return attendanceModelsList;
        }

        #endregion

        #region "GetResult"

        [Route("StudentResult")]
        public HttpResponseMessage GetResult(int SchoolId, int UID)
        {
            List<AttendanceModels> attendanceModelsList = new List<AttendanceModels>();
            attendanceModelsList = this.GetResultL(SchoolId, UID);
            return Request.CreateResponse(HttpStatusCode.OK, attendanceModelsList);
        }

        [HttpPost]
        public List<AttendanceModels> GetResultL(int SchoolId, int UID)
        {
            List<AttendanceModels> attendanceModelsList = new List<AttendanceModels>();
            AttendanceModels attedanceModels = new AttendanceModels();
            attedanceModels.SchoolID = SchoolId;
            attedanceModels.UID = UID;
            if (!string.IsNullOrEmpty(Convert.ToString(attedanceModels.SchoolID)))
            {
                DataTable dtSubjectList = new DataTable();
                dtSubjectList = attedanceModels.GetStudentResult();
                if (dtSubjectList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubjectList.Rows)
                    {
                        AttendanceModels attedanceModelsTypes = new AttendanceModels();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Subject"])))
                            attedanceModelsTypes.Subject = Convert.ToString(dr["Subject"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ChapterName"])))
                            attedanceModelsTypes.Chapter = Convert.ToString(dr["ChapterName"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Marks"])))
                            attedanceModelsTypes.Marks = Convert.ToInt32(dr["Marks"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ExamTime"])))
                            attedanceModelsTypes.TotalTime = Convert.ToString(dr["ExamTime"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ExamFinished"])))
                            attedanceModelsTypes.TimeTaken = Convert.ToString(dr["ExamFinished"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["CreatedOn"])))
                            attedanceModelsTypes.ExamDate = Convert.ToString(dr["CreatedOn"]);

                        attendanceModelsList.Add(attedanceModelsTypes);
                    }
                }
            }
            return attendanceModelsList;
        }

        #endregion

        #region "Mobile - Insert Attedence"

        /// <summary>
        /// Staff role
        /// </summary>
        /// <param name="SchoolID"></param>
        /// <param name="StandID"></param>
        /// <param name="studID"></param>
        /// <param name="reason"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("insert")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage InsertAttedence(int SchoolID, int StandID, int studID, string reason, int userID)
        {
            string Status = string.Empty;
            AttendanceModels attendanceModels = new AttendanceModels();
            attendanceModels.SchoolID = SchoolID;
            attendanceModels.StandardID = StandID;
            attendanceModels.StduentID = studID;
            attendanceModels.Reason = reason;
            attendanceModels.UID = userID;
            Status = attendanceModels.InsertAttendance();
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }

        #endregion

        #region "Mobile - Delete Attedence"

        [Route("delete")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage DeleteAttedence(int userID)
        {
            bool Status = false;
            AttendanceModels attendanceModels = new AttendanceModels();
            attendanceModels.UID = userID;
            Status = attendanceModels.DeleteAttendance();
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }

        #endregion

        #region "Mobile - Get Attedence details"

        /// <summary>
        /// Type = 0 ==> Daily : Type = 1 ==> Whole list
        /// </summary>
        /// <param name="SchoolId"></param>
        /// <param name="StdID"></param>
        /// <param name="StudID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [Route("attedencedetails")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage getAttedence(int SchoolId, int StdID, int StudID, int Type)
        {
            List<AttendanceModels> attendanceModelsList = new List<AttendanceModels>();
            attendanceModelsList = this.getAttedenceL(SchoolId, StdID, StudID, Type);
            return Request.CreateResponse(HttpStatusCode.OK, attendanceModelsList);
        }

        [HttpPost]
        public List<AttendanceModels> getAttedenceL(int SchoolId, int StdID, int StudID, int Type)
        {
            List<AttendanceModels> attendanceModelsList = new List<AttendanceModels>();
            AttendanceModels attedanceModels = new AttendanceModels();
            attedanceModels.SchoolID = SchoolId;
            attedanceModels.StandardID = StdID;
            attedanceModels.StduentID = StudID;
            attedanceModels.Type = Type;
            if (!string.IsNullOrEmpty(Convert.ToString(attedanceModels.SchoolID)))
            {
                DataTable dtSubjectList = new DataTable();
                dtSubjectList = attedanceModels.GetAttedenceList();
                if (dtSubjectList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubjectList.Rows)
                    {
                        AttendanceModels attedanceModelsTypes = new AttendanceModels();

                        attedanceModelsTypes.ID = Convert.ToInt32(dr["id"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["exam_id"])))
                            attedanceModelsTypes.SchoolID = Convert.ToInt32(dr["exam_id"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["standard_id"])))
                            attedanceModelsTypes.StandardID = Convert.ToInt32(dr["standard_id"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["student_id"])))
                            attedanceModelsTypes.StduentID = Convert.ToInt32(dr["student_id"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["reason"])))
                            attedanceModelsTypes.Reason = Convert.ToString(dr["reason"]);
                        
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["absent_on"])))
                            attedanceModelsTypes.AttedendanceDate = Convert.ToDateTime(dr["absent_on"]);
                        
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["taken_by"])))
                            attedanceModelsTypes.AttedenceMarkedBy = Convert.ToString(dr["taken_by"]);

                        attendanceModelsList.Add(attedanceModelsTypes);
                    }
                }
            }
            return attendanceModelsList;
        }


        #endregion
    }
}
