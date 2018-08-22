using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangementTool
{
    public partial class MainPage : Form
    {
        static private readonly string FORMAT_PATH_0     = @"{0}\Resources\0.png";
        static private readonly string FORMAT_PATH_START = @"{0}\Resources\1.png";
        static private readonly string FORMAT_PATH_END   = @"{0}\Resources\2.png";
        static private readonly string FORMAT_PATH_3     = @"{0}\Resources\3.png";
        static private readonly string FORMAT_PATH_4     = @"{0}\Resources\4.png";

        static private readonly string FORMAT_NAME = "picture_{0}";

        private SaveData m_SaveData = null;
        private Image[] m_Img = null;
        private int[] m_iImgNumber = null;
        private int[] m_iRotate = null;
        private bool m_isLoad = false;

        public MainPage()
        {
            InitializeComponent();

            //m_SaveData = new SaveData();
            m_SaveData = SaveData.Get();

            InitSetting();
            PictureUpdate();
            SaveDataUpdate();
        }

        private void InitSetting()
        {
            //이미지 미리 할당.
            m_Img = new Image[5];
            //string tempPath = Application.StartupPath;
            string tempPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            m_Img[0] = Image.FromFile(string.Format(FORMAT_PATH_0, tempPath));
            m_Img[1] = Image.FromFile(string.Format(FORMAT_PATH_START, tempPath));
            m_Img[2] = Image.FromFile(string.Format(FORMAT_PATH_END, tempPath));
            m_Img[3] = Image.FromFile(string.Format(FORMAT_PATH_3, tempPath));
            m_Img[4] = Image.FromFile(string.Format(FORMAT_PATH_4, tempPath));
        }

        private void PictureUpdate()
        {
            groupBox3.Controls.Clear();

            int iHorizontal = (int)horizontalSlotsNum.Value;
            int iVertical = (int)verticalSlotsNum.Value;

            m_iImgNumber = new int[iHorizontal * iVertical];
            m_iRotate = new int[iHorizontal * iVertical];

            PictureBox[,] pictureBoxes = new PictureBox[iVertical, iHorizontal];

            PictureBoxCreate(pictureBoxes, iHorizontal, iVertical);
        }

        private void PictureBoxCreate(PictureBox[,] _pictureboxes, int _iHorizontal, int _iVertical)
        {
            int x = 0;
            int y = 0;

            for (int iVerticalLoop = 0; iVerticalLoop < _iVertical; ++iVerticalLoop)
            {
                for (int iHorizontalLoop = 0; iHorizontalLoop < _iHorizontal; ++iHorizontalLoop)
                {
                    int idx = iVerticalLoop * _iHorizontal + iHorizontalLoop;
                    _pictureboxes[iVerticalLoop, iHorizontalLoop] = new PictureBox();
                    groupBox3.Controls.Add(_pictureboxes[iVerticalLoop, iHorizontalLoop]);
                    _pictureboxes[iVerticalLoop, iHorizontalLoop].Image = m_Img[0];
                    _pictureboxes[iVerticalLoop, iHorizontalLoop].Name = string.Format(FORMAT_NAME, idx);
                    _pictureboxes[iVerticalLoop, iHorizontalLoop].SizeMode = PictureBoxSizeMode.StretchImage;
                    _pictureboxes[iVerticalLoop, iHorizontalLoop].Size = new Size(50, 50);

                    if (idx == 0)
                    {
                        _pictureboxes[iVerticalLoop, iHorizontalLoop].Location = new Point(15, 20);
                    }
                    else
                    {
                        if (iHorizontalLoop == 0)
                        {
                            x = _pictureboxes[iVerticalLoop - 1, iHorizontalLoop].Location.X;
                            y = _pictureboxes[iVerticalLoop - 1, iHorizontalLoop].Location.Y + 55;
                        }
                        else
                        {
                            x = _pictureboxes[iVerticalLoop, iHorizontalLoop - 1].Location.X + 55;
                            y = _pictureboxes[iVerticalLoop, iHorizontalLoop - 1].Location.Y;
                        }

                        _pictureboxes[iVerticalLoop, iHorizontalLoop].Location = new Point(x, y);
                    }

                    _pictureboxes[iVerticalLoop, iHorizontalLoop].MouseClick += new MouseEventHandler(Picturebox_MouseDownEvent);
                }
            }
        }

        private void SaveDataUpdate()
        {
            m_SaveData.Current._iIndex      = Int32.Parse(stageIndex.Text);
            m_SaveData.Current._iHorizontal = (int)horizontalSlotsNum.Value;
            m_SaveData.Current._iVertical   = (int)verticalSlotsNum.Value;
            m_SaveData.Current._iTouchCount = Int32.Parse(touchCount.Text);
            m_SaveData.DataUpdate();
        }

        private void Picturebox_MouseDownEvent(object sender, MouseEventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            if (picture == null) return;

            string[] tempSplit = picture.Name.Split('_');
            int iImgNum = Int32.Parse(tempSplit[tempSplit.Length - 1]);

            if (radioImageChange.Checked)
            {
                ++m_iImgNumber[iImgNum];

                if (m_iImgNumber[iImgNum] >= m_Img.Length)
                    m_iImgNumber[iImgNum] = 0;

                picture.Image = m_Img[m_iImgNumber[iImgNum]];
                m_SaveData.PieceImgNumberUpdate(iImgNum, m_iImgNumber[iImgNum]);
            }
            else if(radioRotationChange.Checked)
            {
                m_iRotate[iImgNum] += 90;
                if (m_iRotate[iImgNum] >= 360)
                    m_iRotate[iImgNum] = 0;

                Bitmap temp = (Bitmap)picture.Image.Clone();
                temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                picture.Image = temp;

                m_SaveData.PieceRotationUpdate(iImgNum, m_iRotate[iImgNum]);

                //test
                test.Text = m_SaveData.GetPieceRotate(iImgNum).ToString();
            }
        }

        private void horizontalSlotsNum_ValueChanged(object sender, EventArgs e)
        {
            if (m_isLoad) return;

            PictureUpdate();

            m_SaveData.Current._iHorizontal = (int)horizontalSlotsNum.Value;
            m_SaveData.DataUpdate();
        }

        private void verticalSlotsNum_ValueChanged(object sender, EventArgs e)
        {
            if (m_isLoad) return;

            PictureUpdate();

            m_SaveData.Current._iVertical = (int)verticalSlotsNum.Value;
            m_SaveData.DataUpdate();
        }

        private void stageIndex_TextChanged(object sender, EventArgs e)
        {
            if (m_isLoad) return;

            m_SaveData.Current._iIndex = Int32.Parse(stageIndex.Text);
        }

        private void touchCount_TextChanged(object sender, EventArgs e)
        {
            if (m_isLoad) return;

            m_SaveData.Current._iTouchCount = Int32.Parse(touchCount.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "iniFile (*.ini)|*.ini|txt (*.txt)|*.txt |All files (*.*)|(*.*)";
            save.Title = "Select a Save File";
            
            if (save.ShowDialog() == DialogResult.OK)
            {
                m_SaveData.ToolDataSave(save.FileName);

                string strDirectory = System.IO.Path.GetDirectoryName(save.FileName);
                string strFileName = System.IO.Path.GetFileNameWithoutExtension(save.FileName);
                if(strFileName != "")
                {
                    string strPath = string.Format("{0}/{1}.json", strDirectory, strFileName);
                    m_SaveData.SaveJson(strPath);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            m_isLoad = true;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "iniFile (*.ini)|*.ini|txt (*.txt)|*.txt |All files (*.*)|(*.*)";
            open.Title = "Select a Open File";

            if (open.ShowDialog() == DialogResult.OK)
            {
                m_SaveData.ToolDataLoad(open.FileName);

                stageIndex.Text          = m_SaveData.Current._iIndex.ToString();
                horizontalSlotsNum.Value = m_SaveData.Current._iHorizontal;
                verticalSlotsNum.Value   = m_SaveData.Current._iVertical;
                touchCount.Text          = m_SaveData.Current._iTouchCount.ToString();
                
                m_iImgNumber = m_SaveData.Current._iArrayPieceImg;
                m_iRotate    = m_SaveData.Current._iArrayPieceRotate;

                int iHorizontal = m_SaveData.Current._iHorizontal;
                int iVertical   = m_SaveData.Current._iVertical;

                groupBox3.Controls.Clear();

                PictureBox[,] pictureBoxes = new PictureBox[iVertical, iHorizontal];

                PictureBoxCreate(pictureBoxes, iHorizontal, iVertical);
                
                foreach(PictureBox temp in groupBox3.Controls)
                {
                    if (temp == null) continue;
                    string[] tempSplit = temp.Name.Split('_');
                    int iImgNum = Int32.Parse(tempSplit[tempSplit.Length - 1]);

                    //이미지 바꿔주고.
                    temp.Image = m_Img[m_iImgNumber[iImgNum]];

                    //회전 바꿔줌.
                    Bitmap tempBitmap = (Bitmap)temp.Image.Clone();
                    RotateFlipType type = RotateFlipType.RotateNoneFlipNone;

                    switch(m_SaveData.Current._iArrayPieceRotate[iImgNum])
                    {
                        case 90:
                            type = RotateFlipType.Rotate90FlipNone;
                            break;
                        case 180:
                            type = RotateFlipType.Rotate180FlipNone;
                            break;
                        case 270:
                            type = RotateFlipType.Rotate270FlipNone;
                            break;
                        default:
                            break;
                    }

                    tempBitmap.RotateFlip(type);
                    temp.Image = tempBitmap;
                }
            }

            m_isLoad = false;
        }
    }
}
