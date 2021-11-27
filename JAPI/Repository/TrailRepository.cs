using JAPI.Data;
using JAPI.Models;
using JAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _db;
        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateTrail(Trail trail)
        {
            _db.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _db.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int naionalParkId)
        {
            return _db.Trails.Include(c => c.NationalPark).Where(a => a.Id == naionalParkId).FirstOrDefault(a => a.Id == naionalParkId);
        }

        public ICollection<Trail> GetTrails()
        {
            return _db.Trails.OrderBy(a => a.Name).ToList();
        }

        public bool TrailExists(string name)
        {
            return _db.Trails.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool TrailExists(int id)
        {
            return _db.Trails.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Trails.Update(trail);
            return Save();
        }

        public ICollection<Trail> GetTrailsInNationalPark(int npId)
        {
           return _db.Trails.Include(c=>c.NationalPark).Where(a => a.Id == npId).ToList();  
        }
    }
}
