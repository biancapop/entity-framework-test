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
    /// Lógica de interacción para CategoryAdd.xaml
    /// </summary>
    public partial class CategoryAdd : Window
    {
        UnitOfWork unitOfWork;
        List<Category> listaCombo;
        public CategoryAdd(List<Category> listCombo)
        {
            unitOfWork = new UnitOfWork();
            InitializeComponent();
            listaCombo = listCombo;
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            Category category = new Category();
            category.Name = CategoryText.Text.ToString();
            var comp = unitOfWork.Categories.SearchCategory(category.Name);

            if (comp == null)
            {
                unitOfWork.Categories.Create(category);
                listaCombo.Add(category);
                comp = unitOfWork.Categories.SearchCategory(category.Name);
                if (comp != null)
                {
                    MessageBox.Show("La categoría ha sido añadida con éxito");
                    Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error durante el proceso, por favor, vuelve a intentarlo");
                }
            }
            else
            {
                MessageBox.Show("La categoría que intentas crear ya existe en el contexto actual");
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
