using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BooksStoreDbContext _dbContext;
        public GetBooksQuery(BooksStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}