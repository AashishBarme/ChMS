using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface;

 public interface IInventoryService
    {
        public Task<Guid> Create(Inventory entity);
        public Task Update(Inventory entity);
        public Inventory Get(string id);
        public void Delete(string id);
        public List<Inventory> List(); 


    }
