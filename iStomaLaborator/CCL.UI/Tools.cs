#region Using directives

using System;
using System.Drawing;
using System.Drawing.Imaging;

#endregion

namespace CCL.UI
{
    public static class Tools
    {


        #region Pixel Access


        private static unsafe byte GetRed(BitmapData bmd, int x, int y)
        {
            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
            return row[x * 3 + 2]; // red
        }

        private static unsafe void SetRed(BitmapData bmd, int x, int y, byte value)
        {
            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
            row[x * 3 + 2] = value; // red
        }

        private static unsafe byte GetGreen(BitmapData bmd, int x, int y)
        {
            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
            return row[x * 3 + 1]; // green
        }

        private static unsafe void SetGreen(BitmapData bmd, int x, int y, byte value)
        {
            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
            row[x * 3 + 1] = value; // green
        }

        private static unsafe byte GetBlue(BitmapData bmd, int x, int y)
        {
            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
            return row[x * 3 + 0]; // blue
        }

        private static unsafe void SetBlue(BitmapData bmd, int x, int y, byte value)
        {
            byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
            row[x * 3 + 0] = value; // blue
        }


        #endregion


        #region Color Filters


        public static void Grayscale(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // strip all colors but blue
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        int value;

                        // we set all components to the red-green-blue average
                        value = (GetRed(bmd, x, y) + GetGreen(bmd, x, y) + GetBlue(bmd, x, y)) / 3;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));

                        SetRed(bmd, x, y, (byte)value);
                        SetGreen(bmd, x, y, (byte)value);
                        SetBlue(bmd, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }

        public static void Negate(Bitmap image)
        {
            if (image == null || arePixeliiIndexati(image)) return; 
            
            const int RED_PIXEL = 2;
            const int GREEN_PIXEL = 1;
            const int BLUE_PIXEL = 0;

            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);

            try
            {
                int stride = bmData.Stride;
                int bytesPerPixel = (image.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4);

                unsafe
                {
                    byte* pixel = (byte*)(void*)bmData.Scan0;
                    int yMax = image.Height;
                    int xMax = image.Width;

                    for (int y = 0; y < yMax; y++)
                    {
                        int yPos = y * stride;
                        for (int x = 0; x < xMax; x++)
                        {
                            int pos = yPos + (x * bytesPerPixel);

                            pixel[pos + RED_PIXEL] = (byte)(255 - pixel[pos + RED_PIXEL]);
                            pixel[pos + GREEN_PIXEL] = (byte)(255 - pixel[pos + GREEN_PIXEL]);
                            pixel[pos + BLUE_PIXEL] = (byte)(255 - pixel[pos + BLUE_PIXEL]);
                        }

                    }
                }
            }
            finally
            {
                image.UnlockBits(bmData);
            }

        }

        public static bool arePixeliiIndexati(Bitmap bitmapImage)
        {
            return bitmapImage.PixelFormat == PixelFormat.Format1bppIndexed || bitmapImage.PixelFormat == PixelFormat.Format4bppIndexed || bitmapImage.PixelFormat == PixelFormat.Format8bppIndexed || bitmapImage.PixelFormat == PixelFormat.Indexed;
        }

        public static void Invert(Bitmap bitmapImage)
        {
            if (bitmapImage == null || arePixeliiIndexati(bitmapImage)) return;

            byte A, R, G, B;
            Color pixelColor;

            for (int y = 0; y < bitmapImage.Height; y++)
            {
                for (int x = 0; x < bitmapImage.Width; x++)
                {
                    pixelColor = bitmapImage.GetPixel(x, y);
                    A = pixelColor.A;
                    R = (byte)(255 - pixelColor.R);
                    G = (byte)(255 - pixelColor.G);
                    B = (byte)(255 - pixelColor.B);
                    bitmapImage.SetPixel(x, y, Color.FromArgb((int)A, (int)R, (int)G, (int)B));
                }
            }

            //Bitmap copy = new Bitmap(img.Width, img.Height);

            //ImageAttributes ia = new ImageAttributes();
            //ColorMatrix cm = new ColorMatrix();
            //cm.Matrix00 = cm.Matrix11 = cm.Matrix22 = 0.99f;
            //cm.Matrix33 = cm.Matrix44 = 1;
            //cm.Matrix40 = cm.Matrix41 = cm.Matrix42 = .04f;
            //ia.SetColorMatrix(cm);


            //Graphics g = Graphics.FromImage(copy);
            //g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            //g.Dispose();
            //img.Dispose();

            //return copy;
        }

        public static void InvertNaspa(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // invert values (255 - value)
                        SetRed(bmd, x, y, (byte)(255 - GetRed(bmd, x, y))); // red
                        SetGreen(bmd, x, y, (byte)(255 - GetGreen(bmd, x, y))); // green
                        SetBlue(bmd, x, y, (byte)(255 - GetBlue(bmd, x, y))); // blue
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void RedPass(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // strip all colors but red
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // we set green and blue to 0
                        SetBlue(bmd, x, y, 0); // blue
                        SetGreen(bmd, x, y, 0); // green
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }

        public static void RedBlock(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // strip red
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // we set red to 0
                        SetRed(bmd, x, y, 0); // red
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void GreenPass(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // strip all colors but green
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // we set red and blue to 0
                        SetRed(bmd, x, y, 0); // red
                        SetBlue(bmd, x, y, 0); // blue
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void GreenBlock(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // strip green
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // we set green to 0
                        SetGreen(bmd, x, y, 0); // green
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void BluePass(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // strip all colors but blue
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // we set red and green to 0
                        SetRed(bmd, x, y, 0); // red
                        SetGreen(bmd, x, y, 0); // green
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void BlueBlock(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // strip blue
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // we set blue to 0
                        SetBlue(bmd, x, y, 0); // blue
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        #endregion


        #region Weight Filters


        public static void Blur(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply bluring algorithm:
            // bluring algorithm is:
            // 1/9 1/9 1/9
            // 1/9 1/9 1/9
            // 1/9 1/9 1/9

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            (
                            GetRed(bmdOld, x - 1, y - 1) +
                            GetRed(bmdOld, x + 0, y - 1) +
                            GetRed(bmdOld, x + 1, y - 1) +
                            GetRed(bmdOld, x - 1, y + 0) +
                            GetRed(bmdOld, x + 0, y + 0) +
                            GetRed(bmdOld, x + 1, y + 0) +
                            GetRed(bmdOld, x - 1, y + 1) +
                            GetRed(bmdOld, x + 0, y + 1) +
                            GetRed(bmdOld, x + 1, y + 1)
                            ) / 9;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            (
                            GetGreen(bmdOld, x - 1, y - 1) +
                            GetGreen(bmdOld, x + 0, y - 1) +
                            GetGreen(bmdOld, x + 1, y - 1) +
                            GetGreen(bmdOld, x - 1, y + 0) +
                            GetGreen(bmdOld, x + 0, y + 0) +
                            GetGreen(bmdOld, x + 1, y + 0) +
                            GetGreen(bmdOld, x - 1, y + 1) +
                            GetGreen(bmdOld, x + 0, y + 1) +
                            GetGreen(bmdOld, x + 1, y + 1)
                            ) / 9;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            (
                            GetBlue(bmdOld, x - 1, y - 1) +
                            GetBlue(bmdOld, x + 0, y - 1) +
                            GetBlue(bmdOld, x + 1, y - 1) +
                            GetBlue(bmdOld, x - 1, y + 0) +
                            GetBlue(bmdOld, x + 0, y + 0) +
                            GetBlue(bmdOld, x + 1, y + 0) +
                            GetBlue(bmdOld, x - 1, y + 1) +
                            GetBlue(bmdOld, x + 0, y + 1) +
                            GetBlue(bmdOld, x + 1, y + 1)
                            ) / 9;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void HorizontalBlur(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply horizontal bluring algorithm:
            // horizontal bluring algorithm is:
            // 1/5 1/5 1/5 1/5 1/5

            unsafe
            {
                for (int y = 0; y < bmdBmp.Height; y++)
                {
                    for (int x = 2; x < bmdBmp.Width - 2; x++)
                    {
                        int value;

                        // Red
                        value =
                            (
                            GetRed(bmdOld, x - 2, y) +
                            GetRed(bmdOld, x - 1, y) +
                            GetRed(bmdOld, x + 0, y) +
                            GetRed(bmdOld, x + 1, y) +
                            GetRed(bmdOld, x + 2, y)
                            ) / 5;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            (
                            GetGreen(bmdOld, x - 2, y) +
                            GetGreen(bmdOld, x - 1, y) +
                            GetGreen(bmdOld, x + 0, y) +
                            GetGreen(bmdOld, x + 1, y) +
                            GetGreen(bmdOld, x + 2, y)
                            ) / 5;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            (
                            GetBlue(bmdOld, x + 2, y) +
                            GetBlue(bmdOld, x - 1, y) +
                            GetBlue(bmdOld, x + 0, y) +
                            GetBlue(bmdOld, x + 1, y) +
                            GetBlue(bmdOld, x + 2, y)
                            ) / 5;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void VerticalBlur(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply vertical bluring algorithm:
            // vertical bluring algorithm is:
            // 1/5
            // 1/5
            // 1/5
            // 1/5
            // 1/5

            unsafe
            {
                for (int y = 2; y < bmdBmp.Height - 2; y++)
                {
                    for (int x = 0; x < bmdBmp.Width; x++)
                    {
                        int value;

                        // Red
                        value =
                            (
                            GetRed(bmdOld, x, y - 2) +
                            GetRed(bmdOld, x, y - 1) +
                            GetRed(bmdOld, x, y + 0) +
                            GetRed(bmdOld, x, y + 1) +
                            GetRed(bmdOld, x, y + 2)
                            ) / 5;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            (
                            GetGreen(bmdOld, x, y - 2) +
                            GetGreen(bmdOld, x, y - 1) +
                            GetGreen(bmdOld, x, y + 0) +
                            GetGreen(bmdOld, x, y + 1) +
                            GetGreen(bmdOld, x, y + 2)
                            ) / 5;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            (
                            GetBlue(bmdOld, x, y - 2) +
                            GetBlue(bmdOld, x, y - 1) +
                            GetBlue(bmdOld, x, y + 0) +
                            GetBlue(bmdOld, x, y + 1) +
                            GetBlue(bmdOld, x, y + 2)
                            ) / 5;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void Soften(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply softening algorithm:
            // softening algorithm is:
            // 1/18  1/18  1/18
            // 1/18 10/18  1/18
            // 1/18  1/18  1/18

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            (
                            GetRed(bmdOld, x - 1, y - 1) +
                            GetRed(bmdOld, x + 0, y - 1) +
                            GetRed(bmdOld, x + 1, y - 1) +
                            GetRed(bmdOld, x - 1, y + 0) +
                            10 * GetRed(bmdOld, x + 0, y + 0) +
                            GetRed(bmdOld, x + 1, y + 0) +
                            GetRed(bmdOld, x - 1, y + 1) +
                            GetRed(bmdOld, x + 0, y + 1) +
                            GetRed(bmdOld, x + 1, y + 1)
                            ) / 18;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            (
                            GetGreen(bmdOld, x - 1, y - 1) +
                            GetGreen(bmdOld, x + 0, y - 1) +
                            GetGreen(bmdOld, x + 1, y - 1) +
                            GetGreen(bmdOld, x - 1, y + 0) +
                            10 * GetGreen(bmdOld, x + 0, y + 0) +
                            GetGreen(bmdOld, x + 1, y + 0) +
                            GetGreen(bmdOld, x - 1, y + 1) +
                            GetGreen(bmdOld, x + 0, y + 1) +
                            GetGreen(bmdOld, x + 1, y + 1)
                            ) / 18;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            (
                            GetBlue(bmdOld, x - 1, y - 1) +
                            GetBlue(bmdOld, x + 0, y - 1) +
                            GetBlue(bmdOld, x + 1, y - 1) +
                            GetBlue(bmdOld, x - 1, y + 0) +
                            10 * GetBlue(bmdOld, x + 0, y + 0) +
                            GetBlue(bmdOld, x + 1, y + 0) +
                            GetBlue(bmdOld, x - 1, y + 1) +
                            GetBlue(bmdOld, x + 0, y + 1) +
                            GetBlue(bmdOld, x + 1, y + 1)
                            ) / 18;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void SharpenI(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply first sharpening algorithm:
            // first sharpening algorithm is:
            //   0   -1/2   0
            // -1/2   6/2  -1/2
            //   0   -1/2   0

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            (
                            -GetRed(bmdOld, x + 0, y - 1)
                            - GetRed(bmdOld, x - 1, y + 0)
                            + 6 * GetRed(bmdOld, x + 0, y + 0)
                            - GetRed(bmdOld, x + 1, y + 0)
                            - GetRed(bmdOld, x + 0, y + 1)
                            ) / 2;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            (
                            -GetGreen(bmdOld, x + 0, y - 1)
                            - GetGreen(bmdOld, x - 1, y + 0)
                            + 6 * GetGreen(bmdOld, x + 0, y + 0)
                            - GetGreen(bmdOld, x + 1, y + 0)
                            - GetGreen(bmdOld, x + 0, y + 1)
                            ) / 2;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            (
                            -GetBlue(bmdOld, x + 0, y - 1)
                            - GetBlue(bmdOld, x - 1, y + 0)
                            + 6 * GetBlue(bmdOld, x + 0, y + 0)
                            - GetBlue(bmdOld, x + 1, y + 0)
                            - GetBlue(bmdOld, x + 0, y + 1)
                            ) / 2;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void SharpenII(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply second sharpening algorithm:
            // second sharpening algorithm is:
            // 
            //           1/8  1/8  1/8
            // Delta =   1/8 -8/8  1/8
            //           1/8  1/8  1/8
            //
            // pixel -= delta OR pixel -= 2*delta

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            (
                            +GetRed(bmdOld, x - 1, y - 1)
                            + GetRed(bmdOld, x + 0, y - 1)
                            + GetRed(bmdOld, x + 1, y - 1)
                            + GetRed(bmdOld, x - 1, y + 0)
                            - 8 * GetRed(bmdOld, x + 0, y + 0)
                            + GetRed(bmdOld, x + 1, y + 0)
                            + GetRed(bmdOld, x - 1, y + 1)
                            + GetRed(bmdOld, x + 0, y + 1)
                            + GetRed(bmdOld, x + 1, y + 1)
                            ) / 8;
                        value = GetRed(bmdOld, x, y) - value;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            (
                            +GetGreen(bmdOld, x - 1, y - 1)
                            + GetGreen(bmdOld, x + 0, y - 1)
                            + GetGreen(bmdOld, x + 1, y - 1)
                            + GetGreen(bmdOld, x - 1, y + 0)
                            - 8 * GetGreen(bmdOld, x + 0, y + 0)
                            + GetGreen(bmdOld, x + 1, y + 0)
                            + GetGreen(bmdOld, x - 1, y + 1)
                            + GetGreen(bmdOld, x + 0, y + 1)
                            + GetGreen(bmdOld, x + 1, y + 1)
                            ) / 8;
                        value = GetGreen(bmdOld, x, y) - value;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            (
                            +GetBlue(bmdOld, x - 1, y - 1)
                            + GetBlue(bmdOld, x + 0, y - 1)
                            + GetBlue(bmdOld, x + 1, y - 1)
                            + GetBlue(bmdOld, x - 1, y + 0)
                            - 8 * GetBlue(bmdOld, x + 0, y + 0)
                            + GetBlue(bmdOld, x + 1, y + 0)
                            + GetBlue(bmdOld, x - 1, y + 1)
                            + GetBlue(bmdOld, x + 0, y + 1)
                            + GetBlue(bmdOld, x + 1, y + 1)
                            ) / 8;
                        value = GetBlue(bmdOld, x, y) - value;
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void EmbossTL(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply embossing algorithm:
            // embossing algorithm is:
            //  1  0  0
            //  0  0  0 
            //  0  0 -1

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            +GetRed(bmdOld, x - 1, y - 1)
                            - GetRed(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            +GetGreen(bmdOld, x - 1, y - 1)
                            - GetGreen(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            +GetBlue(bmdOld, x - 1, y - 1)
                            - GetBlue(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void EmbossBR(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply embossing algorithm:
            // embossing algorithm is:
            // -1  0  0
            //  0  0  0
            //  0  0  1

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            -GetRed(bmdOld, x - 1, y - 1)
                            + GetRed(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            -GetGreen(bmdOld, x - 1, y - 1)
                            + GetGreen(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            -GetBlue(bmdOld, x - 1, y - 1)
                            + GetBlue(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }

        public static void EdgeDetectionLH(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply edge detection algorithm:
            // edge detection algorithm is:
            //  1  1 -1
            //  1 -2 -1
            //  1  1 -1

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            +GetRed(bmdOld, x - 1, y - 1)
                            + GetRed(bmdOld, x - 1, y + 0)
                            + GetRed(bmdOld, x - 1, y + 1)
                            + GetRed(bmdOld, x + 0, y - 1)
                            - 2 * GetRed(bmdOld, x + 0, y + 0)
                            + GetRed(bmdOld, x + 0, y + 1)
                            - GetRed(bmdOld, x + 1, y - 1)
                            - GetRed(bmdOld, x + 1, y + 0)
                            - GetRed(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            +GetGreen(bmdOld, x - 1, y - 1)
                            + GetGreen(bmdOld, x - 1, y + 0)
                            + GetGreen(bmdOld, x - 1, y + 1)
                            + GetGreen(bmdOld, x + 0, y - 1)
                            - 2 * GetGreen(bmdOld, x + 0, y + 0)
                            + GetGreen(bmdOld, x + 0, y + 1)
                            - GetGreen(bmdOld, x + 1, y - 1)
                            - GetGreen(bmdOld, x + 1, y + 0)
                            - GetGreen(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            +GetBlue(bmdOld, x - 1, y - 1)
                            + GetBlue(bmdOld, x - 1, y + 0)
                            + GetBlue(bmdOld, x - 1, y + 1)
                            + GetBlue(bmdOld, x + 0, y - 1)
                            - 2 * GetBlue(bmdOld, x + 0, y + 0)
                            + GetBlue(bmdOld, x + 0, y + 1)
                            - GetBlue(bmdOld, x + 1, y - 1)
                            - GetBlue(bmdOld, x + 1, y + 0)
                            - GetBlue(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void EdgeDetectionULH(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply edge detection algorithm:
            // edge detection algorithm is:
            //  1  1  1
            //  1 -2 -1
            //  1 -1 -1

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value;

                        // Red
                        value =
                            +GetRed(bmdOld, x - 1, y - 1)
                            + GetRed(bmdOld, x - 1, y + 0)
                            - GetRed(bmdOld, x - 1, y + 1)
                            + GetRed(bmdOld, x + 0, y - 1)
                            - 2 * GetRed(bmdOld, x + 0, y + 0)
                            + GetRed(bmdOld, x + 0, y + 1)
                            + GetRed(bmdOld, x + 1, y - 1)
                            - GetRed(bmdOld, x + 1, y + 0)
                            - GetRed(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value =
                            +GetGreen(bmdOld, x - 1, y - 1)
                            + GetGreen(bmdOld, x - 1, y + 0)
                            - GetGreen(bmdOld, x - 1, y + 1)
                            + GetGreen(bmdOld, x + 0, y - 1)
                            - 2 * GetGreen(bmdOld, x + 0, y + 0)
                            + GetGreen(bmdOld, x + 0, y + 1)
                            + GetGreen(bmdOld, x + 1, y - 1)
                            - GetGreen(bmdOld, x + 1, y + 0)
                            - GetGreen(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value =
                            +GetBlue(bmdOld, x - 1, y - 1)
                            + GetBlue(bmdOld, x - 1, y + 0)
                            - GetBlue(bmdOld, x - 1, y + 1)
                            + GetBlue(bmdOld, x + 0, y - 1)
                            - 2 * GetBlue(bmdOld, x + 0, y + 0)
                            + GetBlue(bmdOld, x + 0, y + 1)
                            + GetBlue(bmdOld, x + 1, y - 1)
                            - GetBlue(bmdOld, x + 1, y + 0)
                            - GetBlue(bmdOld, x + 1, y + 1);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        public static void EdgeDetectionPrewittCombined(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // create temporary bitmap
            Bitmap old = (Bitmap)bmp.Clone();

            // lock image bits for faster access
            BitmapData bmdBmp = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            BitmapData bmdOld = old.LockBits(new Rectangle(0, 0, old.Width, old.Height), ImageLockMode.ReadOnly, old.PixelFormat);

            // apply edge detection algorithm:
            // -1  0  1     -1 -1 -1
            // -1  0  1 and  0  0  0
            // -1  0  1      1  1  1

            unsafe
            {
                for (int y = 1; y < bmdBmp.Height - 1; y++)
                {
                    for (int x = 1; x < bmdBmp.Width - 1; x++)
                    {
                        int value, value1, value2;
                        double v1, v2;
                        double k1, k2;

                        k1 = 1.0;
                        k2 = 1.0;

                        // Red
                        value1 =
                            -GetRed(bmdOld, x - 1, y - 1)
                            - GetRed(bmdOld, x - 1, y + 0)
                            - GetRed(bmdOld, x - 1, y + 1)
                            + GetRed(bmdOld, x + 1, y - 1)
                            + GetRed(bmdOld, x + 1, y + 0)
                            + GetRed(bmdOld, x + 1, y + 1);
                        value2 =
                            -GetRed(bmdOld, x - 1, y - 1)
                            - GetRed(bmdOld, x + 0, y - 1)
                            - GetRed(bmdOld, x + 1, y - 1)
                            + GetRed(bmdOld, x - 1, y + 1)
                            + GetRed(bmdOld, x + 0, y + 1)
                            + GetRed(bmdOld, x + 1, y + 1);
                        v1 = k1 * Math.Abs(value1) / 255.0;
                        v2 = k2 * Math.Abs(value2) / 255.0;
                        value = (int)(Math.Sqrt(v1 * v1 + v2 * v2) * 255);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetRed(bmdBmp, x, y, (byte)value);

                        // Green
                        value1 =
                            -GetGreen(bmdOld, x - 1, y - 1)
                            - GetGreen(bmdOld, x - 1, y + 0)
                            - GetGreen(bmdOld, x - 1, y + 1)
                            + GetGreen(bmdOld, x + 1, y - 1)
                            + GetGreen(bmdOld, x + 1, y + 0)
                            + GetGreen(bmdOld, x + 1, y + 1);
                        value2 =
                            -GetGreen(bmdOld, x - 1, y - 1)
                            - GetGreen(bmdOld, x + 0, y - 1)
                            - GetGreen(bmdOld, x + 1, y - 1)
                            + GetGreen(bmdOld, x - 1, y + 1)
                            + GetGreen(bmdOld, x + 0, y + 1)
                            + GetGreen(bmdOld, x + 1, y + 1);
                        v1 = k1 * Math.Abs(value1) / 255.0;
                        v2 = k2 * Math.Abs(value2) / 255.0;
                        value = (int)(Math.Sqrt(v1 * v1 + v2 * v2) * 255);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetGreen(bmdBmp, x, y, (byte)value);

                        // Blue
                        value1 =
                            -GetBlue(bmdOld, x - 1, y - 1)
                            - GetBlue(bmdOld, x - 1, y + 0)
                            - GetBlue(bmdOld, x - 1, y + 1)
                            + GetBlue(bmdOld, x + 1, y - 1)
                            + GetBlue(bmdOld, x + 1, y + 0)
                            + GetBlue(bmdOld, x + 1, y + 1);
                        value2 =
                            -GetBlue(bmdOld, x - 1, y - 1)
                            - GetBlue(bmdOld, x + 0, y - 1)
                            - GetBlue(bmdOld, x + 1, y - 1)
                            + GetBlue(bmdOld, x - 1, y + 1)
                            + GetBlue(bmdOld, x + 0, y + 1)
                            + GetBlue(bmdOld, x + 1, y + 1);
                        v1 = k1 * Math.Abs(value1) / 255.0;
                        v2 = k2 * Math.Abs(value2) / 255.0;
                        value = (int)(Math.Sqrt(v1 * v1 + v2 * v2) * 255);
                        value = (value < 0 ? 0 : (value > 255 ? 255 : value));
                        SetBlue(bmdBmp, x, y, (byte)value);
                    }
                }
            }

            // unlock data
            old.UnlockBits(bmdOld);
            bmp.UnlockBits(bmdBmp);
        }


        #endregion


        #region Level Filters


        public static void OrderedDitherI(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // apply ordered dither algorithm
            int dim = 6;
            int max = 18;
            int[,] levels = {
				{ 9,  7,  8, 10, 12, 11},
				{ 6,  1,  2, 13, 18, 17},
				{ 5,  4,  3, 14, 15, 16},
				{10, 12, 11,  9,  7,  8},
				{13, 18, 17,  6,  1,  2},
				{14, 15, 16,  5,  4,  3}
			};

            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // red
                        if (GetRed(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetRed(bmd, x, y, 255);
                        else
                            SetRed(bmd, x, y, 0);

                        // green
                        if (GetGreen(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetGreen(bmd, x, y, 255);
                        else
                            SetGreen(bmd, x, y, 0);

                        // blue
                        if (GetBlue(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetBlue(bmd, x, y, 255);
                        else
                            SetBlue(bmd, x, y, 0);
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void OrderedDitherII(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // apply ordered dither algorithm
            int dim = 8;
            int max = 32;
            int[,] levels = {
				{14, 12, 13, 16, 19, 21, 20, 17},
				{ 5,  4,  3, 10, 28, 29, 30, 23},
				{ 6,  1,  2, 11, 27, 32, 31, 22},
				{ 9,  7,  8, 15, 24, 26, 25, 18},
				{19, 21, 20, 17, 14, 12, 13, 16},
				{28, 29, 30, 23,  5,  4,  3, 10},
				{27, 32, 31, 22,  6,  1,  2, 11},
				{24, 26, 25, 18,  9,  7,  8, 15}
			};

            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // red
                        if (GetRed(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetRed(bmd, x, y, 255);
                        else
                            SetRed(bmd, x, y, 0);

                        // green
                        if (GetGreen(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetGreen(bmd, x, y, 255);
                        else
                            SetGreen(bmd, x, y, 0);

                        // blue
                        if (GetBlue(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetBlue(bmd, x, y, 255);
                        else
                            SetBlue(bmd, x, y, 0);
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void DispersedDot(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // apply ordered dither algorithm
            int dim = 4;
            int max = 16;
            int[,] levels = {
				{ 2, 16,  3, 13},
				{10,  6, 11,  7},
				{ 4, 14,  1, 15},
				{12,  8,  9,  5}
			};

            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // red
                        if (GetRed(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetRed(bmd, x, y, 255);
                        else
                            SetRed(bmd, x, y, 0);

                        // green
                        if (GetGreen(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetGreen(bmd, x, y, 255);
                        else
                            SetGreen(bmd, x, y, 0);

                        // blue
                        if (GetBlue(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetBlue(bmd, x, y, 255);
                        else
                            SetBlue(bmd, x, y, 0);
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void LineHalftone(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // apply ordered dither algorithm
            int dim = 6;
            int max = 36;
            int[,] levels = {
				{36, 34, 32, 31, 33, 35},
				{24, 22, 20, 19, 21, 23},
				{12, 10,  8,  7,  9, 11},
				{ 6,  4,  2,  1,  3,  5},
				{18, 16, 14, 13, 15, 17},
				{30, 28, 26, 25, 27, 29}
			};


            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // red
                        if (GetRed(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetRed(bmd, x, y, 255);
                        else
                            SetRed(bmd, x, y, 0);

                        // green
                        if (GetGreen(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetGreen(bmd, x, y, 255);
                        else
                            SetGreen(bmd, x, y, 0);

                        // blue
                        if (GetBlue(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetBlue(bmd, x, y, 255);
                        else
                            SetBlue(bmd, x, y, 0);
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void SnakeDither(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // apply ordered dither algorithm
            int dim = 8;
            int max = 32;
            int[,] levels = {
				{32, 30, 20, 18, 25, 27, 21, 23},
				{22, 24,  4,  2, 17, 19,  5,  7},
				{ 8,  6, 12, 10,  1,  3, 13, 15},
				{16, 14, 28, 26,  9, 11, 29, 31},
				{25, 27, 21, 23, 32, 30, 20, 18},
				{17, 19,  5,  7, 22, 24,  4,  2},
				{ 1,  3, 13, 15,  8,  6, 12, 10},
				{ 9, 11, 29, 31, 16, 14, 28, 26}
			};


            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // red
                        if (GetRed(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetRed(bmd, x, y, 255);
                        else
                            SetRed(bmd, x, y, 0);

                        // green
                        if (GetGreen(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetGreen(bmd, x, y, 255);
                        else
                            SetGreen(bmd, x, y, 0);

                        // blue
                        if (GetBlue(bmd, x, y) * max > levels[y % dim, x % dim] * 255)
                            SetBlue(bmd, x, y, 255);
                        else
                            SetBlue(bmd, x, y, 0);
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        #endregion


        #region Other Effects


        public static void ErrorDiffusion(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // the main working variables
            int treshold = 127;
            int error;

            // create two buffers of ints (we use width+2 so that we get two additional elements on
            // the left and on the right, so we don't have to worry about using first[-1] for example)
            int[] r = new int[bmd.Width + 2];
            int[] g = new int[bmd.Width + 2];
            int[] b = new int[bmd.Width + 2];
            int[] r_ = new int[bmd.Width + 2];
            int[] g_ = new int[bmd.Width + 2];
            int[] b_ = new int[bmd.Width + 2];

            // copy the first line
            for (int x = 0; x < bmd.Width; x++)
            {
                r[x + 1] = GetRed(bmd, x, 0);
                g[x + 1] = GetGreen(bmd, x, 0);
                b[x + 1] = GetBlue(bmd, x, 0);
            }

            // now let's run the algorithm for all the lines, excluding the last one
            unsafe
            {
                for (int y = 0; y < bmd.Height - 1; y++)
                {
                    // copy the second line
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        r_[x + 1] = GetRed(bmd, x, y + 1);
                        g_[x + 1] = GetGreen(bmd, x, y + 1);
                        b_[x + 1] = GetBlue(bmd, x, y + 1);
                    }

                    // run the error diffusion code for the current line
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // --- RED

                        int red = r[x + 1];

                        // set curent element
                        if (red > treshold)
                        {
                            error = red - 255;
                            red = 255;
                        }
                        else
                        {
                            error = red;
                            red = 0;
                        }

                        // set color
                        SetRed(bmd, x, y, (byte)red);

                        // propagate error to neighbours
                        r_[x] += error * 3 / 16;				// down, left	-> 3/16*error
                        r_[x + 1] += error * 5 / 16;			// down			-> 5/16*error
                        r_[x + 2] += error * 1 / 16;			// down, right	-> 1/16*error
                        r[x + 2] += error * 7 / 16;				// right		-> 7/16*error


                        // --- GREEN

                        int green = g[x + 1];

                        // set curent element
                        if (green > treshold)
                        {
                            error = green - 255;
                            green = 255;
                        }
                        else
                        {
                            error = green;
                            green = 0;
                        }

                        // set color
                        SetGreen(bmd, x, y, (byte)green);

                        // propagate error to neighbours
                        g_[x] += error * 3 / 16;				// down, left	-> 3/16*error
                        g_[x + 1] += error * 5 / 16;			// down			-> 5/16*error
                        g_[x + 2] += error * 1 / 16;			// down, right	-> 1/16*error
                        g[x + 2] += error * 7 / 16;				// right		-> 7/16*error


                        // --- BLUE

                        int blue = b[x + 1];

                        // set curent element
                        if (blue > treshold)
                        {
                            error = blue - 255;
                            blue = 255;
                        }
                        else
                        {
                            error = blue;
                            blue = 0;
                        }

                        // set color
                        SetBlue(bmd, x, y, (byte)blue);

                        // propagate error to neighbours
                        b_[x] += error * 3 / 16;				// down, left	-> 3/16*error
                        b_[x + 1] += error * 5 / 16;			// down			-> 5/16*error
                        b_[x + 2] += error * 1 / 16;			// down, right	-> 1/16*error
                        b[x + 2] += error * 7 / 16;				// right		-> 7/16*error
                    }

                    // swap lines
                    int[] tmp;
                    tmp = r; r = r_; r_ = tmp;
                    tmp = g; g = g_; g_ = tmp;
                    tmp = b; b = b_; b_ = tmp;
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        public static void HistogramEqualization(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // histogram array
            int[] hist;
            hist = new int[256];
            // histogram transform
            int[] transform;
            transform = new int[256];

            // RED

            // reset the histogram
            for (int i = 0; i < 256; i++)
                hist[i] = 0;
            // compute the image histogram
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                    hist[GetRed(bmd, x, y)]++;
            // compute the cumulative histogram
            for (int i = 1; i < 256; i++)
                hist[i] += hist[i - 1];
            // compute the histogram transformation
            for (int i = 1; i < 256; i++)
                transform[i] = 255 * hist[i] / (bmd.Width * bmd.Height);
            // now rewrite the color component
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                    SetRed(bmd, x, y, (byte)transform[GetRed(bmd, x, y)]);

            // GREEN

            // reset the histogram
            for (int i = 0; i < 256; i++)
                hist[i] = 0;
            // compute the image histogram
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                    hist[GetGreen(bmd, x, y)]++;
            // compute the cumulative histogram
            for (int i = 1; i < 256; i++)
                hist[i] += hist[i - 1];
            // compute the histogram transformation
            for (int i = 1; i < 256; i++)
                transform[i] = 255 * hist[i] / (bmd.Width * bmd.Height);
            // now rewrite the color component
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                    SetGreen(bmd, x, y, (byte)transform[GetGreen(bmd, x, y)]);

            // BLUE

            // reset the histogram
            for (int i = 0; i < 256; i++)
                hist[i] = 0;
            // compute the image histogram
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                    hist[GetBlue(bmd, x, y)]++;
            // compute the cumulative histogram
            for (int i = 1; i < 256; i++)
                hist[i] += hist[i - 1];
            // compute the histogram transformation
            for (int i = 1; i < 256; i++)
                transform[i] = 255 * hist[i] / (bmd.Width * bmd.Height);
            // now rewrite the color component
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                    SetBlue(bmd, x, y, (byte)transform[GetBlue(bmd, x, y)]);

            // unlock data
            bmp.UnlockBits(bmd);
        }


        #endregion


        #region Histogram


        public static float[] HistogramGray(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return null;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // histogram array
            float[] hist;
            hist = new float[256];
            float max = 0.0F;

            // GRAY AVERAGE

            // reset the histogram
            for (int i = 0; i < 256; i++)
                hist[i] = 0.0F;
            // compute the image histogram
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                {
                    int level = (GetRed(bmd, x, y) + GetGreen(bmd, x, y) + GetBlue(bmd, x, y)) / 3;
                    hist[level] += 1.0F;
                    if (hist[level] > max)
                        max = hist[level];
                }

            // scale histogram according to the max
            for (int i = 0; i < 256; i++)
                hist[i] /= max;

            // unlock data
            bmp.UnlockBits(bmd);

            // return the computed histogram
            return hist;
        }


        public static float[] HistogramRed(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return null;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // histogram array
            float[] hist;
            hist = new float[256];
            float max = 0.0F;

            // RED

            // reset the histogram
            for (int i = 0; i < 256; i++)
                hist[i] = 0.0F;
            // compute the image histogram
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                {
                    int level = GetRed(bmd, x, y);
                    hist[level] += 1.0F;
                    if (hist[level] > max)
                        max = hist[level];
                }

            // scale histogram according to the max
            for (int i = 0; i < 256; i++)
                hist[i] /= max;

            // unlock data
            bmp.UnlockBits(bmd);

            // return the computed histogram
            return hist;
        }


        public static float[] HistogramGreen(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return null;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // histogram array
            float[] hist;
            hist = new float[256];
            float max = 0.0F;

            // GREEN

            // reset the histogram
            for (int i = 0; i < 256; i++)
                hist[i] = 0.0F;
            // compute the image histogram
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                {
                    int level = GetGreen(bmd, x, y);
                    hist[level] += 1.0F;
                    if (hist[level] > max)
                        max = hist[level];
                }

            // scale histogram according to the max
            for (int i = 0; i < 256; i++)
                hist[i] /= max;

            // unlock data
            bmp.UnlockBits(bmd);

            // return the computed histogram
            return hist;
        }


        public static float[] HistogramBlue(Bitmap bmp)
        {
            // check that we have the image
            if (bmp == null)
                return null;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            // histogram array
            float[] hist;
            hist = new float[256];
            float max = 0.0F;

            // GREEN

            // reset the histogram
            for (int i = 0; i < 256; i++)
                hist[i] = 0.0F;
            // compute the image histogram
            for (int x = 0; x < bmd.Width; x++)
                for (int y = 0; y < bmd.Height; y++)
                {
                    int level = GetBlue(bmd, x, y);
                    hist[level] += 1.0F;
                    if (hist[level] > max)
                        max = hist[level];
                }

            // scale histogram according to the max
            for (int i = 0; i < 256; i++)
                hist[i] /= max;

            // unlock data
            bmp.UnlockBits(bmd);

            // return the computed histogram
            return hist;
        }


        #endregion


        #region Brightness / Contrast


        public static Bitmap AdjustBrightness(Bitmap bmp, float valoare)
        {
            float lBrightness = valoare * 0.01f;
            float[][] colorMatrixElements = {
      new float[] {
            1,
            0,
            0,
            0,
            0
      },
      new float[] {
            0,
            1,
            0,
            0,
            0
      },
      new float[] {
            0,
            0,
            1,
            0,
            0
      },
      new float[] {
            0,
            0,
            0,
            1,
            0
      },
      new float[] {
            lBrightness,
            lBrightness,
            lBrightness,
            0,
            1
      }
};
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            Bitmap bm_dest = null;
            Image _img = bmp;
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
                using (Graphics _g = Graphics.FromImage(bm_dest))
                {
                    _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
                }
            }

            colorMatrixElements = null;
            _img = null;

            return bm_dest;
        }

        public static void Brightness(Bitmap bmp, int delta)
        {
            // clamp to -255..255
            delta = (delta < -255) ? -255 : (delta > 255) ? 255 : delta;

            // check that we have the image
            if (bmp == null)
                return;

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // adjust brightness
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // get new values for all components
                        int red = GetRed(bmd, x, y) + delta;
                        int green = GetGreen(bmd, x, y) + delta;
                        int blue = GetBlue(bmd, x, y) + delta;
                        // apply 0..255 bounds
                        red = (red < 0) ? 0 : (red > 255) ? 255 : red;
                        green = (green < 0) ? 0 : (green > 255) ? 255 : green;
                        blue = (blue < 0) ? 0 : (blue > 255) ? 255 : blue;
                        // update colors
                        SetRed(bmd, x, y, (byte)red); // red
                        SetGreen(bmd, x, y, (byte)green); // green
                        SetBlue(bmd, x, y, (byte)blue); // blue
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }

        public static Bitmap AdjustContrast(Bitmap Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        public static void Contrast(Bitmap bmp, int perc)
        {
            // check that we have the image
            if (bmp == null)
                return;

            // clamp to -100..100
            perc = (perc < -100) ? -100 : (perc > 100) ? 100 : perc;
            // get angle
            double angle = Math.PI / 4 * ((double)perc / 100 + 1.0);

            // lock image bits for faster access
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);

            // compute color transform array
            byte[] color = new byte[256];
            if (angle >= Math.PI / 2)
                angle = Math.PI / 2 - 0.001;
            if (angle < 0.0)
                angle = 0.0;
            double tanalpha = Math.Tan(angle);
            double xx, yy;
            for (int i = 0; i < 256; i++)
            {
                xx = i;
                yy = (xx - 127) * tanalpha + 127;
                yy = (yy < 0.0) ? 0.0 : (yy > 255.0) ? 255.0 : yy;
                color[i] = (byte)yy;
            }

            // adjust brightness
            unsafe
            {
                for (int y = 0; y < bmd.Height; y++)
                {
                    for (int x = 0; x < bmd.Width; x++)
                    {
                        // update colors
                        SetRed(bmd, x, y, color[GetRed(bmd, x, y)]); // red
                        SetGreen(bmd, x, y, color[GetGreen(bmd, x, y)]); // green
                        SetBlue(bmd, x, y, color[GetBlue(bmd, x, y)]); // blue
                    }
                }
            }

            // unlock data
            bmp.UnlockBits(bmd);
        }


        #endregion


    }
}
