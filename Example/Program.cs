using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using GeometryLib;


namespace Example
{
    class Program
    {
        static void Main()
        {
            List<GeometricObject> geometricObjects = new List<GeometricObject>();

            string path = @"C:\\Users\\Bruh\\source\\repos\\TestExercise\\Example\\Example.txt";

            try
            {
                using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {


                    if (fileStream.Length <= 0)
                    {
                        using (var streamWriter = new StreamWriter(fileStream))
                        {
                            streamWriter.WriteLine("point 1 2");
                            streamWriter.WriteLine("rect 1 2 3 4");
                            streamWriter.WriteLine("line 10 10 20 20");
                            streamWriter.WriteLine("circle 10 10 5");
                        }
                    }
                }

                using (var streamReader = new StreamReader(path))
                {
                    string str = null;

                    while (!streamReader.EndOfStream)
                    {
                        str = streamReader.ReadLine();

                        if (str.Contains("point"))
                        {
                            var factory = new FactoryPoint(str);
                            geometricObjects.Add(factory.Create());
                        }

                        if (str.Contains("rect"))
                        {
                            var factory = new FactoryRec(str);
                            geometricObjects.Add(factory.Create());
                        }



                        if (str.Contains("line"))
                        {
                            var factory = new FactoryLine(str);
                            geometricObjects.Add(factory.Create());
                        }



                        if (str.Contains("circle"))
                        {
                            var factory = new FactoryCircle(str);
                            geometricObjects.Add(factory.Create());
                        }
                    }
                }
                for (int i = 0; i < geometricObjects.Count; i++)
                {
                    geometricObjects[i].Draw();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}




