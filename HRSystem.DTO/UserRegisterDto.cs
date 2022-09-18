using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.DTO
{
    public class UserRegisterDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you must enter Name")]
        public string Username { get; set; }


        [Required(ErrorMessage = "you must enter  address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "you must enter email")]
        [EmailAddress(ErrorMessage = "You must enter a correct email.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "you must enter mobile phone")]
        [RegularExpression(@"^01[0125][0-9]{8}$",
            ErrorMessage = "Phone number must meet requirements")]
        public string Mobile { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public byte Type { get; set; }

        public int? ManagerId { get; set; }


        [Required(ErrorMessage = "you must enter the password")]
        public string Password { get; set; }

    }
}