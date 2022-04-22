// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;


//SamuraiContext _context = new SamuraiContext();
//_context.Database.EnsureCreated();
//AddSamurai("Samurai 1", "Samurai 2");
//AddVariousTypes();
//QueryFilters();
//QueryAggregates();
//RetrieveAndUpdateSamurai();
//RetrieveAndUpdateSamuraiS();
//MultipleDatabaseOperations();
//RetrieveAndDeleteSamurai();
//QueryAndUpdateBattles_Disconnect();
//InsertNewSamuraiWithQuote();
//AddQuoteToExistingSamurai();
//AddQuoteToExistingSamuraiNoTracking(2);
//SimpleAddQuoteToExistingSamuraiNoTracking(4);
//EagerLoadSamuraiWithQuote();
//ProjectingSample();
//ExplicitLoadQuotes();
//FilteringWithRelatedData();
//ModifyRelatedData();
//ModifyRelatedDataNoTracking();
//AddNewSamuraiToBattle();
//BattleWithSamurai();
//AddAllSamuraiToAllBattle();
//RemoveSamuraiFromBattle();
//RemoveSamuraiFromBattleExplicit();
//AddNewSamuraiWithHorse();
//AddNewHorseToSamurai();
//AddNewHorseNoTracking();
//GetSamuraiWithHorse();
//QueryViewBattleStat();
//QueryUsingRawSql();
//QueryUsingSPRaw();

//AddSamuraiByName ("Coriza", "Caesar", "Chakti");

//GetSamurais();
//GetQuotes();
//GetBattles();
//Console.WriteLine("Press any key");
Console.ReadLine();

//void Save()
//{
//    _context.SaveChanges();
//}

//void AddSamurai(params string[] names)
//{
//    foreach (string name in names)
//    {
//        _context.Samurais.Add(new Samurai { Name = name });
//    }
//    Save();
//}

//void AddVariousTypes()
//{
//    _context.AddRange(
//        new Samurai { Name = "Kensin" },
//        new Samurai { Name = "Shisio" },
//        new Battle { Name = "Battle of Anegawa"}, 
//        new Battle { Name = "Battle of Nagashino"}
//        );
//    Save();
//}

//void GetSamurais()
//{
//    var samurais = _context.Samurais.TagWith("Get Samurai Meethod").ToList();
//    Console.WriteLine($"Jumlah samurai adalah {samurais.Count}");
//    foreach (var samurai in samurais)
//    {
//        Console.WriteLine($"{samurai.Id} - {samurai.Name}");
//    }
//}

//void GetQuotes()
//{
//    var quotes = _context.Quotes.TagWith("Get Quote Meethod").ToList();
//    Console.WriteLine($"Jumlah Quote adalah {quotes.Count}");
//    foreach (var quote in quotes)
//    {
//        Console.WriteLine($"{quote.Id} - {quote.Text}");
//    }
//}

//void GetBattles()
//{
//    var battles = _context.Battles.TagWith("Get Battle Meethod").ToList();
//    Console.WriteLine($"Jumlah Battle terjadi : {battles.Count}");
//    foreach (var battle in battles)
//    {
//        Console.WriteLine($"{battle.BattleId} - {battle.Name} (Start Date : {battle.StartDate}, End Date : {battle.EndDate}");
//    }
//}

//void QueryFilters()
//{
//    //var samurais = _context.Samurais.Where(s => s.Name == "Rengoku").ToList();
//    //var samurais = _context.Samurais.Where(s => s.Name.Contains("Tan")).ToList();
//    //var samurais = _context.Samurais.Where(s => s.Name.StartsWith("Tan")).OrderBy(s => s.Name).ToList();
//    var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "Ino%")).ToList();
//    foreach (var samurai in samurais)
//    {
//        Console.WriteLine(samurai.Name);
//    }
//}

//void QueryAggregates()
//{
//    var name = "Rengoku";
//    //var samurai = (from s in _context.Samurais where s.Name == name select s).FirstOrDefault();
//    var samurai = _context.Samurais.FirstOrDefault(s=>s.Name == name);
//    Console.WriteLine($"ID {samurai.Id} - Nama {samurai.Name}");
//}

//void QueryAggregatesGet(string name)
//{
//    //var samurai = (from s in _context.Samurais where s.Name == name select s).FirstOrDefault();
//    var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
//    Console.WriteLine($"ID {samurai.Id} - Nama {samurai.Name}");
//}

//void RetrieveAndUpdateSamurai()
//{
//    var samurai = _context.Samurais.SingleOrDefault(s => s.Id == 2);
//    samurai.Name = "Kyojiro Rengoku";
//    Save();
//    QueryAggregatesGet(samurai.Name);
//}

//void RetrieveAndUpdateSamuraiS()
//{
//    var samurai = _context.Samurais.Skip(0).Take(4).ToList();
//    samurai.ForEach(s => s.Name += " San");
//    Save();
//}

//void MultipleDatabaseOperations()
//{
//    var samurai = _context.Samurais.OrderBy(s => s.Id).LastOrDefault();
//    samurai.Name += " San";
//    _context.Samurais.Add(new Samurai { Name = "Gyomei Himejima" });
//    Save();
//}

//void RetrieveAndDeleteSamurai()
//{
//    GetSamurais();
//    var samurai = _context.Samurais.Find(6);
//    if (samurai != null)
//    {
//        _context.Samurais.Remove(samurai);
//    }

//        var samurais = _context.Samurais.Where(s => s.Name.StartsWith("Samurai")).ToList();
//    _context.Samurais.RemoveRange(samurais);
//    Save();
//}

//void QueryAndUpdateBattles_Disconnect()
//{
//    /*List<Battle> disconnectedBattles;
//    using (var context1 = new SamuraiContextNoTracking())
//    {
//        //disconnectedBattles = context1.Battles.AsNoTracking().ToList();
//        disconnectedBattles = context1.Battles.ToList();
//    }//context1 sudah di dispose
//    disconnectedBattles.ForEach(b =>
//    {
//        b.StartDate = new DateTime(1580, 11, 01);
//        b.EndDate = new DateTime(1585, 11, 01);
//    });

//    using (var context2 = new SamuraiContext())
//    {
//        context2.UpdateRange(disconnectedBattles);
//        context2.SaveChanges();
//    }*/
//}

//void InsertNewSamuraiWithQuote()
//{
//    var samurai = new Samurai
//    {
//        Name = "Musashi Miyamoto",
//        Quotes = new List<Quote>
//        {
//            new Quote{Text = "Think lightly of yoursef and deeply world"},
//            new Quote{Text = "Do nothing that is of no use"}
//        }
//    };
//    _context.Samurais.Add(samurai);
//    Save();
//}

//void AddQuoteToExistingSamurai()
//{
//    var samurai = _context.Samurais.Where(s => s.Id == 1).FirstOrDefault();
//    samurai.Quotes.Add(new Quote { 
//        Text = "Do not fear of death"
//    });
//    Save();
//}

//void AddQuoteToExistingSamuraiNoTracking(int samuraiID)
//{
//    var samurai = _context.Samurais.Find(samuraiID);
//    samurai.Quotes.Add(new Quote
//    {
//        Text = "Fearless"
//    });

//    using (var context1 = new SamuraiContext())
//    {
//        context1.Samurais.Attach(samurai);
//        context1.SaveChanges();
//    }
//}

//void SimpleAddQuoteToExistingSamuraiNoTracking(int samuraiID)
//{
//    var quote = new Quote { Text = "Never stray from the way", SamuraiId = samuraiID };
//    using (var contex1 = new SamuraiContext())
//    {
//        contex1.Quotes.Add(quote);
//        contex1.SaveChanges();
//    }
//}

//void EagerLoadSamuraiWithQuote()
//{
//    //var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
//    //var splitquery = _context.Samurais.AsSplitQuery().Include(s => s.Quotes).ToList();
//    //var filteredEntity = _context.Samurais.Include(s => s.Quotes.Where(q => q.Text.Contains("fear"))).ToList();
//    //var filteredEntityInclude = _context.Samurais.Where(s => s.Name.Contains("San")).Include(q => q.Quotes).ToList();

//    var filterSingle = _context.Samurais.Where(s => s.Id == 1).Include(q => q.Quotes).FirstOrDefault();
//}

//void ProjectingSample()
//{
//    //Anonymous Type
//    //var results = _context.Samurais.Select(s => new {s.Id, s.Name}).ToList();

//    //With Struct or Class
//    //var results = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();

//    //With Count
//    //var results = _context.Samurais.Select(s => new {s.Id, s.Name, NumOfQuote=s.Quotes.Count}).ToList();

//    var samuraiAndQuotes = _context.Samurais.Select(s => new { Samurai = s, 
//        BestQuote = s.Quotes.Where(q => q.Text.Contains("Fear")) }).ToList();
//}

//void ExplicitLoadQuotes()
//{
//    //Tanpa DbSet di DbContext
//    //_context.Set<Horse>().Add(new Horse { SamuraiId = 2, Name = "Kuda Hutan Liar" });
//    //Save();

//    var samurai = _context.Samurais.Find(1);
//    _context.Entry(samurai).Collection(s => s.Quotes).Load();
//}

//void FilteringWithRelatedData()
//{
//    var samurais = _context.Samurais.Where(s => s.Quotes.Any(q => q.Text.Contains("fear"))).ToList();
//}

//void ModifyRelatedData()
//{
//    var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 2);
//    samurai.Quotes[0].Text = "Hello World";
//    _context.Quotes.Remove(samurai.Quotes[1]);
//    Save();
//}

//void ModifyRelatedDataNoTracking()
//{
//    var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 2);
//    var quote = samurai.Quotes[0];
//    quote.Text = "Hello EF core 6.0";

//    using(var context1 = new SamuraiContext())
//    {
//        //context1.Quotes.Update(quote);
//        context1.Entry(quote).State = EntityState.Modified;
//        context1.SaveChanges();
//    }
//}

//void AddNewSamuraiToBattle()
//{
//    var battle = _context.Battles.FirstOrDefault();
//    battle.Samurais.Add(new Samurai { Name = "Nobunaga Oda" });
//    Save();
//}

//void BattleWithSamurai()
//{
//    //var battle = _context.Battles.Include(b => b.Samurais).FirstOrDefault(b => b.BattleId ==1);
//    var battles = _context.Battles.Include(b => b.Samurais).ToList();
//}

//void AddAllSamuraiToAllBattle()
//{
//    var allbattles = _context.Battles.ToList();
//    var allsamurais = _context.Samurais.ToList();
//    foreach (var battle in allbattles)
//    {
//        battle.Samurais.AddRange(allsamurais);
//    }
//    Save();
//}

//void RemoveSamuraiFromBattle()
//{
//    var battle = _context.Battles.Include(b => b.Samurais.Where(b => b.Id == 2)).SingleOrDefault(b => b.BattleId == 1);
//    var samurai = battle.Samurais.FirstOrDefault();
//    battle.Samurais.Remove(samurai);
//    Save();
//}

//void RemoveSamuraiFromBattleExplicit()
//{
//    var battlesamurai = _context.Set<BattleSamurai>().SingleOrDefault(bs => bs.BattleId == 1 && bs.SamuraiId == 3);
//    if (battlesamurai != null)
//    {
//        _context.Remove(battlesamurai);
//        Save();
//    }
//}

//void AddNewSamuraiWithHorse()
//{
//    var samurai = new Samurai { Name = "Kenshin Himura" };
//    samurai.Horse = new Horse { Name = "Kuda Lumping" };
//    _context.Samurais.Add(samurai);
//    Save();
//}

//void AddNewHorseToSamurai()
//{
//    var horse = new Horse { Name = "Lumping Horse", SamuraiId = 3 };
//    _context.Add(horse);
//    Save();
//}

//void AddNewHorseNoTracking()
//{
//    var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(s => s.Id == 3);
//    samurai.Horse = new Horse { Name = "Kuda Kudaan" };

//    using(var contex1 = new SamuraiContext())
//    {
//        contex1.Samurais.Attach(samurai);
//        Save();
//    }
//}

//void GetSamuraiWithHorse()
//{
//    var samurais = _context.Samurais.Include(s => s.Horse).ToList();
//    //var horseaja = _context.Set<Horse>().Find(2);
//}

//void QueryViewBattleStat()
//{
//    //select all
//    /*var result = _context.SamuraiBattleStats.ToList();
//    foreach(var stat in result)
//    {
//        Console.WriteLine($"{stat.Name} - {stat.NumberOfBattles} - {stat.EarliestBattle}");
//    }*/

//    //select 1
//    var stat = _context.SamuraiBattleStats.FirstOrDefault(s => s.Name == "Inosuke");
//        Console.WriteLine($"{stat.Name} - {stat.NumberOfBattles} - {stat.EarliestBattle}");
//}

//void QueryUsingRawSql()
//{
//    //var samurais = _context.Samurais.FromSqlRaw("SELECT * FROM Samurais").ToList();
//    var name = "Inosuke";
//    var samurais = _context.Samurais.FromSqlInterpolated($"SELECT * FROM Samurais where Samurais.Name = {name}").ToList();
//}

//void QueryUsingSPRaw()
//{
//    //SP Who Said A Word
//    //var text = "fear";
//    //var samurai = _context.Samurais.FromSqlRaw("exec dbo.SamuraisWhoSaidAWord {0}", text).ToList();
//    //var samurai = _context.Samurais.FromSqlInterpolated($"exec dbo.SamuraisWhoSaidAWord {text}").ToList();

//    //SP Delete Quote of Samurai
//    var samuraiID = 17;
//    _context.Database.ExecuteSqlInterpolated($"exec dbo.DeleteQuotesForSamurai {samuraiID}");
//    Console.WriteLine($"Quote sudah dihapus dari samurai dengan id {samuraiID}");
//}

//void AddSamuraiByName(params string[] names)
//{
//    var bs = new BusinessDataLogic();
//    var newSamuraisCreateCount = bs.AddSamuraiByName(names);
//}



//struct IdAndName
//{
//    public IdAndName(int id, string name)
//    {
//        Id = id;
//        Name = name;
//    }
//    public int Id;
//    public string Name;
//}