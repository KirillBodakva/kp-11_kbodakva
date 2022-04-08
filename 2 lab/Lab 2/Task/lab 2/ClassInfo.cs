using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace lab_2
{
    public partial class Info : Window
    {
        public Info()
        {
            Grid w4= new Grid();

            this.Content = w4;
            this.Settings(new Size(Height: 258, Width: 450));
            w4.AddLabel(size: new Size(Width: 280, Height: 100), margin: new Margin(), text: "Бодаква Кирил Ігорович\nКП-11\n2022", font_size: 18);

        }
    }
    public static class WPF
    {
        public static void Settings(this Window window, Size size,WindowStartupLocation startupLocation = WindowStartupLocation.CenterScreen,
                                                        ResizeMode resizeMode = ResizeMode.NoResize)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ResizeMode = ResizeMode.NoResize;
            window.Height = size.Height;
            window.Width = size.Width;
        }
        public static Label AddLabel(this Grid grid, Size size, Margin margin, string text, int fontsize = 15,
                                      HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center,
                                      VerticalAlignment verticalAlignment = VerticalAlignment.Center,
                                      HorizontalAlignment textA = HorizontalAlignment.Center)
        { //694
            Label a1 = new Label();
            grid.Children.Add(a1);
            a1.Content = text;
            size.Apply(a1);
            margin.Aply(a1);
            a1.FontSize = fontsize;
            a1.HorizontalAlignment = horizontalAlignment;
            a1.VerticalAlignment = verticalAlignment;
            return a1;
        }
        public static Button Button
    }
}
