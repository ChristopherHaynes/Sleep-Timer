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
using System.Timers;
using System.Diagnostics;

namespace SleepTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer countdownTimer;
        Timer secondTimer;
        int millisecondsTime;

        public MainWindow()
        {
            InitializeComponent();
            millisecondsTime = 0;
            countdownTimer = new Timer();
            secondTimer = new Timer();
            UpdateUI();
        }

        private void SetTimer(int time)
        {
            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                countdownTimer.Stop();
                countdownTimer.Dispose();
                secondTimer.Stop();
                secondTimer.Dispose();
            }

            if (millisecondsTime > 1000)
            {
                countdownTimer = new Timer(time);
                countdownTimer.Elapsed += ShutdownPC;
                countdownTimer.Start();

                secondTimer = new Timer(1000);
                secondTimer.Elapsed += SecondPassed;
                secondTimer.Enabled = true;
            }
        }

        private void SecondPassed(Object source, ElapsedEventArgs e)
        {
            if (millisecondsTime > 1000)
            {
                millisecondsTime -= 1000;
            }
            else
            {              
                secondTimer.Stop();
                millisecondsTime = 0;               
            }
            UpdateUI();
        }

        private void ShutdownPC(Object source, ElapsedEventArgs e)
        {
            countdownTimer.Stop();
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
            //Console.WriteLine("SHUTDOWN STARTS");
        }

        private String MillisecondsToTimeString(int milliseconds)
        {
            String result = "";

            int hours = milliseconds / 3600000;
            int remainder = milliseconds - (hours * 3600000);

            int minutes = remainder / 60000;
            remainder -= minutes * 60000;

            int seconds = remainder / 1000;

            result = hours.ToString("D2") + ":" +
                     minutes.ToString("D2") + ":" +
                     seconds.ToString("D2");

            return result;
        }

        private void UpdateUI ()
        {
            this.Dispatcher.Invoke(() =>
            {
                lblClock.Content = MillisecondsToTimeString(millisecondsTime);

                if (millisecondsTime >= 1800000)
                {
                    lblClock.Foreground = Brushes.DarkGreen;
                }
                else if (millisecondsTime < 1800000 && millisecondsTime >= 600000)
                {
                    lblClock.Foreground = Brushes.Orange;
                }
                else if (millisecondsTime < 600000)
                {
                    lblClock.Foreground = Brushes.DarkRed;
                }

                if (millisecondsTime > 0) btnStart.IsEnabled = true;
                else btnStart.IsEnabled = false;

                if (countdownTimer.Enabled && millisecondsTime > 0)
                {
                    grdMain.Background = new SolidColorBrush(Color.FromRgb(139, 170, 139));
                }
                else
                {
                    grdMain.Background = new SolidColorBrush(Color.FromRgb(170, 139, 139));
                }
            });
        }
        
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            SetTimer(millisecondsTime);
            UpdateUI();
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if (countdownTimer.Enabled)
            {
                countdownTimer.Stop();
            }
            if (secondTimer.Enabled)
            {
                secondTimer.Stop();
            }
            UpdateUI();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime = 0;

            if (countdownTimer.Enabled)
            {
                countdownTimer.Stop();
            }
            if (secondTimer.Enabled)
            {
                secondTimer.Stop();
            }

            UpdateUI();
        }

        private void BtnHourTenUp_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime += 36000000;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnHourTenDown_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime -= 36000000;
            if (millisecondsTime < 1000) millisecondsTime = 0;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnHourUnitUp_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime += 3600000;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnHourUnitDown_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime -= 3600000;
            if (millisecondsTime < 1000) millisecondsTime = 0;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnMinuteTenUp_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime += 600000;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnMinuteTenDown_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime -= 600000;
            if (millisecondsTime < 1000) millisecondsTime = 0;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnMinuteUnitUp_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime += 60000;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnMinuteUnitDown_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime -= 60000;
            if (millisecondsTime < 1000) millisecondsTime = 0;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnSecondTenUp_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime += 10000;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnSecondTenDown_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime -= 10000;
            if (millisecondsTime < 1000) millisecondsTime = 0;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnSecondUnitUp_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime += 1000;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }

        private void BtnSecondUnitDown_Click(object sender, RoutedEventArgs e)
        {
            millisecondsTime -= 1000;
            if (millisecondsTime < 1000) millisecondsTime = 0;
            UpdateUI();

            if (countdownTimer.Enabled && secondTimer.Enabled)
            {
                SetTimer(millisecondsTime);
            }
        }
    }
}
