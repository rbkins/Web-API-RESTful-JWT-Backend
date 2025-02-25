namespace WebapiproductoJWT.connection
{
    public class connectioBD
    {


        private string connectionstringBD = string.Empty;

        public connectioBD() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionstringBD = builder.GetSection("ConnectionStrings:conexion").Value;
        }

        public string cadenaSQL()
        { 
            return connectionstringBD;
        
        }

    }
}
