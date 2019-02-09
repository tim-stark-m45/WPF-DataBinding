using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_DataBinding_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string myText = "Hello world!";
        public string MyText {get => myText;  set => Set(ref myText, value); }

        private int myFontSize = 30;
        public int MyFontSize{ get => myFontSize; set => Set(ref myFontSize, value);}

        public void Set<T>(ref T field, T value, [CallerMemberName]string prop = "")
        {
            field = value;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(MyText);
            MyText = "Test";
        }

        private void OnPlusClick(object sender, RoutedEventArgs e)
        {
            MyFontSize++;
        }

        private void OnMinusClick(object sender, RoutedEventArgs e)
        {
            MyFontSize--;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName]string prop = "") =>
        //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
