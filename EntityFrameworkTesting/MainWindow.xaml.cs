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

            Category homeCat = new Category("Hogar");
            Task task = new Task("Barrer","Barrer la cocina y el pasillo", homeCat);
            
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Categories.Create(homeCat);
            unitOfWork.Tasks.Create(task);
        }
    }
}
