using MarketManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    /*
     * Bảng này sẽ là bảng trung gian cho việc thực hiện các giao dịch
     */
    public class DocumentHeaderEntity : BaseEntity
    {
        public string DocumentNo { get; set; } = string.Empty; // Các loại chứng từ PO / SO / TO
        public DocumentStatus DocumentStatus { get; set; } = DocumentStatus.Draft;
        public int DocumentTypeId { get; set; } // khóa ngoại tới MovementType để thể hiện loại giao dịch nào
        public int DocumentFrom { get; set; } // Từ ai ví dụ Supplier không cần khóa ngoại tới check trong logic code
        public int DocumentTo { get; set; } // Đến ai ví dụ Warehouse không cần khóa ngoại tới check trong logic code
        public int UserId { get; set; } // Nếu như PO hoặc Transfer được Manager văn phòng Assign thì sẽ insert vào đây tương ứng với user đã yêu cầu assign 
        public bool IsAssign { get; set; } = false;

        // Đối với lệnh transfer thì sẽ thực hiện trong bảng này luôn với 2 cột này UserId và IsAssign gioosg như PO

        // Navigation Properties
        public MovementTypeEntity? MovementType { get; set; }
        public ICollection<DocumentDetailEntity> DocumentDetailEntities { get; set; } = new List<DocumentDetailEntity>();
    }
}
