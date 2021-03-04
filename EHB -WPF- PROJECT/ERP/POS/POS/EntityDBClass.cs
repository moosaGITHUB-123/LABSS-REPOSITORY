using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

namespace POS
{
    class EntityDBClass
    {
        static string constr = ConfigurationManager.ConnectionStrings["POS.Properties.Settings.Setting"].ConnectionString;
        public static int Create(string spname, string[] parametername, string[] parametervalue)
        {
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            string query = "EXECUTE " + spname + " ";
            for(int i =0; i < parametername.Count(); i++)
            {
                query = query + parametername[i].ToString() + "=";
                int n;
                bool isint = int.TryParse(parametervalue[i], out n);
                if (isint == true)
                {
                    query = query + parametervalue[i] + ", ";
                }else
                {
                    decimal d;
                    bool isdecimal = decimal.TryParse(parametervalue[i], out d);
                    if (isdecimal == true)
                    {
                        query = query + parametervalue[i] + ", ";
                    }else
                    {
                        bool x;
                        bool isboolean = bool.TryParse(parametervalue[i], out x);
                        if (x == true)
                        {
                            query = query + parametervalue[i] + ", ";
                        }
                        else
                        {
                            query = query +"'" +parametervalue[i] + "', ";
                        }

                    }
                }
            }
            string queryx = query.Remove(query.Length - 2, 1);
            SqlCommand command = new SqlCommand(queryx,
              connection);

            command.ExecuteNonQuery();
            
            int newid = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return newid;
        }

        public static bool Update(string spname, string[] parametername, string[] parametervalue)
        {
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            string query = "EXECUTE " + spname + " ";
            for (int i = 0; i < parametername.Count(); i++)
            {
                query = query + parametername[i].ToString() + "=";
                int n;
                bool isint = int.TryParse(parametervalue[i], out n);
                if (isint == true)
                {
                    query = query + parametervalue[i] + ", ";
                }
                else
                {
                    decimal d;
                    bool isdecimal = decimal.TryParse(parametervalue[i], out d);
                    if (isdecimal == true)
                    {
                        query = query + parametervalue[i] + ", ";
                    }
                    else
                    {
                        bool x;
                        bool isboolean = bool.TryParse(parametervalue[i], out x);
                        if (x == true)
                        {
                            query = query + parametervalue[i] + ", ";
                        }
                        else
                        {
                            query = query + "'" + parametervalue[i] + "', ";
                        }

                    }
                }
            }
            string queryx = query.Remove(query.Length - 2, 1);
            SqlCommand command = new SqlCommand(queryx,
              connection);

            int a = command.ExecuteNonQuery();
            connection.Close();
            if (a == 0)
                return false;
            else
                return true;
        }


        public static DataTable Select(string spname, string[] parametername, string[] parametervalue)
        {
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            string query = "EXECUTE " + spname + " ";
            for (int i = 0; i < parametername.Count(); i++)
            {
                query = query + parametername[i].ToString() + "=";
                int n;
                bool isint = int.TryParse(parametervalue[i], out n);
                if (isint == true)
                {
                    query = query + parametervalue[i] + ", ";
                }
                else
                {
                    decimal d;
                    bool isdecimal = decimal.TryParse(parametervalue[i], out d);
                    if (isdecimal == true)
                    {
                        query = query + parametervalue[i] + ", ";
                    }
                    else
                    {
                        bool x;
                        bool isboolean = bool.TryParse(parametervalue[i], out x);
                        if (x == true)
                        {
                            query = query + parametervalue[i] + ", ";
                        }
                        else
                        {
                            query = query + "'" + parametervalue[i] + "', ";
                        }

                    }
                }
            }
            string queryx = query.Remove(query.Length - 2, 1);
            SqlCommand command = new SqlCommand(queryx,
              connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            connection.Close();
            da.Dispose();
            return dt;
           
        }

      

    }
}
