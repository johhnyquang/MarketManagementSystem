using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    // Table này tương ứng với việc log lại các transaction trong hệ thống 
    // ví dụ: Nhập hàng khi nhà cung cấp giao, chuyển kho, bán hàng (SO), hàng trả lại
    // Để dễ dàng truy xuất
    public class DocumentTransactionEntity : BaseEntity
    {
        public string DocumentNo { get; set; } = string.Empty; // Số chứng từ (PO, SO, Transfer No...)
        public int ProductId { get; set; } 
        public int QuantityTransaction {  get; set; } // Số lượng sản phẩm được giao dịch trong transaction
        public int FromLocationId { get; set; } // bắt đầu từ giao dịch nào
        public int ToLocationId { get; set; }// Đến giao dịch  nào 

        // Ví dụ khi nhập hàng (PO) thì FromLocationId sẽ là Supplier -> ToLocationId sẽ là kho mà được chỉ định nhận hàng
        // Không cần khóa ngoại ở 2 cột FromLocationId và ToLocationId vì nó đang thể hiện ở mức ý niệm thôi không ràng buộc quá chặt

        public int MovementTypeId { get; set; } // Loại giao dịch nào 
        public int UserId { get; set; } // Ai là người thực hiện không cần khóa ngoại luôn vì không cần quản lý chặt chỗ này chỉ cần insert vào thôi vì 1 transaction chỉ thuộc 1 nhân viên giao dịch nhưng 1 nhân viên sẽ phải thực hiện nhiều transaction 
        public int UserAssignTransactionId { get; set; } // Nhân viên nào đã assign transaction này 

        // Navigation Properties
        public MovementTypeEntity? MovementType { get; set; }
    }
}
