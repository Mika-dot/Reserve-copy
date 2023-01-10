using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideoWatcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            System.Windows.Threading.DispatcherTimer dispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer2.Tick += new EventHandler(dispatcherTimer_Tick2);
            dispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer2.Start();

            MainSlider.AddHandler(MouseLeftButtonDownEvent,
                      new MouseButtonEventHandler(MainSlider_MouseDown),
                      true);
            MainSlider.AddHandler(MouseLeftButtonUpEvent,
                      new MouseButtonEventHandler(MainSlider_MouseUp),
                      true);
        }

        TimeSpan TimeA = TimeSpan.MinValue;
        TimeSpan TimeB = TimeSpan.MinValue;

        Brush OrigBrush = new SolidColorBrush(Color.FromArgb(255, 221, 221, 221));
        Brush BrushBlue = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
        Brush BrushRed = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

        bool SliderHovered = false, Fullscreen = false;
        string ss(int n) => n < 10 ? ("0" + n) : n.ToString();
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (videoPlayer != null && videoPlayer.IsLoaded && !SliderHovered) MainSlider.Value = videoPlayer.Position.TotalSeconds;
        }
        private void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            if (videoPlayer != null && videoPlayer.IsLoaded)
            {
                if (TimeA != TimeSpan.MinValue)
                {
                    if (videoPlayer.Position < TimeA) videoPlayer.Position = TimeA;
                }
                if (TimeB != TimeSpan.MinValue)
                {
                    if (videoPlayer.Position >= TimeB)
                    {
                        if ((bool)isLoop.IsChecked)
                        {
                            videoPlayer.Position = TimeA;
                            videoPlayer.Play();
                        }
                        else
                        {
                            videoPlayer.Pause();
                            videoPlayer.Position = TimeB;
                        }
                    }
                }
            }
        }
        private void MainSlider_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SliderHovered = true;
        }
        private void MainSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var dtv = MainSlider.Value;
            var dt = TimeSpan.FromSeconds(dtv);
            currentTime.Content = ss(dt.Hours) + ":" + ss(dt.Minutes) + ":" + ss(dt.Seconds);
            videoPlayer.Position = dt;
            SliderHovered = false;
        }
        private void MainSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var dtv = MainSlider.Value;
            var dt = TimeSpan.FromSeconds(dtv);
            currentTime.Content = ss(dt.Hours) + ":" + ss(dt.Minutes) + ":" + ss(dt.Seconds);
        }
        string filenameLast = "";
        void openFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mp4";
            dlg.Filter = "MP4 Files (*.mp4)|*.mp4";
            bool result = dlg.ShowDialog().Value;
            if (result == true)
            {
                string filename = dlg.FileName;
                fileName.Content = filename;
                videoPlayer.Source = new Uri(filename);
                filenameLast = filename;
                videoPlayer.Play();
            }
        }

        void videoPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            speedSlider.Value = 1;
            totalTime.Content = videoPlayer.NaturalDuration.ToString();
            MainSlider.Maximum = videoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            AX_Click(null, null);
            BX_Click(null, null);
            MainSlider.Value = 0;
            currentTime.Content = "00:00:00";

            if (File.Exists(filenameLast + ".inf"))
            {
                var ss = File.ReadAllLines(filenameLast + ".inf");

                TimeA = TimeSpan.Parse(ss[0]);
                A.Background = BrushBlue;
                AGUI.Width = 3;
                Canvas.SetLeft(AGUI, Canvas.GetLeft(MainSlider) + (MainSlider.Width) * (TimeA.TotalSeconds / videoPlayer.NaturalDuration.TimeSpan.TotalSeconds));

                TimeB = TimeSpan.Parse(ss[1]);
                B.Background = BrushRed;
                BGUI.Width = 3;
                Canvas.SetLeft(BGUI, Canvas.GetLeft(MainSlider) + (MainSlider.Width) * (TimeB.TotalSeconds / videoPlayer.NaturalDuration.TimeSpan.TotalSeconds));

                speedSlider.Value = double.Parse(ss[2]);

                isLoop.IsChecked = ss[3] == "1";

                XM = float.Parse(ss[4]);
                YM = float.Parse(ss[5]);
                XO = float.Parse(ss[6]);
                YO = float.Parse(ss[7]);

                videoPlayer.Width = MainCanvas.Width * XM;
                videoPlayer.Height = MainCanvas.Height * YM;
                Canvas.SetLeft(videoPlayer, XO);
                Canvas.SetTop(videoPlayer, YO);
            }

        }

        void Save(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(filenameLast + ".inf", new[]
            {
                TimeA.ToString(),
                TimeB.ToString(),
                speedSlider.Value.ToString(),
                (bool)isLoop.IsChecked ? "1" : "0",
                XM.ToString(),
                YM.ToString(),
                XO.ToString(),
                YO.ToString()
            });
        }

        void Play(object sender, RoutedEventArgs e) => videoPlayer.Play();
        void Pause(object sender, RoutedEventArgs e) => videoPlayer.Pause();
        void Stop(object sender, RoutedEventArgs e) => videoPlayer.Stop();
        private void resetSpeed(object sender, RoutedEventArgs e) => speedSlider.Value = 1;

        private void speedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (videoPlayer != null && videoPlayer.IsLoaded)
            {
                videoPlayer.SpeedRatio = speedSlider.Value;
                speedLabel.Content = speedSlider.Value.ToString();
            }
        }

        private void videoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if ((bool)isLoop.IsChecked)
            {
                videoPlayer.Stop();
                videoPlayer.Play();
            }
        }

        void makeScreenshot(object sender, RoutedEventArgs e)
        {
            if (videoPlayer != null && videoPlayer.IsLoaded)
            {
                int width = videoPlayer.NaturalVideoWidth;
                int height = videoPlayer.NaturalVideoHeight;
                var bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
                var vb = new VisualBrush(videoPlayer);
                DrawingVisual dv = new DrawingVisual();
                using (DrawingContext dc = dv.RenderOpen())
                {
                    dc.DrawRectangle(vb, null, new Rect(new Size(width, height)));
                }
                bitmap.Render(dv);
                JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                jpg.Frames.Add(BitmapFrame.Create(bitmap));
                using (Stream stm = File.Create("Screenshot.jpg"))
                {
                    jpg.Save(stm);
                }
            }
        }


        private void A_Click(object sender, RoutedEventArgs e)
        {
            TimeA = videoPlayer.Position;
            A.Background = BrushBlue;
            AGUI.Width = 3;
            Canvas.SetLeft(AGUI, Canvas.GetLeft(MainSlider) + (MainSlider.Width) * (videoPlayer.Position.TotalSeconds / videoPlayer.NaturalDuration.TimeSpan.TotalSeconds));
        }
        private void AX_Click(object sender, RoutedEventArgs e)
        {
            TimeA = TimeSpan.MinValue;
            A.Background = OrigBrush;
            AGUI.Width = 0;
        }
        private void B_Click(object sender, RoutedEventArgs e)
        {
            TimeB = videoPlayer.Position;
            B.Background = BrushRed;
            BGUI.Width = 3;
            Canvas.SetLeft(BGUI, Canvas.GetLeft(MainSlider) + (MainSlider.Width) * (videoPlayer.Position.TotalSeconds / videoPlayer.NaturalDuration.TimeSpan.TotalSeconds));
        }
        private void BX_Click(object sender, RoutedEventArgs e)
        {
            TimeB = TimeSpan.MinValue;
            B.Background = OrigBrush;
            BGUI.Width = 0;
        }

        float XM = 1, YM = 1;
        float XO = 0, YO = 0;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (videoPlayer != null && videoPlayer.IsLoaded)
            {
                switch (e.Key)
                {
                    case Key.NumPad6:
                        {
                            XM += 0.1f;
                            break;
                        }
                    case Key.NumPad4:
                        {
                            XM -= 0.1f;
                            if (XM < 0) XM = 0;
                            break;
                        }
                    case Key.NumPad8:
                        {
                            YM += 0.1f;
                            break;
                        }
                    case Key.NumPad2:
                        {
                            YM -= 0.1f;
                            if (YM < 0) YM = 0;
                            break;
                        }
                    case Key.NumPad9:
                        {
                            XO += 50f;
                            break;
                        }
                    case Key.NumPad3:
                        {
                            XO -= 50f;
                            break;
                        }
                    case Key.NumPad7:
                        {
                            YO += 50f;
                            break;
                        }
                    case Key.NumPad1:
                        {
                            YO -= 50f;
                            break;
                        }
                    case Key.NumPad5:
                        {
                            XM = 1;
                            YM = 1;
                            XO = 0;
                            YO = 0;
                            break;
                        }
                    case Key.F12:
                        {
                            if (Fullscreen)
                            {
                                this.WindowStyle = WindowStyle.SingleBorderWindow;
                                this.WindowState = WindowState.Normal;
                                MainCanvas.Width = 613;
                                MainCanvas.Height = 335;
                                //videoPlayer.Width = MainCanvas.Width * XM;
                                //videoPlayer.Height = MainCanvas.Height * YM;
                                Canvas2.Visibility = Canvas3.Visibility = Canvas4.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                this.WindowStyle = WindowStyle.None;
                                this.WindowState = WindowState.Maximized;
                                MainCanvas.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                                MainCanvas.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                                //videoPlayer.Width = MainCanvas.Width * XM;
                                //videoPlayer.Height = MainCanvas.Height * YM;
                                Canvas2.Visibility = Canvas3.Visibility = Canvas4.Visibility = Visibility.Collapsed;
                            }
                            Fullscreen = !Fullscreen;
                            break;
                        }
                }
                videoPlayer.Width = MainCanvas.Width * XM;
                videoPlayer.Height = MainCanvas.Height * YM;
                Canvas.SetLeft(videoPlayer, XO);
                Canvas.SetTop(videoPlayer, YO);
                /*
                */
                //MessageBox.Show(XM + " " + YM);
                //videoPlayer.ClipToBounds = true;
                //videoPlayer. = 613 * XM;
                //videoPlayer.Clip = new RectangleGeometry(new Rect(0, 0, 613 * XM, 335 * YM));
                //MessageBox.Show(videoPlayer.Clip.Bounds.ToString());
            }
        }
    }
}
