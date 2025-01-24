using Coroutines;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Unity_Mask_Map_Generator.DataClasses;

namespace Unity_Mask_Map_Generator
{
    public partial class Form1 : Form
    {
        Bitmap metallic, ao, detail, smoothness, maskMap;
        bool state1, state2, state3, state4 = false;
        bool invertState1, invertState2, invertState3, invertState4 = false;
        int imageCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imgSize.Visible = false;
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
                        image?.Dispose();
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
                metallic?.Dispose();
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
                ao?.Dispose();
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
                smoothness?.Dispose();
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
            if (state1 == true || state2 == true || state3 == true || state4 == true)
            {
                helpText.Visible = false;
                generateMaskMap();
            }
            else if (metallic != null && ao != null && smoothness != null && detail != null && !isBoundsMatching())
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
                bool width = metallic.Width == ao.Width && ao.Width == smoothness.Width && smoothness.Width == detail.Width;
                bool height = metallic.Height == ao.Height && ao.Height == smoothness.Height && smoothness.Height == detail.Height;
                if (width && height)
                    return true;
            }
            catch (Exception)
            {
                return true;
            }
            return false;
        }

        private void filePathText1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Bitmap bp = new Bitmap(filePathText1.Text);
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = new Bitmap(bp);
                metallic?.Dispose();
                metallic = bp;
                label4.Visible = false;
                filePick1.Text = "Clear";
                state1 = true;
            }
            catch (Exception)
            {
                pictureBox1.Image = null;
                metallic?.Dispose();
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
                Bitmap bp = new Bitmap(filePathText2.Text);
                pictureBox2.Image?.Dispose();
                pictureBox2.Image = new Bitmap(bp);
                ao?.Dispose();
                ao = new Bitmap(filePathText2.Text);
                label4.Visible = false;
                filePick2.Text = "Clear";
                state2 = true;
            }
            catch (Exception)
            {
                pictureBox2.Image = null;
                ao?.Dispose();
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
                Bitmap bp = new Bitmap(filePathText3.Text);
                pictureBox3.Image?.Dispose();
                pictureBox3.Image = new Bitmap(bp);
                smoothness?.Dispose();
                smoothness = new Bitmap(filePathText3.Text);
                label4.Visible = false;
                filePick3.Text = "Clear";
                state3 = true;
            }
            catch (Exception)
            {
                pictureBox3.Image = null;
                smoothness?.Dispose();
                smoothness = null;
                state3 = false;
                filePick3.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void showOrHideNoImageLabel()
        {
            errLabel.Visible = false;
            if (state1 == false && state2 == false && state3 == false && state4 == false)
                label4.Visible = true;
        }

        private void pictureBox3_DragDrop(object sender, DragEventArgs e)
        {

        }

        private async void generateMaskMap()
        {
            CheckForIllegalCrossThreadCalls = false;
            int width = Math.Max(Math.Max(metallic?.Width ?? 0, ao?.Width ?? 0), Math.Max(smoothness?.Width ?? 0, detail?.Width ?? 0));
            int height = Math.Max(Math.Max(metallic?.Height ?? 0, ao?.Height ?? 0), Math.Max(smoothness?.Height ?? 0, detail?.Height ?? 0));
            save.Visible = false;
            imgSize.Visible = false;
            maskMap?.Dispose();
            maskMap = null;
            resultPictureBox.Image = null;
            maskMap = new Bitmap(width, height);
            progressBar1.Visible = true;
            EnableOrDisableCheckBoxes(false);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await GlobalScope.Launch(() =>
            {
                generate.Enabled = false;
                generate.Text = "Generating...";
                helpText2.Visible = true;
                progressLabel.Visible = true;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int r = metallic != null ? metallic.GetPixel(x, y).R : 0;
                        if (invertState1) r = 255 - r;
                        int g = ao != null ? ao.GetPixel(x, y).G : 0;
                        if (invertState2) g = 255 - g;
                        int b = detail != null ? detail.GetPixel(x, y).B : 0;
                        if (invertState4) b = 255 - b;
                        int a = smoothness != null ? smoothness.GetPixel(x, y).R : 255;
                        if (invertState3) a = 255 - a;
                        maskMap.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                    int progress = (int)((y * 1f) / height * 100);
                    progressLabel.Text = progress + "%";
                    progressBar1.Value = progress;
                }
                stopwatch.Stop();
                imgSize.Text = $"Image Size: {width} x {height} ({stopwatch.ElapsedMilliseconds / 1000f}s)";
                imgSize.Visible = true;
                progressBar1.Visible = false;
                progressLabel.Visible = false;
                save.Visible = true;
                helpText2.Visible = false;
                generate.Text = "Generate";
                EnableOrDisableCheckBoxes(true);
                generate.Enabled = true;
            });
            resultPictureBox.Image = maskMap;
        }

        private void EnableOrDisableCheckBoxes(bool state)
        {
            checkBox1.Enabled = state;
            checkBox2.Enabled = state;
            checkBox3.Enabled = state;
            checkBox4.Enabled = state;
            filePick1.Enabled = state;
            filePick2.Enabled = state;
            filePick3.Enabled = state;
            filePick4.Enabled = state;
            filePathText1.Enabled = state;
            filePathText2.Enabled = state;
            filePathText3.Enabled = state;
            filePathText4.Enabled = state;
        }

        private void saveGeneratedImage()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Save the Mask Map";
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            invertState1 = checkBox2.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            invertState2 = checkBox1.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            invertState3 = checkBox3.Checked;
        }

        private void filePathText4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Bitmap bp = new Bitmap(filePathText4.Text);
                pictureBox4.Image?.Dispose();
                pictureBox4.Image = new Bitmap(bp);
                detail?.Dispose();
                detail = bp;
                label4.Visible = false;
                filePick4.Text = "Clear";
                state4 = true;
            }
            catch (Exception)
            {
                pictureBox4.Image = null;
                detail?.Dispose();
                detail = null;
                state4 = false;
                filePick4.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void filePick4_Click(object sender, EventArgs e)
        {
            if (filePick4.Text != "Clear")
            {
                BitmapImage bmp = LoadImage(ref detail, pictureBox4);
                if (bmp != null)
                {
                    filePathText4.Text = bmp.getSource();
                    filePick4.Text = "Clear";
                    state4 = true;
                }
            }
            else
            {
                pictureBox4.Image = null;
                detail?.Dispose();
                detail = null;
                state4 = false;
                filePathText4.Text = "";
                filePick4.Text = "Select";
            }
            showOrHideNoImageLabel();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            invertState4 = checkBox4.Checked;
        }

        private void resultPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
