using Microsoft.EntityFrameworkCore;
using System;
using ProjectB.Models;
using ProjectB.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Services
{
    public class AboutService : IAboutService 
    {
        private IGenericRepository _repo;
        public AboutService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Quote> GetAllQuotes()
        {
            var data = _repo.Query<Quote>().ToList();
            return data;
        }

        public object GetQuoteById(int id)
        {
            var _quote = _repo.Query<Quote>().Where(q => q.Id == id).Select(q => new Quote
            {
                Id = q.Id,
                Statement = q.Statement,
                Author = q.Author
            }).FirstOrDefault();
            return _quote;
        }
        public void SaveQuote(Quote _quote)
        {
            if(_quote.Id == 0)
            {
                _repo.Add(_quote);
            }
            else
            {
                _repo.Update(_quote);
            }
        }

    }
}
