using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Management;
using Microsoft.Win32;

namespace WCLDBUpdater;

class Program
{
    static void Main(string[] args)
    {
        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        rk.SetValue("WCLDBUpdater", AppDomain.CurrentDomain.BaseDirectory + "WCLDBUpdater.exe", RegistryValueKind.String);
        rk.Close();
        Listen();

        Task.Delay(-1).GetAwaiter().GetResult();
    }

    static void Listen()
    {
        var query = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 1), "TargetInstance isa \"Win32_Process\" and TargetInstance.Name = 'WowClassic.exe'");

        using (var watcher = new ManagementEventWatcher(query))
        {
            ManagementBaseObject e = watcher.WaitForNextEvent();
            CreateDB();
            Listen();
        }
    }

    static void CreateDB()
    {
        string baseURL = "https://sheets.googleapis.com";

        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        request.Headers["Accept"] = "application/json";

        StringBuilder sb = new StringBuilder();

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            var sheet = JsonConvert.DeserializeObject<Deserializers.SpreadSheetDeserializer>(reader.ReadToEnd());
            foreach (var sht in sheet.sheets)
            {
                foreach (var data in sht.data)
                {
                    foreach (var dat in data.rowData)
                    {
                        foreach (var d in dat.values)
                        {
                            sb.AppendLine(d.formattedValue);
                        }
                    }
                }
            }
        }

        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Wild Growth_DB.lua", sb.ToString());
    }
}
