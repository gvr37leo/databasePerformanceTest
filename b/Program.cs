using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

delegate int del(int i);
namespace b
{
    class Program
    {
        
        static unsafe void Main(string[] args)
        {
            byte[] bytes = File.ReadAllBytes("a");
            fixed (byte* p = bytes) {
                //bytes = &bytes + 2
            }
            
            foreach(byte b in bytes)
            {
                Console.WriteLine(b);
            }
        }
    }
}
