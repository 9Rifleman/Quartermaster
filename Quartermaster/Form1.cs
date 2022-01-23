using System.Media;
using System.Text;

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
        private const string DataFile = @"\QMsource.csv";

        private void AutoConfig()
        {
            ConfigFolderPath = Directory.GetCurrentDirectory();
           if (!File.Exists(ConfigFolderPath + ConfigFile))
            {
                MessageBox.Show("Please select a folder containing the main data file. If you don't have one, it will be created in the selected location when you save. You can change it later at any time.", "First run", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (dialogDataPath.ShowDialog() == DialogResult.OK)
                {
                    DataFolderPath = dialogDataPath.SelectedPath;
                }
                using StreamWriter sw = File.CreateText(ConfigFolderPath + ConfigFile);
                sw.WriteLine(DataFolderPath);
                if (File.Exists(DataFolderPath + DataFile))
                {
                    ReadFromExcel();
                }
                else
                {
                    PlayDefault();
                    formSave formSave = new();
                    if (formSave.ShowDialog() == DialogResult.OK)
                    {
                        DataFolderPath = dialogDataPath.SelectedPath;
                    }
                    else
                    {
                        ButtonOpenLoop();
                    }
                }
            }
            else if (File.Exists(ConfigFolderPath + ConfigFile))
            {
                using StreamReader sr = File.OpenText(ConfigFolderPath + ConfigFile);
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
                    PlayDefault();
                    formSave formSave = new();
                    if (formSave.ShowDialog() == DialogResult.OK)
                    {
                        DataFolderPath = dialogDataPath.SelectedPath;
                    }
                    else
                    {
                        ButtonOpenLoop();
                    }
                }
            }

        }
        private void WriteToExcel()
        {
             string csvSeparator = ",";
             StringBuilder stringBuilder = new();

             laptop1New = Convert.ToInt32(numLaptop1New.Value);
             laptop1Old = Convert.ToInt32(numLaptop1Old.Value);
             laptop2New = Convert.ToInt32(numLaptop2New.Value);
             laptop2Old = Convert.ToInt32(numLaptop2Old.Value);
             dock = Convert.ToInt32(numDock.Value);
             headset = Convert.ToInt32(numHeadset.Value);
             kbMouse = Convert.ToInt32(numKBMouse.Value);
             twentyFourInch = Convert.ToInt32(num24inch.Value);
             twentySevenInch = Convert.ToInt32(num27inch.Value);

            int[][] outputArray = new int[][]
            {
                 new int[] {laptop1New},
                 new int[] {laptop1Old},
                 new int[] {laptop2New},
                 new int[] {laptop2Old},
                 new int[] {dock},
                 new int[] {headset},
                 new int[] {kbMouse},
                 new int[] {twentyFourInch},
                 new int[] {twentySevenInch}
            };

             for (int i = 0; i < 9; i++)
             {
                stringBuilder.AppendLine(string.Join(csvSeparator, outputArray[i]));
             }



             File.WriteAllText(DataFolderPath + DataFile, stringBuilder.ToString());
        }

        private void ReadFromExcel()
        {
            int[] inputArray = new int[9];
            int arrayCount = 0;
            StreamReader sr = new StreamReader(DataFolderPath + DataFile);
            while(!sr.EndOfStream)
            {
                inputArray[arrayCount] = Convert.ToInt32(sr.ReadLine());
                arrayCount++;
            }

            numLaptop1New.Value = Convert.ToInt32(inputArray[0]);
            numLaptop1Old.Value = Convert.ToInt32(inputArray[1]);
            numLaptop2New.Value = Convert.ToInt32(inputArray[2]);
            numLaptop2Old.Value = Convert.ToInt32(inputArray[3]);
            numDock.Value = Convert.ToInt32(inputArray[4]);
            numHeadset.Value = Convert.ToInt32(inputArray[5]);
            numKBMouse.Value = Convert.ToInt32(inputArray[6]);
            num24inch.Value = Convert.ToInt32(inputArray[7]);
            num27inch.Value = Convert.ToInt32(inputArray[8]);

            sr.Close();           
        }
        private static void PlayTada()
        {
            SoundPlayer simpleSound = new(@"c:\Windows\Media\tada.wav");
            simpleSound.Play();
        }

        private static void PlayDefault()
        {
            SoundPlayer simpleSound = new(@"c:\Windows\Media\Windows Default.wav");
            simpleSound.Play();
        }

        private void ButtonOpenLoop()
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
                    PlayDefault();
                    formSave formSave = new();
                    if (formSave.ShowDialog() == DialogResult.OK)
                    {
                        DataFolderPath = dialogDataPath.SelectedPath;
                    }
                    else
                    {
                    ButtonOpenLoop();
                    }
                }
                using StreamWriter sw = File.CreateText(ConfigFolderPath + ConfigFile);
                sw.WriteLine(DataFolderPath);
            }
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
            PlayDefault();
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
            ButtonOpenLoop();
        }

        private void lblLaptop1_DoubleClick(object sender, EventArgs e)
        {
            string oldName = lblLaptop1.Text;
            PlayDefault();
            FormRename formRename = new FormRename();
            if(formRename.ShowDialog() == DialogResult.OK)
            {
                string newName = formRename.boxRename.Text;
                if(newName == "")
                {
                    return;
                }
                else
                {
                    lblLaptop1.Text = newName;
                    lblLaptop1.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
        }

        private void lblLaptop2_DoubleClick(object sender, EventArgs e)
        {
            string oldName = lblLaptop2.Text;
            PlayDefault();
            FormRename formRename = new FormRename();
            if (formRename.ShowDialog() == DialogResult.OK)
            {
                string newName = formRename.boxRename.Text;
                if (newName == "")
                {
                    return;
                }
                else
                {
                    lblLaptop2.Text = newName;
                    lblLaptop2.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
        }
    }
}