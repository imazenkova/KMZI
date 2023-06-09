using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cripta_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string f;
            string name_deu = "Khlystov Gleb Georgievich";
            name_deu = name_deu.Replace(" ", "").ToLower();

            string name_rus = "Хлыстов Глеб Георгиевич";
            name_rus = name_rus.Replace(" ", "").ToLower();

            Entropia_Shennon shan = new Entropia_Shennon();

            Console.WriteLine("-------------1-2---------------\n");

            //rusaine
            f = shan.data_file_str("rus.txt");
            double ent_rus_str = shan.entrop(f, "rusResult.log");
            Console.WriteLine("Энтропия текста на русском языке: \n" + ent_rus_str + "\n");

            StringBuilder f_byte = new StringBuilder();
            foreach (char a in f)
                f_byte.Append(Convert.ToString(a, 2));
            double ent_rus_byte = shan.entrop(f_byte.ToString(), "rusByteResult.log");
            Console.WriteLine("Энтропия бинарного текста на русском языке: \n" + ent_rus_byte + "\n");

            //deuland
            f = shan.data_file_str("deu.txt");
            double ent_deu_str = shan.entrop(f, "deuResult.log");
            Console.WriteLine("Энтропия текста на немецком языке: \n" + ent_deu_str + "\n");

            foreach (char a in f)
                f_byte.Append(Convert.ToString(a, 2));
            double ent_deu_byte = shan.entrop(f_byte.ToString(), "deuByteResult.log");
            Console.WriteLine("Энтропия бинарного текста на немецком языке: \n" + ent_deu_byte + "\n");

            Console.WriteLine("-------------3---------------\n");
            //FIO
            Console.WriteLine("Количество информации в моём ФИО: \n\t на русском: " + shan.info(name_rus, ent_rus_str) 
                                                            + "\n\t на немецком: " + shan.info(name_deu, ent_deu_str) + "\n");

            byte[] bytes = Encoding.ASCII.GetBytes(name_rus);
            String ASCII_rus = "";
            foreach (var b in bytes)
                ASCII_rus += b;

            bytes = Encoding.ASCII.GetBytes(name_deu);
            String ASCII_deu = "";
            foreach (var b in bytes)
                ASCII_deu += b;

            Console.WriteLine("Количество информации в моём ФИО(ASCII): \n\t на русском: " + shan.info(ASCII_rus, ent_rus_byte) 
                                                            + "\n\t на немецком: " + shan.info(ASCII_deu, ent_deu_byte) + "\n");
            
            Console.WriteLine("-------------4----------------\n");

            Console.WriteLine("Количество информации в моём ФИО с вероятностью ошибочной передачи единичного бита 0.1:"
                + "\n\t на русском: " + shan.infoMistake(name_rus.Length, 0.1)
                + "\n\t на немецком: " + shan.infoMistake(name_deu.Length, 0.1) + "\n");

            Console.WriteLine("Количество информации в моём ФИО с вероятностью ошибочной передачи единичного бита 0.5:"
                + "\n\t на русском: " + shan.infoMistake(name_rus.Length, 0.5)
                + "\n\t на немецком: " + shan.infoMistake(name_deu.Length, 0.5) + "\n");

            Console.WriteLine("Количество информации в моём ФИО с вероятностью ошибочной передачи единичного бита 1.0:"
                + "\n\t на русском: " + shan.infoMistake(name_rus.Length, 1.0)
                + "\n\t на немецком: " + shan.infoMistake(name_deu.Length, 1.0) + "\n");
        }
    }
}
