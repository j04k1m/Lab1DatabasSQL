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
using System.Data;
using System.Configuration;
using System.Threading;

namespace WpfAppDatabasLab1
{

    public partial class MainWindow : Window
    {  
        static SqlConnection connect = new SqlConnection(@"
        Data Source = (localdb)\MSSQLLocalDB; 
        Initial Catalog = Shop; 
        Integrated Security = True; 
        Connect Timeout = 30; 
        Encrypt=False;TrustServerCertificate=True;
        ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        //SqlCommands and sqlQuery

        //Customer
        static string sqlQueryUpdateCustomer = @"UPDATE Customer SET Customer_Id = @Customer_Id, Firstname = @Firstname, Lastname = @Lastname
        WHERE Customer_Id = @SelectedItem";
        static SqlCommand UpdateTableCustomer = new SqlCommand(sqlQueryUpdateCustomer, connect);
         
        static string sqlQueryAddCustomer = @"INSERT INTO Customer (Customer_Id, Firstname, Lastname)
         VALUES (@Customer_Id, @Firstname, @Lastname)";
        static SqlCommand AddTableCustomer = new SqlCommand(sqlQueryAddCustomer, connect);

        //Order
        static string sqlQueryAddOrder = @"INSERT INTO Orders (Orders_Id, Customer_Id, Date, Total_Amount)
         VALUES (@Orders_Id, @Customer_Id, @Date, @Total_Amount)";
        static SqlCommand AddTableOrder = new SqlCommand(sqlQueryAddOrder, connect);

        static string sqlQueryUpdateOrder = @"UPDATE Orders SET Orders_Id = @Orders_Id, Customer_Id = @Customer_Id, Date = @Date, Total_Amount = @Total_Amount
        WHERE Orders_Id = @SelectedItemTableB";
        static SqlCommand UpdateTableOrder = new SqlCommand(sqlQueryUpdateOrder, connect);

        //Funktioner
        public void UpdateListbox()
        {                       
            ListBoxInformationTableCustomer.Items.Clear();
            ListBoxInformationTableOrder.Items.Clear();
            FillData();
        }

        public void SelectedItem()
        {
            TextBoxInfoCustomer_SelectedItem.Visibility = Visibility.Hidden;
            TextBoxInfoOrder_SelectedItem.Visibility = Visibility.Hidden;

        }

        //Main 
        public MainWindow()
        {
            this.DataContext = connect;
            InitializeComponent();
            SelectedItem();
            connect.Open();
            FillData();

        }

        //Table to Listbox
        void FillData()
        {

           
           // Create new DataAdapter
           using (SqlDataAdapter a = new SqlDataAdapter(
            "SELECT * FROM Customer", connect))
             {      
                    DataTable t = new DataTable();
                    a.Fill(t);
                    
                        foreach (DataRow jh in t.Rows)
                        {
                        ListBoxInformationTableCustomer.Items.Add(jh["Customer_Id"].ToString());
                        }
             }
        }


        //Listbox Changed
        private void ListBoxInformationTableCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Listbox Customer
            if (ListBoxInformationTableCustomer.SelectedItem != null)
             {

             SqlDataAdapter kp = new SqlDataAdapter(
             "SELECT * FROM Customer WHERE Customer_Id = '" + ListBoxInformationTableCustomer.SelectedItem.ToString() + "'", connect);

                 DataTable dp = new DataTable();
                 kp.Fill(dp);

                 foreach(DataRow mp in dp.Rows)
                 {

                     TextBoxInfoCustomer_SelectedItem.Text = ListBoxInformationTableCustomer.SelectedItem.ToString();
                     TextBoxInfoCustomer_Customer_Id.Text = mp["Customer_Id"].ToString();
                     TextBoxInfoCustomer_Firstname.Text = mp["Firstname"].ToString();
                     TextBoxInfoCustomer_Lastname.Text = mp["Lastname"].ToString();
                 }
               
              //Listbox Order
              SqlDataAdapter xyf = new SqlDataAdapter(

             "SELECT Orders_Id FROM Orders WHERE Orders.Customer_Id = '" + ListBoxInformationTableCustomer.SelectedItem.ToString() + "'", connect);


                 // Use DataAdapter to fill DataTable
                 DataTable tpf = new DataTable();
                 xyf.Fill(tpf);

                 ListBoxInformationTableOrder.Items.Clear();

                 foreach (DataRow drw in tpf.Rows)
                 {
                 ListBoxInformationTableOrder.Items.Add(drw["Orders_Id"].ToString());
                 }

                ButtonDeleteTableCustomer.IsEnabled = true;
                ButtonUpdateTableCustomer.IsEnabled = true;
             }

             //Listbox Customer
             else if(ListBoxInformationTableCustomer.SelectedItem == null)
             {
                TextBoxInfoCustomer_SelectedItem.Text = "";
                TextBoxInfoCustomer_Customer_Id.Text = "";
                TextBoxInfoCustomer_Firstname.Text = "";
                TextBoxInfoCustomer_Lastname.Text = "";

                ButtonDeleteTableCustomer.IsEnabled = false;
                ButtonUpdateTableCustomer.IsEnabled = false;
            }

             
            

       
        }

        private void ListBoxInformationTableOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Listbox Order
            if(ListBoxInformationTableOrder.SelectedItem != null)
            {

            SqlDataAdapter abck = new SqlDataAdapter(

            "SELECT * FROM Orders WHERE Orders.Orders_Id = '" + ListBoxInformationTableOrder.SelectedItem.ToString() + "'", connect);

             DataTable dapun = new DataTable();
             abck.Fill(dapun);

             foreach(DataRow ktyk in dapun.Rows)
             {

                 TextBoxInfoOrder_SelectedItem.Text = ListBoxInformationTableOrder.SelectedItem.ToString();
                 TextBoxInfoOrder_Orders_Id.Text = ktyk["Orders_Id"].ToString();
                 TextBoxInfoOrder_Customer_Id.Text = ktyk["Customer_Id"].ToString();
                 TextBoxInfoOrder_Date.Text = ktyk["Date"].ToString();
                 TextBoxInfoOrder_Total_Amount.Text = ktyk["Total_Amount"].ToString();
             }

                ButtonDeleteTableOrder.IsEnabled = true;
                ButtonUpdateTableOrder.IsEnabled = true;
            }

            //Listbox Order
            else if(ListBoxInformationTableOrder.SelectedItem == null)
            {

                    TextBoxInfoOrder_SelectedItem.Text = "";
                    TextBoxInfoOrder_Orders_Id.Text = "";
                    TextBoxInfoOrder_Customer_Id.Text = "";
                    TextBoxInfoOrder_Date.Text = "";
                    TextBoxInfoOrder_Total_Amount.Text = "";


                ButtonDeleteTableOrder.IsEnabled = false;
                ButtonUpdateTableOrder.IsEnabled = false;

            }
        }
        
        //Buttons

        //Butons Customer Start
        private void ButtonDeleteTableCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string sqlQueryDelete = @"DELETE FROM Customer WHERE Customer_Id = '" + TextBoxInfoCustomer_SelectedItem.Text + "'";
            SqlCommand DeleteTableCustomer = new SqlCommand(sqlQueryDelete, connect);
            DeleteTableCustomer.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            UpdateListbox();
            }
            catch
            {
                MessageBox.Show("Error: Unable to DELETE, this ID has orders, DELETE the orders first");
                
            }

        }

        private void ButtonAddTableCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            
            AddTableCustomer.Parameters.AddWithValue("Customer_Id", TextBoxInfoCustomer_Customer_Id.Text);
            AddTableCustomer.Parameters.AddWithValue("Firstname", TextBoxInfoCustomer_Firstname.Text);
            AddTableCustomer.Parameters.AddWithValue("Lastname", TextBoxInfoCustomer_Lastname.Text);
            AddTableCustomer.ExecuteNonQuery();
            AddTableCustomer.Parameters.Clear();
            MessageBox.Show("Added");
            UpdateListbox();

            }
            catch
            {
                MessageBox.Show("Error: Customer ID is duplicate or Invalid character input");
                AddTableCustomer.Parameters.Clear();
            }

        }


        private void ButtonUpdateTableCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            UpdateTableCustomer.Parameters.AddWithValue("SelectedItem", TextBoxInfoCustomer_SelectedItem.Text);
            UpdateTableCustomer.Parameters.AddWithValue("Customer_Id", TextBoxInfoCustomer_Customer_Id.Text);
            UpdateTableCustomer.Parameters.AddWithValue("Firstname", TextBoxInfoCustomer_Firstname.Text);
            UpdateTableCustomer.Parameters.AddWithValue("Lastname", TextBoxInfoCustomer_Lastname.Text);
            UpdateTableCustomer.ExecuteNonQuery();
            UpdateTableCustomer.Parameters.Clear();
            MessageBox.Show("Saved");
            UpdateListbox();
            }
            catch
            {
                MessageBox.Show("Error: Customer ID is duplicate or Invalid character input");
                UpdateTableCustomer.Parameters.Clear();
            }


        }
        //Buttons Customer End

        //Buttons Orders Start
        private void ButtonDeleteTableOrder_Click(object sender, RoutedEventArgs e)
        {
            string sqlQueryDeleteOrder = @"DELETE FROM Orders WHERE Orders_Id = '" + TextBoxInfoOrder_SelectedItem.Text + "'";
            SqlCommand DeleteTableOrder = new SqlCommand(sqlQueryDeleteOrder, connect);
            DeleteTableOrder.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            UpdateListbox();
        }

        private void ButtonAddTableOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            AddTableOrder.Parameters.AddWithValue("Orders_Id", TextBoxInfoOrder_Orders_Id.Text);
            AddTableOrder.Parameters.AddWithValue("Customer_Id", TextBoxInfoOrder_Customer_Id.Text);
            AddTableOrder.Parameters.AddWithValue("Date", TextBoxInfoOrder_Date.Text);
            AddTableOrder.Parameters.AddWithValue("Total_Amount", TextBoxInfoOrder_Total_Amount.Text);
            AddTableOrder.ExecuteNonQuery();
            AddTableOrder.Parameters.Clear();
            MessageBox.Show("Added");
            UpdateListbox();
            }
            catch
            {
                MessageBox.Show("Error: Order ID is duplicate or choosen Customer ID don't exist or invalid character input");
                AddTableOrder.Parameters.Clear();
            }

        }

        private void ButtonUpdateTableOrder_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
            UpdateTableOrder.Parameters.AddWithValue("SelectedItemTableB", TextBoxInfoOrder_SelectedItem.Text);
            UpdateTableOrder.Parameters.AddWithValue("Orders_Id", TextBoxInfoOrder_Orders_Id.Text);
            UpdateTableOrder.Parameters.AddWithValue("Customer_Id", TextBoxInfoOrder_Customer_Id.Text);
            UpdateTableOrder.Parameters.AddWithValue("Date", TextBoxInfoOrder_Date.Text);
            UpdateTableOrder.Parameters.AddWithValue("Total_Amount", TextBoxInfoOrder_Total_Amount.Text);
            UpdateTableOrder.ExecuteNonQuery();
            UpdateTableOrder.Parameters.Clear();
            MessageBox.Show("Saved");
            UpdateListbox();
            }
            catch
            {
                MessageBox.Show("Error: Order ID is duplicate or choosen Customer ID don't  or invalid character input");
                UpdateTableOrder.Parameters.Clear();
            }
        }
        //Buttons Orders End
    }
}
