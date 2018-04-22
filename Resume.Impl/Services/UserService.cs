using System.Threading.Tasks;
using Resume.Core.Services;
using Resume.Core.UnitOfWork;
using Resume.Data.Entities;
using Resume.Impl.Services.Base;

namespace Resume.Impl.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
