using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            list = unitOfWork.Tasks.Mostrar();


            //Aqui tienes un ejemplo aunque es un poco trampa
            //primero en la línea 19 saco las tareas de la base de datos - si no hay ninguna es posible que te de error
            // porque el método del repo devuelva null - se debería comprobar en ese método si no hay tareas y que devuelva una
            //lista vacía.
            //Luego para hacer el binding lo he hecho pasando los datos a una lista de strings que solo lleva el nombre
            // de la tarea. Se puede hacer con la lista de objetos - en este link te dice cómo lo hacen
            // habría que hacer una plantilla  -- https://stackoverflow.com/questions/449410/programmatically-binding-list-to-listbox
            // y tmb se puede hacer de esta otra manera:  https://stackoverflow.com/questions/9368506/wpf-listbox-binding
            List<string> strListTask = new List<string>();
            list.ForEach(t => strListTask.Add(t.Name));

            BindingOperations.SetBinding(List1, ItemsControl.ItemsSourceProperty, new Binding
            {
                Source = strListTask
            });


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