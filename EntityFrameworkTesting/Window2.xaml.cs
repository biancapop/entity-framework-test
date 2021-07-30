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
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditarWPF editarWPF = new EditarWPF();
            editarWPF.CategoryCombo.SelectedItem = CategoryBlock.Content;
            editarWPF.ContentBlock.Text = ContentBlock.Content.ToString();
            editarWPF.NameBlock.Text = NameBlock.Content.ToString();
            editarWPF.IdBlock.Text = IdBlock.Content.ToString();
            editarWPF.Show();
            Close();
        }
    }
}