using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Email
{
    public class EmailModels
    {

        #region "Property - Email"

        public int ID { get; set; }

        public int UID { get; set; }

        public int SchoolID { get; set; }

        public int MessageBoxID { get; set; }

        public int SentBy { get; set; }

        public string SentByName { get; set; }

        public int SentTo { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string TO_list_ID { get; set; }

        public string CC_list_ID { get; set; }

        public int MoveTo { get; set; }

        public string FolderName { get; set; }

        public bool IsFavorite { get; set; }

        public DateTime SendDate { get; set; }

        public string SendTime { get; set; }

        public bool ReadContent { get; set; }

        public bool Deleted { get; set; }

        #endregion

        #region "Property - Invitations"

        public int InvitationID { get; set; }

        public string InvitationTitle { get; set; }

        public string InvitationImage { get; set; }

        public string Description { get; set; }

        public int PostedBy { get; set; }

        public DateTime PostedOn { get; set; }

        public string PostedTime { get; set; }

        public int Privacy { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        #endregion

        #region "Public methods

        #region InsertEmail

        public string InsertEmail()
        {
            SqlCommand sqlcommand = new SqlCommand("usp_insert_email_list");
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@sid", this.SchoolID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@uid", this.UID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@subject", this.Subject.ToString().Trim());
            if (string.IsNullOrEmpty(Convert.ToString(this.Body)))
                this.Body = string.Empty;
            sqlcommand.Parameters.AddWithValue("@body", this.Body.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@TO", this.TO_list_ID.ToString().Trim());
            if (string.IsNullOrEmpty(Convert.ToString(this.CC_list_ID)))
                this.CC_list_ID = string.Empty;
            sqlcommand.Parameters.AddWithValue("@CC", this.CC_list_ID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString().ToString().Trim());
            DBOperations dbOperation = new DBOperations();
            string outputValue = string.Empty;
            bool Status = dbOperation.SaveData(sqlcommand, out outputValue, "");
            if (Status)
                return outputValue;
            else
                return outputValue;
        }

        #endregion

        #region SaveInvitations

        public string SaveInvitations()
        {
            SqlCommand sqlcommand = new SqlCommand("usp_insert_email_invitations");
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@sid", this.SchoolID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@posted_by", this.PostedBy.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@invitation_title", this.InvitationTitle.ToString().Trim());
            if (string.IsNullOrEmpty(Convert.ToString(this.InvitationImage)))
                this.InvitationImage = string.Empty;
            else
                sqlcommand.Parameters.AddWithValue("@invitation_image", this.InvitationImage.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@description", this.Description.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString().ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@privacy", this.Privacy.ToString().Trim());
            DBOperations dbOperation = new DBOperations();
            string outputValue = string.Empty;
            bool Status = dbOperation.SaveData(sqlcommand, out outputValue, "");
            if (Status)
                return outputValue;
            else
                return outputValue;
        }

        #endregion

        #endregion

        #region "Private methods"

        #region getEmailList

        protected internal DataTable getEmailList(int SID, int UID, int Type)
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_email_notifications");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", SID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@login_user_id", UID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@type", Type.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        #endregion

        #region getInvitations

        protected internal DataTable getInvitations(int SID, int UType)
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_email_invitations");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", SID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@user_type", UType.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        #endregion

        #endregion
    }
}