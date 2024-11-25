using AForge.Imaging.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class Form1 : Form
    {
        Color default_color = Color.FromArgb(64, 64, 64);
        Color selected_color = Color.FromArgb(94, 94, 94);
        public Form1()
        {
            InitializeComponent();
            ApplySwitch.BackColor = selected_color;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (GoButton.Text.Equals("Apply") && !(ImageBox.Image == null || WatermarkBox.Image == null))
            {
                Bitmap simple = new Bitmap(ImageBox.Image);
                Bitmap secretGreyScale = new Bitmap(WatermarkBox.Image);

                if (secretGreyScale.Height != simple.Height || secretGreyScale.Width != simple.Width)
                {
                    ResizeBilinear resizeFilter = new ResizeBilinear(simple.Width, simple.Height);
                    secretGreyScale = resizeFilter.Apply(secretGreyScale);
                }

                Color pixelContainerImage = new Color();
                Color pixelMsgImage = new Color();

                byte[] MsgBits;
                byte[] AlphaBits;
                byte[] RedBits;
                byte[] GreenBits;
                byte[] BlueBits;
                byte newAlpha = 0;
                byte newRed = 0;
                byte newGreen = 0;
                byte newBlue = 0;

                #region Encryption
                Progress.Maximum = simple.Height * simple.Width;
                Progress.Step = 1;
                Progress.Value = 0; // Початок прогресу

                for (int i = 0; i < simple.Height; i++)
                {
                    for (int j = 0; j < simple.Width; j++)
                    {
                        pixelMsgImage = secretGreyScale.GetPixel(j, i);
                        MsgBits = getBits((byte)pixelMsgImage.R);
                        pixelContainerImage = simple.GetPixel(j, i);

                        AlphaBits = getBits((byte)pixelContainerImage.A);
                        RedBits = getBits((byte)pixelContainerImage.R);
                        GreenBits = getBits((byte)pixelContainerImage.G);
                        BlueBits = getBits((byte)pixelContainerImage.B);

                        // Зміна бітів для нанесення водяного знаку
                        AlphaBits[6] = MsgBits[0];
                        AlphaBits[7] = MsgBits[1];
                        RedBits[6] = MsgBits[2];
                        RedBits[7] = MsgBits[3];
                        GreenBits[6] = MsgBits[4];
                        GreenBits[7] = MsgBits[5];
                        BlueBits[6] = MsgBits[6];
                        BlueBits[7] = MsgBits[7];

                        newAlpha = getByte(AlphaBits);
                        newRed = getByte(RedBits);
                        newGreen = getByte(GreenBits);
                        newBlue = getByte(BlueBits);

                        pixelContainerImage = Color.FromArgb(newAlpha, newRed, newGreen, newBlue);
                        simple.SetPixel(j, i, pixelContainerImage);

                        // Оновлення прогрес-бару
                        Progress.PerformStep();
                        Application.DoEvents(); // Оновлює інтерфейс
                    }
                }

                ResultBox.Image = simple;
                ResultBox.SizeMode = PictureBoxSizeMode.StretchImage;
                Progress.Value = 0; // Скидання прогресу після завершення
                #endregion
            }
            else if (GoButton.Text.Equals("Read") && ImageBox.Image != null)
            {
                Bitmap EncryptedImage = (Bitmap)ImageBox.Image;
                Bitmap hiddenImage = new Bitmap(EncryptedImage.Width, EncryptedImage.Height);
                Color pixelToDecrypt = new Color();

                byte[] BitsToDecrypt = new byte[8];
                byte[] AlphaBits;
                byte[] RedBits;
                byte[] GreenBits;
                byte[] BlueBits;
                byte newGrey = 0;

                #region Decryption
                Progress.Maximum = EncryptedImage.Height * EncryptedImage.Width;
                Progress.Step = 1;
                Progress.Value = 0; // Початок прогресу

                for (int i = 0; i < EncryptedImage.Height; i++)
                {
                    for (int j = 0; j < EncryptedImage.Width; j++)
                    {
                        pixelToDecrypt = EncryptedImage.GetPixel(j, i);

                        AlphaBits = getBits((byte)pixelToDecrypt.A);
                        RedBits = getBits((byte)pixelToDecrypt.R);
                        GreenBits = getBits((byte)pixelToDecrypt.G);
                        BlueBits = getBits((byte)pixelToDecrypt.B);

                        // Витягуємо біти водяного знаку
                        BitsToDecrypt[0] = AlphaBits[6];
                        BitsToDecrypt[1] = AlphaBits[7];
                        BitsToDecrypt[2] = RedBits[6];
                        BitsToDecrypt[3] = RedBits[7];
                        BitsToDecrypt[4] = GreenBits[6];
                        BitsToDecrypt[5] = GreenBits[7];
                        BitsToDecrypt[6] = BlueBits[6];
                        BitsToDecrypt[7] = BlueBits[7];

                        newGrey = getByte(BitsToDecrypt);
                        pixelToDecrypt = Color.FromArgb(newGrey, newGrey, newGrey);
                        hiddenImage.SetPixel(j, i, pixelToDecrypt);

                        // Оновлення прогрес-бару
                        Progress.PerformStep();
                        Application.DoEvents(); // Оновлює інтерфейс
                    }
                }

                ResultBox.Image = hiddenImage;
                ResultBox.SizeMode = PictureBoxSizeMode.StretchImage;
                Progress.Value = 0; // Скидання прогресу після завершення
                #endregion
            }
        }
    



        private void ApplySwitch_Click(object sender, EventArgs e)
        {
            ApplySwitch.BackColor = selected_color;
            ReadSwitch.BackColor = default_color;
            GoButton.Text = "Apply";
            WatermarkBox.Visible = true;
            Clear();

        }

        private void ReadSwitch_Click(object sender, EventArgs e)
        {
            ReadSwitch.BackColor = selected_color;
            ApplySwitch.BackColor = default_color;
            GoButton.Text = "Read";
            WatermarkBox.Visible = false;
            Clear();

        }
        private void Clear()
        {
            ImageBox.Image = null;
            WatermarkBox.Image = null;
            ResultBox.Image = null;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void ImageBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Png Image (.png)|*.png| Bitmap Image (.bmp)|*.bmp| Gif Image(.gif) | *.gif | JPGImage(.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImageBox.ImageLocation = ofd.FileName;
                ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        private Bitmap ToGreyScale(Bitmap bitmap)
        {
            int grey, i, j;
            Color color;
            Progress.Maximum = bitmap.Width * bitmap.Height;
            Progress.Step = 1;
            for (i = 0; i < bitmap.Width; i++)
            {
                for (j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    grey = (int)((color.R + color.G + color.B) / 3);
                    bitmap.SetPixel(i, j, Color.FromArgb(grey, grey, grey));
                    Progress.PerformStep();
                }
            }
            Progress.Value = 0;
            return bitmap;
        }

        private void WatermarkBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Png Image (.png)|*.png| Bitmap Image (.bmp)|*.bmp| Gif Image(.gif) | *.gif | JPGImage(.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap img = new Bitmap(ofd.FileName);
                WatermarkBox.Image = ToGreyScale(img);
                WatermarkBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void ResultBox_Click(object sender, EventArgs e)
        {
            if (ResultBox.Image == null) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap Image (.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK) ResultBox.Image.Save(sfd.FileName);
        }
        private byte getByte(byte[] bits)
        {
            String bitString = "";
            for (int i = 0; i < 8; i++)
                bitString += bits[i];
            byte newpix = Convert.ToByte(bitString, 2);
            int dePix = (int)newpix ^ 2;
            return (byte)dePix;
        }
        private byte[] getBits(byte simplepixel)
        {
            int pixel = 0;
            pixel = (int)simplepixel ^ 2;
            BitArray bits = new BitArray(new byte[] { (byte)pixel });
            bool[] boolarray = new bool[bits.Count];
            bits.CopyTo(boolarray, 0);
            byte[] bitsArray = boolarray.Select(bit => (byte)(bit ? 1 : 0)).ToArray();
            Array.Reverse(bitsArray);
            return bitsArray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
