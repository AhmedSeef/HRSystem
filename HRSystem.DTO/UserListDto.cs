using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRSystem.DTO
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string BirthDate { get; set; }
        public int? ManagerId { get; set; }
        public int typeId { get; set; }
        public string Manager { get; set; }

    }
}
