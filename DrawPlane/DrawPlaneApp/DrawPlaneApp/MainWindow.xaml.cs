using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawPlaneApp
{
    public partial class MainWindow : Window
    {
        public bool mClicked;
        public bool lineClicked;
        public bool rectangleClicked;
        public bool eraseClicked;
        public bool circleClicked;
        public Point prePosition;
        public Line line;
        public Rectangle temprectangle;
        public Rectangle myrectangle;
        public Ellipse myellipse;
        public Ellipse tempellipse;
        public Brush myBrush; 

        public MainWindow()
        {
            InitializeComponent();
            mClicked = false;
            lineClicked = true;
            rectangleClicked = false;
            circleClicked = false;
            eraseClicked = false;
            myBrush = new SolidColorBrush(Colors.Black);
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mClicked = true;
            prePosition = e.GetPosition(canvas); // 지정된 요소를 기준으로 마우스 포인터의 상대적인 위치를 반환
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var nowPosition = e.GetPosition(canvas);
            if (mClicked)
            {
                if (lineClicked)
                {
                    line = new Line();
                    line.X1 = prePosition.X;
                    line.X2 = nowPosition.X;
                    line.Y1 = prePosition.Y;
                    line.Y2 = nowPosition.Y;
                    line.Stroke = myBrush;
                    line.StrokeThickness = 2;
                    canvas.Children.Add(line);

                    prePosition = nowPosition;
                }

                // 사각형그리기
                else if (rectangleClicked)
                {
                    if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
                    {
                        myrectangle = new Rectangle();

                        myrectangle.Stroke = Brushes.Plum;
                        myrectangle.Fill = myBrush;
                        myrectangle.Opacity = 0.8;

                        double left = prePosition.X;
                        double top = prePosition.Y;

                        double width = nowPosition.X - prePosition.X;
                        double height = nowPosition.Y - prePosition.Y;

                        if (nowPosition.X < prePosition.X)
                        {
                            left = nowPosition.X;
                            width *= -1;
                        }
                        if (nowPosition.Y < prePosition.Y)
                        {
                            top = nowPosition.Y;
                            height *= -1;
                        }

                        myrectangle.Margin = new Thickness(left, top, 0, 0);
                        myrectangle.Width = width;
                        myrectangle.Height = height;

                        canvas.Children.Remove(temprectangle);
                        temprectangle = myrectangle;
                        canvas.Children.Add(myrectangle);
                    }
                    else
                    {
                        temprectangle = null;
                    }
                }

                else if (circleClicked)
                {
                    if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
                    {
                        myellipse = new Ellipse();

                        myellipse.Fill = myBrush;
                        myellipse.StrokeThickness = 2;
                        myellipse.Stroke = Brushes.LightSkyBlue;
                        myellipse.Opacity = 0.8;

                        double width = nowPosition.X - prePosition.X;
                        double height = nowPosition.Y - prePosition.Y;

                        double left = prePosition.X;
                        double top = prePosition.Y;

                        if (nowPosition.X < prePosition.X)
                        {
                            left = nowPosition.X;
                            width *= -1;
                        }
                        if (nowPosition.Y < prePosition.Y)
                        {
                            top = nowPosition.Y;
                            height *= -1;
                        }

                        myellipse.Margin = new Thickness(left, top, 0, 0);
                        myellipse.Width = width;
                        myellipse.Height = height;

                        canvas.Children.Remove(tempellipse);
                        tempellipse = myellipse;
                        canvas.Children.Add(myellipse);
                    }
                    else
                    {
                        tempellipse = null;
                    }
                        
                }


                else if (eraseClicked)
                {
                    tempellipse = new Ellipse();

                    if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
                    {
                        myellipse = new Ellipse();
                        myellipse.Fill = new SolidColorBrush(Colors.White); 
                        myellipse.StrokeThickness = 2;
                        myellipse.Opacity = 1.0;

                        double width = nowPosition.X - prePosition.X;
                        double height = nowPosition.Y - prePosition.Y;

                        double left = prePosition.X;
                        double top = prePosition.Y;

                        if (nowPosition.X < prePosition.X)
                        {
                            left = nowPosition.X;
                            width *= -1;
                        }
                        if (nowPosition.Y < prePosition.Y)
                        {
                            top = nowPosition.Y;
                            height *= -1;
                        }

                        myellipse.Margin = new Thickness(left, top, 0, 0);
                        myellipse.Width = width;
                        myellipse.Height = height;

                        canvas.Children.Remove(tempellipse);
                        tempellipse = myellipse;
                        canvas.Children.Add(myellipse);
                    }
                    else
                        tempellipse = null;
                }

            }
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mClicked = false;
            temprectangle = null;
            tempellipse = null;
        }

        private void canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void button_line_Click(object sender, RoutedEventArgs e)
        {
            lineClicked = true;
            rectangleClicked = false;
            eraseClicked = false;
            circleClicked = false;
        }

        private void button_circle_Click(object sender, RoutedEventArgs e)
        {
            lineClicked = false;
            rectangleClicked = false;
            eraseClicked = false;
            circleClicked = true;
        }

        private void button_rectangle_Click(object sender, RoutedEventArgs e)
        {
            lineClicked = false;
            rectangleClicked = true;
            eraseClicked = false;
            circleClicked = false;
        }

        private void button_erase_Click(object sender, RoutedEventArgs e)
        {
            lineClicked = false;
            rectangleClicked = false;
            eraseClicked = true;
            circleClicked = false;
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
            canvas.Children.Clear();
            canvas.Background = Brushes.Transparent;
        }

        private void color_black_Click(object sender, RoutedEventArgs e)
        {
            myBrush = new SolidColorBrush(Colors.Black);
        }

        private void color_red_Click(object sender, RoutedEventArgs e)
        {
            myBrush = new SolidColorBrush(Colors.Red);
        }

        private void color_blue_Click(object sender, RoutedEventArgs e)
        {
            myBrush = new SolidColorBrush(Colors.Blue);
        }

        private void color_green_Click(object sender, RoutedEventArgs e)
        {
            myBrush = new SolidColorBrush(Colors.Green);
        }

        private void color_yellow_Click(object sender, RoutedEventArgs e)
        {
            myBrush = new SolidColorBrush(Colors.Yellow);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
