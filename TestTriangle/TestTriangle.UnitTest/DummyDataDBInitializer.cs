using TestTriangle.Entities.Modesl;

namespace TestTriangle.UnitTest
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(TestTriangleContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Employees.AddRange(
                new Employees() { FirstName = "CSHARP", LastName = "csharp", Addresss = "csharp", City = "csharp", Country = "csharp", HomePhone = "csharp" },
                new Employees() { FirstName = "VISUAL STUDIO", LastName = "visualstudio" , Addresss = "csharp", City = "csharp", Country = "csharp", HomePhone = "csharp" }
            );

            context.SaveChanges();
        }
    }
}