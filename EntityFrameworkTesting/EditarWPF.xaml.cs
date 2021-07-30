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
    /// Lógica de interacción para EditarWPF.xaml
    /// </summary>
    public partial class EditarWPF : Window
    {
        Task task;
        UnitOfWork unitOfWork;
        List<Category> listCombo;
        public EditarWPF()
        {
            unitOfWork = new UnitOfWork();
            task = new Task();
            InitializeComponent();
            listCombo = unitOfWork.Categories.MostrarCategorias();
            UpdateCombo();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool comp = false;

            UnitOfWork unitOfWork = new UnitOfWork();
            DatabaseContext database = new DatabaseContext();
            MainWindow mainWindow = new MainWindow();

            task.Name = (from a in database.Tasks where a.Id == Int32.Parse(IdBlock.Text) select a).First().Name;
            task.Content = (from a in database.Tasks where a.Id == Int32.Parse(IdBlock.Text) select a).First().Content;
            task.CategoryId = (from a in database.Tasks where a.Id == Int32.Parse(IdBlock.Text) select a).First().CategoryId;
            task.Id = Int32.Parse(IdBlock.Text);

            if (task.Name != NameBlock.Text)
            {
                task.Name = NameBlock.Text;
                
                comp = true;
            }
            if (task.Content != ContentBlock.Text)
            {
                task.Content = ContentBlock.Text;
                comp = true;
            }
            if (task.CategoryId != (from a in database.Categories where a.Name == CategoryCombo.SelectedItem.ToString() select a).First().Id)
            {
                task.CategoryId = (from a in database.Categories where a.Name == CategoryCombo.SelectedItem.ToString() select a).First().Id;
                comp = true;
            }
            if (comp == true)
            {
                unitOfWork.Tasks.Update(task);
                mainWindow.UpdateList();
                unitOfWork.Tasks.Mostrar();
            }
            Close();
        }
        public void UpdateCombo()
        {
            List<string> strListCombo = new List<string>();
            listCombo.ForEach(t => strListCombo.Add(t.Name));

            BindingOperations.SetBinding(CategoryCombo, ItemsControl.ItemsSourceProperty, new Binding
            {
                Source = strListCombo
            });
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
