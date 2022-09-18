using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRSystem.Model
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }
       
        public string Employee_Name { get; set; }
        public string Employee_Address { get; set; }
        public string Employee_EmailAddress { get; set; }
        public string Employee_Mobile { get; set; }
        public DateTime Employee_BithDate { get; set; }
        public byte Employee_type { get; set; }

        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; }
        public int? ManagerId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
