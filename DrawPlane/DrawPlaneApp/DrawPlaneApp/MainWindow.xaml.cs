using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawPlaneApp
{
    public partial class MainWindow : Window
    {
        public bool mClicked = false;
        public bool lineClicked = false;
        public Point prePosition;
        public Brush mycolor = new LinearGradientBrush(
        Colors.Blue,
        Color.FromRgb(204, 204, 255),
        new Point(0, 0),
        new Point(1, 1));
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mClicked = true;
            prePosition = e.GetPosition(canvas);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var nowPosition = e.GetPosition(canvas);
            if (mClicked)
            {
                if (lineClicked)
                {
                    Line line = new Line();
                    line.X1 = prePosition.X;
                    line.X2 = nowPosition.X;
                    line.Y1 = prePosition.Y;
                    line.Y2 = nowPosition.Y;
                    line.Stroke = mycolor;
                    line.StrokeThickness = 2;
                    canvas.Children.Add(line);

                    prePosition = nowPosition;
                }
            }
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void button_line_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_circle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_rectangle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_erase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_fileopen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_jsonsave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_jsonload_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_paint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_allerase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void color_black_Click(object sender, RoutedEventArgs e)
        {

        }

        private void color_red_Click(object sender, RoutedEventArgs e)
        {

        }

        private void color_blue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void color_green_Click(object sender, RoutedEventArgs e)
        {

        }

        private void color_yellow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
