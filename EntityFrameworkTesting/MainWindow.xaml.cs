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
            
            Task task = new Task();
            task.Name = "Tarea1";

            DatabaseContext databaseContext = new DatabaseContext();
            
            TaskRepository taskRepo = new TaskRepository(databaseContext);
            taskRepo.CreateTask(task);
        }
    }
}
