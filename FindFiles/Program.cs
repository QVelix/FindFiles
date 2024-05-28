using System.Runtime.InteropServices;

namespace FindFiles;

class Program
{
	private static string[] fileTypes = new[] { ".png", ".gif", ".jpg", ".jpeg" };
	static void Main(string[] args)
	{
		Console.WriteLine(DateTime.Now);
		List<string> files = new List<string>();
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach (var drive in allDrives)
			{
				foreach (var type in fileTypes)
				{
					try
					{
						files.AddRange(Directory.GetFiles(drive.Name, "*"+type, new EnumerationOptions
						{
							IgnoreInaccessible = true,
							RecurseSubdirectories = true
						}));
					}
					catch (Exception e)
					{
						// Console.WriteLine(e);
						// throw;
					}
					
				}
				// FindFiles(drive.Name, files);
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
		foreach (var file in files)
		{
			sw.WriteLine(file);
		}
		sw.Close();
		Console.WriteLine(DateTime.Now);
	}

	public static void FindFiles(string currentDirectory, List<string> files)
	{
		try
		{
			var filesInDirectory = Directory.GetFiles(currentDirectory).ToList();
			if (filesInDirectory.Count > 0)
			{
				foreach (var fileType in fileTypes)
				{
					files.AddRange(filesInDirectory.Where(e=>e.Contains(fileType)));
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