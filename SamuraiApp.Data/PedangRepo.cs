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
    public class PedangRepo : IPedang
    {
        private readonly SamuraiContext _context;
        public PedangRepo(SamuraiContext context)
        {
            _context = context;
        }


        public async Task Delete(int id)
        {
            try
            {
                var deletePedang = await GetById(id);
                _context.Pedangs.Remove(deletePedang);
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

        public async Task<IEnumerable<Pedang>> GetAll()
        {
            var results = await _context.Pedangs.OrderBy(s => s.Nama).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Pedang> GetById(int id)
        {
            var results = await _context.Pedangs.FirstOrDefaultAsync(s => s.Id == id);
            if (results == null) throw new Exception($"Data Pedang Id: {id} tidak ditemukan");
            return results;
        }

        public async Task<Pedang> Insert(Pedang obj)
        {
            try
            {
                _context.Pedangs.Add(obj);
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

        public async Task<Pedang> InsertPedangWithElement(Pedang obj)
        {
            try
            {
                foreach (var element in obj.Elements)
                {
                    element.PedangId = obj.Id;
                }
                _context.Pedangs.Add(obj);
                _context.Elements.AddRange(obj.Elements);
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

        public async Task<Pedang> Update(int id, Pedang obj)
        {
            try
            {
                var updatePedang = await GetById(id);
                updatePedang.Nama = obj.Nama;
                updatePedang.TahunPembuatan = obj.TahunPembuatan;
                updatePedang.Berat = obj.Berat;
                await _context.SaveChangesAsync();
                return updatePedang;
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
