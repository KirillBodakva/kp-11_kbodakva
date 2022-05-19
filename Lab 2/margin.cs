using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace LABbb_2
{
    class bruh
    {
        public void SetMargin(Control con, int left = 0, int right = 0, int top = 0, int bottom = 0)
        {
            Thickness margin = con.Margin;
            margin.Left = left;
            margin.Right = right;
            margin.Top = top;
            margin.Bottom = bottom;
            con.Margin = margin;
        }
    }
}