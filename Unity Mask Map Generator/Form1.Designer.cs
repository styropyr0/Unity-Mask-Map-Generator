namespace Unity_Mask_Map_Generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            checkBox4 = new CheckBox();
            label5 = new Label();
            filePick4 = new Button();
            filePathText4 = new TextBox();
            errLabel = new Label();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            filePick3 = new Button();
            filePick2 = new Button();
            filePick1 = new Button();
            filePathText3 = new TextBox();
            filePathText2 = new TextBox();
            filePathText1 = new TextBox();
            generate = new Button();
            resultPictureBox = new PictureBox();
            helpText = new Label();
            save = new Button();
            progressBar1 = new ProgressBar();
            helpText2 = new Label();
            progressLabel = new Label();
            imgSize = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultPictureBox).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(filePick4);
            groupBox1.Controls.Add(filePathText4);
            groupBox1.Controls.Add(errLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(pictureBox4);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(filePick3);
            groupBox1.Controls.Add(filePick2);
            groupBox1.Controls.Add(filePick1);
            groupBox1.Controls.Add(filePathText3);
            groupBox1.Controls.Add(filePathText2);
            groupBox1.Controls.Add(filePathText1);
            groupBox1.Font = new Font("Segoe UI Variable Display Semib", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(313, 407);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pick Files";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.BackColor = Color.Transparent;
            checkBox4.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox4.Location = new Point(234, 172);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(63, 21);
            checkBox4.TabIndex = 17;
            checkBox4.Text = "Invert";
            checkBox4.UseVisualStyleBackColor = false;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 176);
            label5.Name = "label5";
            label5.Size = new Size(90, 17);
            label5.TabIndex = 16;
            label5.Text = "Detail map (B):";
            // 
            // filePick4
            // 
            filePick4.Location = new Point(226, 196);
            filePick4.Name = "filePick4";
            filePick4.Size = new Size(71, 29);
            filePick4.TabIndex = 15;
            filePick4.Text = "Select";
            filePick4.UseVisualStyleBackColor = true;
            filePick4.Click += filePick4_Click;
            // 
            // filePathText4
            // 
            filePathText4.Location = new Point(15, 196);
            filePathText4.Name = "filePathText4";
            filePathText4.Size = new Size(203, 27);
            filePathText4.TabIndex = 14;
            filePathText4.TextChanged += filePathText4_TextChanged;
            // 
            // errLabel
            // 
            errLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            errLabel.AutoSize = true;
            errLabel.BackColor = Color.Red;
            errLabel.ForeColor = Color.White;
            errLabel.Location = new Point(38, 340);
            errLabel.Name = "errLabel";
            errLabel.Size = new Size(233, 20);
            errLabel.TabIndex = 10;
            errLabel.Text = "Please select at least one image.";
            errLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(46, 340);
            label4.Name = "label4";
            label4.Size = new Size(207, 20);
            label4.TabIndex = 9;
            label4.Text = "No image has been selected.";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(165, 320);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(60, 60);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 13;
            pictureBox4.TabStop = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.Transparent;
            checkBox3.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox3.Location = new Point(234, 240);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(63, 21);
            checkBox3.TabIndex = 12;
            checkBox3.Text = "Invert";
            checkBox3.UseVisualStyleBackColor = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.Transparent;
            checkBox2.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox2.Location = new Point(234, 36);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(63, 21);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Invert";
            checkBox2.UseVisualStyleBackColor = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(234, 103);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(63, 21);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Invert";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 244);
            label3.Name = "label3";
            label3.Size = new Size(130, 17);
            label3.TabIndex = 8;
            label3.Text = "Smoothness map (A):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 108);
            label2.Name = "label2";
            label2.Size = new Size(167, 17);
            label2.TabIndex = 7;
            label2.Text = "Ambient occlusion map (G):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 40);
            label1.Name = "label1";
            label1.Size = new Size(104, 17);
            label1.TabIndex = 2;
            label1.Text = "Metallic map (R):";
            label1.Click += label1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(240, 320);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(60, 60);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            pictureBox3.DragDrop += pictureBox3_DragDrop;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(90, 320);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(15, 320);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // filePick3
            // 
            filePick3.Location = new Point(226, 264);
            filePick3.Name = "filePick3";
            filePick3.Size = new Size(71, 29);
            filePick3.TabIndex = 4;
            filePick3.Text = "Select";
            filePick3.UseVisualStyleBackColor = true;
            filePick3.Click += filePick3_Click;
            // 
            // filePick2
            // 
            filePick2.Location = new Point(226, 128);
            filePick2.Name = "filePick2";
            filePick2.Size = new Size(71, 29);
            filePick2.TabIndex = 3;
            filePick2.Text = "Select";
            filePick2.UseVisualStyleBackColor = true;
            filePick2.Click += filePick2_Click;
            // 
            // filePick1
            // 
            filePick1.Location = new Point(226, 60);
            filePick1.Name = "filePick1";
            filePick1.Size = new Size(71, 29);
            filePick1.TabIndex = 2;
            filePick1.Text = "Select";
            filePick1.UseVisualStyleBackColor = true;
            filePick1.Click += filePick1_Click;
            // 
            // filePathText3
            // 
            filePathText3.Location = new Point(15, 264);
            filePathText3.Name = "filePathText3";
            filePathText3.Size = new Size(203, 27);
            filePathText3.TabIndex = 2;
            filePathText3.TextChanged += filePathText3_TextChanged;
            // 
            // filePathText2
            // 
            filePathText2.Location = new Point(15, 128);
            filePathText2.Name = "filePathText2";
            filePathText2.Size = new Size(203, 27);
            filePathText2.TabIndex = 1;
            filePathText2.TextChanged += filePathText2_TextChanged;
            // 
            // filePathText1
            // 
            filePathText1.Location = new Point(15, 60);
            filePathText1.Name = "filePathText1";
            filePathText1.Size = new Size(203, 27);
            filePathText1.TabIndex = 0;
            filePathText1.TextChanged += filePathText1_TextChanged;
            // 
            // generate
            // 
            generate.Font = new Font("Segoe UI Variable Display Semib", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            generate.Location = new Point(12, 435);
            generate.Name = "generate";
            generate.Size = new Size(150, 55);
            generate.TabIndex = 1;
            generate.Text = "Generate";
            generate.UseVisualStyleBackColor = true;
            generate.Click += button1_Click;
            // 
            // resultPictureBox
            // 
            resultPictureBox.Location = new Point(348, 22);
            resultPictureBox.Name = "resultPictureBox";
            resultPictureBox.Size = new Size(460, 465);
            resultPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            resultPictureBox.TabIndex = 2;
            resultPictureBox.TabStop = false;
            // 
            // helpText
            // 
            helpText.AutoSize = true;
            helpText.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            helpText.ForeColor = Color.Gray;
            helpText.Location = new Point(379, 230);
            helpText.Name = "helpText";
            helpText.Size = new Size(403, 17);
            helpText.TabIndex = 3;
            helpText.Text = "Import the textures to convert them to an Unity HDRP Mask map.";
            // 
            // save
            // 
            save.Font = new Font("Segoe UI Variable Display Semib", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            save.Location = new Point(168, 435);
            save.Name = "save";
            save.Size = new Size(157, 55);
            save.TabIndex = 4;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(358, 256);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(400, 4);
            progressBar1.TabIndex = 5;
            // 
            // helpText2
            // 
            helpText2.AutoSize = true;
            helpText2.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            helpText2.ForeColor = Color.FromArgb(64, 64, 64);
            helpText2.Location = new Point(490, 224);
            helpText2.Name = "helpText2";
            helpText2.Size = new Size(176, 20);
            helpText2.TabIndex = 6;
            helpText2.Text = "Generating Mask Map...";
            // 
            // progressLabel
            // 
            progressLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            progressLabel.Font = new Font("Segoe UI Variable Display", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            progressLabel.ImageAlign = ContentAlignment.MiddleRight;
            progressLabel.Location = new Point(757, 246);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(41, 20);
            progressLabel.TabIndex = 7;
            progressLabel.Text = "0%";
            progressLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // imgSize
            // 
            imgSize.AutoSize = true;
            imgSize.BackColor = Color.Red;
            imgSize.ForeColor = Color.White;
            imgSize.Location = new Point(348, 467);
            imgSize.Name = "imgSize";
            imgSize.Size = new Size(0, 20);
            imgSize.TabIndex = 11;
            imgSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 499);
            Controls.Add(imgSize);
            Controls.Add(progressLabel);
            Controls.Add(helpText2);
            Controls.Add(progressBar1);
            Controls.Add(save);
            Controls.Add(helpText);
            Controls.Add(resultPictureBox);
            Controls.Add(generate);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MaskGen";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button generate;
        private Button filePick1;
        private TextBox filePathText3;
        private TextBox filePathText2;
        private TextBox filePathText1;
        private Button filePick3;
        private Button filePick2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox resultPictureBox;
        private Label helpText;
        private Button save;
        private Label label4;
        private ProgressBar progressBar1;
        private Label errLabel;
        private Label helpText2;
        private Label progressLabel;
        private CheckBox checkBox1;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private PictureBox pictureBox4;
        private CheckBox checkBox4;
        private Label label5;
        private Button filePick4;
        private TextBox filePathText4;
        private Label imgSize;
    }
}
