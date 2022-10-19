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
                                int x, y;
                                string tmpStr = null;
                                int i = str.IndexOf(" ") + 1;
                                while (str[i] != ' ')
                                {
                                    tmpStr += str[i];
                                    if (i != str.Length-1)
                                    i++;
                                }
                                i+=1;
                                x = Int32.Parse(tmpStr);
                            tmpStr = null;
                                while (str[i] != ' ')
                                {
                                    tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                                else
                                    break;
                                }
                                y = Int32.Parse(tmpStr);
                                geometricObjects.Add(new Point(x, y));
                            }

                            if (str.Contains("rect"))
                            {
                            int x1, y1, x2, y2;
                            string tmpStr = null;
                            int i = str.IndexOf(" ") + 1;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                            }
                            i += 1;
                            x1 = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                                else
                                    break;
                            }
                            i += 1;
                            y1 = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                            }
                            i += 1;
                            x2 = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                                else
                                    break;
                            }
                            i += 1;
                            y2 = Int32.Parse(tmpStr);
                            geometricObjects.Add(new Rec(x1, y1, x2, y2));
                        }



                            if (str.Contains("line"))
                            {
                            int x1, y1, x2, y2;
                            string tmpStr = null;
                            int i = str.IndexOf(" ") + 1;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                            }
                            i += 1;
                            x1 = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                                else
                                    break;
                            }
                            i += 1;
                            y1 = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                            }
                            i += 1;
                            x2 = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                                else
                                    break;
                            }
                            i += 1;
                            y2 = Int32.Parse(tmpStr);
                            geometricObjects.Add(new Line(x1, y1, x2, y2));
                        }



                            if (str.Contains("circle"))
                            {
                            int x, y, r;
                            string tmpStr = null;
                            int i = str.IndexOf(" ") + 1;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                            }
                            i += 1;
                            x = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                                else
                                    break;
                            }
                            i += 1;
                            y = Int32.Parse(tmpStr);
                            tmpStr = null;
                            while (str[i] != ' ')
                            {
                                tmpStr += str[i];
                                if (i != str.Length - 1)
                                    i++;
                                else
                                    break;
                            }
                            r = Int32.Parse(tmpStr);
                            geometricObjects.Add(new Circle(x, y, r));
                        }
                        }
                    }
                for (int i = 0; i < geometricObjects.Count; i++)
                    geometricObjects[i].Draw();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}




