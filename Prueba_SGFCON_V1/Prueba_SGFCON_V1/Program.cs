using SGFCON_V1;
using System;

namespace Prueba_SGFCON_V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImagenesSignafile imagenesSignafile = new ImagenesSignafile();
            long imagenes = imagenesSignafile.sgfcongf("000 0 1000 00000125882 FERNANDO 123456,78 15000010024554014200013202031 TranID0123");
            Console.WriteLine(imagenes);
            Console.WriteLine();
        }
    }
}
