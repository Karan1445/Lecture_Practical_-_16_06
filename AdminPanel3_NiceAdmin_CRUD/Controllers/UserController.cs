﻿using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class UserController : Controller
    {
        public static List<UserModel> user = new List<UserModel>() { 
        new UserModel{UserID=1,UserName="Karan",Email="goheljitu164@gmail.com",Password="Karan@1234",MobileNo="8141953822",Address="Rajkot",IsActive=true },


        new UserModel{UserID=2,UserName="Parth",Email="Path@gmail.com",Password="Parth@1234",MobileNo="89899899",Address="Kokidia",IsActive=true },
        new UserModel{UserID=3,UserName="Harsh",Email="harsh@gmail.com",Password="harsh@1234",MobileNo="252515565",Address="sapar",IsActive=true },
        };
        public IConfiguration configuration;
        public UserController(IConfiguration config) {
            configuration = config;
            }
        public IActionResult User()
        {
            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_User_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return View(dt);
        }
        public IActionResult AddUser() {
            return View();
        }
        public IActionResult AddInContoller(UserModel newData) {
            newData.UserID = user.Count + 1;
            user.Add(newData);
            return View("User",user);
        }
    }
}
