using NUnit.Framework;
using Resume.Core.UnitOfWork;
using Resume.Data.Entities;
using Resume.Tests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Test
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private IUnitOfWork unitOfWork;

        //fake repositories
        RepositoryMocker<User> userRepo = new RepositoryMocker<User>();

        

        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            

           // Assert.IsFalse(result, "1 should not be prime");
        }
    }
}
