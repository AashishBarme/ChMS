namespace ChMS.Core.Application.Groups
{
    public interface IGroupRepository
    {
        public Task<int> Create(Group entity);
        public Task Update(Group entity);
        public void Delete(int id);
        public List<Group> List();
        public Group Get(int id);
    }
}