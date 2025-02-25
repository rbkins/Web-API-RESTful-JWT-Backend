using System.Data.SqlClient;
using System.Data;
using WebapiproductoJWT.connection;
using WebapiproductoJWT.Models;

namespace WebapiproductoJWT.Data
{
    public class Dclientes
    {

        connectioBD cn = new connectioBD();

        public async Task<List<usuarioModel>> listarusuario()
        {

            var listar = new List<usuarioModel>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {


                using (var cmd = new SqlCommand("sp_listarusuario", sql))
                {

                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {

                            var productomodelo = new usuarioModel();
                            productomodelo.idusuario = (int)item["idusuario"];
                            productomodelo.correo = (string)item["correo"];
                            productomodelo.clave = (string)item["clave"];


                        }

                    }
                    return listar;

                }


            }
        }



        public async Task insertarusuario(usuarioModel usuariomodel)
        {

            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {

                using (var cmd = new SqlCommand("sp_insertarusuario", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@correo", usuariomodel.correo);
                    cmd.Parameters.AddWithValue("@clave", usuariomodel.clave);
                    
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }

            }


        }




        public async Task editarusuario(usuarioModel usuarioModel)
        {

            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {


                using (var cmd = new SqlCommand("sp_editarusuario", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idusuario", usuarioModel.idusuario);
                    cmd.Parameters.AddWithValue("@correo", usuarioModel.correo);
                    cmd.Parameters.AddWithValue("@clave", usuarioModel.clave);
                    
                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }

            }


        }


        public async Task eliminarusuario(usuarioModel parametro)
        {

            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {

                using (var cmd = new SqlCommand("sp_eliminarusuario", sql))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idusuario", parametro.idusuario);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                }

            }


        }

    }
}
