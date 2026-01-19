using MarketManagement.Core.DataContext;
using MarketManagement.Core.Enums;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.DocumentRepository
{
    public class DocumentRepository(AppDbContext appDbContext) : RepositoryBase<DocumentHeaderEntity>(appDbContext), IDocumentRepository
    {
        public async Task<bool> ExistByDocumentAsync(string documentNo)
        {
            return await AnyAsync(doc => doc.DocumentNo.Equals(documentNo));
        }

        public async Task<DocumentHeaderEntity?> GetDocumentDetailAsync(string documentNo)
        {
            return await GetWithIncludeAsync
                (doc => doc.DocumentNo.Equals(documentNo), doc1 => doc1.MovementType!, doc2 => doc2.DocumentDetailEntities);
        }

        public async Task<IEnumerable<DocumentHeaderEntity>> GetDocumentsWithMovementType(int movementTypeId)
        {
            return await FindAsync(doc => doc.DocumentTypeId == movementTypeId);
        }

        public async Task<IEnumerable<DocumentHeaderEntity>> GetDocumentWithStatusAsync(DocumentStatus status)
        {
            return await FindAsync(doc => doc.DocumentStatus == status);
        }

        // Lấy các phiếu chuyển kho đang trên đường tới kho của mình hoặc là nếu như với đơn PO thì có thể hiểu là 2 trạng thái này đang cập nhật xong xong với nhau
        public async Task<IEnumerable<DocumentHeaderEntity>> GetIncomingTransfersAsync(int warehouseFrom)
        {
            return await FindAsync(doc => doc.DocumentFrom == warehouseFrom);
        }

        public async Task<IEnumerable<DocumentHeaderEntity>> GetOutgoingTransfersAsync(int warehouseTo)
        {
            return await FindAsync(doc => doc.DocumentTo == warehouseTo);
        }
    }
}
