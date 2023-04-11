using System.IO;
using System.Windows.Forms.Design;

namespace Cryptor
{
    public partial class ImageCryptor : Form
    {
        string? FileNameToEncrypt="";

        public ImageCryptor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox.AllowDrop = true;
        }

        private void ENCRYPT_Click(object sender, EventArgs e)
        {
            if (FileNameToEncrypt == "" || !File.Exists(FileNameToEncrypt))
            {
                log.Text = "Error: Select a file to encrypt!";
                return;
            }
            if (PictureBox.Image is not null)
            {
                FileStream file = File.OpenRead(FileNameToEncrypt);
                var pic = new Bitmap(PictureBox.Image);
                if (pic.Width*pic.Height*4 < file.Length/2)
                {
                    log.Text = new("(" + DateTime.Now.ToString("hh:mm:ss") + ") " + "Error: The picture is too small!");
                }
                var v = Logic.WriteBits(FileNameToEncrypt, ref pic);
                foreach (string z in v)
                {
                    log.Text += z;
                }
            }
            else
            {
                log.Text = "Error: The Picture Box is empty!"; 
            };
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);

            if (data is not null)
            {
                var f = data as string[];
                if (f != null)
                {
                    PictureBox.Image = Image.FromFile(f[0]);
                }
            }
        }

        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            var od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                var data = od.FileName;
                
                if (data is not null)
                {
                    PictureBox.Image = Image.FromFile(data);
                }
            }
        }


        private void Selector_Click(object sender, EventArgs e)
        {
            var od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                var data = od.FileName;

                if (data is not null)
                {
                    FileNameToEncrypt=data;
                    log.Text = "(" + DateTime.Now.ToString("hh:mm:ss") + ") selected a file to encrypt: " + data;
                }
            }
        }
    }
}