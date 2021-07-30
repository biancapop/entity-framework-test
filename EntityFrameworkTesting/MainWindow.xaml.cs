using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Documents;

namespace EntityFrameworkTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Task> list = new List<Task>();
        public List<Task> Lista
        {
            get { return list; }
            set { list = value; }
        }
        private List<Category> listCombo = new List<Category>();
        public List<Category> _listCombo 
        {
            get { return listCombo; }
            set { listCombo = value; }
        }
        UnitOfWork unitOfWork;
        Task task;
        public MainWindow()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            list = unitOfWork.Tasks.Mostrar();
            UpdateList();
            
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(list,listCombo);
            window1.Owner = this;
            window1.ShowDialog();
            UpdateList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Task task = list.FirstOrDefault(t => t.Name == List1.SelectedItem.ToString());
            unitOfWork.Tasks.Delete(task);
            Lista.Remove(task);
            UpdateList();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            List<string> strListSearch = new List<string>();

            foreach (Task i in databaseContext.Tasks)
            {
                if (i.Name == SearchBox.Text)
                {
                    strListSearch.Add(i.Name);
                }
            }
            BindingOperations.SetBinding(List1, ItemsControl.ItemsSourceProperty, new Binding
            {
                Source = strListSearch
            });
            
        }
        public void UpdateList()
        {
            List<string> strListTask = new List<string>();
            list.ForEach(t => strListTask.Add(t.Name));

            BindingOperations.SetBinding(List1, ItemsControl.ItemsSourceProperty, new Binding
            {
                Source = strListTask
            });
            
        }
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(list, listCombo);
            CategoryAdd categoryAdd = new CategoryAdd(listCombo);
            categoryAdd.Owner = this;
            categoryAdd.ShowDialog();
        }
        private void List1_MouseDoubleClick_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window2 window2 = new Window2();
            DatabaseContext database = new DatabaseContext();

            List<int> idListTask = new List<int>();
            list.ForEach(t => idListTask.Add(t.Id));

            int id = (from i in database.Tasks where List1.SelectedIndex == list.IndexOf(task) select i.Id).FirstOrDefault();


            //int id;
            //id = (from i in database.Tasks where i.Name == List1.SelectedItem.ToString() select i).FirstOrDefault().Id;
            // string name;
            // name = List1.SelectedItem.ToString();

                //window2.IdBlock.Content = i.Id;
                //window2.IdBlock.Content = unitOfWork.Tasks.SearchTask(id).Id;
                window2.NameBlock.Content = unitOfWork.Tasks.SearchTask(id).Name;
                window2.ContentBlock.Content = unitOfWork.Tasks.SearchTask(id).Content;
                window2.CategoryBlock.Content = (from c in database.Tasks where c.Name == List1.SelectedItem.ToString() join cid in database.Categories on c.CategoryId equals cid.Id select cid.Name.ToString());
                window2.Show();
        }
    }
}