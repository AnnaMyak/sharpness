using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpnessExplorationCurrent
{
    class Program
    {
        static void Main(string[] args)
        {
            //inputs
            string slidePath = @"C:\Users\AnnaToshiba2\Desktop\WSI\CMU-1.ndpi"; // @"C:\Wsi\tmp232\BIH-249_IIa_FC19560800.ndpi";

            string outputDir = Path.Combine(Path.GetDirectoryName(slidePath), "meta", "sharpness");
            string outpathPrefix = outputDir + "\\" + Path.GetFileNameWithoutExtension(slidePath);

            // parameter
            int tileSize = 512;
            int numThreads = 4;
            float scale = 0.5f;
            float threshold = 0.3f;

            // result paths and infos
            System.Drawing.Imaging.ImageFormat sharpnessformat = System.Drawing.Imaging.ImageFormat.Png;
            string debug_outpath = outpathPrefix + ".debug.png";
            string result_outpath = outpathPrefix + ".result.png";
            string param_outpath = outpathPrefix + ".parameters.csv";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            //current params
            var result = new SharpAccessory.VirtualMicroscopy.SlideSharpnessEvaluation().Execute(slidePath, tileSize, numThreads, scale);
            result.MinSharpness = threshold;
            result.MinEdgeCount = 200;

            result.GetDebugBitmap().Save(debug_outpath, sharpnessformat);
            result.GetEvaluationBitmap().Save(result_outpath, sharpnessformat);

            StringBuilder csv = new StringBuilder();
            csv.AppendLine("Wsi Url\t" + slidePath);
            csv.AppendLine("Ergebnis Dateien Prefix\t" + outpathPrefix);
            csv.AppendLine("Schärfeschwellwert\t" + threshold.ToString());
            csv.AppendLine("Kachelgröße\t" + tileSize.ToString());
            csv.AppendLine("Skalierung\t" + scale.ToString());
            csv.AppendLine("Anzahl Threads\t" + numThreads.ToString());
            csv.AppendLine("Version SharpAcessoryExtension\t" + "1.0.5357.26298"); //from properties...
            File.WriteAllText(param_outpath, csv.ToString());
        }

        static string GetParam(string[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException("Pass Slidepath as Parameter!");
            if (!File.Exists(args[0]))
                throw new ArgumentException("Slidepath does not exist!");

            return args[0];
        }
    }
}
