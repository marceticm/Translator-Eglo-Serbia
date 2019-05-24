using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Prevod_za_carinu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnRestart.Visibility = Visibility.Hidden;
            loadingAnimation.Visibility = Visibility.Hidden;
            lblObrada.Visibility = Visibility.Hidden;
        }

        private string fileName;

        private async void BtnUvuciteFakturu_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() ?? false)
            {
                fileName = openFileDialog1.FileName;

                if (fileName.Substring(fileName.Length - 4) != ".csv")
                {
                    MessageBox.Show("Greska: Niste odabrali .CSV fajl");
                    return;
                }
            }
            Task task = new Task(() => Translation(fileName));
            task.Start();
            btnUvuciteFakturu.Visibility = Visibility.Hidden;
            loadingAnimation.Visibility = Visibility.Visible;
            lblObrada.Visibility = Visibility.Visible;
            await task;
            lblObrada.Visibility = Visibility.Hidden;
            loadingAnimation.Visibility = Visibility.Hidden;
            MessageBox.Show("Operacija uspela!\nPrevod je sacuvan.");
            btnRestart.Visibility = Visibility.Visible;
        }

        public void Translation(string fileName)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;
            Workbook wb = excel.Workbooks.Add();
            var brRedova = 1;
            // staviti exception ako je fajl otvoren i ako je empty path name

            try
            {
                using (var reader = new StreamReader(fileName, Encoding.UTF8))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(new char[] { ';' });
                        var valuesExtended = new string[values.Length + 1];
                        for (int i = 0; i < 4; i++)
                        {
                            valuesExtended[i] = values[i];
                        }
                        var opis = values[3];
                        var sifra = values[2];
                        valuesExtended[4] = "";
                        for (int i = 5; i < valuesExtended.Length; i++)
                        {
                            valuesExtended[i] = values[i - 1];
                        }
                        if (sifra.Contains("GL") || sifra.Contains("KAB") || sifra.Contains("KAT"))
                        {
                            valuesExtended[4] = Prevodi.PrevodPoSifri(sifra);
                        }
                        else
                        {
                            valuesExtended[4] = Prevodi.PrevodPoOpisu(opis);
                        }
                        for (int i = 1; i <= valuesExtended.Count(); i++)
                        {
                            excel.Cells[brRedova, i].Value2 = valuesExtended[i - 1];
                        }
                        brRedova++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Doslo je do greske.\nProverite da li je fajl otvoren i ako jeste zatvorite ga." +
                        "\nAplikacija ce se restartovati.", "UPOZORENJE!");
                System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
                this.Dispatcher.Invoke(() =>
                {
                    System.Windows.Application.Current.Shutdown();
                });
            }


            excel.Cells[1, 1].EntireRow.Font.Bold = true;
            excel.Columns.AutoFit();
            wb.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + @"\Prevod " + DateTime.Now.ToShortDateString() + ".xlsx");
            wb.Close();
            excel.Quit();
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }
    }
}
