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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThinkLib;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Turtle Tess;
        Turtle Alex;
        Turtle bug;

        public MainWindow()
        {
            InitializeComponent();
            Tess = new Turtle(playground);
            Alex = new Turtle(playground, 50, 100);

            Alex.BodyBrush = Brushes.Blue;
            Alex.LineBrush = Brushes.Blue;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Tess.SetAppearance(new LineGeometry(new Point(0, 0), new Point(20, 0)), Brushes.Pink, Brushes.Pink);

            


            Tess.Reset();
            Tess.WarpTo(200, 200);
            


            for (int i = 0; i < 5; i++)   // A five-sided regular polygon is called a pentagon.
            {
                bug = new Turtle(playground, Tess.Position.X, Tess.Position.Y);
                   

                Tess.Forward(100);
                Tess.Left(360 / 5);
            }

        }
        


    }
}
