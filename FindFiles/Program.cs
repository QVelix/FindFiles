using System.Runtime.InteropServices;

namespace FindFiles;

class Program
{
	private static string[] fileTypes = new[] { ".png", ".gif", ".jpg", ".jpeg" };
	static void Main(string[] args)
	{
		HashSet<string> files = new HashSet<string>();
		List<string> filteredFiles = new List<string>();
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach (var drive in allDrives)
			{
				FindFiles(drive.Name, files);
			}
			// HashSet<string> filesHashSet = files.ToHashSet();
			// files = new HashSet<string>();
			foreach (var type in fileTypes)
			{
				filteredFiles.AddRange(files.Where(e => e.Contains(type)));
			}
		}

		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
		    RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
		{
			FindFiles("/", files);
		}
		
		
		if (!File.Exists(Directory.GetCurrentDirectory() + "myfile.txt"))
		{
			File.Create(Directory.GetCurrentDirectory() + "myfile.txt");
		}
		
		StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "/myfile.txt");
		foreach (var file in filteredFiles)
		{
			sw.WriteLine(file);
		}
		sw.Close();
	}

	public static void FindFiles(string currentDirectory, HashSet<string> files) //O(n^3)
	{
		try
		{
			var filesInDirectory = Directory.GetFiles(currentDirectory);
			if (filesInDirectory.Length > 0)
			{
				foreach (var file in filesInDirectory)
				{
					files.Add(file);
				}
			}
			var directories = Directory.GetDirectories(currentDirectory);
			if (directories.Length < 1) return;
			foreach (var directory in directories)
			{
				FindFiles(directory, files);
			}
			// Console.WriteLine(Directory.GetCurrentDirectory());
		}
		catch (Exception e)
		{
		}
	}
}