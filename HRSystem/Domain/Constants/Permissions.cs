using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Helper;

namespace Domain.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionFromModule(string module)
        {
            return new List<string>
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }

        public static List<string> PermissionsList()
        {
            var allPermissions = new List<string>();

            foreach (var module in Enum.GetValues(typeof(PermissionModuleName)))
                allPermissions.AddRange(GeneratePermissionFromModule(module.ToString()));
            return allPermissions;

        }
       
        public static class Account
        {
            public const string View = "Permissions.Account.View";
            public const string Create = "Permissions.Account.Create";
            public const string Edit = "Permissions.Account.Edit";
            public const string Delete = "Permissions.Account.Delete";
        }
      public static class Employees
        {
            public const string View = "Permissions.Employees.View";
            public const string Create = "Permissions.Employees.Create";
            public const string Edit = "Permissions.Employees.Edit";
            public const string Delete = "Permissions.Employees.Delete";
        }
      public static class GeneralSettings
        {
            public const string View = "Permissions.GeneralSettings.View";
            public const string Create = "Permissions.GeneralSettings.Create";
            public const string Edit = "Permissions.GeneralSettings.Edit";
            public const string Delete = "Permissions.GeneralSettings.Delete";
        }
      public static class AttendanceAndDeparture
        {
            public const string View = "Permissions.AttendanceAndDeparture.View";
            public const string Create = "Permissions.AttendanceAndDeparture.Create";
            public const string Edit = "Permissions.AttendanceAndDeparture.Edit";
            public const string Delete = "Permissions.AttendanceAndDeparture.Delete";
        }
      public static class SalaryReports
        {
            public const string View = "Permissions.SalaryReports.View";
            public const string Create = "Permissions.SalaryReports.Create";
            public const string Edit = "Permissions.SalaryReports.Edit";
            public const string Delete = "Permissions.SalaryReports.Delete";
        }
      
    }
}
