using System.Windows;
using System.Diagnostics;

namespace app12
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Debug.WriteLine("LAUNCH CODE");
            base.OnStartup(e);
        }
    }
}
