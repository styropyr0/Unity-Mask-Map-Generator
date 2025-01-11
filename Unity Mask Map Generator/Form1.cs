using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Unity_Mask_Map_Generator.DataClasses;

namespace Unity_Mask_Map_Generator
{
    public partial class Form1 : Form
    {
        Bitmap metallic, ao, smoothness, maskMap;
        bool state1, state2, state3 = false;
        int imageCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            save.Visible = false;
            progressBar1.Visible = false;
            errLabel.Visible = false;
            helpText2.Visible = false;
            progressLabel.Visible = false;
        }

        private BitmapImage LoadImage(ref Bitmap image, PictureBox pictureBox)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        image = new Bitmap(openFileDialog.FileName);
                        pictureBox.Image = image;
                        return new BitmapImage(image, openFileDialog.FileName);
                    }
                }
                catch (Exception) { }
                return null;
            }
        }

        private void filePick1_Click(object sender, EventArgs e)
        {
            if (filePick1.Text != "Clear")
            {
                BitmapImage bmp = LoadImage(ref metallic, pictureBox1);
                if (bmp != null)
                {
                    filePathText1.Text = bmp.getSource();
                    filePick1.Text = "Clear";
                    state1 = true;
                }
            }
            else
            {
                pictureBox1.Image = null;
                metallic = null;
                state1 = false;
                filePathText1.Text = "";
                filePick1.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void filePick2_Click(object sender, EventArgs e)
        {
            if (filePick2.Text != "Clear")
            {
                BitmapImage bmp = LoadImage(ref ao, pictureBox2);
                if (bmp != null)
                {
                    filePathText2.Text = bmp.getSource();
                    filePick2.Text = "Clear";
                    state2 = true;
                }
            }
            else
            {
                pictureBox2.Image = null;
                ao = null;
                state2 = false;
                filePathText2.Text = "";
                filePick2.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void filePick3_Click(object sender, EventArgs e)
        {
            if (filePick3.Text != "Clear")
            {
                BitmapImage bmp = LoadImage(ref smoothness, pictureBox3);
                if (bmp != null)
                {
                    filePathText3.Text = bmp.getSource();
                    filePick3.Text = "Clear";
                    state3 = true;
                }
            }
            else
            {
                pictureBox3.Image = null;
                smoothness = null;
                state3 = false;
                filePathText3.Text = "";
                filePick3.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (state1 == true || state2 == true || state3 == true)
            {
                helpText.Visible = false;
                generateMaskMap();
            }
            else if (!isBoundsMatching())
            {
                errLabel.Visible = true;
                errLabel.Text = "Image bounds are not matching!";
            }
            else
            {
                label4.Visible = false;
                errLabel.Visible = true;
            }
        }

        bool isBoundsMatching()
        {
            try
            {
                bool width = metallic.Width == ao.Width && ao.Width == smoothness.Width;
                bool height = metallic.Height == ao.Height && ao.Height == smoothness.Height;
                if (width && height)
                    return true;
            }
            catch (Exception ex)
            {
                return true;
            }
            return false;
        }

        private void filePathText1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = new Bitmap(filePathText1.Text);
                metallic = new Bitmap(filePathText1.Text);
                label4.Visible = false;
                filePick1.Text = "Clear";
                state1 = true;
            }
            catch (Exception)
            {

                pictureBox1.Image = null;
                metallic = null;
                state1 = false;
                filePick1.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void filePathText2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = new Bitmap(filePathText2.Text);
                ao = new Bitmap(filePathText2.Text);
                label4.Visible = false;
                filePick2.Text = "Clear";
                state2 = true;
            }
            catch (Exception)
            {
                pictureBox2.Image = null;
                ao = null;
                state2 = false;
                filePick2.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void filePathText3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox3.Image = new Bitmap(filePathText3.Text);
                smoothness = new Bitmap(filePathText3.Text);
                label4.Visible = false;
                filePick3.Text = "Clear";
                state3 = true;
            }
            catch (Exception)
            {
                pictureBox3.Image = null;
                smoothness = null;
                state3 = false;
                filePick3.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void showOrHideNoImageLabel()
        {
            errLabel.Visible = false;
            if (state1 == false && state2 == false && state3 == false)
                label4.Visible = true;
        }

        private void pictureBox3_DragDrop(object sender, DragEventArgs e)
        {

        }

        private async void generateMaskMap()
        {
            CheckForIllegalCrossThreadCalls = false;
            int width = metallic?.Width ?? ao?.Width ?? smoothness?.Width ?? 256;
            int height = metallic?.Height ?? ao?.Height ?? smoothness?.Height ?? 256;
            save.Visible = false;
            maskMap = null;
            resultPictureBox.Image = null;
            maskMap = new Bitmap(width, height);
            progressBar1.Visible = true;

            await Task.Run(() =>
            {
                helpText2.Visible = true;
                progressLabel.Visible = true;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int r = metallic != null ? metallic.GetPixel(x, y).R : 128;
                        int g = ao != null ? ao.GetPixel(x, y).G : 128;
                        int b = 128;
                        int a = smoothness != null ? smoothness.GetPixel(x, y).A : 255;
                        maskMap.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                    int progress = (int)((y * 1f) / height * 100);
                    progressLabel.Text = progress + "%";
                    progressBar1.Value = progress;
                }
                progressBar1.Visible = false;
                progressLabel.Visible = false;
                save.Visible = true;
                helpText2.Visible = false;
            });
            resultPictureBox.Image = maskMap;
        }

        private void saveGeneratedImage()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.FileName = "MaskMap" + imageCount++;
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    maskMap.Save(saveFileDialog.FileName, ImageFormat.Png);
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            saveGeneratedImage();
        }
    }
}
