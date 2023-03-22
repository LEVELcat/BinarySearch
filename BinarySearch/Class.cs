using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinarySearch
{

    class MassGenerator
    {
        public int[] RandomMassGenerator(int size, ref int[] mass,int min, int max )
        {
            Array.Resize(ref mass, size);
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                mass[i] = rnd.Next(min, max);
            }
            Array.Sort(mass);
            

            return mass;
        }
    }
    class TextWri
    {
        public void ResultTextGen(int [] mass, string path)
        {
            string result = "";
            for (int i = 0; i < mass.Length; i++)
            {
                result += mass[i].ToString() + " ";
            }
            TextWrite(path, result);
        }
        protected void TextWrite(string path, string txt)
        {
            path = $@"{path}.txt";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(txt);
            }
        }
    }
    class Perebor
    {
        public string PereborMethod (int[] mass, int seek)
        {
            string result = "";
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == seek) { result += $"{i}, ";}
            }
            if (result == "") { return "Искомое значение не найдено";}
            return $"Искомое значение находится в индексах: {result} ";
        }
    }
    class BinaryMethod
    {
        public string Binar(int[] mass, int seek)
        {
            if (mass.Length == 0) { return "Искомое значение не найдено"; }
            int buf1 = 0, buf2 = mass.Length, buf3 = 0, buf4 = 0;

            while (buf2 - buf1 != 1 || buf4 != 1000)
            {
                buf3 = Convert.ToInt32((buf1 + buf2) / 2f);

                if (mass[buf3] == seek) { return Costile(mass, buf3);}

                if (mass[buf3] < seek) { buf1 = buf3; }
                else { buf2 = buf3; }
                buf4++;
            }

            return "Искомое значение не найдено";
        }

        protected string Costile(int[]mass, int seek)
        {
            int buf1 = 1;
            int[] resultMass = new int[1];
            resultMass[0] = seek;
            int buf2 = seek - 1;
            if (buf2 != -1)
            {
                while (mass[seek] == mass[buf2]) { Array.Resize(ref resultMass, resultMass.Length + 1); resultMass[buf1] = buf2; buf2--; buf1++; if (buf2 == -1) { break; } }
            }
            buf2 = seek + 1;
            if (buf2 != mass.Length)
            {
                while (mass[seek] == mass[buf2]) { Array.Resize(ref resultMass, resultMass.Length + 1); resultMass[buf1] = buf2; buf2++; buf1++; if (buf2 == mass.Length) { break; } }
            }
            Array.Sort(resultMass);
            string result = "Искомое значение находится в индексах: ";
            for (int i = 0; i < resultMass.Length ; i++) { result += $"{resultMass[i]}, "; }
            return result;
        }
    }
}

