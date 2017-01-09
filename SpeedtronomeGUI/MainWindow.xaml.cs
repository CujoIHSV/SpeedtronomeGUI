using Speedtronome;

using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace SpeedtronomeGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Metronome metronome;

        public MainWindow()
        {
            metronome = null;
            InitializeComponent();
        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WAV Files|*.wav";
            if (openFileDialog.ShowDialog() ?? false)
            {
                textBox_soundFile.Text = openFileDialog.FileName;
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            bool bpmChecked = radio_bpm.IsChecked ?? false;
            bool fpbChecked = radio_fpb_fps.IsChecked ?? false;
            bool defaultChecked = radio_defaultSound.IsChecked ?? false;
            bool customChecked = radio_customSound.IsChecked ?? false;

            if (bpmChecked)
            {
                if (defaultChecked)
                {
                    try
                    {
                        metronome = new Metronome(Convert.ToDouble(textBox_bpm.Text));
                        metronome.Oscillate();
                    }
                    catch (FormatException rateExcept)
                    {
                        MessageBox.Show("Error: You must specify a rate for the metronome to tick", 
                            "Invalid Tick Rate",
                            MessageBoxButton.OK, 
                            MessageBoxImage.Error);
                    }
                }
                else if (customChecked)
                {
                    try
                    {
                        metronome = new Metronome(Convert.ToDouble(textBox_bpm.Text), textBox_soundFile.Text);
                        metronome.Oscillate();
                    }
                    catch (UriFormatException uriExcept)
                    {
                        MessageBox.Show("Error: Sound file not found",
                            "File Not Found",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    catch (FileNotFoundException fnfExcept)
                    {
                        MessageBox.Show("Error: Sound file not found",
                            "File Not Found",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }

                    catch (FormatException rateExcept)
                    {
                        MessageBox.Show("Error: You must specify a rate for the metronome to tick",
                            "Invalid Tick Rate",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
            else if (fpbChecked)
            {
                if (defaultChecked)
                {
                    try
                    {
                        metronome = new Metronome(Convert.ToInt32(textBox_fpb.Text),
                            Convert.ToDouble(textBox_fps.Text));
                        metronome.Oscillate();
                    }
                    catch (FormatException rateExcept)
                    {
                        MessageBox.Show("Error: You must specify a rate for the metronome to tick",
                            "Invalid Tick Rate",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
                else if (customChecked)
                {
                    try
                    {
                        metronome = new Metronome(Convert.ToInt32(textBox_fpb.Text), 
                            Convert.ToDouble(textBox_fps.Text),
                            textBox_soundFile.Text);
                        metronome.Oscillate();
                    }
                    catch (UriFormatException uriExcept)
                    {
                        MessageBox.Show("Error: Sound file not found",
                            "File Not Found",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    catch (FileNotFoundException fnfExcept)
                    {
                        MessageBox.Show("Error: Sound file not found",
                            "File Not Found",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    catch (FormatException rateExcept)
                    {
                        MessageBox.Show("Error: You must specify a rate for the metronome to tick",
                            "Invalid Tick Rate",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            if (metronome != null)
            {
                metronome.Halt();
            }
        }
    }
}
