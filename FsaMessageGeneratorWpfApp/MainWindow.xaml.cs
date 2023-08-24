using FsaMessageDomain;
using FsaMessageGeneratorLib;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace FsaMessageGeneratorWpfApp
{
    public partial class MainWindow : Window
    {
        Config _config;

        public MainWindow()
        {
            InitializeComponent();
            _config = GetConfig();
        }

        Config GetConfig()
        {
            Config? config = null;

            try
            {
                config = ConfigProvider.GetConfig("config.json");
            }
            catch (FileNotFoundException)
            {
                ShowErrorMessage("config.json not found");
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }

            return config ?? new Config(Array.Empty<ApprovedEmployee>());
        }

        void FgisApplicationPathButton_Click(object sender, RoutedEventArgs e)
        {
            var path = ChooseFileToRead();
            if (!string.IsNullOrEmpty(path))
                FgisApplicationPathTextBox.Text = path;
        }

        void FgisProtocolPathButton_Click(object sender, RoutedEventArgs e)
        {
            var path = ChooseFileToRead();
            if (!string.IsNullOrEmpty(path))
                FgisProtocolPathTextBox.Text = path;
        }

        void FsaMessagePathButton_Click(object sender, RoutedEventArgs e)
        {
            var path = ChooseFileToWrite();
            if (!string.IsNullOrEmpty(path))
                FsaMessagePathTextBox.Text = path;
        }

        string ChooseFileToRead()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            return dialog.ShowDialog() == true
                ? dialog.FileName
                : string.Empty;
        }

        string ChooseFileToWrite()
        {
            var dialog = new SaveFileDialog
            {
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            return dialog.ShowDialog() == true
                ? dialog.FileName
                : string.Empty;
        }

        void GenerateFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (GenerateFile())
                ShowInfoMessage("Файл успешно сформирован");
        }

        bool GenerateFile()
        {
            var config = new FsaMessageGeneratorLib.Config(
                FgisApplicationPathTextBox.Text,
                FgisProtocolPathTextBox.Text,
                FsaMessagePathTextBox.Text,
                _config.Employees);
            var generator = new FsaMessageGenerator(config);

            try
            {
                generator.CreateMessage();
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }

            return false;
        }

        void ShowErrorMessage(string message)
        {
            InfoTextBox.Text = "Что-то пошло не так..."
                + Environment.NewLine
                + message;
        }

        void ShowInfoMessage(string message)
        {
            InfoTextBox.Text = message;
        }
    }
}
