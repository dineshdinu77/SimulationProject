
using ClaimAuthService.Models;
using ClaimAuthService.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ClaimAuthServiceTest
{
    public class Tests
    {
        List<Claim> claim = new List<Claim>();
        IQueryable<Claim> claimdata;
        Mock<DbSet<Claim>> mockSet;
        Mock<ClaimAuthDbContext> claimAuthContextMock;
        [SetUp]
        public void Setup()
        {
            claim = new List<Claim>()
            {
                new Claim{Id = 1, Name="Dinesh", Policy="a12",Claim_amount=10000,Hospital_name="aditya",ContactNo="7032704028"},
                new Claim{Id = 2, Name="rohith", Policy="a123",Claim_amount=15000,Hospital_name="aditya",ContactNo="7032704029"},


            };
            claimdata = claim.AsQueryable();
            mockSet = new Mock<DbSet<Claim>>();
            mockSet.As<IQueryable<Claim>>().Setup(m => m.Provider).Returns(claimdata.Provider);
            mockSet.As<IQueryable<Claim>>().Setup(m => m.Expression).Returns(claimdata.Expression);
            mockSet.As<IQueryable<Claim>>().Setup(m => m.ElementType).Returns(claimdata.ElementType);
            mockSet.As<IQueryable<Claim>>().Setup(m => m.GetEnumerator()).Returns(claimdata.GetEnumerator());
            var c = new DbContextOptions<ClaimAuthDbContext>();
            claimAuthContextMock = new Mock<ClaimAuthDbContext>(c);
            claimAuthContextMock.Setup(x => x.Claims).Returns(mockSet.Object);
        }


        [Test] 
        public void GetByIdTest()
        {
            var claimAuthRepo = new ClaimAuthRepo(claimAuthContextMock.Object);
            var claimAuthObj = claimAuthRepo.BillingAmount(2);
            Assert.IsNotNull(claimAuthObj);
        }
        [Test]
        public void GetByIdTestFail()
        {
            var claimAuthRepo = new ClaimAuthRepo(claimAuthContextMock.Object);
            var claimAuthObj = claimAuthRepo.BillingAmount(90);
            Assert.AreEqual(claimAuthObj,0);
        }
    }
}