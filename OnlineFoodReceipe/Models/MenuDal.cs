using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnlineFoodReceipe.Models
{
    public class MenuDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public MenuDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public int GetCountId()
        {
            int count = 0;
            string str = "select count(Id) as TotId from Login";
            cmd=new SqlCommand(str,con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    count = Convert.ToInt32(dr["TotId"]);
                }
                con.Close();
                return count;
            }
            return count;
        }
        public int GetCountRId()
        {
            int count = 0;
            string str = "select count(Rid) as TotRId from Receipe";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    count = Convert.ToInt32(dr["TotRId"]);
                }
                con.Close();
                return count;
            }
            return count;
        }
        public int Insert(Menu m)
        {
            string str = "insert into Receipe values(@rname,@image,@youtube,@ingredient,@htm,@roleid,@sname,@vnb,@id)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@rname", m.RName);
            cmd.Parameters.AddWithValue("@image", m.Photo);
            cmd.Parameters.AddWithValue("@youtube", m.Youtube);
            cmd.Parameters.AddWithValue("@ingredient", m.Ingredient);
            cmd.Parameters.AddWithValue("@htm", m.HTM);
            cmd.Parameters.AddWithValue("@vnb", m.VNB);
            cmd.Parameters.AddWithValue("@roleid", m.RoleId);
            cmd.Parameters.AddWithValue("@sname", m.State);
            cmd.Parameters.AddWithValue("@id", m.UserId);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public List<Menu> GetAllProducts(string sname,string vnb)
        {
            List<Menu> list = new List<Menu>();
            string str = "select * from Receipe where SName=@sname and VNB=@vnb";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@vnb", vnb);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Menu p = new Menu();
                    p.RId = Convert.ToInt32(dr["Rid"]);
                    p.RName = dr["RName"].ToString();
                    p.VNB = dr["VNB"].ToString();
                    list.Add(p);
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
        public List<Menu> GetAllProductsForModify(string sname,int id)
        {
            List<Menu> list = new List<Menu>();
            string str = "select * from Receipe where SName=@sname and UserId=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Menu p = new Menu();
                    p.RId = Convert.ToInt32(dr["Rid"]);
                    p.RName = dr["RName"].ToString();
                    list.Add(p);
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
        public Menu GetInfo(int id)
        {
            Menu m = new Menu();
            string str = "select * from Receipe where Rid=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    m.RId = Convert.ToInt32(dr["Rid"]);
                    m.RName = dr["Rname"].ToString();
                    m.Youtube = dr["Youtube"].ToString();
                    m.Ingredient = dr["Ingredient"].ToString();
                    m.State = dr["SName"].ToString();
                    m.Photo = dr["Image"].ToString();
                    m.HTM = dr["HTM"].ToString();
                    m.VNB = dr["vnb"].ToString();
                }
                con.Close();
                return m;
            }
            return m;
        }

        public List<State> GetAllState(string vnb)
        {
            List<State> list = new List<State>();
            string str = "select distinct SName from Receipe where VNB=@vnb";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@vnb", vnb);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    State p = new State();
                    p.Sname = dr["SName"].ToString();
                    list.Add(p);
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
        public List<Menu> GetBeverageList(string vnb)
        {
            List<Menu> list = new List<Menu>();
            string str = "select * from Receipe where VNB=@vnb";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@vnb", vnb);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Menu p = new Menu();
                    p.RId = Convert.ToInt32(dr["Rid"]);
                    p.RName = dr["RName"].ToString();
                    p.Photo = dr["Image"].ToString();
                    list.Add(p);
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

        public List<Menu> GetBeverageListByUser(string vnb,int id)
        {
            List<Menu> list = new List<Menu>();
            string str = "select * from Receipe where VNB=@vnb and UserId=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@vnb", vnb);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Menu p = new Menu();
                    p.RId = Convert.ToInt32(dr["Rid"]);
                    p.RName = dr["RName"].ToString();
                    p.Photo = dr["Image"].ToString();
                    list.Add(p);
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
        public int Delete(int id)
        {
            string str = "delete from Receipe where Rid=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Menu m)
        {
            string str = "update Receipe set Rname=@rname,Image=@image,Youtube=@youtube,Ingredient=@ingredient,HTM=@htm,VNB=@vnb,SName=@sname where Rid=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@rname", m.RName);
            cmd.Parameters.AddWithValue("@image", m.Photo);
            cmd.Parameters.AddWithValue("@youtube", m.Youtube);
            cmd.Parameters.AddWithValue("@ingredient", m.Ingredient);
            cmd.Parameters.AddWithValue("@htm", m.HTM);
            cmd.Parameters.AddWithValue("@vnb", m.VNB);
            cmd.Parameters.AddWithValue("@sname", m.State);
            cmd.Parameters.AddWithValue("@id", m.RId);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int UpdateWOPhoto(Menu m)
        {
            string str = "update Receipe set Rname=@rname,Youtube=@youtube,Ingredient=@ingredient,HTM=@htm,VNB=@vnb,SName=@sname where Rid=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@rname", m.RName);
            cmd.Parameters.AddWithValue("@youtube", m.Youtube);
            cmd.Parameters.AddWithValue("@ingredient", m.Ingredient);
            cmd.Parameters.AddWithValue("@htm", m.HTM);
            cmd.Parameters.AddWithValue("@vnb", m.VNB);
            cmd.Parameters.AddWithValue("@sname", m.State);
            cmd.Parameters.AddWithValue("@id", m.RId);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public Profile GetInfoProfile(int id)
        {
            Profile m = new Profile();
            string str = "select * from Login where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    m.Id = Convert.ToInt32(dr["Id"]);
                    m.Username = dr["Username"].ToString();
                    m.Email = dr["Email"].ToString();
                    m.Password = dr["Password"].ToString();
                    m.RoleId = Convert.ToInt32(dr["RoleID"]);
                    m.DOB = dr["DOB"].ToString();
                    m.Gender = dr["Gender"].ToString();
                    m.Profession = dr["Profession"].ToString();
                    m.City = dr["City"].ToString();
                    m.PhotoName = dr["ProfilePhoto"].ToString();
                }
                con.Close();
                return m;
            }
            return m;
        }
        public int UpdateProfilePhoto(Profile p)
        {
            string str = "update Login set Username=@username,Email=@email,Password=@pass,Profession=@profession,City=@city,DOB=@dob,ProfilePhoto=@pname,Gender=@gender where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@username", p.Username);
            cmd.Parameters.AddWithValue("@email", p.Email);
            cmd.Parameters.AddWithValue("@pass", p.Password);
            cmd.Parameters.AddWithValue("@profession", p.Profession);
            cmd.Parameters.AddWithValue("@city", p.City);
            cmd.Parameters.AddWithValue("@dob", p.DOB);
            cmd.Parameters.AddWithValue("@pname", p.PhotoName);
            cmd.Parameters.AddWithValue("@gender", p.Gender);
            cmd.Parameters.AddWithValue("@id", p.Id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int UpdateProfile(Profile p)
        {
            string str = "update Login set Username=@username,Email=@email,Password=@pass,Profession=@profession,City=@city,DOB=@dob,Gender=@gender where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@username", p.Username);
            cmd.Parameters.AddWithValue("@email", p.Email);
            cmd.Parameters.AddWithValue("@pass", p.Password);
            cmd.Parameters.AddWithValue("@profession", p.Profession);
            cmd.Parameters.AddWithValue("@city", p.City);
            cmd.Parameters.AddWithValue("@dob", p.DOB);
            cmd.Parameters.AddWithValue("@gender", p.Gender);
            cmd.Parameters.AddWithValue("@id", p.Id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
