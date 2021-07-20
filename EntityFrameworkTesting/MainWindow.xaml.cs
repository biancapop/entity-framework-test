using System.Collections.Generic;
using System.Windows;


namespace EntityFrameworkTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitOfWork unitOfWork;
        List<Task> list;
        public MainWindow()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            list = new List<Task>();
            


            /*
            Task task = new Task();
            task.Name = "Tarea1";

            Category homeCat = new Category("Hogar");
            Task task = new Task("Barrer","Barrer la cocina y el pasillo", homeCat);

            TaskRepository taskRepo = new TaskRepository(databaseContext);
            taskRepo.Create(task);
            */

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            task.Name = miTextBox.Text;
            unitOfWork.Tasks.Create(task);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            task.Name = (string)List1.SelectedItem;
            DatabaseContext databaseContext = new DatabaseContext();

            TaskRepository taskRepo = new TaskRepository(databaseContext);
            taskRepo.DeleteTask(task);

            /*
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Categories.Create(homeCat);
            unitOfWork.Tasks.Create(task);*/

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}