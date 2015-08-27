using System;
using System.IO;
using System.Reflection.Emit;
using System.Text;

namespace at.jku.ssw.cc {
/// ZSharpCompiler is the driver for the Z# compiler.
/// AW, woess@dotnet.jku.at
/// 
public static class PMain
{
    //int i;

};
public class ZSharpCompiler {
	public static void Main2 (string[] args) {
		// determine the filename
		if (args.Length < 1) { 
			Console.WriteLine("use : zsc.exe <filename>.zs"); 
			return;
		}
		string filename = args[0];
      
		try {
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Z# Compiler, v1.0, 2004-09-28");
			Console.WriteLine("by Albrecht Woess, JKU, Linz, Austria");
			Scanner.Init(new StreamReader(filename));
			Console.WriteLine("Parsing file {0}", filename);
			Console.WriteLine();
           
			Parser.Parse();
			int errCnt = Parser.Errors.Count;
			switch (errCnt) {
				case 0:
					Console.WriteLine("OK, no errors!");
					Console.WriteLine("Generating executable ...");
					Code.WritePEFile();
					Console.WriteLine("Done.");
					break;
				case 1:
					Console.WriteLine();
					Console.WriteLine("1 error");
					break;
				default:
					Console.WriteLine();
					Console.WriteLine("{0} errors", errCnt);
					break;
			}
		} catch (IOException) {
		  Console.WriteLine("File {0} not found.", filename);
		}		
	}	
}

}
