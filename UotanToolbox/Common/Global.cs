﻿using Avalonia.Collections;

namespace UotanToolbox.Common
{
    internal class Global
    {
        public static string runpath = null;
        public static string System = "Windows";
        public static AvaloniaList<string> deviceslist;
        public static string thisdevice = null;

        //分区表储存
        public static string sdatable = "";
        public static string sdbtable = "";
        public static string sdctable = "";
        public static string sddtable = "";
        public static string sdetable = "";
        public static string sdftable = "";
        public static string emmcrom = "";
    }

    public static class GlobalData
    {
        public static MainViewModel MainViewModelInstance { get; set; }
    }

}