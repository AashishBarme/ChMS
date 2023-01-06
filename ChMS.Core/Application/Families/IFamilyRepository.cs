namespace ChMS.Core.Application.Families
{
    public interface IFamilyRepository
    {
        public Task<int> Create(Family entity);
        public Task Update(Family entity);
        public void Delete(int id);
        public List<Family> List();
        public Family Get(int id);

    }
}