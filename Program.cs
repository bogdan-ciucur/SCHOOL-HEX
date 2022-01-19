using System;
using System.IO;

namespace Hexviewer
{
    class Program
    {
        static void Main(string[] args)
        {
            // bool done = false;
            bool done;

            if (done = true)
            {
                
                string path;
                Console.WriteLine(" Introduceti calea fisierului:\n ");
                path = Console.ReadLine();

                int octet;
                Console.WriteLine(" Introduceti numarul de octeti:\n ");
                octet = int.Parse(Console.ReadLine());

                char[] chrDel = new char[] { ' ', '"' };
                path = path.Trim(chrDel); 


                FileStream file = new FileStream(path, FileMode.Open);


                byte[] byteBlock = new byte[octet]; 

                int index = 0, actual;    
                

                while ((actual = file.Read(byteBlock, 0, octet)) > 0)    
                {

                    string hex = BitConverter.ToString(byteBlock, 0, actual); 


                    string text = "";           
                    for (int i = 0; i < actual; i++)
                        text += byteBlock[i] < ' ' || byteBlock[i] == 127 ? "." : ((char)byteBlock[i]).ToString();
                    

                    Console.WriteLine($" {index:X8} : {hex.PadRight(octet * 3 - 1)}  | {text}");    
                    index += octet;

                    
                }

                file.Close();

                done = true; 

            }
            else
            {
                Console.WriteLine("aceasta cale nu exista");
            }
            
        }
    }
}