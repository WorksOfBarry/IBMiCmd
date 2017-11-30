﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using NppPluginNET;
using IBMiCmd.IBMiTools;
using System.Drawing;
using System.Runtime.InteropServices;

namespace IBMiCmd.LanguageTools
{
    class NppFunctions
    {
        public static void OpenFile(string Path, Boolean ReadOnly)
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DOOPEN, 0, Path);
            if (ReadOnly) Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_SETREADONLY, 1, 0);
        }

        public static int GetLineNumber()
        {
            return (int)Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETCURRENTLINE, 0, 0);
        }

        public static string GetLine(int line)
        {
            IntPtr curScintilla = PluginBase.GetCurrentScintilla();
            int lineLength = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINELENGTH, line, 0);
            if (lineLength >= 1)
            {
                StringBuilder sb = new StringBuilder(lineLength);
                Win32.SendMessage(curScintilla, SciMsg.SCI_GETLINE, line, sb);

                if (sb.Length < lineLength)
                    lineLength = sb.Length;

                return sb.ToString().Substring(0, lineLength);
            }
            else
            {
                return "";
            }
        }

        public static string GetLineWithSelection(int line)
        {
            IntPtr curScintilla = PluginBase.GetCurrentScintilla();
            int lineLength = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINELENGTH, line, 0);
            StringBuilder sb = new StringBuilder(lineLength);
            Win32.SendMessage(curScintilla, SciMsg.SCI_GETLINE, line, sb);

            line = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, line, 0);
            lineLength--;
            Win32.SendMessage(curScintilla, SciMsg.SCI_SETSELECTION, line, line + lineLength);

            return sb.ToString().Substring(0, lineLength);
        }
        
        public static void SetLine(string value)
        {
            //Hopefully is still selected?
            Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_REPLACESEL, 0, value);
        }
        
        public static string[] GetOpenFiles()
        {
            int nbFile = (int)Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETNBOPENFILES, 0, 0);
            using (ClikeStringArray cStrArray = new ClikeStringArray(nbFile, Win32.MAX_PATH))
            {
                if (Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETOPENFILENAMES, cStrArray.NativePointer, nbFile) != IntPtr.Zero)
                    return cStrArray.ManagedStringsUnicode.ToArray();
                else
                    return null;
            }
        }

        public static void DisplayErrors(string Lib, string Obj)
        {
            ErrorHandle.getErrors(Lib, Obj);

            if (Main.ErrorWindow != null)
            {
                Main.ErrorWindow.publishErrors();
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_DMMSHOW, 0, Main.ErrorWindow.Handle);
            }
        }
        
        public static void SwitchToFile(string name, int line, int col)
        {
            int pos = 0;
            IntPtr curScintilla = PluginBase.nppData._nppHandle;
            Win32.SendMessage(curScintilla, NppMsg.NPPM_SWITCHTOFILE, 0, name);

            curScintilla = PluginBase.GetCurrentScintilla();
            Win32.SendMessage(curScintilla, SciMsg.SCI_ENSUREVISIBLE, line, 0);
            if (line >= 0)
            {
                pos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, line, 0);
                pos += col;
                Win32.SendMessage(curScintilla, SciMsg.SCI_GOTOPOS, pos, 0);
                Win32.SendMessage(curScintilla, SciMsg.SCI_GRABFOCUS, 0, 0);
            }
        }
        
        public static string GetCurrentFileName()
        {
            var sb = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLCURRENTPATH, 0, sb);
            return sb.ToString();
        }

        public static void RefreshWindow(string path)
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_RELOADFILE, 0, path);
            Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_MAKECURRENTBUFFERDIRTY, 0, 0);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        public static Point GetCaretPos()
        {
            RECT mainWindowPosition;
            GetWindowRect(PluginBase.GetCurrentScintilla(), out mainWindowPosition);
            int currentPos = (int)Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_GETCURRENTPOS, 0, 0);
            int caretOffsetX = (int)Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_POINTXFROMPOSITION, 0, currentPos);
            int caretOffsetY = (int)Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_POINTYFROMPOSITION, 0, currentPos);
            // Get the height of each line in pixels, so the autocomplete pop-up can be offset to fall underneath the current line 
            int lineHeight = (int)Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_TEXTHEIGHT, 0, 0);

            // Determine coordinates for placing the autocomplete popup, by adding aLl the offsets to the NPP window coordinates
            int positionX = (mainWindowPosition.Left + caretOffsetX) - 10;
            int positionY = mainWindowPosition.Top + caretOffsetY + lineHeight + 2;

            return new Point(positionX, positionY);
        }

        public static void CancelNPPAutoC()
        {
            Win32.SendMessage(PluginBase.GetCurrentScintilla(), SciMsg.SCI_AUTOCCANCEL, 0, 0);
        }

        public static void HandleTrigger(SCNotification Notification)
        {
            Thread gothread;
            string path = GetCurrentFileName();
            OpenMember member;
            switch (Notification.nmhdr.code)
            {
                case (uint)NppMsg.NPPN_READY:
                    break;
                case (uint)SciMsg.SCN_MODIFIED:
                    break;

                case (uint)NppMsg.NPPN_FILEBEFOREOPEN:
                    break;
                case (uint)NppMsg.NPPN_FILEOPENED:
                    break;
                case (uint)NppMsg.NPPN_FILESAVED:
                    member = OpenMembers.GetMember(path);
                    if (member != null)
                    {
                        gothread = new Thread((ThreadStart)delegate {
                            if (member.IsEditable())
                            {
                                if (member.GetSystemName() == IBMi.GetConfig("system"))
                                {
                                    bool UploadResult = IBMiUtilities.UploadMember(member.GetLocalFile(), member.GetLibrary(), member.GetObject(), member.GetMember());
                                    if (UploadResult == false)
                                    {
                                        System.Windows.Forms.MessageBox.Show("Failed to upload to " + member.GetMember() + " on " + member.GetSystemName() + ".");
                                    }
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("Unable to upload to " + member.GetMember() + ". You must be connected to " + member.GetSystemName() + " in order to save this file.");
                                }
                                if (Main.CommandWindow != null) Main.CommandWindow.loadNewOutput();
                            }
                        });
                        gothread.Start();
                    }
                    break;

                case (uint)NppMsg.NPPN_FILEBEFORECLOSE:
                    if (OpenMembers.Contains(path))
                    {
                        OpenMembers.RemoveMember(path);
                        File.Delete(path);
                    }
                    break;
            }
        }
    }
}
