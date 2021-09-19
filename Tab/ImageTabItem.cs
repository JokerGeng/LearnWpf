using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tab
{
    public class ImageTabItem: TabItem
    {
        static ImageTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageTabItem), new FrameworkPropertyMetadata(typeof(ImageTabItem)));
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageTabItem));

    }
}
