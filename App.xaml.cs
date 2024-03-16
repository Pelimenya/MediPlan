using MediPlan.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MediPlan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dbcontext db = new();
    }

}
