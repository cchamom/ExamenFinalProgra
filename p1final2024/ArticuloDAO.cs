using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace p1final2024
{
    public class ArticuloDAO
    {
        private string connectionString = "DESKTOP-PQBRDPK\\SQLEXPRESS" + // Actualiza esto con la dirección de tu servidor SQL Server
            "Database=ArticulosDB;" +      // Nombre de la base de datos
            "User Id=Cristian Chamo;" +            // Usuario de SQL Server
            "Password=06062005;" +           // Contraseña
            "TrustServerCertificate=True;";       // Opcional: necesario para conexiones seguras sin un certificado SSL válido

        public ArticuloDAO()
        {
        }

        public void Create(Articulo articulo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO articulos (nombre, descripcion, precio, imagen) VALUES (@nombre, @descripcion, @precio, @imagen)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                        cmd.Parameters.AddWithValue("@precio", articulo.Precio);
                        cmd.Parameters.AddWithValue("@imagen", articulo.Imagen);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el artículo: " + ex.Message);
            }
        }

        public Articulo Read(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM articulos WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Articulo
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                    Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                    Imagen = reader["imagen"] as byte[]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el artículo: " + ex.Message);
            }
            return null;
        }

        public List<Articulo> ReadAll()
        {
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM articulos";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                articulos.Add(new Articulo
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                    Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                    Imagen = reader["imagen"] as byte[]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer todos los artículos: " + ex.Message);
            }
            return articulos;
        }

        public void Update(Articulo articulo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE articulos SET nombre = @nombre, descripcion = @descripcion, precio = @precio, imagen = @imagen WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                        cmd.Parameters.AddWithValue("@precio", articulo.Precio);
                        cmd.Parameters.AddWithValue("@imagen", articulo.Imagen);
                        cmd.Parameters.AddWithValue("@id", articulo.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el artículo: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM articulos WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el artículo: " + ex.Message);
            }
        }
    }

    // Definición de la clase Articulo
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}
