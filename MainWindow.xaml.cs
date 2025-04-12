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
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MostrarProductos();  // Llamamos al método para llenar el DataGrid de Productos
    }

    private void MostrarProductos()
    {
        string connectionString = "tu_conexion_a_base_de_datos";  // Reemplaza con tu cadena de conexión

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Productos"; // Consulta SQL para obtener productos
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGridProductos.ItemsSource = dt.DefaultView;  // Asignamos los datos al DataGrid
        }
    }
}