using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RigoAccounts.DLL;

namespace RigoAccounts.BLL.Manager
{
    public class UserManager
    {

        public static bool insertUser(UserDetail obj, bool isInsert)
        {

            bool status = false;

            if (obj != null)
            {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
                if (isInsert)
                {

                    //Case of Insert
                    obj.CreatedOn = DateTime.Now;
                    dc.UserDetails.InsertOnSubmit(obj);
                }

                else
                {
                    //Case of update
                    UserDetail dbobj = dc.UserDetails.Where(x => x.UserID == obj.UserID).SingleOrDefault();

                    if (dbobj != null)
                    {

                        dbobj.FullName = obj.FullName;
                        dbobj.UserName = obj.UserName;
                        dbobj.PasswordAsHash = obj.PasswordAsHash;
                        dbobj.UserType_ID = obj.UserType_ID;
                    }
                }

                dc.SubmitChanges();
                status = true;
            }

            //Status represents if Insert/Object became successful or not
            return status;
        }

        public static List<GetUserDetailsResult> GetAllUsers(string searchText)
        {
            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
            //SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
            return dc.GetUserDetails(searchText).ToList();
        }

        public static UserDetail GetUserByID(Guid userID)
        {

            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
            return dc.UserDetails.Where(x => x.UserID == userID).SingleOrDefault();
        }

        public static bool deleteUser(UserDetail obj)
        {

            bool status = false;

            if (obj != null)
            {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
                UserDetail dbObj = dc.UserDetails.Where(x => x.UserID == obj.UserID).SingleOrDefault();

                if (dbObj != null)
                {

                    dc.UserDetails.DeleteOnSubmit(dbObj);
                    dc.SubmitChanges();
                    status = true;
                }

            }

            return status;
        }
    }

}