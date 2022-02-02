using MySql.Data.MySqlClient;
using mysqlwebapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysqlwebapp.Services
{
    public class CourseService
    {
        private static string _connection_string = "server=127.0.0.1;user=root;password=Puspraj@123;database=appdb";
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connection_string);
        }
        public IEnumerable<Course> GetCources()
        {
            List<Course> _lst = new List<Course>();
            string statement = "SELECT * FROM course";
            MySqlConnection _connection = GetConnection();
            _connection.Open();
            MySqlCommand _command = new MySqlCommand(statement, _connection);
            using (MySqlDataReader _reader = _command.ExecuteReader())
            {
                while(_reader.Read())
                {
                    Course course = new Course()
                    {
                        courseName = _reader.GetString(0),
                        rating = _reader.GetInt32(1)
                    };
                    _lst.Add(course);
                }
            }
            _connection.Close();
            return _lst;
        }
    }
}
