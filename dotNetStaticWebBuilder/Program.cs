using System;
using Markdig;
using System.IO;

namespace MarkdigTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"D:\Code\MarkdigTest\TestFile.md"))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                    Console.WriteLine("——————预览读取的内容————————");
                    Console.WriteLine(line);
                }

                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                var result = Markdown.ToHtml(line, pipeline);

                // Set a variable to the Documents path.
                string docPath = @"D:\Code\MarkdigTest\";
                //Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.html")))
                {
                    //foreach (string line in lines)
                    outputFile.WriteLine(result);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
