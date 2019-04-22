using apiOnlineBookStoreProject.Controllers;
using apiOnlineBookStoreProject.Models;

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace apiOnlineBookTesting
{
    public class BookTestController
    {
        private OnlineBookStoreAPIDbContext context;

        public static DbContextOptions<OnlineBookStoreAPIDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-512;Initial Catalog=OnlineBookStoreAPIDbContext;Integrated Security=true;";

        static BookTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<OnlineBookStoreAPIDbContext>().UseSqlServer(connectionString).Options;
        }
        public BookTestController()
        {
            context = new OnlineBookStoreAPIDbContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetBookById_Return_OkResult()
        {
            var controller = new BookController(context);
            var BookId = 2;
            var data = await controller.Get(BookId);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetBook_ById_Return_NotFound()
        {
            var controller = new BookController(context);
            var BookId = 6;
            var data = await controller.Get(BookId);
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetBook_ById_Return_MatchedData()
        {

            //Arrange
            var controller = new BookController(context);
            var BookId = 1;

            //Act

            var data = await controller.Get(BookId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
            //var okResult = data.Should().BeOfType<NotFoundResult>().Subject;
            //var bk = okResult.Value.Should().BeAssignableTo<Book>().Subject;
            //Assert.Equal("Fiction", bk.BookName);
           
        }
        [Fact]
        public async void TaskGetBook_ById_Return_BadRequestResult()
        {

            //Arrange
            var controller = new BookController(context);
            int? id = null;


            //Act

            var data = await controller.Get(id);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Add_Book_Return_OkResult()
        {

            //Arrange
            var controller = new BookController(context);
            var bk = new Book()
            {
                BookName = "English",
                BookPrice = 500,
                BookType = "e-book",
                BookImage = "123",              
                AuthorId = 2,
                PublicationId = 1,
                BookCategoryId = 3
            };

            //Act

            var data = await controller.Post(bk);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);

        }

        [Fact]
        public async void Task_Add_Book_Return_BadRequest()
        {

            //Arrange
            var controller = new BookController(context);
            var bk = new Book()
            {
                BookName = "MathsMathsMathsMathsMathsMaths",
               BookPrice = 500,
               BookType = "e-book",
               BookImage = "image",
               AuthorId = 2,
               PublicationId = 1,
               BookCategoryId = 3
            };

            //Act

            var data = await controller.Post(bk);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);

        }

        [Fact]
        public async void Task_Delete_Book_Return_OkResult()
        {
            //Arrange
            var controller = new BookController(context);
            var id = 10;
            //Act
            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundResult>(data);

        }
        [Fact]
        public async void Task_Delete_Book_Return_BadRequest()
        {
            //Arrange
            var controller = new BookController(context);
            int? id = null;
            //Act
            var data = await controller.Get(id);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }
        [Fact]
        public async void Task_Update_Book_Return_OkResult()
        {

            //Arrange
            var controller = new BookController(context);
            var BookId = 11;

            //Assert
            var editBook = new Book()
            {
                BookId = 14,
                BookName = "Baba",
               BookPrice = 500,
               BookType = "e-book",
               BookImage = "image",
               AuthorId =2 ,
               PublicationId = 1,
               BookCategoryId = 3
            };
            var updateData = await controller.Put(BookId, editBook);

            Assert.IsType<NotFoundResult>(updateData);
        }


    }
}
