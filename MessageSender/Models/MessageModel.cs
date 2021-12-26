using System.ComponentModel.DataAnnotations;

namespace MessageSender.Models
{
    public class MessageModel
    {
        [Required]
        public String? MobileNumber { get; set; }

        public string? MessageText { get; set; }
    }
}
