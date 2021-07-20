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
<<<<<<< HEAD
            /*
            Task task = new Task();
            task.Name = "Tarea1";
=======
>>>>>>> af7fd5b5412d9850f6ed90fe06f8893076f00764

            Category homeCat = new Category("Hogar");
            Task task = new Task("Barrer","Barrer la cocina y el pasillo", homeCat);
            
<<<<<<< HEAD
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
=======
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Categories.Create(homeCat);
            unitOfWork.Tasks.Create(task);
>>>>>>> af7fd5b5412d9850f6ed90fe06f8893076f00764
        }
    }
}
