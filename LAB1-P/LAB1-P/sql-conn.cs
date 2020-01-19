using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LAB1_P
{
    class SQLConn
    {
        SqlConnection conObj = new SqlConnection("Data Source=DESKTOP-4NDGMAR;Initial Catalog=Students;Integrated Security=True");
        SqlCommand cmdObj;
        SqlDataAdapter adpObj;
        DataTable dt = new DataTable();

        public DataTable selectData(string sql)
        {
            conObj.Open();
            cmdObj = new SqlCommand(sql, conObj);
            adpObj = new SqlDataAdapter(sql, conObj);
            adpObj.Fill(dt);
            conObj.Close();
            return dt;
        }
        public bool manipulateData(string sql)
        {
            conObj.Open();
            try
            {
                cmdObj = new SqlCommand(sql, conObj);
                cmdObj.ExecuteNonQuery();
            }
            catch
            {
                conObj.Close();
                return false;
            }
            conObj.Close();
            return true;
        }
        public int scalar(string sql)
        {
            conObj.Open();
            cmdObj = new SqlCommand(sql, conObj);
            int i = Convert.ToInt16(cmdObj.ExecuteScalar());
            conObj.Close();
            return i;
        }
    }
}

