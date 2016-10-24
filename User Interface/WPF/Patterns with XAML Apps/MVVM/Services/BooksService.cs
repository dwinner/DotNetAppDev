﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Models;

namespace Services
{
   public class BooksService : IBooksService
   {
      private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();
      private readonly IBooksRepository _booksRepository;

      public BooksService(IBooksRepository repository)
      {
         _booksRepository = repository;
      }

      public async Task LoadBooksAsync()
      {
         if (_books.Count > 0) return;

         var books = await _booksRepository.GetItemsAsync();
         _books.Clear();
         foreach (var b in books)
         {
            _books.Add(b);
         }
      }

      public Book GetBook(int bookId) =>
         _books.Where(b => b.BookId == bookId).SingleOrDefault();

      public async Task<Book> AddOrUpdateBookAsync(Book book)
      {
         Book updated = null;
         if (book.BookId == 0)
         {
            updated = await _booksRepository.AddAsync(book);
            _books.Add(updated);
         }
         else
         {
            updated = await _booksRepository.UpdateAsync(book);
            var old = _books.Where(b => b.BookId == updated.BookId).Single();
            var ix = _books.IndexOf(old);
            _books.RemoveAt(ix);
            _books.Insert(ix, updated);
         }

         return updated;
      }

      IEnumerable<Book> IBooksService.Books => _books;
   }
}