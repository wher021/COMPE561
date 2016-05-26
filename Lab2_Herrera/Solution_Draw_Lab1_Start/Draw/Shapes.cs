using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;

namespace Draw
{
    public enum ShapeType { Line, Rectangle, FreeLine };

    [Serializable]
    public abstract class Shape
    {
        protected Color penColor;
        protected int penWidth;
        public Pen penFinal//Accessors
        {
            get { return new Pen(penColor, penWidth); }
            set
            {
                penColor = value.Color;
                penWidth = (int)value.Width;
            }
        }
        //public Form1 frm1;
       // public Pen penFinal;
        public static Pen penTemp;
        public abstract void Draw(Graphics g, Pen pen);
        public abstract void mouseMove(Graphics g, MouseEventArgs e);
        public abstract void writeBinary(BinaryWriter bw);
        public abstract void readBinary(BinaryReader br);
        public abstract void writeText(StreamWriter sw);
        public abstract void readText(StreamReader sr);
        public abstract XElement createXmlElement();
        public abstract void readXmlElement(XElement xe);

        public Shape(Pen pen)
        {
            this.penFinal = pen;
        }

        public Shape()
        {
            penFinal = penTemp;
        }

        public static Shape CreateShape(ShapeType type, Point pt, Pen pen)
        {
            switch (type)
            {
                case ShapeType.Line:
                    return new Line(pt, pen);
                case ShapeType.Rectangle:
                    return new Rect(pt, pen);
                case ShapeType.FreeLine:
                    return new FreeLine(pt, pen);
                default:
                    return null;
            }
        }

        public static Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Line:
                    return new Line();
                case ShapeType.Rectangle:
                    return new Rect();
                case ShapeType.FreeLine:
                    return new FreeLine();
                default:
                    return null;
            }
        }

        public Point getPointBinary(BinaryReader br)
        {
            int x = br.ReadInt32();
            int y = br.ReadInt32();
            return new Point(x, y);
        }

        public Color getColorBinary(BinaryReader br)
        {
            int iColor = br.ReadInt32();
            return Color.FromArgb(iColor);
        }

        public Color getColorText(string hexString)
        {
            int iColor = int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(iColor);
        }

    }  // End Shape class
    [Serializable]
    public class Line : Shape
    {
        protected Point pt1, pt2;

        public Point Pt1
        {
            get { return pt1; }
            set { pt1 = value; }
        }

        //public Line(Form1 a)
        //{
        //    this.frm1 = a;
        //}

        public Point Pt2
        {
            get { return pt2; }
            set { pt2 = value; }
        }

        public Line(Point p1, Point p2, Pen pen)
            : base(pen)
        {
            pt1 = p1;
            pt2 = p2;
        }

        public Line()
        {
            pt1 = Point.Empty;
            pt2 = Point.Empty;
            penFinal = penTemp;
        }

        public Line(Point pt, Pen pen)
        {
            pt1 = pt2 = pt;
            this.penFinal = pen;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, pt1, pt2);
        }

        public override void mouseMove(Graphics g, MouseEventArgs e)
        {
            pt2 = e.Location;
            Draw(g, penTemp);
        }

        public override string ToString()
        {
            string s = string.Format("Line:{0},{1};{2},{3};{4};{5}",
                pt1.X, pt1.Y, pt2.X, pt2.Y, (int)penFinal.Width, penFinal.Color.ToArgb().ToString("X8"));
            // "Line:strPtX,strPtY;endPtX,endPtY;penWidth;penColor" color in hex
            return s;
        }

        public override void writeBinary(BinaryWriter bw)
        {
            bw.Write("Line");
            bw.Write(pt1.X);
            bw.Write(pt1.Y);
            bw.Write(pt2.X);
            bw.Write(pt2.Y);
            bw.Write((int)penFinal.Width);
            bw.Write(penFinal.Color.ToArgb());
        }

        public override void readBinary(BinaryReader br)//OK
        {
            pt1.X = br.ReadInt32();//reads 4 bytes
            pt1.Y = br.ReadInt32();
            pt2.X = br.ReadInt32();
            pt2.Y = br.ReadInt32();

            //Form1.Instance.penWidth = br.ReadInt32();
            //Form1.Instance.penColor = Color.FromArgb(br.ReadInt32());
            int width = br.ReadInt32();
            Color color = Color.FromArgb(br.ReadInt32());
            this.penFinal = new Pen(color, width);
            //  Pen myPen = new Pen(Form1.Instance.penColor, Form1.Instance.penWidth);
            Line myLine = new Line(pt1, pt2, penFinal);
            Form1.Instance.shapeList.Add(myLine);
        }

        public override void writeText(StreamWriter sw)
        {
            sw.WriteLine(this);
        }

        public override void readText(StreamReader sr)//OK
        {
           // pt1.X = Convert.ToInt32(frm1.dataArray[1]);
            pt1.X = int.Parse(Form1.Instance.dataArray[1]);
            pt1.Y = Convert.ToInt32(Form1.Instance.dataArray[2]);
            pt2.X = Convert.ToInt32(Form1.Instance.dataArray[3]);
            pt2.Y = Convert.ToInt32(Form1.Instance.dataArray[4]);
            Form1.Instance.penWidth = Convert.ToInt32(Form1.Instance.dataArray[5]);
            Form1.Instance.penColor = Color.FromArgb(int.Parse(Form1.Instance.dataArray[6], System.Globalization.NumberStyles.AllowHexSpecifier));
            Pen myPen = new Pen(Form1.Instance.penColor, Form1.Instance.penWidth);
            Line myLine = new Line(pt1, pt2, myPen);

            Form1.Instance.shapeList.Add(myLine);
        }

        public override XElement createXmlElement()
        {
            return new XElement("Shape", new XAttribute("Type","Line"),new XElement("StartPoint_X", Pt1.X),
                new XElement("StartPoint_Y", Pt1.Y), new XElement("EndPoint_X", Pt2.X), new XElement("EndPoint_Y", Pt2.Y), new XElement("PenWidth", (int)penFinal.Width),
                new XElement("PenColor", penFinal.Color.ToArgb().ToString("X8")));

            //xe.Add(new XAttribute("StartPoint_X", Pt1.X),
            //    new XAttribute("StartPoint_Y", Pt1.Y),
            //    new XAttribute("EndPoint_X", Pt2.X),
            //    new XAttribute("EndPoint_Y", Pt2.Y),
            //    new XAttribute("PenWidth", (int)penFinal.Width),
            //    new XAttribute("PenColor", penFinal.Color.ToArgb().ToString("X8")));
            //<Line StartPoint_X="..." StartPoint_Y="..." EndPoint_X="..." EndPoint_Y="..." PenWidth="..." PenColor="..." />
           // return new XElement("Shape", new XAttribute("Type","Line"), new XElement("Point1", pt1), new XElement("Point2", pt2), new XElement("Width", (int)penFinal.Width), new XElement("Color", penFinal.Color.ToArgb().ToString("X8")));
        }

        public override void readXmlElement(XElement xe)
        {
        }

    } // End line class
    [Serializable]
    public class Rect : Line
    {
        public Rect(Point p1, Point p2, Pen pen)
            : base(p1, p2, pen)
        { }

        public Rect()
            : base()
        { }

        public Rect(Point pt, Pen pen)
            : base(pt, pen)
        { }

        public override void Draw(Graphics g, Pen pen)
        {
            int x = Math.Min(pt1.X, pt2.X);
            int y = Math.Min(pt1.Y, pt2.Y);
            int width = Math.Abs(pt2.X - pt1.X);
            int height = Math.Abs(pt2.Y - pt1.Y);
            Rectangle rect = new Rectangle(x, y, width, height);
            g.DrawRectangle(pen, rect);
        }

        public override void mouseMove(Graphics g, MouseEventArgs e)
        {
            pt2 = e.Location;
            Draw(g, penTemp);
        }

        public override string ToString()
        {
            string s = string.Format("Rectangle:{0},{1};{2},{3};{4};{5}",
                pt1.X, pt1.Y, pt2.X, pt2.Y, (int)penFinal.Width, penFinal.Color.ToArgb().ToString("X8"));
            // "Rectangle:strPtX,strPtY;endPtX,endPtY;penWidth;penColor" color in hex
            return s;

        }

        public override void writeBinary(BinaryWriter bw)
        {
            bw.Write("Rect");
            bw.Write(pt1.X);
            bw.Write(pt1.Y);
            bw.Write(pt2.X);
            bw.Write(pt2.Y);
            bw.Write((int)penFinal.Width);
            bw.Write(penFinal.Color.ToArgb());
        }

        public override void readBinary(BinaryReader br)
        {
            pt1.X = br.ReadInt32();
            pt1.Y = br.ReadInt32();
            pt2.X = br.ReadInt32();
            pt2.Y = br.ReadInt32();
            Form1.Instance.penWidth = br.ReadInt32();
            Form1.Instance.penColor = Color.FromArgb(br.ReadInt32());
            Pen myPen = new Pen(Form1.Instance.penColor, Form1.Instance.penWidth);
            Rect myRect = new Rect(pt1, pt2, myPen);
            Form1.Instance.shapeList.Add(myRect);
        }

        public override void writeText(StreamWriter sw)
        {
            sw.WriteLine(this);
        }

        public override void readText(StreamReader sr)
        {
            pt1.X = Convert.ToInt32(Form1.Instance.dataArray[1]);
            pt1.Y = Convert.ToInt32(Form1.Instance.dataArray[2]);
            pt2.X = Convert.ToInt32(Form1.Instance.dataArray[3]);
            pt2.Y = Convert.ToInt32(Form1.Instance.dataArray[4]);
            Form1.Instance.penWidth = Convert.ToInt32(Form1.Instance.dataArray[5]);
            Form1.Instance.penColor = Color.FromArgb(int.Parse(Form1.Instance.dataArray[6], System.Globalization.NumberStyles.AllowHexSpecifier));
            Pen myPen = new Pen(Form1.Instance.penColor, Form1.Instance.penWidth);
            Rect myRect = new Rect(pt1, pt2, myPen);

            Form1.Instance.shapeList.Add(myRect);
        }

        public override XElement createXmlElement()
        {
            return new XElement("Shape", new XAttribute("Type", "Rectangle"), new XElement("StartPoint_X", Pt1.X),
                new XElement("StartPoint_Y", Pt1.Y), new XElement("EndPoint_X", Pt2.X), new XElement("EndPoint_Y", Pt2.Y), new XElement("PenWidth", (int)penFinal.Width),
                new XElement("PenColor", penFinal.Color.ToArgb().ToString("X8")));
        }

        public override void readXmlElement(XElement xe)
        {
        }

    } // End Rect class
    [Serializable]
    public class FreeLine : Shape
    {
        protected List<Point> freeList;
        protected Point pt1;

        public List<Point> FreeList
        {
            get { return freeList; }
            set { freeList = value; }
        }

        public FreeLine(Point pt, Pen pen)
            : base(pen)
        {
            freeList = new List<Point>();
            freeList.Add(pt);
        }

        public FreeLine(Pen pen)
            : base(pen)
        {
            freeList = new List<Point>();
        }

        public FreeLine()
            : base()
        {
            freeList = new List<Point>();
        }

        public override void Draw(Graphics g, Pen pen)
        {
            Point[] ptArray = freeList.ToArray();
            g.DrawLines(pen, ptArray);
        }

        public override void mouseMove(Graphics g, MouseEventArgs e)
        {
            freeList.Add(e.Location);
            Draw(g, penTemp);
        }

        public override string ToString()
        {
            string s = string.Format("FreeLine:{0};{1}", (int)penFinal.Width, penFinal.Color.ToArgb().ToString("X8"));
            foreach (Point p in freeList)
                s += string.Format(";{0},{1}", p.X, p.Y);  // "FreeLine:penWidth;penColor;ptX,ptY;ptX,ptY;..." color in hex
            return s;
        }

        public override void writeBinary(BinaryWriter bw)
        {
            bw.Write("FreeLine");
            bw.Write((int)penFinal.Width);
            bw.Write(penFinal.Color.ToArgb());
            int count = 0;

            foreach (Point p in freeList)
            {
                count++;
            }
            bw.Write(count);
            foreach (Point p in freeList)
            {
                bw.Write(p.X);
                bw.Write(p.Y);

            }
        }

        public override void readBinary(BinaryReader br)
        {
            Form1.Instance.penWidth = br.ReadInt32();
            Form1.Instance.penColor = Color.FromArgb(br.ReadInt32());
            Pen myPen = new Pen(Form1.Instance.penColor, Form1.Instance.penWidth);
            FreeLine myFreeLine = new FreeLine(myPen);
            int count = br.ReadInt32();
            int i = 0;
            while (i < count) // DONE//
            {
                pt1.X = br.ReadInt32();
                pt1.Y = br.ReadInt32();
                myFreeLine.FreeList.Add(pt1);
                i++;
            }
            Form1.Instance.shapeList.Add(myFreeLine);
        }

        public override void writeText(StreamWriter sw)
        {
            sw.WriteLine(this);
        }

        public override void readText(StreamReader sr)
        {
            FreeLine myFreeLine = new FreeLine();

            Form1.Instance.penWidth = Convert.ToInt32(Form1.Instance.dataArray[1]);
            Form1.Instance.penColor = Color.FromArgb(int.Parse(Form1.Instance.dataArray[2], System.Globalization.NumberStyles.AllowHexSpecifier));
            Pen myPen = new Pen(Form1.Instance.penColor, Form1.Instance.penWidth);
            myFreeLine = new FreeLine(myPen);
            for (int i = 3; i < Form1.Instance.dataArray.Length; i = i + 2)
            {
                myFreeLine.pt1.X = Convert.ToInt32(Form1.Instance.dataArray[i]);
                myFreeLine.pt1.Y = Convert.ToInt32(Form1.Instance.dataArray[i + 1]);
                myFreeLine.FreeList.Add(myFreeLine.pt1);
            }
            Form1.Instance.shapeList.Add(myFreeLine);
        }

        public override XElement createXmlElement()
        {
            XElement points = new XElement("Shape");
           // points.Name = "FreeLine";
            points.Add(new XAttribute("PenWidth", (int)penFinal.Width), 
                new XAttribute("PenColor",penFinal.Color.ToArgb().ToString("X8")),new XAttribute("Type","FreeLine"));
            foreach (Point p in freeList)
            {
                points.Add(new XElement("Point", new XAttribute("X", p.X), new XAttribute("Y", p.Y)));
            }
            return points;
        }

        public override void readXmlElement(XElement xe)
        {
        }

    } // End FreeLine class
}
