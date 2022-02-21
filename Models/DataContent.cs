using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebAppExam_21.Models
{
    public class DataContent
    {
        const string CONNECTIONSTRING = "Data Source=RILPT170;Initial Catalog=ShoppingApp;User ID=sa;Password=sa123";
        public List<Shopping> GetAllDresses()
        {
            var list = new List<Shopping>();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {

                try
                {
                    con.Open();
                    SqlCommand sqlCmd = con.CreateCommand();
                    sqlCmd.CommandText = "SELECT *FROM SHOPPTAB";
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var shp = new Shopping();
                        shp.shopapp_Id = Convert.ToInt32(reader[0]);
                        shp.shopapp_Name = reader[1].ToString();
                        shp.product_Type = reader[2].ToString();
                        shp.dress = reader[3].ToString();
                        shp.product_Colour = reader[4].ToString();
                        shp.size = reader[5].ToString();
                        shp.product_Price = Convert.ToInt32(reader[6]);
                        list.Add(shp);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }

        public Shopping FindDresses(int id)
        {
            Shopping shp = new Shopping();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM STOPPTAB WHERE SHOPAPP_ID =" + id;
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        shp.shopapp_Id = Convert.ToInt32(reader[0]);
                        shp.shopapp_Name = reader[1].ToString();
                        shp.product_Type = reader[2].ToString();
                        shp.dress = reader[3].ToString();
                        shp.product_Colour = reader[4].ToString();
                        shp.size = reader[5].ToString();
                        shp.product_Price = Convert.ToInt32(reader[6]);
                    }
                    else
                        throw new Exception("No Studnet Found");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            return shp;
        }

        public void UpdateDresses(Shopping shp)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = $"UPDATE SHOPPTAB set shopapp_Name='{shp.shopapp_Name}',product_Type ='{shp.product_Type }',dress='{shp.dress}',product_Colour='{shp.product_Colour}',size='{shp.size}',product_Price='{shp.product_Price}'WHERE shopapp_Id={shp.shopapp_Id}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void AddNewDresses(Shopping shp)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = "Insert into ShoppTab values(@id,@name,@type,@dress,@colour,@size,@price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", shp.shopapp_Id);
                cmd.Parameters.AddWithValue("@name", shp.shopapp_Name);
                cmd.Parameters.AddWithValue("@type", shp.product_Type);
                cmd.Parameters.AddWithValue("@dress", shp.dress);
                cmd.Parameters.AddWithValue("@colour", shp.product_Colour);
                cmd.Parameters.AddWithValue("@size", shp.size);
                cmd.Parameters.AddWithValue("@price", shp.product_Price);
                try
                {
                    con.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected == 0)
                        throw new Exception("No Details Were Added");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void DeleteDresses(int shopapp_Id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = $"Delete * from  ShoppTab where shopapp_Id={shopapp_Id}";
                SqlCommand Command = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rows = Command.ExecuteNonQuery();
                    if (rows == 0)
                        throw new Exception("Row does not exists");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}