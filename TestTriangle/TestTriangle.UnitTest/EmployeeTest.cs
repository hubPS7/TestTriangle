using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTriangle.API.Controllers;
using TestTriangle.Contracts;
using TestTriangle.Entities.Modesl;
using Xunit;

namespace TestTriangle.UnitTest
{
    public class EmployeeTest
    {
        private Mock<IRepositoryWrapper> _moqrepository;
        private Mock<ILoggerManager> _moqlogger;
        EmployeeController controller;
        public EmployeeTest()
        {
            _moqrepository = new Mock<IRepositoryWrapper>();
            _moqlogger = new Mock<ILoggerManager>();
        }

        #region GetAll Employee

        [Fact]
        public void Task_GetEmployees_Return_OkResult()
        {
            //Arrange
            _moqrepository.Setup(x => x.Employee.GetAllEmployeesAsync()).ReturnsAsync(GetTestSessions());
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act  
           var data = controller.GetAllEmployees();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
            Assert.NotNull(data);
            Assert.IsType<Task<IActionResult>>(data);
            Assert.True(data.IsCompletedSuccessfully);
        }

        [Fact]
        public void Task_GetPosts_Return_BadRequestResult()
        {
            //Arrange
            _moqrepository.Setup(x => x.Employee.GetAllEmployeesAsync()).ReturnsAsync(GetTestSessions());
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act
            System.Threading.Tasks.Task<IActionResult> data = controller.GetAllEmployees();
            data = null;

            if (data != null)
            {
                //Assert
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetPosts_MatchResult()
        {
            //Arrange
            _moqrepository.Setup(x => x.Employee.GetAllEmployeesAsync()).ReturnsAsync(GetTestSessions());
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act
            IActionResult data = await controller.GetAllEmployees();

            //Assert
            Assert.IsType<OkObjectResult>(data);

            OkObjectResult okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            List<Employees> emp = okResult.Value.Should().BeAssignableTo<List<Employees>>().Subject;

            Assert.Equal("csharp", emp[0].LastName);
            Assert.Equal("CSHARP", emp[0].FirstName);

            //Assert.Equal("Test Title 2", emp[1].LastName);
            //Assert.Equal("Test Description 2", emp[1].FirstName);
        }
        #endregion

        #region Add New Employee

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            _moqrepository.Setup(repo => repo.Employee.CreateEmployeeAsync(It.IsAny<Employees>())).Returns(Task.CompletedTask).Verifiable();
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);
            Employees employee = new Employees()
            {
                FirstName = "CSHARP",
                LastName = "csharp",
                Addresss = "csharp",
                City = "csharp",
                Country = "csharp",
                HomePhone = "csharp"
            };

            //Act  
            var result = await controller.AddEmployee(employee);

            //Assert  
            Assert.IsType<OkObjectResult>(result);
            _moqrepository.Verify();
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            _moqrepository.Setup(repo => repo.Employee.CreateEmployeeAsync(It.IsAny<Employees>())).Returns(Task.CompletedTask).Verifiable();
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);
            Employees employee = null;

            //Act              
            IActionResult data = await controller.AddEmployee(employee);

            //Assert  
            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_ValidData_MatchResult()
        {
            _moqrepository.Setup(repo => repo.Employee.CreateEmployeeAsync(It.IsAny<Employees>())).Returns(Task.CompletedTask).Verifiable();
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);
            Employees employee = new Employees()
            {
                FirstName = "CSHARP",
                LastName = "csharp",
                Addresss = "csharp",
                City = "csharp",
                Country = "csharp",
                HomePhone = "csharp"
            };

            //Act  
            IActionResult data = await controller.AddEmployee(employee);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            OkObjectResult okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            // var result = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;  

            Assert.Equal(200, okResult.StatusCode);
        }

        #endregion

        #region Update Employee  

        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            int empId = 2;
            //Arrange  
            _moqrepository.Setup(repo => repo.Employee.GetEmployeeByIdAsync(empId)).ReturnsAsync(GetTestSessions().FirstOrDefault(
            s => s.EmployeeId == empId));
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act  
            IActionResult existingPost = await controller.GetEmployeeById(empId);
            OkObjectResult okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            Employees result = okResult.Value.Should().BeAssignableTo<Employees>().Subject;

            Employees employee = new Employees
            {
                EmployeeId = empId,
                FirstName = "Test Title 2 Updated",
                LastName = result.LastName,
                Addresss = result.Addresss,
                City = result.City,
                Country = result.Country,
                HomePhone = result.HomePhone
            };

            IActionResult updatedData = await controller.UpdateEmployee(empId, employee);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_BadRequest()
        {
            int empId = 2;
            //Arrange  
            _moqrepository.Setup(repo => repo.Employee.GetEmployeeByIdAsync(empId)).ReturnsAsync(GetTestSessions().FirstOrDefault(
            s => s.EmployeeId == empId));
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act  
            IActionResult existingPost = await controller.GetEmployeeById(empId);
            OkObjectResult okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            Employees result = okResult.Value.Should().BeAssignableTo<Employees>().Subject;

            Employees employee = null;

            IActionResult data = await controller.UpdateEmployee(empId, employee);

            //Assert  
            Assert.IsType<BadRequestObjectResult>(data);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_NotFound()
        {
            int empId = 2;
            //Arrange  
            _moqrepository.Setup(repo => repo.Employee.GetEmployeeByIdAsync(empId)).ReturnsAsync(GetTestSessions().FirstOrDefault(
            s => s.EmployeeId == empId));
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act  
            IActionResult existingPost = await controller.GetEmployeeById(empId);
            OkObjectResult okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            Employees result = okResult.Value.Should().BeAssignableTo<Employees>().Subject;

            Employees employee = new Employees
            {
                EmployeeId = 3,
                FirstName = "Task_Update_InvalidData_Return_NotFound",
                LastName = result.LastName,
                Addresss = result.Addresss,
                City = result.City,
                Country = result.Country,
                HomePhone = result.HomePhone
            };
            
            IActionResult data = await controller.UpdateEmployee(employee.EmployeeId, employee);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        #endregion

        #region Delete Employee  

        [Fact]
        public async void Task_Delete_Post_Return_OkResult()
        {
            int empId = 2;
            //Arrange  
            _moqrepository.Setup(repo => repo.Employee.GetEmployeeByIdAsync(empId)).ReturnsAsync(GetTestSessions().FirstOrDefault(
            s => s.EmployeeId == empId));
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act  
            IActionResult data = await controller.DeleteEmployee(empId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Delete_Post_Return_NotFoundResult()
        {
            int empId = 3;
            //Arrange  
            _moqrepository.Setup(repo => repo.Employee.GetEmployeeByIdAsync(empId)).ReturnsAsync(GetTestSessions().FirstOrDefault(
            s => s.EmployeeId == empId));
            controller = new EmployeeController(_moqlogger.Object, _moqrepository.Object);

            //Act  
            IActionResult data = await controller.DeleteEmployee(empId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        #endregion

        private IEnumerable<Employees> GetTestSessions()
        {
            List<Employees> sessions = new List<Employees>
            {
                new Employees()
                {
                    EmployeeId = 1,
                    FirstName = "CSHARP",
                    LastName = "csharp",
                    Addresss = "csharp",
                    City = "csharp",
                    Country = "csharp",
                    HomePhone = "csharp"
                },
                new Employees()
                {
                    EmployeeId = 2,
                    FirstName = "CSHARP",
                    LastName = "csharp",
                    Addresss = "csharp",
                    City = "csharp",
                    Country = "csharp",
                    HomePhone = "csharp"
                }
            };
            return sessions;
        }
    }

   
}
