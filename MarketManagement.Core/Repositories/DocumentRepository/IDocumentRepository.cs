using MarketManagement.Core.Enums;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.DocumentRepository
{
    public interface IDocumentRepository : IRepositoryBase<DocumentHeaderEntity>
    {
        Task<bool> ExistByDocumentAsync(string documentNo);
        Task<DocumentHeaderEntity?> GetDocumentDetailAsync(string documentNo);
        Task<IEnumerable<DocumentHeaderEntity>> GetDocumentWithStatusAsync(DocumentStatus status);
        Task<IEnumerable<DocumentHeaderEntity>> GetIncomingTransfersAsync(int warehouseFrom);
        Task<IEnumerable<DocumentHeaderEntity>> GetOutgoingTransfersAsync(int warehouseTo);
        Task<IEnumerable<DocumentHeaderEntity>> GetDocumentsWithMovementType(int movementTypeId);
    }
}
