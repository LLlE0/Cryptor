namespace Cryptor
{
    public partial class ImageCryptor : Form
    {
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

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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
            if(od.ShowDialog() == DialogResult.OK)
            {
                var data = od.FileName;
                
                if (data is not null)
                {
                    PictureBox.Image = Image.FromFile(data);
                }
            }
        }
    }
}