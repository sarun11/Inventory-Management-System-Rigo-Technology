using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RigoAccounts.DLL;

namespace RigoAccounts.BLL.Manager
{
    public class UserTypeManager
    {
        public static List<tblUserType> getAllUserTypes() {
            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
            return dc.tblUserTypes.ToList();
        }

        public static bool insertUserType(tblUserType userType, bool isInsert) {

            bool status = false;

            if (userType != null) {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();

                if (isInsert)
                {
                    //Case of Inserting a new UserType
                    dc.tblUserTypes.InsertOnSubmit(userType);
                }
                else {

                    //Case of Updating a new UserType
                    tblUserType dbUserType = dc.tblUserTypes.Where(x => x.UserTypeID == userType.UserTypeID).SingleOrDefault();
                    dbUserType.Name = userType.Name;
                }

                dc.SubmitChanges();
                status = true;
            }

            return status;
        }

        public static tblUserType getUserTypeById(Guid id) {

            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
            return dc.tblUserTypes.Where(x => x.UserTypeID == id).SingleOrDefault();
        }

        public static bool deleteUserType(tblUserType userType) {

            bool status = false;

            if (userType != null) {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
                tblUserType dbobj = dc.tblUserTypes.Where(x => x.UserTypeID == userType.UserTypeID).SingleOrDefault();

                if (dbobj != null) {
                    dc.tblUserTypes.DeleteOnSubmit(dbobj);
                    dc.SubmitChanges();
                    status = true;
                }
            }
            
            return status;
        }
    }
}