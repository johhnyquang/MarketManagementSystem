using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Enums
{
    public enum PurchaseStatus
    {
        Created = 1, // Vừa mới khởi tạo
        Confirmed = 2, // Nhà cung cấp đã xác nhận đơn hàng mình đặt
        Processing = 3, // Trong quá trình giao hàng (sẽ có thể giao nhiều đợt)
        Completed = 4, // Nhà cung cấp hoàn tất giao hàng
    }
}
