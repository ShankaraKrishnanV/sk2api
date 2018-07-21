using BrainIQAPI.Models.Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Email
{
    [RoutePrefix("api/emailnotifications")]
    public class EmailController : ApiController
    {

        #region "Get email"


        [HttpGet]
        [Route("getemails")]
        public HttpResponseMessage EmailNotification(int SchoolID, int UID, int Type)
        {
            List<EmailModels> emailModelsList = new List<EmailModels>();
            emailModelsList = this.GetEmailNotificationList(SchoolID, UID, Type);
            return Request.CreateResponse(HttpStatusCode.OK, emailModelsList);
        }

        public List<EmailModels> GetEmailNotificationList(int SchoolID, int UID, int Type)
        {
            List<EmailModels> emailModelsList = new List<EmailModels>();
            EmailModels emailModels = new EmailModels();
            if (!string.IsNullOrEmpty(Convert.ToString(SchoolID)) && !string.IsNullOrEmpty(Convert.ToString(UID)))
            {
                DataTable dtEmailList = new DataTable();
                dtEmailList = emailModels.getEmailList(SchoolID, UID, Type);
                if (dtEmailList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEmailList.Rows)
                    {
                        EmailModels emailModelsTypes = new EmailModels();
                        emailModelsTypes.ID = Convert.ToInt32(dr["id"]);
                        emailModelsTypes.SchoolID = Convert.ToInt32(dr["exam_id"]);
                        emailModelsTypes.MessageBoxID = Convert.ToInt32(dr["message_box_id"]);
                        emailModelsTypes.SentBy = Convert.ToInt32(dr["send_by"]);
                        emailModelsTypes.SentByName = Convert.ToString(dr["send_by_name"]);
                        emailModelsTypes.SentTo = Convert.ToInt32(dr["sent_to"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["subject"]).ToString().Trim()))
                            emailModelsTypes.Subject = Convert.ToString(dr["subject"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["body"]).ToString().Trim()))
                            emailModelsTypes.Body = Convert.ToString(dr["body"]).ToString().Trim();
                        emailModelsTypes.MoveTo = Convert.ToInt32(dr["move_to"]);
                        emailModelsTypes.FolderName = Convert.ToString(dr["folder_name"]).ToString().Trim();
                        emailModelsTypes.IsFavorite = Convert.ToBoolean(dr["isfavorite"]);
                        emailModelsTypes.SendDate = Convert.ToDateTime(dr["send_date"]);
                        emailModelsTypes.SendTime = Convert.ToString(dr["send_time"]).ToString().Trim();
                        emailModelsTypes.ReadContent = Convert.ToBoolean(dr["read_content"]);
                        emailModelsTypes.Deleted = Convert.ToBoolean(dr["deleted"]);
                        emailModelsList.Add(emailModelsTypes);
                    }
                }
            }
            return emailModelsList;
        }

        #endregion  

        #region "Get invitations"


        [HttpGet]
        [Route("GetInvitations")]
        public HttpResponseMessage GetInvitation(int SID, int UType)
        {
            List<EmailModels> emailModelsList = new List<EmailModels>();
            emailModelsList = this.GetInvitationList(SID, UType);
            return Request.CreateResponse(HttpStatusCode.OK, emailModelsList);
        }

        public List<EmailModels> GetInvitationList(int SID, int UType)
        {
            List<EmailModels> emailModelsList = new List<EmailModels>();
            EmailModels emailModels = new EmailModels();
            if (!string.IsNullOrEmpty(Convert.ToString(SID)) && !string.IsNullOrEmpty(Convert.ToString(UType)))
            {
                DataTable dtInvitaionList = new DataTable();
                dtInvitaionList = emailModels.getInvitations(SID, UType);
                if (dtInvitaionList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInvitaionList.Rows)
                    {
                        EmailModels emailModelsTypes = new EmailModels();
                        emailModelsTypes.InvitationID = Convert.ToInt32(dr["id"]);
                        emailModelsTypes.SchoolID = Convert.ToInt32(dr["exam_id"]);
                        emailModelsTypes.InvitationTitle = Convert.ToString(dr["invitation_title"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["invitation_image"])))
                            emailModelsTypes.InvitationImage = Convert.ToString(dr["invitation_image"]);
                        emailModelsTypes.Description = Convert.ToString(dr["description"]);
                        emailModelsTypes.Privacy = Convert.ToInt32(dr["privacy"]);

                        emailModelsTypes.PostedBy = Convert.ToInt32(dr["posted_by"]);
                        emailModelsTypes.PostedOn = Convert.ToDateTime(dr["posted_on"]);
                        emailModelsTypes.PostedTime = Convert.ToString(dr["posted_time"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["first_name"])))
                            emailModelsTypes.FirstName = Convert.ToString(dr["first_name"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["last_name"])))
                            emailModelsTypes.LastName = Convert.ToString(dr["last_name"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["profile_picture"])))
                            emailModelsTypes.ProfilePicture = Convert.ToString(dr["profile_picture"]);

                        emailModelsList.Add(emailModelsTypes);
                    }
                }
            }
            return emailModelsList;
        }

        #endregion  

        #region "Save email"

        [Route("insertMail")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage SaveMail(int SID, int UID, string Subject, string Message, string TO_list_ID, string CC_list_ID)
        {
            string Status = string.Empty;
            EmailModels emailModelsList = new EmailModels();
            emailModelsList.SchoolID = SID;
            emailModelsList.UID = UID;
            emailModelsList.Subject = Subject;
            emailModelsList.Body = Message;
            emailModelsList.TO_list_ID = TO_list_ID;
            emailModelsList.CC_list_ID = CC_list_ID;
            Status = emailModelsList.InsertEmail();
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }

        #endregion

        #region "Save Invitation"

        [Route("insertInvitation")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage SaveInvitation(int SID, int UID, string ITitle, string IImage, string Description, int Privacy)
        {
            string Status = string.Empty;
            EmailModels emailModelsList = new EmailModels();
            emailModelsList.SchoolID = SID;
            emailModelsList.PostedBy = UID;
            emailModelsList.InvitationTitle = ITitle;
            emailModelsList.InvitationImage = IImage;
            emailModelsList.Description = Description;
            emailModelsList.Privacy = Privacy;
            Status = emailModelsList.SaveInvitations();
            return Request.CreateResponse(HttpStatusCode.OK, Status);
        }

        #endregion


    }
}
