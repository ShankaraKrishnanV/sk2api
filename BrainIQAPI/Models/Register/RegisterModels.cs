using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Register
{
    public class RegisterModels
    {

        #region "Property"

        /// <summary>
        /// get or set the UID
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// get or set the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// get or set the Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// get or set the FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// get or set the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// get or set the LastName
        /// </summary>
        public int SchoolID { get; set; }

        /// <summary>
        /// get or set the PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// get or set the EmailId
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// get or set the PostalCode
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// get or set the PostalCode
        /// </summary>
        public int StandardId { get; set; }

        /// <summary>
        /// get or set the QualificationId
        /// </summary>
        public int QualificationId { get; set; }

        /// <summary>
        /// get or set the QualificationOthers
        /// </summary>
        public string QualificationOthers { get; set; }

        /// <summary>
        /// get or set the DOB
        /// </summary>
        public string DOB { get; set; }

        /// <summary>
        /// get or set the UserType
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// get or set the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// get or set the State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// get or set the PrimaryUser
        /// </summary>
        public bool PrimaryUser { get; set; }

        public string ProfilePicture { get; set; }

        public string About { get; set; }

        public string Gender { get; set; }

        public bool Active { get; set; }

        public string CreatedOn { get; set; }

        public string Address { get; set; }

        public string Fax { get; set; }

        public string QueryType { get; set; }

        public string Location { get; set; }

        public DateTime expire_on { get; set; }

        #endregion

        #region "Public Methods"

        public string UpdateUserInfo()
        {
            SqlCommand sqlcommand = new SqlCommand("usp_update_user_details");
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@user_type", this.UserType.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@UID", this.UID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@exam_id", this.SchoolID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@about", this.About.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@gender", this.Gender.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@address", this.Address.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@state", this.State.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@country", this.Country.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@postal_code", this.PostalCode.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@phone_no", this.PhoneNumber.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@fax", this.Fax.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@execute_query", this.QueryType.ToString().Trim());
            DBOperations dbOperation = new DBOperations();
            string outputValue = string.Empty;
            bool Status = dbOperation.SaveData(sqlcommand, out outputValue, "");
            if (Status)
                return outputValue;
            else
                return outputValue;
        }

        public string UpdateProfilePicture()
        {
            SqlCommand sqlcommand = new SqlCommand("usp_update_profile_picture");
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@sid", this.SchoolID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@uid", this.UID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@user_type", this.UserType.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@location", this.Location.ToString().Trim());
            DBOperations dbOperation = new DBOperations();
            string outputValue = string.Empty;
            bool Status = dbOperation.SaveData(sqlcommand, out outputValue, "");
            if (Status)
                return outputValue;
            else
                return outputValue;
        }

        #endregion

        #region "Private Methods"

        protected internal DataTable GetUserDetails(string UserName, string Password)
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_login_user");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserName", UserName.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@Password", Password.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        protected internal DataTable SearchEmail(int SID, string SearchName, string std,int UserType)
        {
            SqlCommand sqlCommand = new SqlCommand("usp_search_email");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@exam_id", SID.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@email", SearchName.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@std", std.ToString().Trim());
            sqlCommand.Parameters.AddWithValue("@user_type", UserType.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }


        /// <summary>
        /// Search the users
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        protected internal DataTable SearchUserType(int UserType)
        {
            SqlCommand sqlCommand = new SqlCommand("usp_search_users");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserType", UserType);
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        #endregion  
    }
}