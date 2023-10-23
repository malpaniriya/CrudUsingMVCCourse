using System.Data.SqlClient;

namespace CrudUsingMVCCourse.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public CourseDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            string qry = "select *from Course";
            cmd=new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Course course = new Course();
                    course.Id = Convert.ToInt32(dr["id"]);
                    course.Name = dr["name"].ToString();
                    course.Duration = Convert.ToInt32(dr["duration"]);
                    courses.Add(course);
                }
            }
            con.Close();
            return courses;
        }

        public Course GetCourse(int id)
        {
            Course courses = new Course();
            string qry = "select * from Course where id=@id";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    courses.Id = Convert.ToInt32(dr["id"]); 
                    courses.Name = dr["name"].ToString();
                    courses.Duration = Convert.ToInt32(dr["duration"]);
                    courses.fees = Convert.ToDouble(dr["fees"]);
                }
            }
            con.Close();
            return courses;
        }

        public int AddCourse(Course course)
        {
            int result = 0;
            string qry = "insert into Course values(@name,@duration,@fees)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", course.Name);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            cmd.Parameters.AddWithValue("@fees", course.fees);
            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateCourse(Course course)
        {
            int result = 0;
            string qry = "update Course set name=@name,@duration,@fees where id=@id";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name",course.Name);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            cmd.Parameters.AddWithValue("@fees", course.fees);
            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }

        public int DeleteCourse(int id)
        {
            int result = 0;
            string qry = "delete from Course where id=@id";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
