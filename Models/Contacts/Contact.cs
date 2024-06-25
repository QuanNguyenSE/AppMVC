using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Models.Contacts
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }
        [StringLength(100)]
        [Required]
        [Display(Name = "Đỉa chỉ email")]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateSent { get; set; }
        [Display(Name = "Nội dung")]
        public string Message { get; set; }
        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        [Phone]
        public string Phone { get; set; }
    }
}