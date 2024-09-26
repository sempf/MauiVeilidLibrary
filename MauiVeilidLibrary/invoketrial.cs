using System;
using System.Runtime.InteropServices;

namespace MauiVeilidLibrary
{
    public class NativeMethods
    {
        // Example of P/Invoke to a native library
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
    }

    public class MauiClass
    {
        public void ShowMessageBox(string message, string title)
        {
            NativeMethods.MessageBox(IntPtr.Zero, message, title, 0);
        }
    }
}