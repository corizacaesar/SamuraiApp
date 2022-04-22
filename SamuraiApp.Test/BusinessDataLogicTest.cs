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
    public class BusinessDataLogicTest
    {
        [TestMethod]
        public void CanAddSamuraiByName()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanAddSamuraiByName");

            using (var context = new SamuraiContext(builder.Options))
            {
                var bs = new BusinessDataLogic(context);
                int expected = 3;
                var namelist = new string[] { "Satu", "Dua", "Tiga" };
                var result = bs.AddSamuraiByName(namelist);
                Assert.AreEqual(expected, result);
            }
        }


        [TestMethod]
        public void CanInsertSingleSamurai()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertSingleSamurai");

            using (var context = new SamuraiContext(builder.Options))
            {
                int expected = 1;
                var bs = new BusinessDataLogic(context);
                bs.InsertNewSamurai(new Samurai { Name = "Joko San" });
                Assert.AreEqual(expected, context.Samurais.Count());
            }
        }

        [TestMethod]
        public void CanInsertSamuraiWithQuotes()
        {
            var expected = 2;
            var newSamurai = new Samurai
            {
                Name = "Basuki",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "Quote 1"},
                    new Quote { Text = "Quote 2"}
                }
            };
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("SamuraiWithQuotes");

            using (var context = new SamuraiContext(builder.Options))
            {
                var bs = new BusinessDataLogic(context);
                var result = bs.InsertNewSamurai(newSamurai);
            }

            using (var context2 = new SamuraiContext(builder.Options))
            {
                var samuraiWithQuotes = context2.Samurais.Include(s => s.Quotes).FirstOrDefault();
                Assert.AreEqual(expected, samuraiWithQuotes.Quotes.Count);
            }
        }

        [TestMethod]
        public void CanGetSamuraiWithQuotes()
        {
            var expected = 3;
            int samuraiId;
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("SamuraiGetQuotes");

            using (var context = new SamuraiContext(builder.Options))
            {
                var newSamurai = new Samurai
                {
                    Name = "Shihui",
                    Quotes = new List<Quote>
                    {
                        new Quote { Text = "Quote1"},
                        new Quote { Text = "Quote2"},
                        new Quote { Text = "Quote3"}
                    }
                };
                context.Samurais.Add(newSamurai);
                context.SaveChanges();
                samuraiId = newSamurai.Id;
            }

            using (var context2 = new SamuraiContext(builder.Options))
            {
                var bs = new BusinessDataLogic(context2);
                var result = bs.GetSamuraiWithQuotes(samuraiId);
                Assert.AreEqual(expected, result.Quotes.Count);
            }
        }
    }
}
