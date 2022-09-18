using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace HRSystem.Model
{
    [Table("Transaction")]
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateSignIn  { get; set; }
        public DateTime? DateSignOut  { get; set; }

        [ForeignKey("LoginUserId")]
        public virtual Employee Employee { get; set; }
        public int LoginUserId { get; set; }

    }
}