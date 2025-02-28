using ejercicio2.conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ejercicio2.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaID { get; set; }
        public string CategoriaNombre { get; set; }
        public int ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }
        public bool Activo { get; set; }
    }

    public class ProductoModel
    {
        private readonly DatabaseConnection bd;

        public ProductoModel()
        {
            bd = new DatabaseConnection();
        }

        public List<Producto> ObtenerProductosActivos()
        {
            var productos = new List<Producto>();

            using (var con = bd.GetConnection())
            {
                var query = @"
                    SELECT p.ProductoID, p.Nombre, p.Precio, p.Stock, c.Nombre AS CategoriaNombre, pr.Nombre AS ProveedorNombre
                    FROM Productos p
                    INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
                    INNER JOIN Proveedores pr ON p.ProveedorID = pr.ProveedorID
                    WHERE p.Activo = 1";

                using (var command = new SqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                ProductoID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3),
                                CategoriaNombre = reader.GetString(4),
                                ProveedorNombre = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return productos;
        }

        public void CambiarEstadoProducto(int productoID, bool estado)
        {
            using (var connection = bd.GetConnection())
            {
                var query = "UPDATE Productos SET Activo = @Estado WHERE ProductoID = @ProductoID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Estado", estado ? 1 : 0);
                    command.Parameters.AddWithValue("@ProductoID", productoID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Categoria> ObtenerCategorias()
        {
            var categorias = new List<Categoria>();

            using (var con = bd.GetConnection())
            {
                var query = "SELECT CategoriaID, Nombre FROM Categorias";

                using (var command = new SqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorias.Add(new Categoria
                            {
                                CategoriaID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return categorias;
        }

        // Método para obtener todos los proveedores
        public List<Proveedor> ObtenerProveedores()
        {
            var proveedores = new List<Proveedor>();

            using (var con = bd.GetConnection())
            {
                var query = "SELECT ProveedorID, Nombre FROM Proveedores";

                using (var command = new SqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proveedores.Add(new Proveedor
                            {
                                ProveedorID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return proveedores;
        }


        // Método para agregar un nuevo producto
        public void AgregarProducto(Producto producto)
        {
            using (var connection = bd.GetConnection())
            {
                var query = @"
                INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaID, ProveedorID, Activo)
                VALUES (@Nombre, @Descripcion, @Precio, @Stock, @CategoriaID, @ProveedorID, 1)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                    command.Parameters.AddWithValue("@ProveedorID", producto.ProveedorID);
                    command.ExecuteNonQuery();
                }
            }
        }


        public Producto ObtenerProductoPorId(int productoID)
        {
            using (var con = bd.GetConnection())
            {
                var query = @"
            SELECT ProductoID, Nombre, Descripcion, Precio, Stock, CategoriaID, ProveedorID 
            FROM Productos 
            WHERE ProductoID = @ProductoID";

                using (var command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ProductoID", productoID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Producto
                            {
                                ProductoID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                Stock = reader.GetInt32(4),
                                CategoriaID = reader.GetInt32(5),
                                ProveedorID = reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void ActualizarProducto(Producto producto)
        {
            using (var connection = bd.GetConnection())
            {
                var query = @"
            UPDATE Productos 
            SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, 
                Stock = @Stock, CategoriaID = @CategoriaID, ProveedorID = @ProveedorID 
            WHERE ProductoID = @ProductoID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                    command.Parameters.AddWithValue("@ProveedorID", producto.ProveedorID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

public class Categoria
{
    public int CategoriaID { get; set; }
    public string Nombre { get; set; }
}

public class Proveedor
{
    public int ProveedorID { get; set; }
    public string Nombre { get; set; }
}