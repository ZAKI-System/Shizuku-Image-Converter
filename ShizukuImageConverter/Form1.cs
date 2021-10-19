using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ShizukuImageConverter
{
    public partial class Form1 : Form
    {
        private const int SzkW = 160;
        private const int SzkH = 128;

        private string loadedFileName;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>表示中の画像をShizuku用txt形式で保存</summary>
        private void Save()
        {
            if (resultPictureBox.Image == null)
            {
                MessageBox.Show("画像がロードされていません", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string savePath = Path.Combine(Path.GetDirectoryName(loadedFileName), Path.GetFileNameWithoutExtension(loadedFileName) + "-szkc.txt");
            if (MessageBox.Show(savePath+"\nに保存しますか？(同名のファイルは上書きされます)", "保存確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            // PixelScan開始
            using (var bitmap = new Bitmap(resultPictureBox.Image))
            using (var outputStream = new MemoryStream())
            using (var sw = new StreamWriter(outputStream))
            using (var fs = new FileStream(savePath, FileMode.Create))
            {
                // 縦
                for (int y = 0; y < SzkH; y++)
                {
                    // 横
                    for (int x = 0; x < SzkW; x++)
                    {
                        // 画像サイズ範囲内か
                        if (x < bitmap.Width && y < bitmap.Height)
                        {
                            Color color = bitmap.GetPixel(x, y);
                            if (color.R == 255 && color.G == 0 && color.B == 0)
                            {
                                sw.Write("0");
                            }
                            else if (color.R == 0 && color.G == 0 && color.B == 255)
                            {
                                sw.Write("1");
                            }
                            else if (color.R == 0 && color.G == 128 && color.B == 0)
                            {
                                sw.Write("2");
                            }
                            else if (color.R == 0 && color.G == 255 && color.B == 255)
                            {
                                sw.Write("3");
                            }
                            else if (color.R == 0 && color.G == 0 && color.B == 0)
                            {
                                sw.Write("4");
                            }
                            else if (color.R == 255 && color.G == 255 && color.B == 255)
                            {
                                sw.Write("5");
                            }
                            else if (color.R == 128 && color.G == 0 && color.B == 128)
                            {
                                sw.Write("6");
                            }
                            else if (color.R == 255 && color.G == 165 && color.B == 0)
                            {
                                sw.Write("7");
                            }
                            else if (color.R == 128 && color.G == 128 && color.B == 128)
                            {
                                sw.Write("8");
                            }
                            else if (color.R == 255 && color.G == 255 && color.B == 0)
                            {
                                sw.Write("9");
                            }
                            else if (color.R == 144 && color.G == 238 && color.B == 144)
                            {
                                sw.Write("10");
                            }
                            else if (color.R == 240 && color.G == 128 && color.B == 128)
                            {
                                sw.Write("11");
                            }
                            else if (color.R == 255 && color.G == 255 && color.B == 224)
                            {
                                sw.Write("12");
                            }
                            else if (color.R == 173 && color.G == 216 && color.B == 230)
                            {
                                sw.Write("13");
                            }
                            else if (color.R == 255 && color.G == 182 && color.B == 193)
                            //else if (color.R == 248 && color.G == 164 && color.B == 248)
                            {
                                sw.Write("14");
                            }
                            else if (color.R == 169 && color.G == 169 && color.B == 169)
                            {
                                sw.Write("15");
                            }
                            else
                            {
                                sw.Write("16");
                            }
                        }
                        else
                        {
                            sw.Write("16");
                        }
                        // 1pixel書き終わったら区切り
                        sw.Write(",");
                    }
                    // 横のpixelを全て書き終えたら改行
                    sw.WriteLine("");
                }
                // 反映、保存
                sw.Flush();
                outputStream.Seek(0, SeekOrigin.Begin);
                outputStream.CopyTo(fs);
            }
            MessageBox.Show(savePath+"\n入力と同じディレクトリに保存しました。\n使用時はShizukuの/img/ に入れ、list.txtにファイル名を追記してください。");
        }

        /// <summary>BitmapをShizuku向けに変換</summary>
        /// <param name="bitmap">入力画像Bitmap</param>
        /// <returns>Shizuku向けに変換された画像Bitmap</returns>
        private Bitmap Convert(Bitmap bitmap)
        {
            using (var inputStream = new MemoryStream())
            {
                // streamに展開
                bitmap.Save(inputStream, System.Drawing.Imaging.ImageFormat.Png);
                inputStream.Seek(0, SeekOrigin.Begin);
                using (var workImg = new MagickImage(inputStream))
                {
                    // サイズ変更と減色
                    using (IMagickImage<QuantumType> colors = CreatePalleteImage())
                    {
                        workImg.Resize(SzkW, SzkH);
                        workImg.Extent(SzkW, SzkH, Gravity.Center, backWhiteCheckbox.Checked ? MagickColors.White : MagickColors.Transparent);
                        if (noDhitherCheckbox.Checked)
                        {
                            workImg.Map(colors, new QuantizeSettings() { DitherMethod = DitherMethod.No });
                        }
                        else
                        {
                            workImg.Map(colors);
                        }
                    }
                    // 画像書き込みと生成
                    using (var outputStream = new MemoryStream())
                    {
                        workImg.Format = MagickFormat.Png;
                        workImg.Write(outputStream);
                        outputStream.Position = 0;
                        return new Bitmap(outputStream);
                    }
                }
            }
        }

        /// <summary>Shizuku減色用色画像生成</summary>
        /// <returns>減色用色画像</returns>
        private IMagickImage<QuantumType> CreatePalleteImage()
        {
            using (var images = new MagickImageCollection())
            {
                images.Add(new MagickImage(MagickColors.Red, 1, 1));
                images.Add(new MagickImage(MagickColors.Blue, 1, 1));
                images.Add(new MagickImage(MagickColors.Green, 1, 1));
                images.Add(new MagickImage(MagickColors.Cyan, 1, 1));
                images.Add(new MagickImage(MagickColors.Black, 1, 1));
                images.Add(new MagickImage(MagickColors.White, 1, 1));
                images.Add(new MagickImage(MagickColors.Purple, 1, 1));
                images.Add(new MagickImage(MagickColors.Orange, 1, 1));
                images.Add(new MagickImage(MagickColors.Gray, 1, 1));
                images.Add(new MagickImage(MagickColors.Yellow, 1, 1));
                images.Add(new MagickImage(MagickColors.LightGreen, 1, 1));
                images.Add(new MagickImage(MagickColors.LightCoral, 1, 1));//
                images.Add(new MagickImage(MagickColors.LightYellow, 1, 1));
                images.Add(new MagickImage(MagickColors.LightBlue, 1, 1));
                images.Add(new MagickImage(MagickColors.LightPink, 1, 1));//
                //images.Add(new MagickImage(new MagickColor("#F8A4F8FF"), 1, 1));//?
                images.Add(new MagickImage(MagickColors.DarkGray, 1, 1));

                return images.AppendHorizontally();
            }
        }

        /// <summary>D&amp;D開始時</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>D&amp;D処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                pathBox.Text = file;
                // 最初のファイルのみ
                break;
            }
        }

        /// <summary>参照ボタン</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "PNG画像ファイル (*.png)|*.png|JPG画像ファイル (*.jpg)|*.jpg";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 読み込み
                    pathBox.Text = fileDialog.FileName;
                }
            }
        }

        /// <summary>変換ボタン</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            pathBox.Text = pathBox.Text.Replace("\"", "");
            if (File.Exists(pathBox.Text))
            {
                loadedFileName = pathBox.Text;
                try
                {
                    using (var bitmap = new Bitmap(pathBox.Text))
                    {
                        resultPictureBox.Image = Convert(bitmap);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ファイルが存在しません", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>保存ボタン</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>注意事項クリック</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarnLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("このアプリケーションは個人開発です。バグが存在する可能性があります。\n保証はありません。", "注意事項", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>OSS一覧</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OssLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Magick.NET", "使用OSS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
