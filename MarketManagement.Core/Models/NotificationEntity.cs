using MarketManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class NotificationEntity : BaseEntity
    {
        public int UserId { get; set; }
        public NotificationType NotificationType { get; set; } = NotificationType.NewMessage;
        public string Title { get; set; } = string.Empty;
        public string? Message { get; set; }
        public bool IsRead { get; set; } = false;
        public string? Data { get; set; } // Json Data

        public UserEntity? User { get; set; }
    }
}
