using System;

namespace AbsensiApp_Api.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FullName { get; set; }
        public string DepartmentSection { get; set; }
    }
    public class UserAttendance
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string UserLocation { get; set; }
        public DateTime AttendanceDate { get; set; }
    }


}