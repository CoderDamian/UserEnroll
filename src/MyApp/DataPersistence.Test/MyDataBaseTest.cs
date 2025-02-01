using Microsoft.EntityFrameworkCore;

namespace DataPersistence.Test
{
    public class MyDataBaseTest
    {
        [Fact]
        public void Be_Valid_Conection_To_DataBase()
        {
            using var myDbContext = new MyDbContext();

            try
            {
                myDbContext.Database.OpenConnection();
                myDbContext.Database.CloseConnection();
            }
            catch (Exception ex)
            {
                Assert.Fail($"No se pudo establecer una conexion con la base de datos: {ex.Message}");
            }
        }
    }
}