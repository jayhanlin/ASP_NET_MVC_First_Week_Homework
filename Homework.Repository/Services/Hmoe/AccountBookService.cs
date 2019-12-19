using Homework.Repository.Entities;

namespace Homework.Repository.Services
{
    public class AccountBookService : BaseService<AccountBook>
    {
        public AccountBookService() : base(new SkillTreeHomeworkEntities())
        {
        }
    }
}
