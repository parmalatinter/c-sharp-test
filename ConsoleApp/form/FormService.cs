﻿using System.Windows.Forms;

namespace ConsoleApp.form
{
    public class FormService
    {
        public static void ShowMessage(string msg)
        {
            Form form = new Form(msg); 
            form.ShowDialog();
        }
    }
}