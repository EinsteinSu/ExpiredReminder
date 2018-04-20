﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ExpiredReminder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
        }
    }
}
