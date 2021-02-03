using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\ZipFileDemo1", @"D:\ZipFileDemo2\myZipeFile.zip");
            ZipFile.ExtractToDirectory(@"D:\ZipFileDemo2\myZipeFile.zip", @"D:\ZipFileDemoResult");
           
        }
    }
}
