using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
namespace dotnetapp.Tests
{
    [TestFixture]
    public class BookingControllerTests
    {
        private BookingController _BookingController;
        private ServiceBookingDbContext _context;

        [SetUp]
        public void Setup()
        {
            // Initialize an in-memory database for testing
            var options = new DbContextOptionsBuilder<ServiceBookingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ServiceBookingDbContext(options);
            _context.Database.EnsureCreated(); // Create the database

            // Seed the database with sample data
            _context.Bookings.AddRange(new List<Booking>
            {
new Booking { BookingID = 1,userId="101",userName="user1", Description="Description 1",SubmissionDate=DateTime.Parse("2023-02-10"),BookingStatus=0,ServiceType="Service1"},
new Booking { BookingID = 2,userId="102",userName="user2", Description="Description 2",SubmissionDate=DateTime.Parse("2023-04-30"),BookingStatus=0,ServiceType="Service2"},
new Booking { BookingID = 3,userId="101",userName="user3", Description="Description 3",SubmissionDate=DateTime.Parse("2023-07-20"),BookingStatus=0,ServiceType="Service3"}
            });
            _context.SaveChanges();

            _BookingController = new BookingController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // Delete the in-memory database after each test
            _context.Dispose();
        }
        [Test]
        public void BookingClassExists()
        {
            // Arrange
            Type BookingType = typeof(Booking);

            // Act & Assert
            Assert.IsNotNull(BookingType, "Booking class not found.");
        }
        [Test]
        public void Booking_Properties_userId_ReturnExpectedDataTypes()
        {
            // Arrange
            Booking Booking = new Booking();
            PropertyInfo propertyInfo = Booking.GetType().GetProperty("userId");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "userId property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "userId property type is not string.");
        }
[Test]
        public void Booking_Properties_userName_ReturnExpectedDataTypes()
        {
            // Arrange
            Booking Booking = new Booking();
            PropertyInfo propertyInfo = Booking.GetType().GetProperty("userName");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "userName property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "userName property type is not string.");
        }

        [Test]
        public async Task GetAllBookings_ReturnsOkResult()
        {
            // Act
            var result = await _BookingController.GetAllBookings();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAllBookings_ReturnsAllBookings()
        {
            // Act
            var result = await _BookingController.GetAllBookings();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf<IEnumerable<Booking>>(okResult.Value);
            var Bookings = okResult.Value as IEnumerable<Booking>;

            var BookingCount = Bookings.Count();
            Assert.AreEqual(3, BookingCount); // Assuming you have 3 Bookings in the seeded data
        }


        [Test]
        public async Task AddBooking_ValidData_ReturnsOkResult()
        {
            // Arrange
            var newBooking = new Booking
            {
userId="101",userName="user1", SubmissionDate=DateTime.Parse("2023-04-30"), Description="self@m.com",BookingStatus=0,ServiceType="Service new" };

            // Act
            var result = await _BookingController.AddBooking(newBooking);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
        [Test]
        public async Task DeleteBooking_ValidId_ReturnsNoContent()
        {
            // Arrange
              // var controller = new BookingsController(context);

                // Act
                var result = await _BookingController.DeleteBooking(1) as NoContentResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(204, result.StatusCode);
        }

        [Test]
        public async Task DeleteBooking_InvalidId_ReturnsBadRequest()
        {
                   // Act
                var result = await _BookingController.DeleteBooking(0) as BadRequestObjectResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(400, result.StatusCode);
                Assert.AreEqual("Not a valid Booking id", result.Value);
        }
    }
}
