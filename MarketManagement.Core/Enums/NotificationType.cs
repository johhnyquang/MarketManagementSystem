using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Enums
{
    public enum NotificationType
    {
        NewMessage = 1,
        OrderStatusChanged = 2,
        InventoryAlert = 3,
        ShippingUpdate = 4
    }
}
