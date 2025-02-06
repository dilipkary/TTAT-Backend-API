using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTATAutomation.Data.Dto;
using TTATAutomation.Models;

namespace TTATAutomation.Services.Interfaces
{
    public interface IWeighmentService
    {
        Task<Weighment?> GetWeighmentByWIdAsync(Guid WId);
        Task<Weighment?> GetWeighmentByVIDAsync(Guid VId);
        Task<IEnumerable<Weighment>> GetAllWeighmentsAsync();
        Task<bool> RecordFirstWeighmentAsync(Weighment wt);
        Task<bool> RecordSecondWeighmentAsync(Weighment wt);
        Task<bool> DeleteWeighmentAsync(Guid WId);
        Task<bool> UpdateWeighmentAsync(Weighment weighment);
        Task<Weighment?> GetWeighmentActiveByVidAsync(Guid Vid);
        Task<string> ApproveWeighmentAsync(Weighment wt);
        Task<bool> AddWeighment(Weighment w);
    }
}