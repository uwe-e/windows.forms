using BSE.Wpf.Windows.Controls.ImageFlow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BSE.Wpf.Windows.Test
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static readonly DependencyProperty ImageDirecoryProperty
            = DependencyProperty.Register("ImageDirecory", typeof(DirectoryInfo), typeof(DirectoryInfo), null);
        
        public DirectoryInfo ImageDirecory
        {
            get
            {
                return (DirectoryInfo)this.GetValue(ImageDirecoryProperty);
            }
            set
            {
                this.SetValue(ImageDirecoryProperty, value);
                this.OnImageDirectoryChanged(EventArgs.Empty);
            }
        }
        
        public Window1()
        {
            InitializeComponent();
            this.imageFlowPanel1.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 38, 43, 63));
        }

        private void OnImageDirectoryChanged(System.EventArgs e)
        {
            if (this.ImageDirecory != null && this.ImageDirecory.Exists == true)
            {
                this.textBox1.Text = this.ImageDirecory.FullName;
                List<ImageFlowItemFromFileInfo> imageFlowItems
                    = (from FileInfo fileInfo in this.ImageDirecory.GetFiles("*.jpg")
                       select new ImageFlowItemFromFileInfo
                            {
                                FileInfo = fileInfo,
                            }).ToList();

                this.imageFlowPanel1.ItemsSource = imageFlowItems;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.ImageDirecory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            }
        }

        private void imageFlowPanel1_SelectedItemMouseDown(object sender, ImageFlowItemMouseEventArgs e)
        {

        }

        private void imageFlowPanel1_SelectedItemMouseDoubleClick(object sender, ImageFlowItemMouseEventArgs e)
        {

        }

        private void textBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
