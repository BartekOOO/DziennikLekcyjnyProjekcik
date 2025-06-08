using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;
using DziennikLekcyjny.Interfaces;
using DziennikLekcyjny.Services;
using DziennikLekcyjny.Helpers;
using DziennikLekcyjny.Windows;

namespace DziennikLekcyjny
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider _serviceProvider;
   
        public App()
        {
            var servicesCollection = new ServiceCollection();

            servicesCollection.AddTransient<MainWindow>();
            servicesCollection.AddTransient<LogowanieWindow>();
            servicesCollection.AddTransient<NowaOcenaWindow>();

            servicesCollection.AddSingleton<IDziennikService,DziennikService>();
            servicesCollection.AddSingleton<IBazaDanych,BazaDanychService>();
            servicesCollection.AddSingleton<ILogowanieService,LogowanieService>();

            _serviceProvider = servicesCollection.BuildServiceProvider();

            MainWindow = _serviceProvider.GetRequiredService<LogowanieWindow>();
            MainWindow.Show();
        }
    }
}
