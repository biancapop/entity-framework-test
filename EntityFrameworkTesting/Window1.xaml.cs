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
using System.Windows.Shapes;

namespace EntityFrameworkTesting
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Task> lista;
        UnitOfWork unitOfWork;
        List<Category> listaCombo;
        Task task;
        public Window1(List<Task> list, List<Category> listCombo)
        {
            task = new Task();
            unitOfWork = new UnitOfWork();
            listCombo = unitOfWork.Categories.MostrarCategorias();
            
            InitializeComponent();
            listaCombo = listCombo;
            lista = list;
            UpdateCombo();
        }
        public void UpdateCombo()
        {
            List<string> strListCombo = new List<string>();
            listaCombo.ForEach(t => strListCombo.Add(t.Name));

            BindingOperations.SetBinding(TaskComboBox, ItemsControl.ItemsSourceProperty, new Binding
            {
                Source = strListCombo
            });
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DatabaseContext database = new DatabaseContext();
                       

            if (TaskText.Text != null && TaskComboBox.SelectedItem != null)
            {
                MainWindow mainWindow = new MainWindow();
                task.Name = TaskText.Text;
                task.Content = TaskContent.Text;
                task.CategoryId = (from a in database.Categories where a.Name == TaskComboBox.SelectedItem.ToString() select a).First().Id;
                unitOfWork.Tasks.Create(task);
                lista.Add(task);
                Close();
            }
            else
            {
                MessageBox.Show("No has introducido los datos necesarios, por favor, vuelve a intentarlo");
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
