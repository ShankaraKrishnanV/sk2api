using BrainIQAPI.Models.Device;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrainIQAPI.Controllers.Device
{

    [RoutePrefix("api/Device")]
    public class DeviceController : ApiController
    {

        /// <summary>
        /// Get Chapter Based Exams
        /// </summary>
        /// <param name="ChapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getdevicelist")]
        public HttpResponseMessage Devicelist(int UID)
        {
            List<DeviceModels> deviceModelslist = new List<DeviceModels>();
            deviceModelslist = this.GetDevice(UID);
            return Request.CreateResponse(HttpStatusCode.OK, deviceModelslist);
        }

        [HttpPost]
        public List<DeviceModels> GetDevice(int UID)
        {
            List<DeviceModels> DeviceModelsList = new List<DeviceModels>();
            DeviceModels deviceModels = new DeviceModels();
            deviceModels.UID = UID;
            if (!string.IsNullOrEmpty(Convert.ToString(deviceModels.UID)))
            {
                DataTable dtSubjectList = new DataTable();
                dtSubjectList = deviceModels.Get();
                if (dtSubjectList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubjectList.Rows)
                    {
                        DeviceModels deviceModelsTypes = new DeviceModels();
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["UID"])))
                            deviceModelsTypes.UID = Convert.ToInt32(dr["UID"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["DeviceId"])))
                            deviceModelsTypes.DeviceID = Convert.ToString(dr["DeviceId"]);

                        DeviceModelsList.Add(deviceModelsTypes);
                    }
                }
            }
            return DeviceModelsList;
        }


        [HttpGet]
        [Route("SaveDevice")]
        public IHttpActionResult SaveResult(int UID, string DeviceID)
        {
            DeviceModels deviceModels = new DeviceModels();
            deviceModels.UID = UID;
            deviceModels.DeviceID = DeviceID;
            try
            {
                string Status = string.Empty;
                Status = deviceModels.InsertDevice();
                return ResponseMessage(Request.CreateResponse(Status));
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateResponse("Failed"));
            }
        }




    }
}
