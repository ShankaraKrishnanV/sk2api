using BrainIQAPI.Models.Register;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Register
{
    [RoutePrefix("api/Register")]
    public class RegisterController : ApiController
    {

        #region GetLogin

        [HttpGet]
        [Route("GetLogin")]
        public HttpResponseMessage RegisterInfo(string UserName, string Password)
        {
            List<RegisterModels> contactModelsList = new List<RegisterModels>();
            contactModelsList = this.GetContactList(UserName, Password);
            return Request.CreateResponse(HttpStatusCode.OK, contactModelsList);
        }

        [HttpPost]
        public List<RegisterModels> GetContactList(string UserName, string Password)
        {
            string UID = "0";
            ConfigurationManager.AppSettings["UID"] = "0";
            List<RegisterModels> contactModelsList = new List<RegisterModels>();
            RegisterModels registerModels = new RegisterModels();
            if (!string.IsNullOrEmpty(Convert.ToString(UserName)) && !string.IsNullOrEmpty(Convert.ToString(Password)))
            {
                DataTable dtContactList = new DataTable();

                dtContactList = registerModels.GetUserDetails(UserName, Password);
                if (dtContactList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtContactList.Rows)
                    {
                        RegisterModels contactModelsTypes = new RegisterModels();
                        contactModelsTypes.UID = Convert.ToInt32(dr["UID"]);
                        contactModelsTypes.UserName = Convert.ToString(dr["user_name"]);
                        contactModelsTypes.Password = Convert.ToString(dr["password"]);
                        contactModelsTypes.FirstName = Convert.ToString(dr["first_name"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["last_name"])))
                            contactModelsTypes.LastName = Convert.ToString(dr["last_name"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["phone_no"])))
                            contactModelsTypes.PhoneNumber = Convert.ToString(dr["phone_no"]).ToString().Trim();
                        contactModelsTypes.EmailId = Convert.ToString(dr["e_mail"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["postal_code"])))
                            contactModelsTypes.PostalCode = Convert.ToString(dr["postal_code"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["standard"])))
                            contactModelsTypes.StandardId = Convert.ToInt32(dr["standard"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["DOB"])))
                            contactModelsTypes.DOB = dr["DOB"].ToString().Trim().ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["user_type"])))
                            contactModelsTypes.UserType = Convert.ToInt32(dr["user_type"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Country"])))
                            contactModelsTypes.Country = Convert.ToString(dr["Country"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["State"])))
                            contactModelsTypes.State = Convert.ToString(dr["State"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["expire_on"])))
                            contactModelsTypes.expire_on = Convert.ToDateTime(dr["expire_on"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["profile_picture"])))
                            contactModelsTypes.Location = Convert.ToString(dr["profile_picture"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["gender"])))
                            contactModelsTypes.Gender = Convert.ToString(dr["gender"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["about"])))
                            contactModelsTypes.About = Convert.ToString(dr["about"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["active"])))
                            contactModelsTypes.Active = Convert.ToBoolean(dr["active"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["created_on"])))
                            contactModelsTypes.CreatedOn = Convert.ToDateTime(dr["created_on"]).ToShortDateString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["address"])))
                            contactModelsTypes.Address = Convert.ToString(dr["address"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["address"])))
                            contactModelsTypes.Fax = Convert.ToString(dr["fax"]).ToString().Trim();
                        UID = Convert.ToString(dr[0]);
                        contactModelsList.Add(contactModelsTypes);
                    }
                }
            }
            //HttpContext.Current.Session["API_Users"] = UID;
            ConfigurationManager.AppSettings["UID"] = UID;
            return contactModelsList;
        }

        #endregion

        #region SearchUserType

        [HttpGet]
        [Route("SearchUserType")]
        public HttpResponseMessage SearchUserType(int UserType)
        {
            List<RegisterModels> contactModelsList = new List<RegisterModels>();
            contactModelsList = this.SearchUserTypeList(UserType);
            return Request.CreateResponse(HttpStatusCode.OK, contactModelsList);
        }

        [HttpPost]
        public List<RegisterModels> SearchUserTypeList(int UserType)
        {
            string UID = "0";
            ConfigurationManager.AppSettings["UID"] = "0";
            List<RegisterModels> contactModelsList = new List<RegisterModels>();
            RegisterModels registerModels = new RegisterModels();
            if (!string.IsNullOrEmpty(Convert.ToString(UserType)))
            {
                DataTable dtContactList = new DataTable();

                dtContactList = registerModels.SearchUserType(UserType);
                if (dtContactList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtContactList.Rows)
                    {
                        RegisterModels contactModelsTypes = new RegisterModels();
                        contactModelsTypes.UID = Convert.ToInt32(dr["UID"]);
                        contactModelsTypes.UserName = Convert.ToString(dr["UserName"]);
                        contactModelsTypes.Password = Convert.ToString(dr["Password"]);
                        contactModelsTypes.FirstName = Convert.ToString(dr["FirstName"]).ToString().Trim();
                        contactModelsTypes.SchoolID = Convert.ToInt32(dr["exam_id"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["LastName"])))
                            contactModelsTypes.LastName = Convert.ToString(dr["LastName"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["PhoneNo"])))
                            contactModelsTypes.PhoneNumber = Convert.ToString(dr["PhoneNo"]).ToString().Trim();
                        contactModelsTypes.EmailId = Convert.ToString(dr["EmailId"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["PostalCode"])))
                            contactModelsTypes.PostalCode = Convert.ToString(dr["PostalCode"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Standard"])))
                            contactModelsTypes.StandardId = Convert.ToInt32(dr["Standard"]);
                        contactModelsTypes.DOB = dr["DOB"].ToString().Trim().ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["UserType"])))
                            contactModelsTypes.UserType = Convert.ToInt32(dr["UserType"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Country"])))
                            contactModelsTypes.Country = Convert.ToString(dr["Country"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["State"])))
                            contactModelsTypes.State = Convert.ToString(dr["State"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["PrimeUser"])))
                            contactModelsTypes.PrimaryUser = Convert.ToBoolean(dr["PrimeUser"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ProfilePicture"])))
                            contactModelsTypes.ProfilePicture = Convert.ToString(dr["ProfilePicture"]).ToString().Trim();
                        UID = Convert.ToString(dr[0]);
                        contactModelsList.Add(contactModelsTypes);
                    }
                }
            }
            //HttpContext.Current.Session["API_Users"] = UID;
            ConfigurationManager.AppSettings["UID"] = UID;
            return contactModelsList;
        }

        #endregion

        #region update ABOUT Info

        [Route("updateInfo")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage updateInfos(int UID,  int SchoolID, string About, int UType)
        {
            try
            {
                string Status = string.Empty;
                RegisterModels registerModels = new RegisterModels();
                registerModels.UID = UID;
                registerModels.SchoolID = SchoolID;
                registerModels.About = About;
                registerModels.UserType = UType;
                registerModels.Gender = string.Empty;
                registerModels.Address = string.Empty;
                registerModels.State = string.Empty;
                registerModels.Country = string.Empty;
                registerModels.PostalCode = string.Empty;
                registerModels.PhoneNumber = string.Empty;
                registerModels.QueryType = "1";
                registerModels.Fax = string.Empty;
                Status = registerModels.UpdateUserInfo();
                return Request.CreateResponse(HttpStatusCode.OK, Status);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.ToString().Trim());
            }
        }

        #endregion

        #region "UpdateBasicInfo"

        [HttpPost]
        [Route("UpdateBasicInfo")]
        public IHttpActionResult updateBasicInfo(RegisterModels registerModels)
        {
            try
            {
                string Status = string.Empty;
                registerModels.QueryType = "2";
                registerModels.Fax = string.Empty;
                Status = registerModels.UpdateUserInfo();
                return ResponseMessage(Request.CreateResponse(Status));
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateResponse(ex.ToString().Trim()));
            }
        }

        #endregion

        #region "UpdateContactInfo"

        [Route("UpdateContactInfo")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage UpdateContact(int UID, int SchoolID, string ContactNo, int UType, string Fax)
        {
            try
            {
                string Status = string.Empty;
                RegisterModels registerModels = new RegisterModels();
                registerModels.UID = UID;
                registerModels.SchoolID = SchoolID;
                registerModels.PhoneNumber = ContactNo;
                registerModels.Gender = string.Empty;
                registerModels.Address = string.Empty;
                registerModels.State = string.Empty;
                registerModels.Country = string.Empty;
                registerModels.PostalCode = string.Empty;
                registerModels.About = string.Empty;
                registerModels.UserType = UType;
                registerModels.QueryType = "3";
                registerModels.Fax = Fax;
                Status = registerModels.UpdateUserInfo();
                return Request.CreateResponse(HttpStatusCode.OK, Status);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.ToString().Trim());
            }
        }
        #endregion

        #region GetLogin

        [HttpGet]
        [Route("searchEmail")]
        public HttpResponseMessage Search(int SID, string SearchText, string std, int UserType)
        {
            if (string.IsNullOrEmpty(Convert.ToString(SearchText)))
                SearchText = string.Empty;
            if (string.IsNullOrEmpty(Convert.ToString(std)))
                std = string.Empty;
            List<RegisterModels> searchList = new List<RegisterModels>();
            searchList = this.SearchEmilList(SID, SearchText, std, UserType);
            return Request.CreateResponse(HttpStatusCode.OK, searchList);
        }

        [HttpPost]
        public List<RegisterModels> SearchEmilList(int SID, string SearchText, string std, int UserType)
        {
            List<RegisterModels> searchModelsList = new List<RegisterModels>();
            RegisterModels registerModels = new RegisterModels();
            if (!string.IsNullOrEmpty(Convert.ToString(SID)))
            {
                DataTable dtContactList = new DataTable();

                dtContactList = registerModels.SearchEmail(SID, SearchText, std, UserType);
                if (dtContactList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtContactList.Rows)
                    {
                        RegisterModels contactModelsTypes = new RegisterModels();
                        contactModelsTypes.UID = Convert.ToInt32(dr["UID"]);
                        contactModelsTypes.FirstName = Convert.ToString(dr["first_name"]).ToString().Trim();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["last_name"])))
                            contactModelsTypes.LastName = Convert.ToString(dr["last_name"]).ToString().Trim();
                        contactModelsTypes.SchoolID = Convert.ToInt32(dr["exam_id"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["e_mail"])))
                            contactModelsTypes.EmailId = Convert.ToString(dr["e_mail"]).ToString().Trim();
                        contactModelsTypes.UserType = Convert.ToInt32(dr["userType"]);
                        searchModelsList.Add(contactModelsTypes);
                    }
                }
            }
            return searchModelsList;
        }

        #endregion

        #region "UpdateProfilePicture"

        [Route("UpdateProfilePicture")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage UpdateProfilePictures(int SID, int UID, int UserType, string Location)
        {
            try
            {
                string Status = string.Empty;
                RegisterModels registerModels = new RegisterModels();
                registerModels.UID = UID;
                registerModels.SchoolID = SID;
                registerModels.UserType = UserType;
                registerModels.Location = Location;
                Status = registerModels.UpdateProfilePicture();
                return Request.CreateResponse(HttpStatusCode.OK, Status);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.ToString().Trim());
            }
        }
        #endregion

    }
}
