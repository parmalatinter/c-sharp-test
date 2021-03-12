using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ConsoleApp.form
{
    public partial class FormCapture : System.Windows.Forms.Form
    {
        // Create class-level accesible variables
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        private readonly System.Diagnostics.Stopwatch sw;

        private void StopWatchStart()
        {
            sw.Start();
        }

        private void StopWatchStop()
        {
            sw.Stop();
        }

        private int GetStopWatchSec()
        {
            TimeSpan ts = sw.Elapsed;
            string secStr = ts.ToString(@"ss");
            int.TryParse(secStr, NumberStyles.AllowThousands, null, out int sec);
            return sec;
        }

        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }


        public FormCapture()
        {
            InitializeComponent();

            sw = new System.Diagnostics.Stopwatch();
        }

        private void FormCapture_Load(object sender, EventArgs e)
        {
            CaptureCamera();
        }

        private void CaptureCameraCallback()
        {
            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                int sec = 0;
                StopWatchStart();

                while (sec < 5)
                {
                    sec = GetStopWatchSec();
                    capture.Read(frame);
                    pictureBox.Image = BitmapConverter.ToBitmap(frame);
                }

                StopWatchStop();

                Bitmap snapshot = new(BitmapConverter.ToBitmap(frame));

                string resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
                string filePath = Path.Combine(resourcesPath, string.Format(@"{0}.png", "user"));

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                snapshot.Save(filePath, ImageFormat.Png);
            }
        }
    }
}
