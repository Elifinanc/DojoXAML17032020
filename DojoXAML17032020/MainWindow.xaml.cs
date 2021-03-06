﻿using System;
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
using System.IO;
using Microsoft.Win32;

namespace DojoXAML17032020
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewfile(object sender, RoutedEventArgs e)
        {
            string message = "Do you want to save your work?";
            string title = "Save your work";
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SaveFile_Click(sender, e);
                txtBox.Text = "";
            }
            else
            {
                txtBox.Text = "";
            }
        }

        private void btnOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                txtBox.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, txtBox.Text);
        }

        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            string textData = txtBox.SelectedText;
            Clipboard.SetData(DataFormats.Text, (Object)textData);
        }

        private void PasteFromClipboard_Click(object sender, RoutedEventArgs e)
        {
            int debut = txtBox.SelectionStart;
            txtBox.Text = txtBox.Text.Substring(0, debut) + Clipboard.GetText() + txtBox.Text.Substring(debut, txtBox.Text.Length - debut);
            
        }

    }
}
