using System.Runtime.InteropServices;

namespace FindFiles;

class Program
{
	static void Main(string[] args)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach (var drive in allDrives)
			{
				
			}
		}

		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
		    RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
		{
			
		}
	}
}