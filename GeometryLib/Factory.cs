using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public abstract class Factory
    {
        public string str { get; set; }

        public Factory(string str) => this.str = str;

        public abstract GeometricObject Create();
    }

    public class FactoryPoint : Factory
    {
        public FactoryPoint(string str) : base(str)
        {
        }

        public override GeometricObject Create()
        {
            int x, y;
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
            y = Int32.Parse(tmpStr);
            return new Point(x, y);
        }
    }

    public class FactoryRec : Factory
    {
        public FactoryRec(string str) : base(str)
        {
        }

        public override GeometricObject Create()
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
            return new Rec(x1, y1, x2, y2);
        }
    }

    public class FactoryLine : Factory
    {
        public FactoryLine(string str) : base(str)
        {
        }

        public override GeometricObject Create()
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
            return new Line(x1, y1, x2, y2);
        }
    }

    public class FactoryCircle : Factory
    {
        public FactoryCircle(string str) : base(str)
        {
        }

        public override GeometricObject Create()
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
            return new Circle(x, y, r);
        }
    }

}
