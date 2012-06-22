using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLibraryPro;



namespace BLibraryPro
{
   public class User
    {
       public int UserID { get; set; }
       public string Username { get; set; }
       public string Password { get; set; }       public User() { }
       public User(int paramUserID, string paramUsername, string paramPassword)
       {
           UserID = paramUserID;
           Username = paramUsername;
           Password = paramPassword;
       }
       public User(string paramUsername, string paramPassword)
       {   
           Username = paramUsername;
           Password = paramPassword;
       }

       public bool VerifyUser()
       {
           return DLibraryPro.User.VerifyUser(this);
           //return false;
       }

       public void GetUserInfo(int user_id)
       {

       }

       public bool AddUser()
       {
           return DLibraryPro.User.AddUser(this);
       }
    }
}
