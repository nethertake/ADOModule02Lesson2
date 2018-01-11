using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;

namespace ADOModule02Lesson2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connString = "";
        public MainWindow()
        {
            InitializeComponent();
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void ErButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(_connString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * form AccessTab";
          
                SqlDataReader rdr = cmd.ExecuteReader();
                List<AccessTab> accessTabs = new List<AccessTab>;
                while (rdr.Read())
                {
                    AccessTab accessTab = new AccessTab();
                    accessTab.intTabID = Int32.Parse(rdr[0].ToString());
                    accessTab.strTabName = rdr[1].ToString();
                    accessTabs.Add(accessTab);

                }
                AccessTabListView.ItemsSource = accessTabs;
            }

        }

        public class AccessTab
        {
            public int intTabID { get; set; }
            public string strTabName { get; set; }
        }

    }
}
