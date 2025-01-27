using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace practicalTest1
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {

            int choice = 0;
            do
            {
                Console.WriteLine("List of file operations, please select one option:");
                Console.WriteLine("1.Read from file\n2.Write to file\n3.Count a character after read.\n4.Exit");
                String input = Console.ReadLine();
                int.TryParse(input, out choice);
                if (choice == 1)
                    ReadFromFile();

                else if (choice == 2)
                    writeToFile();

                else if (choice == 3)
                    countInFile();
                else
                    break;

            } while (choice < 4 && choice > 0);
        }

        static string ReadFromFile()
        {
            string aPath = "", content="";

            try
            {
                Console.WriteLine("Enter the path of the file");
                //Get the path from user input and trims the spaces from the beginning and end
                aPath = Console.ReadLine().TrimEnd().TrimStart();
                //Reads the text from the file
                content = File.ReadAllText(aPath);
                //Write the text to the Console.
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return content;
        }

        static private void writeToFile()
        {
            string aPath = ""; TextWriter txtWriter = null;
            try
            {
                Console.WriteLine("Enter the path of the file");
                //Get the path from user input and trims the spaces from the beginning and the end
                aPath = Console.ReadLine().TrimEnd().TrimStart();
                //Opens a stream to the File
                txtWriter = new StreamWriter(aPath);

                Console.WriteLine("Write the content then press enter! ");
                //Writes the text
                txtWriter.WriteLine(Console.ReadLine());

                Console.WriteLine("File Is Updated Successfully!");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            finally
            {
                //closing the stream!!!!
                if (txtWriter != null)
                    txtWriter.Close();
            }
        }

        static private void countInFile()
        {
            string word = "", text = "", aPath = "";
            int countWord = 0;
            try
            {
                       
                //Reads the text from the file
                text = ReadFromFile();
                Console.WriteLine("Write the requested word: ");
                //Gets the requested word
                word = Console.ReadLine().TrimEnd().TrimStart();
                //Calls the count method
                countWord = CountWord(text, word);
                //shows the count
                Console.WriteLine("The word appeared : " + countWord + "times");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        //Method to count a given word
        static int CountWord(string text, string word)
        {
            int count = 0;
            int i = text.IndexOf(word);
            while (i != -1)
            {

                i = text.IndexOf(word, i + 1);
                count++;
            }
            return count;
        }
    }
}
