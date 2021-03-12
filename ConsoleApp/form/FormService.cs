using System;
using System.Windows.Forms;

namespace ConsoleApp.form
{
    public class FormService
    {
        public static void ShowMessage(string msg)
        {
            Form form = new(msg); 
            form.ShowDialog();
        }

        public static void Capture()
        {
            try
            {
                FormCapture form = new();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex}");
            }
        }
    }
}
