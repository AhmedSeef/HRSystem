using System;
using System.Collections.Generic;
using System.Text;

namespace HRSystem.DTO
{
    public class UserDataBrowseDto
    {
        public int  userID { get; set; }
        public byte userType { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
