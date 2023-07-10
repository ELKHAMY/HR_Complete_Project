using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Helper
    {

        public enum Roles
        {
            SuperAdmin,
            Admin,
            Basic
        }


        public enum PermissionModuleName
        {
            Account,
            Employees,
            GeneralSettings,
            AttendanceAndDeparture,
            SalaryReports
        }

        // Default User's Data SupperAdmin
        public const string Email = "SuperAdmin@HR.com";
        public const string UserName = "SuperAdmin@HR.com";
        public const string Name = "SuperAdmin";
        public const string Password = "SuperAdmin@P755ssw0rd";

        // Default User's Data Basic
        public const string EmailAdmin = "Admin@HR.com";
        public const string UserNameAdmin = "Admin@HR.com";
        public const string NameAdmin = "Admin";
        public const string PasswordAdmin = "Admin@P755ssw0rd";

        // Default User's Data Basic 
        public const string EmailBasic = "basic@HR.com";
        public const string UserNameBasic = "basic@HR.com";
        public const string NameBasic = "basic";
        public const string PasswordBasic = "basic@P755ssw0rd";


        // Permission variable
        public const string Permission = "Permission";

    }
}
