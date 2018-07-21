using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections;
using BrainIQAPI.Models.Question;
using System.IO;
using System.Net.Http.Headers;
using BrainIQAPI.Models.Register;
using System.Configuration;

namespace BrainIQAPI.Controllers.Question
{
    [RoutePrefix("api/files")]
    public class FileController : ApiController
    {

        /// <summary>
        /// Upload status
        /// API - MOBILE
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("profile")]
        public string ProfileUpload(int TypeId, int SID, int UID, int UserType)
        {
            try
            {
                string ext = string.Empty;
                string pic = string.Empty;
                string FolderName = string.Empty;
                if (TypeId == 1)
                    FolderName = "UserProfile";
                else if (TypeId == 2)
                    FolderName = "Status";
                else
                    FolderName = "UserProfile";

                string sPath = "images/" + FolderName + "/";

                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    string filePath = string.Empty;
                    string FileName = string.Empty;
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        pic = Path.GetFileName(SID + "_" + UID);
                        ext = Path.GetExtension(postedFile.FileName);
                        filePath = Path.Combine(HttpContext.Current.Server.MapPath("/images/" + FolderName + "/"), pic + ext);
                        FileName = postedFile.FileName;
                        postedFile.SaveAs(filePath);
                    }
                    string Location = ConfigurationManager.AppSettings["API_URL"].ToString().Trim() + "/images/UserProfile/" + pic + ext;
                    string Status = string.Empty;
                    RegisterModels registerModels = new RegisterModels();
                    registerModels.UID = UID;
                    registerModels.SchoolID = SID;
                    registerModels.UserType = UserType;
                    registerModels.Location = Location;
                    Status = registerModels.UpdateProfilePicture();
                    return Location;
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                return result.ToString().Trim();
            }
            catch (Exception ex)
            {
                return ex.ToString().Trim();
            }
        }



    }
}
