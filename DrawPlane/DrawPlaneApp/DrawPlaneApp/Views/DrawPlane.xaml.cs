using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawPlaneApp.Views;

public partial class DrawPlane : Window
{
    private bool V_LeftMouseClick;
    private E_Click V_ClickState;
    private E_Color V_ColorState;
    private E_Mouse V_MouseState;
    private Point V_PrePosition;
    public DrawPlane()
    {
        InitializeComponent();
        V_LeftMouseClick = false;
        V_ClickState = E_Click.Line;
        V_ColorState = E_Color.Black;
        V_MouseState = E_Mouse.Normal;
    }

    private void e_canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // 좌클릭
    {
        V_LeftMouseClick = true;
        V_PrePosition = e.GetPosition(canvas);   
    }

    private void e_canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) // 좌클릭 해제
    {
        V_LeftMouseClick = false;
    }

    private void e_canvas_MouseMove(object sender, MouseEventArgs e) // 마우스 무브
    {
        Point nowPosition = e.GetPosition(canvas);

        if (V_LeftMouseClick)
        {
            switch (V_MouseState)
            {
                case E_Mouse.Normal:
                    break;
                case E_Mouse.Grap:
                    break;
                case E_Mouse.Draw:
                    Draw();
                    break;
            }
        }
    }

    private void e_canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e) // 우클릭
    {

    }

    private void e_canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {

    }

    private void e_colorChange(object sender, RoutedEventArgs e)
    {
        Button button = (Button)e.Source;
        string newColor = button.Name;
        string[] colorNames = Enum.GetNames(typeof(E_Color));

        for (int i = 0; i < colorNames.Length; ++i)
        {
            if (newColor == colorNames[i])
            {
                V_ColorState = (E_Color)i;
            }
        }
    }
    private void e_shapeChange(object sender, RoutedEventArgs e)
    {
        Button button = (Button)e.Source;
        string newShape = button.Name;
        string[] shapeNames = Enum.GetNames(typeof(E_Click));

        for (int i = 0; i < shapeNames.Length; ++i)
        {
            if (newShape == shapeNames[i])
            {
                V_ClickState = (E_Click)i;
            }
        }
    }

    private void Draw()
    {
        switch (V_ColorState) { }
    }

    private void CircleDraw()
    {

    }
}

enum E_Mouse
{
    Normal = 0,
    Draw,
    Grap
}
enum E_Click
{
    Line = 0,
    Circle,
    Rectangle,
    Erase
}
enum E_Color
{
    Black = 0,
    Red,
    Green,
    Blue,
    Yellow
}