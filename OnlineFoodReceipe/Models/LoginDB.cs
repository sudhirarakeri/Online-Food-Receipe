using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnlineFoodReceipe.Models
{
    public class LoginDB
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public LoginDB()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        // Feedback Query
        public int Feedback(string name,string email,string msg)
        {
            string str = "insert into Feedback(Name,Email,Message) values(@name,@email,@msg)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@msg", msg);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public List<Feedback> FeedbackInfo()
        {
            List<Feedback> list = new List<Feedback>();
            string str = "select Top 3 * from Feedback order by Fid desc";
            cmd=new SqlCommand(str, con);
            con.Open();
            dr=cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Feedback f = new Feedback();
                    f.Name = dr["Name"].ToString();
                    f.Msg = dr["Message"].ToString();
                    list.Add(f);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }
        }
        public List<Feedback> AllFeedbackInfo()
        {
            List<Feedback> list = new List<Feedback>();
            string str = "select * from Feedback order by Fid desc";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Feedback f = new Feedback();
                    f.Name = dr["Name"].ToString();
                    f.Msg = dr["Message"].ToString();
                    list.Add(f);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }
        }

        // Login Query
        public int Save(Login u)
        {
            string str = "insert into Login(Username,Email,Password,RoleID,ProfilePhoto) values(@name,@email,@password,@roleid,@photo)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", u.UserName);
            cmd.Parameters.AddWithValue("@email", u.Email);
            cmd.Parameters.AddWithValue("@password", u.Password);
            cmd.Parameters.AddWithValue("@roleid", u.RoleID);
            cmd.Parameters.AddWithValue("@photo", u.PhotoName);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Search(string user, string pass)
        {
            Login u = new Login();
            string str = "select * from Login where Email=@user and Password=@pass";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                con.Close();
                return 1;
            }
            con.Close();
            return 0;
        }

        // Forget Password Query
        public int ForgetPassword(string email,string date,string pass)
        {
            string str = "update Login set Password=@pass where Email=@email and DOB=@date";
            cmd= new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@pass", pass);
            int res = cmd.ExecuteNonQuery();
            return res;
        }

        // Find Role Query
        public Login GetRole(string user,string pass)
        {
            Login l = new Login();
            string str = "select * from Login where Email=@user and Password=@pass";
            cmd= new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    l.RoleID = Convert.ToInt32(dr["RoleID"]);
                    l.Id = Convert.ToInt32(dr["Id"]);
                }
                con.Close();
                return l;
            }
            con.Close();
            return l;
        }

        // Find Name Query
        public Login GetName(string email,string pass)
        {
            Login log = new Login();
            string str = "select * from Login where Email=@email and Password=@pass";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", pass);
            dr= cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    log.Id = Convert.ToInt32(dr["Id"]);
                    log.UserName = dr["Username"].ToString();
                    log.RoleID = Convert.ToInt32(dr["RoleID"]);
                }
                con.Close();
                return log;
            }
            else
            {
                con.Close();
                return log;
            }     
        }
        public int Temporary(string Email,string Password)
        {
            string str = "insert into Logged(Username,Password) values(@email,@password)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@password", Password);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        // After Logged Query
        public int Temporaryvnb(string Email, string vnb)
        {
            string str = "update Logged set vnb=@vnb where Username=@email";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@vnb", vnb);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Temporarystate(string Email, string sname)
        {
            string str = "update Logged set sname=@sname where Username=@email";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@sname", sname);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public Logged TempName()
        {
            Logged log = new Logged();
            string str = "select * from Logged";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    log.Name = dr["Username"].ToString();
                    log.Password = dr["Password"].ToString();
                    log.Sname = dr["sname"].ToString();
                    log.Vnb = dr["vnb"].ToString();
                }
                con.Close();
                return log;
            }
            else
            {
                con.Close();
                return log;
            }
        }

        public void DeleteLogged()
        {
            string str = "delete from Logged";
            cmd= new SqlCommand(str, con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
