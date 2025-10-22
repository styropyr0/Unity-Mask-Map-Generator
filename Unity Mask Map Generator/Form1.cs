using Coroutines;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using Unity_Mask_Map_Generator.DataClasses;

namespace Unity_Mask_Map_Generator
{
    public partial class Form1 : Form
    {
        private static Bitmap? metallic, ao, detail, smoothness, maskMap;
        private static bool state1, state2, state3, state4 = false;
        private static bool invertState1, invertState2, invertState3, invertState4 = false;
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

        private BitmapImage? LoadImage(ref Bitmap image, PictureBox pictureBox)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter =
                            "PNG Image|*.png|" +
                            "JPEG Image|*.jpg;*.jpeg|" +
                            "TIFF Image|*.tif;*.tiff|" +
                            "BMP Image|*.bmp|" +
                            "EXR Image|*.exr|" +
                            "All Image Files|*.png;*.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.exr";

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
                BitmapImage? bmp = LoadImage(ref metallic, pictureBox1);
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
                BitmapImage? bmp = LoadImage(ref ao, pictureBox2);
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
                BitmapImage? bmp = LoadImage(ref smoothness, pictureBox3);
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
            if (!isBoundsMatching())
            {
                errLabel.Visible = true;
                errLabel.Text = "Images must be the same size.";
            }
            else if (state1 == true || state2 == true || state3 == true || state4 == true)
            {
                helpText.Visible = false;
                GenerateMaskMap();
            }
            else
            {
                label4.Visible = false;
                errLabel.Text = "Please select at least one image.";
                errLabel.Visible = true;
            }
        }

        bool isBoundsMatching()
        {
            try
            {
                int maxWidth = Math.Max(Math.Max(metallic?.Width ?? 0, ao?.Width ?? 0), Math.Max(smoothness?.Width ?? 0, detail?.Width ?? 0));
                int maxHeight = Math.Max(Math.Max(metallic?.Height ?? 0, ao?.Height ?? 0), Math.Max(smoothness?.Height ?? 0, detail?.Height ?? 0));

                bool widthMatch = maxWidth == (metallic?.Width ?? maxWidth) && maxWidth == (ao?.Width ?? maxWidth) && maxWidth == (smoothness?.Width ?? maxWidth) && maxWidth == (detail?.Width ?? maxWidth);
                bool heightMatch = maxHeight == (metallic?.Height ?? maxHeight) && maxHeight == (ao?.Height ?? maxHeight) && maxHeight == (smoothness?.Height ?? maxHeight) && maxHeight == (detail?.Height ?? maxHeight);
                if (widthMatch && heightMatch)
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

        private async void GenerateMaskMap()
        {
            CheckForIllegalCrossThreadCalls = false;

            int width = Math.Max(Math.Max(metallic?.Width ?? 0, ao?.Width ?? 0), Math.Max(smoothness?.Width ?? 0, detail?.Width ?? 0));
            int height = Math.Max(Math.Max(metallic?.Height ?? 0, ao?.Height ?? 0), Math.Max(smoothness?.Height ?? 0, detail?.Height ?? 0));

            save.Visible = false;
            imgSize.Visible = false;
            maskMap?.Dispose();
            maskMap = null;
            resultPictureBox.Image = null;
            resultPictureBox.Visible = false;

            maskMap = new Bitmap(width, height);
            progressBar1.Visible = true;
            EnableOrDisableCheckBoxes(false);

            generate.Enabled = false;
            generate.Text = "Generating...";
            helpText2.Visible = true;
            progressLabel.Visible = true;

            byte[] maskMapData = new byte[width * height * 4];
            byte[]? metallicData = metallic != null ? ConvertBitmapToByteArray(metallic) : null;
            byte[]? aoData = ao != null ? ConvertBitmapToByteArray(ao) : null;
            byte[]? detailData = detail != null ? ConvertBitmapToByteArray(detail) : null;
            byte[]? smoothnessData = smoothness != null ? ConvertBitmapToByteArray(smoothness) : null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            progress = 0;

            // Using the CoroutineBuilder to launch multiple coroutines in parallel
            await CoroutineBuilder.LaunchAll(new List<Func<Task>>{
                () => { ProcessImage(progressBar1, progressLabel, maskMapData, metallicData, aoData, detailData, smoothnessData, width, height, 0, height / 4); return Task.CompletedTask; },
                () => { ProcessImage(progressBar1, progressLabel, maskMapData, metallicData, aoData, detailData, smoothnessData, width, height, height / 4, height / 4); return Task.CompletedTask; },
                () => { ProcessImage(progressBar1, progressLabel, maskMapData, metallicData, aoData, detailData, smoothnessData, width, height, height / 2, height / 4); return Task.CompletedTask; },
                () => { ProcessImage(progressBar1, progressLabel, maskMapData, metallicData, aoData, detailData, smoothnessData, width, height, 3 * height / 4, height / 4); return Task.CompletedTask; }
            }, Dispatcher.Main);

            await Suspend.ForMilliseconds(1000);

            progressBar1.Value = 100;
            progressLabel.Text = "100%";
            maskMap = ConvertToBitmap(maskMapData, width, height);
            resultPictureBox.Image = maskMap;
            resultPictureBox.Visible = true;
            stopwatch.Stop();
            imgSize.Text = $"Image Size: {width} x {height} ({stopwatch.ElapsedMilliseconds / 1000f:F2}s)";
            imgSize.Visible = true;
            progressBar1.Visible = false;
            progressLabel.Visible = false;
            save.Visible = true;
            helpText2.Visible = false;
            generate.Text = "Generate";
            EnableOrDisableCheckBoxes(true);
            generate.Enabled = true;
        }

        private static byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            byte[] byteArray = new byte[width * height * 4];

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, byteArray, 0, byteArray.Length);
            bitmap.UnlockBits(bitmapData);

            return byteArray;
        }

        static int progress = 0;
        static bool progressMutex = false;

        private static void ProcessImage(ProgressBar progressBar, Label progressView, byte[] maskMapData, byte[] metallicData, byte[] aoData, byte[] detailData, byte[] smoothnessData, int width, int height, int startY, int chunkHeight)
        {
            for (int y = startY; y < startY + chunkHeight; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * width + x) * 4;

                    int a = 255, r = 0, g = 0, b = 0;

                    if (metallicData != null)
                    {
                        int metallicIndex = index;
                        r = metallicData[metallicIndex + 2];
                        if (invertState1) r = 255 - r;
                    }

                    if (aoData != null)
                    {
                        int aoIndex = index;
                        g = aoData[aoIndex + 1];
                        if (invertState2) g = 255 - g;
                    }

                    if (detailData != null)
                    {
                        int detailIndex = index;
                        b = detailData[detailIndex];
                        if (invertState4) b = 255 - b;
                    }

                    if (smoothnessData != null)
                    {
                        int smoothnessIndex = index;
                        a = smoothnessData[smoothnessIndex + 3];
                        if (invertState3) a = 255 - a;
                    }

                    maskMapData[index + 0] = (byte)b;
                    maskMapData[index + 1] = (byte)g;
                    maskMapData[index + 2] = (byte)r;
                    maskMapData[index + 3] = (byte)a;

                    int p = (int)((y * width + x) * 100 / (width * height));

                    if (!progressMutex && p > progress)
                    {
                        progressMutex = true;
                        progress = p;
                        progressBar.Value = p;
                        progressView.Text = progress + "%";
                        progressMutex = false;
                    }
                }
            }
        }

        private static Bitmap ConvertToBitmap(byte[] pixelData, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(pixelData, 0, bitmapData.Scan0, pixelData.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
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
                saveFileDialog.Filter =
                        "PNG Image|*.png|" +
                        "JPEG Image|*.jpg;*.jpeg|" +
                        "TIFF Image|*.tif;*.tiff|" +
                        "BMP Image|*.bmp|" +
                        "GIF Image|*.gif|" +
                        "EXR Image|*.exr|" +
                        "All Image Files|*.png;*.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.gif;*.exr";

                saveFileDialog.Title = "Save the Mask Map";
                saveFileDialog.FileName = "MaskMap" + imageCount++;
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    if (maskMap != null)
                        maskMap?.Save(saveFileDialog.FileName, ImageFormat.Png);
                    else
                        MessageBox.Show("Failed to save the image. Seems like there is an issue with one or more of the selected images", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                BitmapImage? bmp = LoadImage(ref detail, pictureBox4);
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
