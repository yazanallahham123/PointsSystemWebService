using System;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;
using PointsSystemWebService.Classes.Core;

public sealed class PdfHelper
{
    private PdfHelper() { }

    public static PdfHelper Instance { get; } = new PdfHelper();

    internal void SaveImageAsPdf(string imageFileName, string pdfFileName, int width = 600, bool deleteImage = false)
    {
        var croppedImagePath = imageFileName.Substring(0, imageFileName.LastIndexOf('.')) + ".bmp";

        using (var document = new PdfDocument())
        {
            //Section To Crup Image from top to delete logo
            Image originalImage = Image.FromFile(imageFileName);
            Bitmap bitmapImage = new Bitmap(originalImage);
            //var x = ServiceMethod.Crop(testImage);
            //test crop
            using (Image cropped = bitmapImage.Crop(new Rectangle(0, 30, originalImage.Width, originalImage.Height)))
            {
                cropped.Save(croppedImagePath);
                bitmapImage.Dispose();
                cropped.Dispose();
            }

            //Fix: Update width from imageWidth
            width = originalImage.Width;
            originalImage.Dispose();

            PdfPage page = document.AddPage();
            using (XImage img = XImage.FromFile(croppedImagePath))
            {
                // Calculate new height to keep image ratio
                var height = (int)(((double)width / (double)img.PixelWidth) * img.PixelHeight);

                // Change PDF Page size to match image
                page.Width = width;
                page.Height = height;

                XGraphics gfx = XGraphics.FromPdfPage(page);
                gfx.DrawImage(img, 0, 0, width, height);
            }
            document.Save(pdfFileName);
        }

        if (deleteImage)
        {
            try
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

                File.Delete(croppedImagePath);
                File.Delete(imageFileName);
            }
            catch (Exception) { }
        }
    }
}



static public class ImageExtensions
{
    static public Bitmap Crop(this Image originalImage, Rectangle cropBounds)
    {
        Bitmap croppedImage =
           new Bitmap(cropBounds.Width, cropBounds.Height);

        using (Graphics g = Graphics.FromImage(croppedImage))
        {
            g.DrawImage(originalImage,
               0, 0,
               cropBounds,
               GraphicsUnit.Pixel);
        }

        return croppedImage;
    }
}