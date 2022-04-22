using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiRepo : ISamurai
    {
        private readonly SamuraiContext _context;
        public SamuraiRepo(SamuraiContext context)
        {
            _context = context;
        }


        public async Task Delete(int id)
        {
            try
            {
                var deleteSamurai = await GetById(id);
                _context.Samurais.Remove(deleteSamurai);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Samurai> GetById(int id)
        {
            var results = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (results == null) throw new Exception($"Data Samurai Id: {id} tidak ditemukan");
            return results;
        }

        public async Task<Samurai> GetSamuraiWithPedangElement(int id)
        {
            var result = await _context.Samurais.Where(s => s.Id == id)
                .Include(j => j.Pedangs)
                .ThenInclude(i => i.Elements)
                .FirstOrDefaultAsync();
            if (result == null) throw new Exception($"Data {id} Tidak Ditemukan");
            return result;
        }

        public async Task<Samurai> GetSamuraiWithPedang(int id)
        {
            var result = await _context.Samurais.Include(a => a.Pedangs)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data {id} Tidak Ditemukan");
            return result;
        }



        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Samurai> InsertSamuraiWithPedang(Samurai obj)
        {
            try
            {
                foreach (var sword in obj.Pedangs)
                {
                    sword.SamuraiId = obj.Id;
                }
                _context.Samurais.Add(obj);
                _context.Pedangs.AddRange(obj.Pedangs);
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (DbUpdateConcurrencyException edbx)
            {
                throw new Exception(edbx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Samurai> Update(int id, Samurai obj)
        {
            try
            {
                var updateSamurai = await GetById(id);
                updateSamurai.Name = obj.Name;
                await _context.SaveChangesAsync();
                return updateSamurai;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
