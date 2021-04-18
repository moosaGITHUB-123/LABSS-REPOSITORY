using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCompressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {

            string[] files = Directory.GetFiles(txtSource.Text);

            foreach (var file in files)
            {
                string ext = Path.GetExtension(file).ToUpper();
                if (ext == ".PNG" || ext == ".JPG")
                    CompressImage(file, txtDestination.Text, (int)cmbQuality.SelectedItem);
            }

            MessageBox.Show("Compressed Images has been stored to\n" + txtDestination.Text);
            txtDestination.Text = "";
            txtSource.Text = "";
        }
        public static void CompressImage(string SoucePath, string DestPath, int quality)
        {
            var FileName = Path.GetFileName(SoucePath);
            DestPath = DestPath + "\\" + FileName;

            using (Bitmap bmp1 = new Bitmap(SoucePath))
            {

                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder QualityEncoder = System.Drawing.Imaging.Encoder.Quality;

                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(QualityEncoder, quality);

                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(DestPath, jpgEncoder, myEncoderParameters);


            }
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSouceBrowse_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(txtSource);
        }

        private void OpenFolderDialog(TextBox Filepath)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                Filepath.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void btnDestFolder_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(txtDestination);
        }
    }
}
