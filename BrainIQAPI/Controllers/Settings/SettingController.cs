using BrainIQAPI.Models.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Settings
{
    [RoutePrefix("api/settings")]
    public class SettingController : ApiController
    {
        [HttpGet]
        [Route("GetAwarnessList")]
        public HttpResponseMessage AwarnessList()
        {
            List<SettingsModels> subjecttModelsList = new List<SettingsModels>();
            subjecttModelsList = this.GetAwarnessList();
            return Request.CreateResponse(HttpStatusCode.OK, subjecttModelsList);
        }

        [HttpPost]
        public List<SettingsModels> GetAwarnessList()
        {
            List<SettingsModels> awarnessModelsList = new List<SettingsModels>();
            SettingsModels awarnessModels = new SettingsModels();
            DataTable dtGetList = new DataTable();
            dtGetList = awarnessModels.GetAwarnessList();
            if (dtGetList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtGetList.Rows)
                {
                    SettingsModels settingsModelsTypes = new SettingsModels();
                    settingsModelsTypes.ID = Convert.ToInt32(dr["ID"]);
                    settingsModelsTypes.Title = Convert.ToString(dr["Title"]);
                    settingsModelsTypes.Description = Convert.ToString(dr["Description"]);
                    settingsModelsTypes.CreatedOn = Convert.ToDateTime(dr["Created_On"]).ToShortDateString();
                    settingsModelsTypes.Active = Convert.ToBoolean(dr["Active"]);
                    awarnessModelsList.Add(settingsModelsTypes);
                }
            }

            return awarnessModelsList;
        }

        [HttpGet]
        [Route("insertAwarness")]
        public IHttpActionResult Save(string ID, string Title, string Description, string Active)
        {
            bool Status = false;
            SettingsModels settingsModelsList = new SettingsModels();
            settingsModelsList.ID = Convert.ToInt32(ID);
            settingsModelsList.Title = Title;
            settingsModelsList.Description = Description;
            if (Active.ToString().Trim().Equals("true"))
                settingsModelsList.Active = true;
            else
                settingsModelsList.Active = false;
            Status = settingsModelsList.SaveRecord();
            return ResponseMessage(Request.CreateResponse(Status));
        }

        [HttpGet]
        [Route("deleteAwarness")]
        public IHttpActionResult Delete(int ID)
        {
            bool Status = false;
            SettingsModels subjecttModelsList = new SettingsModels();
            subjecttModelsList.ID = ID;
            Status = subjecttModelsList.DeleteRecord();
            return ResponseMessage(Request.CreateResponse(Status));
        }
    }
}
