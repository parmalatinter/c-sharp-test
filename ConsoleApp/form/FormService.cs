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
            FormCapture form = new();
            form.ShowDialog();
        }
    }
}
