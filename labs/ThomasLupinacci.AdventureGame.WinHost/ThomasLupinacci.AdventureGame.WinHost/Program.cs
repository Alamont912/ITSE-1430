/*
 * Written by Thomas J. Lupinacci III for TCCD ITSE-1430 on 3/31/2022
 * Lab #3
 */

using System;
using System.Windows.Forms;

namespace ThomasLupinacci.AdventureGame.WinHost
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.Run(new MainForm());
        }
    }
}