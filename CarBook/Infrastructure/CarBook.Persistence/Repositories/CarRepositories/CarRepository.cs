using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarWithBrand()
        {
            var values = _context.Cars.Include(c => c.Brand).ToList();
            return values;
        }

        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(c => c.Brand).OrderByDescending(c => c.CarID).Take(5).ToList();
            return values;
        }
    }
}
