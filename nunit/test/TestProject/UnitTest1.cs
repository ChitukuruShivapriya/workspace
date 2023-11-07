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
    public class ServiceControllerTests
    {
        private ServiceController _ServiceController;
        private ServiceBookingDbContext _context;

        [SetUp]
        public void Setup()
        {
            // Initialize an in-memory database for tDescriptionesting
            var options = new DbContextOptionsBuilder<ServiceBookingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ServiceBookingDbContext(options);
            _context.Database.EnsureCreated(); // Create the database

            // Seed the database with sample data
            _context.Services.AddRange(new List<Service>
            {
                new Service { ServiceID = 1, ServiceType = "Service 1", Description = "Service Description1", Charges = 300M,Timing="Time Shift1"  },
                new Service { ServiceID = 2, ServiceType = "Service 2", Description = "Service Description2", Charges = 9000M,Timing="Time Shift2" },
                new Service { ServiceID = 3, ServiceType = "Service 3", Description = "Service Description3", Charges = 2905M,Timing="Time Shift3"  }
            });
            _context.SaveChanges();

            _ServiceController = new ServiceController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // Delete the in-memory database after each test
            _context.Dispose();
        }
        [Test]
        public void ServiceClassExists()
        {
            // Arrange
            Type ServiceType = typeof(Service);

            // Act & Assert
            Assert.IsNotNull(ServiceType, "Service class not found.");
        }
         [Test]
        public void LoginModelClassExists()
        {
            // Arrange
            Type LoginModelType = typeof(LoginModel);

            // Act & Assert
            Assert.IsNotNull(LoginModelType, "LoginModel class not found.");
        }
         [Test]
        public void RegisterModelClassExists()
        {
            // Arrange
            Type RegisterModelType = typeof(RegisterModel);

            // Act & Assert
            Assert.IsNotNull(RegisterModelType, "RegisterModel class not found.");
        }
        [Test]
public void AccountController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetwebapi"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Service";
    string controllerNamespace = "dotnetapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}
 [Test]
public void BookingController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetwebapi"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Booking";
    string controllerNamespace = "dotnetapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}
[Test]
public void AuthController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetwebapi"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Auth";
    string controllerNamespace = "dotnetapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}

        [Test]
        public void Service_Properties_ServiceType_ReturnExpectedDataTypes()
        {
            // Arrange
            Service Service = new Service();
            PropertyInfo propertyInfo = Service.GetType().GetProperty("ServiceType");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "ServiceType property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "ServiceType property type is not string.");
        }
[Test]
        public void Service_Properties_Description_ReturnExpectedDataTypes()
        {
            // Arrange
            Service Service = new Service();
            PropertyInfo propertyInfo = Service.GetType().GetProperty("Description");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "Description property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "Description property type is not string.");
        }

        [Test]
        public async Task GetAllServices_ReturnsOkResult()
        {
            // Act
            var result = await _ServiceController.GetAllServices();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAllServices_ReturnsAllServices()
        {
            // Act
            var result = await _ServiceController.GetAllServices();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf<IEnumerable<Service>>(okResult.Value);
            var Services = okResult.Value as IEnumerable<Service>;

            var ServiceCount = Services.Count();
            Assert.AreEqual(3, ServiceCount); // Assuming you have 3 Services in the seeded data
        }


        [Test]
        public async Task AddService_ValidData_ReturnsOkResult()
        {
            // Arrange
            var newService = new Service
            {
ServiceType = "Service 1", Description = "Service Description1", Charges = 8989M,Timing="Time shift 4"
            };

            // Act
            var result = await _ServiceController.AddService(newService);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
        [Test]
        public async Task DeleteService_ValidId_ReturnsNoContent()
        {
            // Arrange
              // var controller = new ServicesController(context);

                // Act
                var result = await _ServiceController.DeleteService(1) as NoContentResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(204, result.StatusCode);
        }

        [Test]
        public async Task DeleteService_InvalidId_ReturnsBadRequest()
        {
                   // Act
                var result = await _ServiceController.DeleteService(0) as BadRequestObjectResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(400, result.StatusCode);
                Assert.AreEqual("Not a valid Service id", result.Value);
        }
    }
}
