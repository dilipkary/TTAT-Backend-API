using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTATAutomation.Data.Dto;
using TTATAutomation.Models;

namespace TTATAutomation.Repositories.Interfaces
{
    public interface IWeighmentRepository : IRepository<Weighment>
    {
        //Task<Weighment> GetWeighmentByRFIDAsync(Guid RFID);
        Task<Weighment?> GetWeighmentByVIDAsync(Guid VId);
        Task<Weighment?> GetWeighmentActiveByVidAsync(Guid Vid);
        Task<IEnumerable<Weighment>> GetAllWeighmentsAsync();
        // Task<bool> RecordFirstWeighmentAsync(Weighment transaction);
        Task<bool> RecordSecondWeighmentAsync(Weighment wt);
        Task<bool> DeleteWeighmentAsync(Guid VId);

    }
}