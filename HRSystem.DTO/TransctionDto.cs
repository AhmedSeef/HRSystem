using System;

namespace HRSystem.DTO
{
    public class TransctionDto
    {
        public string SignInDate { get; set; }
        public string SignInTime  { get; set; }
        public string SignOutTime  { get; set; }
        public TimeSpan WorkingHours  { get; set; }
        public string Status  { get; set; }
        public int LoginUserId { get; set; }
    }
}