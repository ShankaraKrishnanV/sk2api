using ContactAppAPI.CommonUpdates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BrainIQAPI.Models.Settings
{
    public class SettingsModels
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public bool Active { get; set; }

        protected internal DataTable GetAwarnessList()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_get_awarness");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            DBOperations dbOperations = new DBOperations();
            return dbOperations.GetTableData(sqlCommand);
        }

        public bool SaveRecord()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_insert_general_awarness");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", this.ID);
            sqlCommand.Parameters.AddWithValue("@Title", this.Title);
            sqlCommand.Parameters.AddWithValue("@Description", this.Description);
            sqlCommand.Parameters.AddWithValue("@active", this.Active);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Delete Record
        /// </summary>
        /// <returns></returns>
        public bool DeleteRecord()
        {
            SqlCommand sqlCommand = new SqlCommand("usp_delete_general_awarness");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", this.ID);
            DBOperations dbOperation = new DBOperations();
            string Output = string.Empty;
            bool status = dbOperation.SaveData(sqlCommand, out Output, "");
            if (status)
                return true;
            else
                return false;
        }

    }
}