using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] imagePaths;
        private int currentIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            imagePaths = Directory.GetFiles(folderPath, "*.jpg");
            LoadImage(currentIndex);

            imageInfo.FontSize = 16;
            imageInfo.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void LoadImage(int index)
        {
            if (index >= 0 && index < imagePaths.Length)
            {
                BitmapImage image = new BitmapImage(new Uri(imagePaths[index]));
                imageControl.Source = image;

                BitmapImage mirroredImage = new BitmapImage(new Uri(imagePaths[index]));
                mirrorImage.Source = mirroredImage;

                string imageName = System.IO.Path.GetFileName(imagePaths[index]);
                imageInfo.Text = $"Image: {imageName}\nPosition: {index + 1} / {imagePaths.Length}";
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                LoadImage(currentIndex);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < imagePaths.Length - 1)
            {
                currentIndex++;
                LoadImage(currentIndex);
            }
        }
    }
}
