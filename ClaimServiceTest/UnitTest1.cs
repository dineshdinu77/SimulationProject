using ClaimService.Models;
using ClaimService.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ClaimServiceTest
{
    public class Tests
    {
        List<Claim> claim = new List<Claim>();
        IQueryable<Claim> claimdata;
        Mock<DbSet<Claim>> mockSet;
        Mock<ClaimDbContext> claimcontextmock;
        [SetUp]
        public void Setup()
        {
            claim = new List<Claim>()
            {
                new Claim{Id = 1, Name="Dinesh", Policy="a12",Claim_amount=10000,Hospital_name="aditya",ContactNo="7032704028"},
                new Claim{Id = 2, Name="rohith", Policy="a123",Claim_amount=15000,Hospital_name="aditya",ContactNo="7032704029"},
                new Claim{Id = 3, Name="sujana", Policy="a124",Claim_amount=15400,Hospital_name="surya",ContactNo="7032704018"},
                new Claim{Id = 4, Name="sandeep", Policy="a125",Claim_amount=500000,Hospital_name="vijay",ContactNo="9032704028"},

            };
            claimdata = claim.AsQueryable();
            mockSet = new Mock<DbSet<Claim>>();
            mockSet.As<IQueryable<Claim>>().Setup(m => m.Provider).Returns(claimdata.Provider);
            mockSet.As<IQueryable<Claim>>().Setup(m => m.Expression).Returns(claimdata.Expression);
            mockSet.As<IQueryable<Claim>>().Setup(m => m.ElementType).Returns(claimdata.ElementType);
            mockSet.As<IQueryable<Claim>>().Setup(m => m.GetEnumerator()).Returns(claimdata.GetEnumerator());
            var c = new DbContextOptions<ClaimDbContext>();
            claimcontextmock = new Mock<ClaimDbContext>(c);
            claimcontextmock.Setup(x => x.Claims).Returns(mockSet.Object);
        }

        
        [Test]
        public void GetAllTest()
        {
            var claimrepo = new ClaimRepo(claimcontextmock.Object);
            var claimlist = claimrepo.GetAll();
            Assert.AreEqual(4, claimlist.Count());




        }
       

        [Test]
        public void AddClaimDetailTest()
        {
            var claimrepo = new ClaimRepo(claimcontextmock.Object);
            var claimobj = claimrepo.ClaimUpload(new Claim { Id =5, Name = "sandy", Policy = "a128", Claim_amount = 550000, Hospital_name = "vijayDurga", ContactNo = "9052704028" });
            Assert.IsNotNull(claimobj);
        }

    }
}