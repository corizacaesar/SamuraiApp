using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    [TestClass]
    public class InMemoryTest
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabaseInMemory()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertSamurai");
            using (var context = new SamuraiContext(builder.Options))
            {
                var samurai = new Samurai();
                context.Samurais.Add(samurai);
                //Assert.AreNotEqual(0, samurai.Id);
                Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
            }
        }
    }
}
