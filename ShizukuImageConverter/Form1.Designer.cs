
namespace ShizukuImageConverter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pathBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.backWhiteCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.noDhitherCheckbox = new System.Windows.Forms.CheckBox();
            this.warnLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ossLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pathBox
            // 
            this.pathBox.AllowDrop = true;
            this.pathBox.Location = new System.Drawing.Point(13, 13);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(100, 19);
            this.pathBox.TabIndex = 0;
            this.pathBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PathBox_DragDrop);
            this.pathBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.PathBox_DragEnter);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(119, 11);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "参照";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(201, 11);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "変換";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(282, 11);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPictureBox.Location = new System.Drawing.Point(12, 38);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(160, 128);
            this.resultPictureBox.TabIndex = 4;
            this.resultPictureBox.TabStop = false;
            // 
            // backWhiteCheckbox
            // 
            this.backWhiteCheckbox.AutoSize = true;
            this.backWhiteCheckbox.Location = new System.Drawing.Point(178, 40);
            this.backWhiteCheckbox.Name = "backWhiteCheckbox";
            this.backWhiteCheckbox.Size = new System.Drawing.Size(111, 16);
            this.backWhiteCheckbox.TabIndex = 5;
            this.backWhiteCheckbox.Text = "extentの背景を白";
            this.backWhiteCheckbox.UseVisualStyleBackColor = true;
            // 
            // noDhitherCheckbox
            // 
            this.noDhitherCheckbox.AutoSize = true;
            this.noDhitherCheckbox.Location = new System.Drawing.Point(178, 62);
            this.noDhitherCheckbox.Name = "noDhitherCheckbox";
            this.noDhitherCheckbox.Size = new System.Drawing.Size(70, 16);
            this.noDhitherCheckbox.TabIndex = 6;
            this.noDhitherCheckbox.Text = "ディザなし";
            this.noDhitherCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 72);
            this.label1.TabIndex = 7;
            this.label1.Text = "1 参照またはパスを直接入力\r\n2 変換\r\nオプション変更後は再度変換\r\n3 txtで保存\r\n4 Shizukuの/img/ にtxtを入れて\r\n  list.t" +
    "xtにファイル名を追記";
            // 
            // warnLinkLabel
            // 
            this.warnLinkLabel.AutoSize = true;
            this.warnLinkLabel.Location = new System.Drawing.Point(310, 190);
            this.warnLinkLabel.Name = "warnLinkLabel";
            this.warnLinkLabel.Size = new System.Drawing.Size(29, 12);
            this.warnLinkLabel.TabIndex = 8;
            this.warnLinkLabel.TabStop = true;
            this.warnLinkLabel.Text = "注意";
            this.warnLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WarnLinkLabel_LinkClicked);
            // 
            // ossLinkLabel
            // 
            this.ossLinkLabel.AutoSize = true;
            this.ossLinkLabel.Location = new System.Drawing.Point(345, 190);
            this.ossLinkLabel.Name = "ossLinkLabel";
            this.ossLinkLabel.Size = new System.Drawing.Size(27, 12);
            this.ossLinkLabel.TabIndex = 9;
            this.ossLinkLabel.TabStop = true;
            this.ossLinkLabel.Text = "OSS";
            this.ossLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OssLinkLabel_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.ossLinkLabel);
            this.Controls.Add(this.warnLinkLabel);
            this.Controls.Add(this.noDhitherCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backWhiteCheckbox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.pathBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Shizuku(CT-3) Image Converter";
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox backWhiteCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox noDhitherCheckbox;
        private System.Windows.Forms.LinkLabel warnLinkLabel;
        private System.Windows.Forms.LinkLabel ossLinkLabel;
    }
}

