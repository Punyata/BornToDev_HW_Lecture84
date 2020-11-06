using System;
using System.Collections;
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

namespace HW_Lecture84_ArrayList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name = "";

        public string Name { get => name; set => name = value; }
        ArrayList Custinfo;

        public MainWindow()
        {
            InitializeComponent();
            Custinfo = new ArrayList();
        }

        private void initialLoad()
        {
            tb_NameInput.Text = string.Empty;
            tb_NameInput.Focus();
            tb_Name.Text = string.Empty;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_NameInput.Text != string.Empty)
            {
                name = tb_NameInput.Text;
                int exsits = Custinfo.IndexOf(name);
                if (exsits>=0)
                {
                    MessageBox.Show("Existing Data !!");
                    initialLoad();
                }
                else
                {
                    Custinfo.Add(name);
                    MessageBox.Show("Add Complete");
                    initialLoad();
                }
            }
            else
            {
                MessageBox.Show("Please Input Data.");
            }

        }

        private void bt_ShowAll_Click(object sender, RoutedEventArgs e)
        {
            int num;
            num = Custinfo.Count;

            if (num == 0)
            {
                MessageBox.Show("No Data");
            }
            else
            {
                
                if (num > 1 )
                {
                    StringBuilder builder = new StringBuilder();
                    foreach(string data in Custinfo)
                    {
                        builder = builder.AppendLine(data.ToString());
                        tb_Name.Text = builder.ToString();
                    }

                }
                else
                {
                    foreach (string cust in Custinfo)
                    {
                        tb_Name.Text = cust.ToString();
                    }
                    
                }
               
            }
        }

        private void bt_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (tb_NameInput.Text.Length <= 0)
            {
                MessageBox.Show("Please input data to remove.");
                initialLoad();
            }
            else
            {
                int index;
                index = Custinfo.IndexOf(tb_NameInput.Text);
                if(index >= 0)
                {
                    Custinfo.RemoveAt(index);
                    MessageBox.Show("Removed Complete");
                    initialLoad();
                }
                else
                {
                    MessageBox.Show("No Data");
                    initialLoad();
                }
                
            }
            
        }
    }
}
