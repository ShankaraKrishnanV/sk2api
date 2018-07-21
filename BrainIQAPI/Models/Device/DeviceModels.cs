using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Device
{
    public class DeviceModels
    {

        #region "Property"

        /// <summary>
        /// get or set the UID
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// get or set the DeviceID
        /// </summary>
        public string DeviceID { get; set; }

        #endregion

        #region "Private Method

        public string InsertDevice()
        {
            SqlCommand sqlcommand = new SqlCommand("usp_insert_device_notifications");
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@UID", this.UID.ToString().Trim());
            sqlcommand.Parameters.AddWithValue("@DeviceId", this.DeviceID.ToString().Trim());
            sqlcommand.Parameters.Add("@IdOut", SqlDbType.Int).Direction = ParameterDirection.Output;
            DBOperations dbOperation = new DBOperations();
            string outputValue = string.Empty;
            bool Status = dbOperation.SaveData(sqlcommand, out outputValue, "@IdOut");
            if (Status)
                return outputValue;
            else
                return outputValue;
        }

        protected internal DataTable Get()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_device_notifications");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UID", this.UID.ToString().Trim());
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        #endregion

    }
}