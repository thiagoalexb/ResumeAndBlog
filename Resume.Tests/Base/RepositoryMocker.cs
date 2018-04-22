using Microsoft.EntityFrameworkCore;
using Moq;
using Resume.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Resume.Tests.Base
{
    public class RepositoryMocker<T> where T : class
    {

        public IList<T> Db_mock { get; set; } = new List<T>();
        public IRepository<T> R_mock { get; private set; }

        public RepositoryMocker()
        {
            this.R_mock = GenerateServiceMock();
        }

        public RepositoryMocker(IList<T> db)
        {
            this.Db_mock = db;
            this.R_mock = GenerateServiceMock();
        }

        private IRepository<T> GenerateServiceMock()
        {
            var reportRepositoryMock = new Mock<IRepository<T>>();

            reportRepositoryMock
                .Setup(m => m.GetAllAsync())
                .Returns(() => Task.FromResult(Db_mock.ToList()));

            reportRepositoryMock
                .Setup(m => m.GetAllQueryable())
                .Returns(() => Db_mock.AsQueryable());
            
            reportRepositoryMock
                .Setup(m => m.GetAllQueryableByCriteria(It.IsAny<Expression<Func<T, bool>>>()))
                .Returns<Expression<Func<T, bool>>>((fitler) => Db_mock.AsQueryable().Where(fitler));

            reportRepositoryMock
                .Setup(m => m.GetAllByCriteriaAsync(It.IsAny<Expression<Func<T, bool>>>()))
                .Returns<Expression<Func<T, bool>>>((fitler) => Task.FromResult(this.Db_mock.AsQueryable().Where(fitler).ToList()));

            reportRepositoryMock
                .Setup(m => m.GetByCriteriaAsync(It.IsAny<Expression<Func<T, bool>>>()))
                .Returns<Expression<Func<T, bool>>>(async (fitler) => await Db_mock.AsQueryable().Where(fitler).FirstOrDefaultAsync());

            reportRepositoryMock
                .Setup(m => m.AddAsync(It.IsAny<T>()))
                .Returns<T>(async (entity) => await Task.Run(() => Db_mock.Add(entity)));

            reportRepositoryMock
                .Setup(m => m.Delete(It.IsAny<T>()))
                .Callback<T>((entity) => Db_mock.Remove(entity));

            return reportRepositoryMock.Object;
        }
    }
}
