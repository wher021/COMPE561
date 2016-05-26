using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Draw
{
	public partial class Form1 : Form
	{
		Point pt1,pt2;
        public Color penColor = Color.FromArgb(255, 255, 0, 0); //available
        public int penWidth = 10; //available
        public List<Shape> shapeList = new List<Shape>(); //make available
        ShapeType currentShape = ShapeType.Line;
        Shape shape;
        bool dataModified = false;
        string currentFile;
        bool savedFileExists = false;
        public string[] dataArray;
        string extension;
        public static Form1 Instance; //static methods are accessed through CLASSES!

		public Form1()
		{
			InitializeComponent();
			this.DoubleBuffered = true;
            Shape.penTemp = new Pen(Color.Black);
            Instance = this;
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			pt1 = e.Location;
			Pen pen = new Pen(penColor, penWidth);
            shape = Shape.CreateShape(currentShape, pt1, pen); 
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			Graphics g = this.CreateGraphics();
			if (e.Button == MouseButtons.Left)
			{
				Invalidate();
				Update();
                shape.mouseMove(g, e);
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				return;	// Don't respond to right mouse button up

			Graphics g = this.CreateGraphics();
            shape.mouseMove(g, e);
            shapeList.Add(shape);
			Invalidate();
            dataModified = true;
        }

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
            foreach (Shape shape in shapeList)
                shape.Draw(e.Graphics, shape.penFinal);
        }

		private void penWidthMenuItem_Click(object sender, EventArgs e)
		{
			PenDialog dlg = new PenDialog();
            dlg.PenWidth = penWidth;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                penWidth = dlg.PenWidth;
            }
		}

        private void lineMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Line;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Rectangle;
        }

        private void freeLineMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.FreeLine;
        }

        private void printShapesMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("\nAll Shapes");
            foreach (Shape shape in shapeList)
                Console.WriteLine(shape);
        }

        private void penColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = penColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                penColor = dlg.Color;

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.Filter = "Text Files (*.txt) |*.txt| Binary Files (*.bin) |*.bin| Serialized Object Files (*.ser) |*.ser| XML Files (*.xml) |*.xml";
                fileChooser.DefaultExt = "txt";
                fileChooser.CheckFileExists = false; //Don't need to verify file name after save.
                result = fileChooser.ShowDialog();
                currentFile = fileChooser.FileName;
                extension = Path.GetExtension(fileChooser.FileName);
            }
            if (result == DialogResult.OK && extension == ".txt")
            {
                if (currentFile == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    FileStream fs = new FileStream(currentFile, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (Shape x in shapeList)
                        x.writeText(sw);
                    sw.Close();
                    savedFileExists = true;
                    Console.WriteLine("File saved");
                }
            }
            else if (result == DialogResult.OK && extension == ".bin")
            {
                if (currentFile == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    FileStream fs = new FileStream(currentFile, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    foreach (Shape x in shapeList)
                        x.writeBinary(bw);
                    bw.Close();
                    savedFileExists = true;
                    Console.WriteLine("File saved");
                }
            }
            else if (result == DialogResult.OK && extension == ".ser")//Serialization
            {
                if (currentFile == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream(currentFile, FileMode.Create);

                    try
                    {
                        bf.Serialize(fs, this.shapeList);
                    }
                    catch (SerializationException h)
                    {
                        Console.WriteLine("Failed to serialize. Reason: " + h.Message);
                        throw;
                    }
                    finally
                    {
                        fs.Close();

                        savedFileExists = true;
                        Console.WriteLine("File saved");
                    }
                }
            }
                ///////////WIP//////////////////////////////////////////
            else if (result == DialogResult.OK && extension == ".xml")
            {
                if (currentFile == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    XElement root = new XElement("Document"); ;
                    XDocument Element = new XDocument(root);
                    foreach (Shape x in shapeList)
                    {
                        root.Add(x.createXmlElement());
                    }
                    Element.Declaration = new XDeclaration("1.0", "utf-8", "true");//
                    Element.Save(currentFile);
                    savedFileExists = true;
                    Console.WriteLine("File saved");
                }
            }
        } 

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savedFileExists == false)
                saveAsToolStripMenuItem_Click(sender, e);//redirect to save as
            else if (dataModified && extension == ".txt")
            {
                FileStream fs = new FileStream(currentFile, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                foreach (Shape x in shapeList)
                    x.writeText(sw);
                sw.Close();
                Console.WriteLine("File saved");
            }
            else if (dataModified && extension == ".bin")
            {
                FileStream fs = new FileStream(currentFile, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                foreach (Shape x in shapeList)
                    x.writeBinary(bw);
                bw.Close();
                savedFileExists = true;
                Console.WriteLine("File saved");
            }
            else if (dataModified && extension == ".ser")
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(currentFile, FileMode.Create);

                try
                {
                    bf.Serialize(fs, this.shapeList);
                }
                catch (SerializationException h)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + h.Message);
                    throw;
                }
                finally
                {
                    fs.Close();

                    savedFileExists = true;
                    Console.WriteLine("File saved");
                }
            }
            else if (dataModified && extension == ".xml")
            {
                XElement root = new XElement("Willy"); ;
                XDocument Element = new XDocument(root);
                foreach (Shape x in shapeList)
                {
                    root.Add(x.createXmlElement());
                }
                Element.Declaration = new XDeclaration("1.0", "utf-8", "true");//
                Element.Save(currentFile);
                savedFileExists = true;
                Console.WriteLine("File saved");
            }
                
        } 

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                fileChooser.Filter = "Text Files (*.txt) |*.txt| Binary Files (*.bin) |*.bin| Serialized Object Files (*.ser) |*.ser| XML Files (*.xml) |*.xml";
                fileChooser.DefaultExt = "txt";
                fileChooser.CheckFileExists = false; //Don't need to verify file name after save.
                result = fileChooser.ShowDialog();
                currentFile = fileChooser.FileName;
                extension = Path.GetExtension(fileChooser.FileName);
            }
            try
            {
                if (result == DialogResult.OK && extension == ".txt")
                {
                    shapeList.Clear();
                    Invalidate();
                    FileStream fs = new FileStream(currentFile, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);


                    // Reading of Text Data
                    while (true)
                    {
                        string dataLine = sr.ReadLine();
                        if (dataLine != null)
                        {
                            dataArray = dataLine.Split(',', ';', ':'); // Splits at every , ; :

                            if (dataArray[0] == "Line")
                            {
                                //Line tmpLine = new Line(this);
                                Line tmpLine = new Line();
                                tmpLine.readText(sr);
                            }
                            else if (dataArray[0] == "Rectangle")
                            {
                                Rect tmpRect = new Rect();
                                tmpRect.readText(sr);
                            }
                            else if (dataArray[0] == "FreeLine")
                            {
                                FreeLine tmpFreeLine = new FreeLine();
                                tmpFreeLine.readText(sr);
                            }
                        }
                        else
                        {
                            sr.Close();
                            Invalidate();
                            break;
                        }
                    }
                    savedFileExists = true;
                }//end text file
                else if (result == DialogResult.OK && extension == ".bin")
                {
                    string shapeType;
                    shapeList.Clear();
                    Invalidate();
                    FileStream fs = new FileStream(currentFile, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    // Reading Binary Data
                    while (true)
                    {
                        shapeType = null;
                        if (br.BaseStream.Position != br.BaseStream.Length)
                            shapeType = br.ReadString();//Read string of the bin file
                        if (shapeType != null)
                        {
                            if (shapeType == "Line")
                            {
                                Line tmpLine = new Line();
                                tmpLine.readBinary(br);
                            }
                            else if (shapeType == "Rect")
                            {
                                Rect tmpRect = new Rect();
                                tmpRect.readBinary(br);
                            }
                            else if (shapeType == "FreeLine")
                            {
                                FreeLine tmpFreeLine = new FreeLine();
                                tmpFreeLine.readBinary(br);
                            }
                        }
                        else
                        {
                            br.Close();
                            Invalidate();
                            break;
                        }
                    }//close while
                    savedFileExists = true;
                }//close elseIf

                    //////////////////WIP/////////////////////////////////
                else if (result == DialogResult.OK && extension == ".xml")
                {
                    shapeList.Clear();
                    Invalidate();
          
                    XDocument menu = XDocument.Load(currentFile);
                    //
                   // 
                    foreach (XElement xe in menu.Root.Elements())
                    {
                        foreach (XAttribute fe in xe.Attributes())
                        {

                            if (fe.Value == "Line")
                            {
                                // MessageBox.Show("sfsefse");
                                pt1.X = int.Parse(xe.Element("StartPoint_X").Value);
                                pt1.Y = int.Parse(xe.Element("StartPoint_Y").Value);
                                pt2.X = int.Parse(xe.Element("EndPoint_X").Value);
                                pt2.Y = int.Parse(xe.Element("EndPoint_Y").Value);
                                penWidth = int.Parse(xe.Element("PenWidth").Value);
                                penColor = Color.FromArgb(int.Parse(xe.Element("PenColor").Value, System.Globalization.NumberStyles.AllowHexSpecifier));
                                Pen myPen = new Pen(penColor, penWidth);
                                Line myLine = new Line(pt1, pt2, myPen);
                                shapeList.Add(myLine);
                            }
                            else if (fe.Value == "Rectangle")
                            {
                                pt1.X = int.Parse(xe.Element("StartPoint_X").Value);
                                pt1.Y = int.Parse(xe.Element("StartPoint_Y").Value);
                                pt2.X = int.Parse(xe.Element("EndPoint_X").Value);
                                pt2.Y = int.Parse(xe.Element("EndPoint_Y").Value);
                                penWidth = int.Parse(xe.Element("PenWidth").Value);
                                penColor = Color.FromArgb(int.Parse(xe.Element("PenColor").Value, System.Globalization.NumberStyles.AllowHexSpecifier));
                                Pen myPen = new Pen(penColor, penWidth);
                                Rect myRect = new Rect(pt1, pt2, myPen);
                                shapeList.Add(myRect);
                            }
                            else if (fe.Value == "FreeLine")
                            {
                                penWidth = int.Parse(xe.Attribute("PenWidth").Value);
                                penColor = Color.FromArgb(int.Parse(xe.Attribute("PenColor").Value, System.Globalization.NumberStyles.AllowHexSpecifier));
                                Pen myPen = new Pen(penColor, penWidth);
                                FreeLine myFreeLine = new FreeLine(myPen);
                                foreach (XElement point in xe.Descendants())
                                {
                                    if (point.Name == "Point") // if <Point> element
                                    {
                                        pt1.X = int.Parse(point.Attribute("X").Value);
                                        pt1.Y = int.Parse(point.Attribute("Y").Value);
                                        myFreeLine.FreeList.Add(pt1);
                                    }
                                }
                                shapeList.Add(myFreeLine);
                            }
                        }
                    }//end root element
                    savedFileExists = true;
                    Invalidate();
                }

                else if (result == DialogResult.OK && extension == ".ser")//Deserialization
                {
                    shapeList.Clear();
                    Invalidate();
                    FileStream fs = new FileStream(currentFile, FileMode.Open, FileAccess.Read);
                    BinaryFormatter bf = new BinaryFormatter();
                    shapeList.Clear();
                    this.shapeList = (List<Shape>)bf.Deserialize(fs);

                    fs.Close();
                    Invalidate();
                }
            }//end try
            catch (IOException)
            {
                MessageBox.Show("Error reading from file",
                   "File Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }

            
        } 

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataModified)
            {
                DialogResult dr = MessageBox.Show("Save unsaved changes?", "", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    shapeList.Clear();
                    Invalidate();
                    savedFileExists = false;
                }
                else if (dr == DialogResult.No)
                {
                    shapeList.Clear();
                    Invalidate();
                    savedFileExists = false;
                }
            }
            else
            {
                shapeList.Clear();
                Invalidate();
                savedFileExists = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataModified)
            {
                DialogResult dr = MessageBox.Show("You have unsaved changes. Save before quitting?", "", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    Application.Exit();
                }
                else if (dr == DialogResult.No)
                    Application.Exit();
            }
            else
                Application.Exit();
        } 

	}  // end class Form1   
            
}