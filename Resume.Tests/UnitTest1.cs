using Moq;
using Resume.Core.UnitOfWork;
using Resume.Data.Entities;
using Resume.Impl.Services;
using Resume.Tests.Base;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Resume.Tests
{
    public class UnitTest1
    {
        private IUnitOfWork unitOfWork;

        //fake repositories
        RepositoryMocker<User> userRepo = new RepositoryMocker<User>();

        [Fact]
        public async Task Test1()
        {
            //var factory = new ResumeContextFactory();
            //var context = factory.CreateDbContext(null);
            //var uow = new UnitOfWork(context);
            //var service = new UserService(uow);
            //var user1 = new User(Guid.NewGuid(), $"Thiago {12}", $"Alex {12}", $"thiago{12}@hotmail.com", $"12345{12}", DateTime.Now);
            //user1.SetCreationDate();
            //var entity = await service.AddAsync(user1);

            //var all = await service.GetAllAsync();


            var unitOfWorkMock = new Mock<IUnitOfWork>();

            GetUsers();
            unitOfWorkMock.Setup(m => m.Repository<User>())
            .Returns(userRepo.R_mock);

            unitOfWork = unitOfWorkMock.Object;

            var user = new User(Guid.NewGuid(), $"Thiago {12}", $"Alex {12}", $"thiago{12}@hotmail.com", $"12345{12}", DateTime.Now);
            user.SetCreationDate();

            var userService = new UserService(unitOfWork);
            var hue = await userService.AddAsync(user);

            var users = await userRepo.R_mock.GetAllAsync();
        }

        private void GetUsers()
        {
            for (int i = 0; i < 10; i++)
            {
                var user = new User(Guid.NewGuid(), $"Thiago {i}", $"Alex {i}", $"thiago{i}@hotmail.com", $"12345{i}", DateTime.Now);
                user.SetCreationDate();
                userRepo.Db_mock.Add(user);
            }
            
        }
    }
}
