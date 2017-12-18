using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Connect2Db
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "server=localhost;User Id=root;password=admin;Database=world";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("select * from city", mycon);
            getResultset(mycmd);
            Console.ReadLine();
            mycon.Close();

        }
        public static void getResultset(MySqlCommand mySqlCommand)
        {
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("ID:" + reader.GetInt32(0) + ",Name:" + reader.GetString(1) + ",CountryCode:" + reader.GetString(2) + ",District:" + reader.GetString(3) + ",Population:"+reader.GetInt32(4));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
