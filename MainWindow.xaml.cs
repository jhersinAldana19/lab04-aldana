using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab04_aldana;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // SqlConnection connection =
    //  new SqlConnection("Server=LAB411-023\\SQLEXPRESS01;Database=Neptuno;Integrated Security=True; TrustServerCertificate=true;");
    SqlConnection connection = new SqlConnection("Server=LAB411-023\\SQLEXPRESS01;Database=Neptuno;User ID=WERNER;Password=werner123;TrustServerCertificate=true;");

    public MainWindow()
    {
        InitializeComponent();
    }

    private void LoadDataTableButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            List<Producto> productos = new List<Producto>();
            connection.Open();
            SqlCommand command = new SqlCommand("sp_ListarProductos", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                productos.Add(new Producto
                {
                    IdProducto = Convert.ToInt32(dataReader["idproducto"]),
                    NombreProducto = dataReader["nombreProducto"].ToString(),
                    IdProveedor = Convert.ToInt32(dataReader["idProveedor"]),
                    IdCategoria = Convert.ToInt32(dataReader["idCategoria"]),
                    CantidadPorUnidad = dataReader["cantidadPorUnidad"].ToString(),
                    PrecioUnidad = Convert.ToDouble(dataReader["precioUnidad"]),
                    UnidadesEnExistencia = Convert.ToInt32(dataReader["unidadesEnExistencia"]),
                    UnidadesEnPedido = Convert.ToInt32(dataReader["unidadesEnPedido"]),
                    NivelNuevoPedido = Convert.ToInt32(dataReader["nivelNuevoPedido"]),
                    Suspendido = Convert.ToBoolean(dataReader["suspendido"]),
                    CategoriaProducto = dataReader["categoriaProducto"].ToString()
                });
            }
            connection.Close();
            showClients.ItemsSource = productos;
        }
        catch (SqlException ex)
        {
            // Si ocurre un error al intentar abrir la conexión
            MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }

    private void loadDataReaderButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            List<Categoria> categorias = new List<Categoria>();
            connection.Open();
            SqlCommand command = new SqlCommand("sp_ListarCategorias", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                categorias.Add(new Categoria
                {
                    IdCategoria = Convert.ToInt32(dataReader["idcategoria"]),
                    NombreCategoria = dataReader["nombrecategoria"].ToString(),
                    Descripcion = dataReader["descripcion"].ToString(),
                    Activo = Convert.ToInt32(dataReader["Activo"]),
                    CodCategoria = dataReader["CodCategoria"].ToString()
                });
            }
            connection.Close();
            showClients.ItemsSource = categorias;
        }
        catch (SqlException ex)
        {
            // Si ocurre un error al intentar abrir la conexión
            MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}