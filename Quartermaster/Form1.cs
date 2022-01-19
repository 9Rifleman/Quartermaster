using System.Media;
using Excel = Microsoft.Office.Interop.Excel;

namespace Quartermaster
{
    public partial class Quartermaster : Form
    {
        public Quartermaster()
        {
            InitializeComponent();
        }

        int laptop1New;
        int laptop2New;
        int laptop1Old;
        int laptop2Old;
        int dock;
        int headset;
        int kbMouse;
        int twentyFourInch;
        int twentySevenInch;
        string ConfigFolderPath = "";
        private const string ConfigFile = @"\QMconfig.txt";
        string DataFolderPath = "";
        private const string DataFile = @"\QMsource.xls";
        // some comment
        private void AutoConfig()
        {
            ConfigFolderPath = Directory.GetCurrentDirectory();
            if (!File.Exists(ConfigFolderPath + ConfigFile))
            {
                MessageBox.Show("Please select a folder to save your inventory data. You can change it later at any time.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (dialogDataPath.ShowDialog() == DialogResult.OK)
                {
                    DataFolderPath = dialogDataPath.SelectedPath;
                }
                using (StreamWriter sw = File.CreateText(ConfigFolderPath + ConfigFile))
                {
                    sw.WriteLine(DataFolderPath);
                    if (File.Exists(DataFolderPath + DataFile))
                    {
                        ReadFromExcel();
                    }
                    else
                    {
                        MessageBox.Show("Save your changes to create it at your chosen location.", "Data file not found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            else if (File.Exists(ConfigFolderPath + ConfigFile))
            {
                using (StreamReader sr = File.OpenText(ConfigFolderPath + ConfigFile))
                {
                    DataFolderPath = sr.ReadLine();
                    if (File.Exists(DataFolderPath + DataFile))
                    {
                        EnableNums();
                        ReadFromExcel();
                        Task.Delay(100);
                        DisableNums();
                    }
                    else
                    {
                        MessageBox.Show("Save your changes to create it at your chosen location.", "Data file not found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }

        }
        private void WriteToExcel()
        {
            Excel.Application myexcelApplication = new Excel.Application();
            if (myexcelApplication != null)
            {
                Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Add();
                Excel.Worksheet myexcelWorksheet = (Excel.Worksheet)myexcelWorkbook.Sheets.Add();

                laptop1New = Convert.ToInt32(numLaptop1New.Value);
                myexcelWorksheet.Cells[1, 1] = laptop1New;
                laptop1Old = Convert.ToInt32(numLaptop1Old.Value);
                myexcelWorksheet.Cells[2, 1] = laptop1Old;
                laptop2New = Convert.ToInt32(numLaptop2New.Value);
                myexcelWorksheet.Cells[3, 1] = laptop2New;
                laptop2Old = Convert.ToInt32(numLaptop2Old.Value);
                myexcelWorksheet.Cells[4, 1] = laptop2Old;
                dock = Convert.ToInt32(numDock.Value);
                myexcelWorksheet.Cells[5, 1] = dock;
                headset = Convert.ToInt32(numHeadset.Value);
                myexcelWorksheet.Cells[6, 1] = headset;
                kbMouse = Convert.ToInt32(numKBMouse.Value);
                myexcelWorksheet.Cells[7, 1] = kbMouse;
                twentyFourInch = Convert.ToInt32(num24inch.Value);
                myexcelWorksheet.Cells[8, 1] = twentyFourInch;
                twentySevenInch = Convert.ToInt32(num27inch.Value);
                myexcelWorksheet.Cells[9, 1] = twentySevenInch;
                              
                myexcelApplication.ActiveWorkbook.SaveAs(@DataFolderPath + DataFile, Excel.XlFileFormat.xlWorkbookNormal);

                myexcelWorkbook.Close();
                myexcelApplication.Quit();
            }
        }

        private void ReadFromExcel()
        {
            Excel.Application myexcelApplication = new Excel.Application();
            if (myexcelApplication != null)
            {
                Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Open(@DataFolderPath + DataFile);
                Excel.Worksheet myexcelWorksheet = (Excel.Worksheet)myexcelWorkbook.Sheets[1];

                numLaptop1New.Value = Convert.ToInt32(myexcelWorksheet.Cells[1, 1].Value);
                numLaptop1Old.Value = Convert.ToInt32(myexcelWorksheet.Cells[2, 1].Value);
                numLaptop2New.Value = Convert.ToInt32(myexcelWorksheet.Cells[3, 1].Value);
                numLaptop2Old.Value = Convert.ToInt32(myexcelWorksheet.Cells[4, 1].Value);
                numDock.Value = Convert.ToInt32(myexcelWorksheet.Cells[5, 1].Value);
                numHeadset.Value = Convert.ToInt32(myexcelWorksheet.Cells[6, 1].Value);
                numKBMouse.Value = Convert.ToInt32(myexcelWorksheet.Cells[7, 1].Value);
                num24inch.Value = Convert.ToInt32(myexcelWorksheet.Cells[8, 1].Value);
                num27inch.Value = Convert.ToInt32(myexcelWorksheet.Cells[9, 1].Value);

                myexcelWorkbook.Close();
                myexcelApplication.Quit();
            }
        }

        private static void PlayChime()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }

        private static void PlayTada()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\tada.wav");
            simpleSound.Play();
        }

        private void EnableNums()
        {
            numLaptop1New.Enabled = true;
            numLaptop1Old.Enabled = true;
            numLaptop2New.Enabled = true;
            numLaptop2Old.Enabled = true;
            num24inch.Enabled = true;
            num27inch.Enabled = true;
            numDock.Enabled = true;
            numHeadset.Enabled = true;
            numKBMouse.Enabled = true;
        }

        private void DisableNums()
        {
            numLaptop1New.Enabled = false;
            numLaptop1Old.Enabled = false;
            numLaptop2New.Enabled = false;
            numLaptop2Old.Enabled = false;
            num24inch.Enabled = false;
            num27inch.Enabled = false;
            numDock.Enabled = false;
            numHeadset.Enabled = false;
            numKBMouse.Enabled = false;
        }

        private void CheckAllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            if(checkAllowEdit.Checked)
            {
                EnableNums();
                if(btnSave.Enabled == false)
                {
                    btnSave.Enabled = true;
                    btnSave.Text = "Save";
                }
            }
            else
            {
                DisableNums();
                btnSave.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            WriteToExcel();
            PlayChime();
            btnSave.Text = "Saved!";
            btnSave.Enabled = false;
            checkAllowEdit.Checked = false;
        }

        private void LblHiddenAuthor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PlayTada();
            MessageBox.Show("       Proudly made by Rifleman in 2022", "Credits", MessageBoxButtons.OK);
        }

        private void Quartermaster_Load(object sender, EventArgs e)
        {
            AutoConfig();           
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if(dialogDataPath.ShowDialog() == DialogResult.OK)
            {
                DataFolderPath = dialogDataPath.SelectedPath;
                if (File.Exists(DataFolderPath + DataFile))
                {
                    EnableNums();
                    ReadFromExcel();
                    Task.Delay(100);
                    DisableNums();
                }
                else
                {
                    MessageBox.Show("Save your changes to create it at your chosen location.", "Data file not found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                using (StreamWriter sw = File.CreateText(ConfigFolderPath + ConfigFile))
                {
                    sw.WriteLine(DataFolderPath);
                }
            }
        }
    }
}