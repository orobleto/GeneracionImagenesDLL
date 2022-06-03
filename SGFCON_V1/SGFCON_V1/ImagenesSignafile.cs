using System;
using System.IO;
using System.Text;

namespace SGFCON_V1
{
    public class ImagenesSignafile
    {

        public long sgfcongf(string Params)
        {

            string pathArchivo = @"images";
            string pathImagenes = @"ImagenesPrueba";
            Random random = new Random();
            int aleatorio = random.Next(0, 4);


            // borro las imagenes
            for (int i = 0; i < 3; i++)
            {
                String nombre = "0"+ (i + 1) + ".BMP";
                if (File.Exists(Path.Combine(pathArchivo, nombre)))
                {
                    File.Delete(Path.Combine(pathArchivo, nombre));
                }
            }

            // copio las imagenes
            for (int i = 0; i < aleatorio; i++)
            {
                String nombre = "0" + (i + 1) + ".BMP";
                File.Copy(Path.Combine(pathImagenes, "firma.bmp"), Path.Combine(pathArchivo, nombre), true);
            }

            try
            {
                // creo el archivo si existe
                using (FileStream fs = File.Create(Path.Combine(pathArchivo, "sgfcongf_log.txt")))
                {
                    string[] arreglo = Params.Split(' ');
                    Params = "";
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        Params += "P" + (i + 1) + " = \"" +arreglo[i]+"\"\n";
                    }

                    byte[] info = new UTF8Encoding(true).GetBytes(Params + "\nImagenes Generadas: " + aleatorio);
                    //agrego la info
                    fs.Write(info, 0, info.Length);

                    
                }

                // abro el flujo y leo.
              /*  using (StreamReader sr = File.OpenText(Path.Combine(pathArchivo, "sgfcongf.txt")))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
              */
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return aleatorio;
        }

    }
}
