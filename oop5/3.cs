using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
static class Task3
{
    public static void Run()
    {
        string sourceDir = @"Source";
        string backupDir = @"Backup";
        Directory.CreateDirectory(backupDir);
        int version = GetLastVersion(backupDir);
        string lastBackup = version == 0 ? null :
            Path.Combine(backupDir, $"Version_{version}");
        if (lastBackup == null || FolderChanged(sourceDir, lastBackup))
        {
            version++;
            string newBackup = Path.Combine(backupDir, $"Version_{version}");
            CopyFolder(sourceDir, newBackup);
        }
    }
    private static int GetLastVersion(string backupDir)
    {
        var versions = Directory.GetDirectories(backupDir)
            .Select(d => Path.GetFileName(d))
            .Where(n => n.StartsWith("Version_"))
            .Select(n => int.Parse(n.Replace("Version_", "")));
        return versions.Any() ? versions.Max() : 0;
    }
    private static bool FolderChanged(string source, string backup)
    {
        var sourceFiles = Directory.GetFiles(source, "*", SearchOption.AllDirectories);
        var backupFiles = Directory.GetFiles(backup, "*", SearchOption.AllDirectories);
        if (sourceFiles.Length != backupFiles.Length)
            return true;
        for (int i = 0; i < sourceFiles.Length; i++)
        {
            if (Path.GetFileName(sourceFiles[i]) != Path.GetFileName(backupFiles[i]))
                return true;
            if (GetMD5(sourceFiles[i]) != GetMD5(backupFiles[i]))
                return true;
        }
        return false;
    }
    private static string GetMD5(string file)
    {
        using var md5 = MD5.Create();
        using var stream = File.OpenRead(file);
        return BitConverter.ToString(md5.ComputeHash(stream));
    }
    private static void CopyFolder(string source, string target)
    {
        Directory.CreateDirectory(target);
        foreach (string file in Directory.GetFiles(source))
        {
            File.Copy(file, Path.Combine(target, Path.GetFileName(file)));
        }
        foreach (string dir in Directory.GetDirectories(source))
        {
            CopyFolder(dir, Path.Combine(target, Path.GetFileName(dir)));
        }
    }
}