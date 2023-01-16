using System;
using Belu_Ioana_Proiect.Data;
using System.IO;

namespace Belu_Ioana_Proiect;

public partial class App : Application
{
    static JurnalDatabase database;
    public static JurnalDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               JurnalDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jurnal.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
