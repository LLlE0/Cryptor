using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

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
                if (Logic.WriteBits(FileNameToEncrypt, ref pic))
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        string SaveFilePath = new(Path.GetDirectoryName(FileNameToEncrypt)+"\\" + Path.GetFileNameWithoutExtension(FileNameToEncrypt) + "_CryptedFile" + DateTime.Now.ToString("hh-mm-ss") + ".png");
                        using (FileStream fs = new FileStream(SaveFilePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            pic.Save(memory, ImageFormat.Jpeg);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
                else log.Text = new("(" + DateTime.Now.ToString("hh:mm:ss") + "Unknown error!");
                
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
                FileNameToEncrypt = data; ///?????/
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

        private void DECRYPT_Click(object sender, EventArgs e)
        { 
            var pic = new Bitmap(PictureBox.Image);
            var str = Path.GetDirectoryName(FileNameToEncrypt) + "\\Decr" + DateTime.Now.ToString("hh-mm-ss");
            Logic.WriteBitsToFile(str, ref pic);
            log.Text = "(" + DateTime.Now.ToString("hh:mm:ss") + $") File {str} was successfully saved!";
        }
    }
}