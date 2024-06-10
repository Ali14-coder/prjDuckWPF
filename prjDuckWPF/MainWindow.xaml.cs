using System.Data.SqlClient;
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

namespace prjDuckWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            String strConnection = "Server=tcp:aqeqe.database.windows.net,1433;Initial Catalog=aqeqedb;Persist Security Info=False;User ID=azuresql;Password=PlicalKeech19@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("Insert into Duck Values(@ID,@Name,@Surname)", connection);
                    command.Parameters.AddWithValue("@ID", this.txtDuckID.Text);
                    command.Parameters.AddWithValue("@Name", this.txtDuckFirstName.Text);
                    command.Parameters.AddWithValue("@Surname", this.txtDuckSurname.Text);
                    connection.Open();
                    int temp = command.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        MessageBox.Show(this.txtDuckFirstName.Text + " " + this.txtDuckSurname.Text + " has been captured successfully!", "New Duck Added");
                    }
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString()+"sorry error", "New Duck not added");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            String strConnection = "Server=tcp:aqeqe.database.windows.net,1433;Initial Catalog=aqeqedb;Persist Security Info=False;User ID=azuresql;Password=PlicalKeech19@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {

                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("Update Duck set FirstName = @Name , Surname  = @Surname where DuckID=@ID", connection);
                    command.Parameters.AddWithValue("@ID", this.txtDuckID.Text);
                    command.Parameters.AddWithValue("@Name", this.txtDuckFirstName.Text);
                    command.Parameters.AddWithValue("@Surname", this.txtDuckSurname.Text);
                    connection.Open();
                    int temp = command.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        MessageBox.Show("Duck has been captured successfully!", "Update Duck completed");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "sorry error", "Duck not updated");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            String strConnection = "Server=tcp:aqeqe.database.windows.net,1433;Initial Catalog=aqeqedb;Persist Security Info=False;User ID=azuresql;Password=PlicalKeech19@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this student?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(strConnection))
                    {
                        SqlCommand command = new SqlCommand("delete from Duck where DuckID=@ID;", connection);
                        command.Parameters.AddWithValue("@ID", this.txtDuckID.Text);
                        command.Parameters.AddWithValue("@Name", this.txtDuckFirstName.Text);
                        command.Parameters.AddWithValue("@Surname", this.txtDuckSurname.Text);
                        connection.Open();
                        int temp = command.ExecuteNonQuery();
                        if (temp > 0)
                        {
                            MessageBox.Show("Duck has been deleted successfully!", "Deleted Duck complete");
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "sorry error", "Duck not deleted");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            String strConnection = "Server=tcp:aqeqe.database.windows.net,1433;Initial Catalog=aqeqedb;Persist Security Info=False;User ID=azuresql;Password=PlicalKeech19@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                bool Valid = false;
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("select * from Duck where DuckID=@ID;", connection);
                    command.Parameters.AddWithValue("@ID", this.txtDuckID.Text);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.txtDuckFirstName.Text = reader["FirstName"].ToString();
                        this.txtDuckSurname.Text = reader["Surname"].ToString();
                        Valid = true;
                    }
                    if (Valid == false)
                    {
                        MessageBox.Show("Duck not found!", "Invalid Duck");
                    }
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "sorry error", "search Duck not working");
            }
        }
    }
}
//make it look pretty
