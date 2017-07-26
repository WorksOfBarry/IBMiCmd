﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMiCmd.LanguageTools
{
    public class FieldInfo
    {
        public string Name;
        public string Value;
        public TextType Type;
        public int Length;
        public string Colour = "Green";
        public Point Position;

        public enum TextType
        {
            Input,
            Output,
            Text
        }

        public static Color TextToColor(string Colour)
        {
            switch (Colour.ToUpper())
            {
                case "GREEN":
                    return Color.Lime;
                case "YELLOW":
                    return Color.Yellow;
                case "BLUE":
                    return Color.LightBlue;
                case "RED":
                    return Color.Red;
                case "WHITE":
                    return Color.White;

                default:
                    return Color.Green;
            }
        }
    }
}
