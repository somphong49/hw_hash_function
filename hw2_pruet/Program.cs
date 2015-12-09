using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace hw2_pruet
{
    class Program
    {
        static void Main(string[] args)
        {
            //การเขียนแล้วขึ้นบรรทัดใหม่(ให้กรอกตัวเลข)
            Console.WriteLine("input number"); //write data to screen
            string input = Console.ReadLine(); // read data from keyboard for 1 line

            //Seperate string to mini string into string array
            char[] delimeter = { ' ' };
            string[] spinput = input.Split(delimeter,System.StringSplitOptions.RemoveEmptyEntries); // seperate by white space
            //create array int for keep convert data
            int[] datanumber = new int[spinput.Length];

            if (spinput.Length > 100)
            {
                Console.WriteLine("Error : Total Data is over 100 values");

            }
            else
            {
                //try to convert string to int for calculate + checking error (0-1000) and isDigit
                //for every spinput
                bool isNotError = true;

                for (int i = 0; i < spinput.Length; i++)
                {
                    //convert
                    if (spinput[i] != null)
                        isNotError = int.TryParse(spinput[i], out datanumber[i]);
                    else Console.WriteLine("Data Null");
                    //if it error
                    if (!isNotError)
                    {
                        datanumber = null;
                        Console.WriteLine("Data is not a number");
                        break;
                    }
                    else
                    {
                        //if it not in range 0 - 1000
                        if (datanumber[i] > 1000 || datanumber[i] < 0)
                        {
                            datanumber = null;
                            Console.WriteLine("Data is not in range 0 - 1000");
                            break;
                        }
                    }
                }

                if (datanumber != null)
                {
                    //create hash table 0 - 49
                    Hashtable ht = new Hashtable();

                    for (int i = 0; i < 50; i++)
                    {
                        ht.Add(i, String.Empty);     
                    }
                    
                    //keep data into hash table
                    for (int i = 0; i < datanumber.Length; i++)
                    {
                        int key = datanumber[i] % 50;
                        ht[key] = ht[key] + " " + datanumber[i].ToString();
                    }

                    //show data in hash table
                    Console.WriteLine("Output:");
                    for (int i = 0; i < ht.Count; i++)
                    {
                        Console.WriteLine(i.ToString() + " :"+ ht[i]);

                    }
                    
                }
                

            }

        Console.Read();

        }
    }
}
