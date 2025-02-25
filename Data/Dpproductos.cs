using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using WebapiproductoJWT.connection;
using WebapiproductoJWT.Models;

namespace WebapiproductoJWT.Data
{
    public class Dpproductos
    {

        connectioBD cn = new connectioBD();

        public async Task<List<productoModelo>> listarproductos() { 
        
            var listar = new List<productoModelo>();
            using (var sql = new SqlConnection(cn.cadenaSQL())) {


                using (var cmd = new SqlCommand("sp_listarproducto", sql)) { 
                
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync()) { 
                        
                            var productomodelo = new productoModelo();
                            productomodelo.IdProducto = (int)item["IdProducto"];
                            productomodelo.CodigoBarra = (string)item["CodigoBarra"];
                            productomodelo.Nombre = (string)item["Nombre"];
                            productomodelo.Marca = (string)item["Marca"];
                            productomodelo.Categoria = (string)item["Categoria"];
                            productomodelo.Precio = (decimal)item["Precio"];
                            listar.Add(productomodelo);
                        }

                    }
                
                }
                return listar;
            
            }
        
        
        }



        public async Task insertarproductos(productoModelo productomodelo)
        {

            using (var sql = new SqlConnection(cn.cadenaSQL())) {

                using (var cmd = new SqlCommand("sp_insertarproducto", sql))
                { 
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoBarra", productomodelo.CodigoBarra);
                    cmd.Parameters.AddWithValue("@Nombre", productomodelo.Nombre);
                    cmd.Parameters.AddWithValue("@Marca", productomodelo.Marca);
                    cmd.Parameters.AddWithValue("@Categoria", productomodelo.Categoria);
                    cmd.Parameters.AddWithValue("@Precio", productomodelo.Precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            
            }


        }

        public async Task editarproductos(productoModelo productoModelo) {

            using (var sql = new SqlConnection(cn.cadenaSQL())) {


                using (var cmd = new SqlCommand("sp_editarproducto", sql)) { 
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", productoModelo.IdProducto);
                    cmd.Parameters.AddWithValue("@CodigoBarra", productoModelo.CodigoBarra);
                    cmd.Parameters.AddWithValue("@Nombre", productoModelo.Nombre);
                    cmd.Parameters.AddWithValue("@Marca", productoModelo.Marca);
                    cmd.Parameters.AddWithValue("@Categoria", productoModelo.Categoria);
                    cmd.Parameters.AddWithValue("@Precio", productoModelo.Precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }
            
            }
        
        
        }


        public async Task eliminarproducto(productoModelo parametro)
        {

            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {

                using (var cmd = new SqlCommand("sp_eliminarproducto", sql))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametro.IdProducto);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }

            }


        }
    }


    

       
}
