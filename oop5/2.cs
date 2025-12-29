using System;
using System.Collections.Generic;
using System.IO;
static class Task2
{
    public static void Run()
    {
        List<string> pictures = new List<string>();
        string[] extensions = { ".jpg", ".png", ".bmp", ".jpeg", ".gif" };
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (!drive.IsReady) continue;
            try
            {
                ScanDirectory(drive.RootDirectory.FullName, pictures, extensions);
            }
            catch { }
        }
        File.WriteAllLines("pictures.txt", pictures);
    }
    private static void ScanDirectory(
        string path,
        List<string> pictures,
        string[] extensions)
    {
        try
        {
            foreach (string file in Directory.GetFiles(path))
            {
                if (Array.Exists(extensions,
                    ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                {
                    pictures.Add(file);
                }
            }
        }
    }
}