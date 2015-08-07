using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace drives
{
  class Program
  {
    private static readonly string _exeName = Environment.GetCommandLineArgs()[0];

    static void Main(string[] args)
    {
      Console.WriteLine("Drives 2015 - jorgie@missouri.edu");
      foreach (DriveInfo di in DriveInfo.GetDrives())
      {
        if (di.IsReady)
        {
          string label = (di.VolumeLabel != "") ? di.VolumeLabel : "None";
          Console.Error.WriteLine("{0} {3}\t{1}/{2}\t{4:N2} GB available of {5:N2} GB total",
            di.Name,
            di.DriveFormat,
            di.DriveType,
            label,
            (double)di.TotalFreeSpace / (1024*1024*1024),
            (double)di.TotalSize / (1024*1024*1024)
          );
        }
        else { Console.WriteLine(di.Name + " (Not Ready)"); }
      }
    }
  }
}
