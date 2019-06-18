using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Helpers;
namespace tp9
{
    class Program
    {
        static void Main(string[] args)
        {

           
            //crea un archivo en    C:\tp9_prueba\directorio.txt de nombre directorio.txt
            SoporteParaConfiguracion.CrearArchivoDeConfiguracion();
            string direccion =SoporteParaConfiguracion.LeerConfiguracion(@"C:\tp9_prueba");
            Console.WriteLine("aqui se deberan copiar los datos:"+direccion);

            ////para probar los metodos de morse
            Console.WriteLine("Ingrese una palabra");
            string palabraPrueba = Console.ReadLine();
            string palabraEnMorse, palabraOriginal;
            palabraEnMorse = ConversorDeMorse.TextoAMorse(palabraPrueba);
            Console.WriteLine("Palabra en morse: " + palabraEnMorse);
            palabraOriginal = ConversorDeMorse.MorseATexto(@"C:\tp9_prueba\morse");
            Console.WriteLine("Palabra original: " + palabraOriginal);
            


            moverMp3Dat();


            Console.ReadKey();
        }
        public static void moverMp3Dat()
        {
            string ruta = @"C:\Users\fvg\source\repos\trabajoPractico9\tp9\bin\Debug";
            string rutaDest=@"C:\tp9_prueba";
            string[] archivosTxt = Directory.GetFiles(ruta,"*.txt");
            string[] archivosMp3 = Directory.GetFiles(ruta, "*.mp3");
            //string[] archivosDat = Directory.GetFiles(ruta);
            Console.WriteLine("archivos con extencion .txt y .mp3");

            foreach (string archivoAux in archivosMp3)//Muevo todos los archivos MP3
            {
                string nombreArchivo = Path.GetFileName(archivoAux);
                string destino = Path.Combine(rutaDest, nombreArchivo);

                Console.WriteLine(archivoAux);
                if (!File.Exists(Path.Combine(destino)))
                {
                    File.Copy(archivoAux, destino);
                }
                
                File.Delete(archivoAux);
            }
        }
        
    }
}
