using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface;

 public interface IInventoryService
    {
        public Task<int> Create(Inventory entity);
        public Task Update(Inventory entity);
        public Inventory Get(int id);
        public void Delete(int id);
        public List<Inventory> List(); 


    }
