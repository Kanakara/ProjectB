using System.Collections.Generic;
using ProjectB.Models;

namespace ProjectB.Services
{
    public interface IAboutService
    {
        List<Quote> GetAllQuotes();
        object GetQuoteById(int id);
        void SaveQuote(Quote _quote);
    }
}