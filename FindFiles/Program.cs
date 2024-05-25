using System.Runtime.InteropServices;

namespace FindFiles;

class Program
{
	private static string[] fileTypes = new[] { ".png", ".gif", ".jpg", ".jpeg", ".dll" };
	static void Main(string[] args)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach (var drive in allDrives)
			{
				FindFiles(drive.Name);
			}
		}

		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
		    RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
		{
			
		}
	}

	public static void FindFiles(string currentDirectory)
	{
		Directory.SetCurrentDirectory(currentDirectory);
		Console.WriteLine(Directory.GetCurrentDirectory());
	}
}