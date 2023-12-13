﻿using DataAccess.DataAccess;
using DataAccess.Model;
using DataAccess.Repository.Implement.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Implement {
    public class BookRepository : Generic<Book>, IBookRepository {
        public BookRepository(PRN_BookStoreContext context) : base(context) {
        }


        public Task<List<Book>> GetBookList(GetBooksDto getBooksDto) {
            var query = _context.Books.AsQueryable();

            query = query.Include(x => x.Category);

            if (!string.IsNullOrEmpty(getBooksDto.Title)) {
                query = query.Where(book => book.Title.Contains(getBooksDto.Title));
            }

            if (!string.IsNullOrEmpty(getBooksDto.Category)) {
                query = query.Where(book => book.Category.Name.Contains(getBooksDto.Category));
            }

            if (getBooksDto.Sort is { Field: not null, Direction: not null }) {
                string sortField = getBooksDto.Sort.Field;
                string sortDirection = getBooksDto.Sort.Direction;

                switch (sortField) {
                    case SortField.Title:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Title)
                            : query.OrderByDescending(book => book.Title);
                        break;
                    case SortField.Category:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Category.Name)
                            : query.OrderByDescending(book => book.Category.Name);
                        break;
                    case SortField.Price:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Price)
                            : query.OrderByDescending(book => book.Price);
                        break;
                    case SortField.Status:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.Status)
                            : query.OrderByDescending(book => book.Status);
                        break;
                    case SortField.Stock:
                        query = sortDirection == SortDirection.Asc
                            ? query.OrderBy(book => book.StockQuantity)
                            : query.OrderByDescending(book => book.StockQuantity);
                        break;
                }
            }

            int currentPage = getBooksDto.CurrentPage <= 0 ? 1 : getBooksDto.CurrentPage;
            int pageSize = getBooksDto.PageSize <= 0 ? 10 : getBooksDto.PageSize;
            query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);

            var result = query.ToListAsync();

            return result;
        }

        public Task<int> GetBookCount(GetBooksDto getBooksDto) {

            var query = _context.Books.AsQueryable();
            
            query = query.Include(x => x.Category);

            if (!string.IsNullOrEmpty(getBooksDto.Title)) {
                query = query.Where(book => book.Title.Contains(getBooksDto.Title));
            }

            if (!string.IsNullOrEmpty(getBooksDto.Category)) {
                query = query.Where(book => book.Category.Name.Contains(getBooksDto.Category));
            }

            var result = query.CountAsync();

            return result;
        }
    }
}