using System.Windows;


namespace EntityFrameworkTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            Task task = new Task();
            task.Name = "Tarea1";

            DatabaseContext databaseContext = new DatabaseContext();
            
            TaskRepository taskRepo = new TaskRepository(databaseContext);
            taskRepo.CreateTask(task);
            */

            
            
            
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            
            Task task = new Task();
            task.Name = miTextBox.Text;
            DatabaseContext databaseContext = new DatabaseContext();

            TaskRepository taskRepo = new TaskRepository(databaseContext);
            taskRepo.CreateTask(task);

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            task.Name = (string) List1.SelectedItem;
            DatabaseContext databaseContext = new DatabaseContext();

            TaskRepository taskRepo = new TaskRepository(databaseContext);
            taskRepo.DeleteTask(task);
        }
    }
}
