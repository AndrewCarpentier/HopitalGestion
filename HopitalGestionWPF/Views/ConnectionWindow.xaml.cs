﻿using HospitalGestion.bdd;
using HospitalGestionWPF.Models;
using HospitalGestionWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalGestionWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        public ConnectionWindow()
        {
            InitializeComponent();
            PageConnexionViewModel v = new PageConnexionViewModel();
            DataContext = v;
        }
    }
}
