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

namespace Draw
{
	public partial class Form1 : Form
	{
		Point pt1;
        Point pt2;
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
                fileChooser.Filter = "Text Files (*.txt) |*.txt| Binary Files (*.bin) |*.bin";
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
                
        } 

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                fileChooser.Filter = "Text Files (*.txt) |*.txt| Binary Files (*.bin) |*.bin";
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

                                Line Line = new Line(this);
                                Line.readText(sr);
                                penWidth = Convert.ToInt32(dataArray[5]);
                                penColor = Color.FromArgb(int.Parse(dataArray[6], System.Globalization.NumberStyles.AllowHexSpecifier));//string hex converted to int
                                Pen myPen = new Pen(penColor, penWidth);
                                Line = new Line(Line.Pt1, Line.Pt2, myPen);
       
                                shapeList.Add(Line);
                            }
                            else if (dataArray[0] == "Rectangle")
                            {
                                Rect myRect = new Rect();
                                myRect.readText(sr);
                                penWidth = Convert.ToInt32(dataArray[5]);
                                penColor = Color.FromArgb(int.Parse(dataArray[6], System.Globalization.NumberStyles.AllowHexSpecifier));
                                Pen myPen = new Pen(penColor, penWidth);
                                myRect = new Rect(myRect.Pt1, myRect.Pt2, myPen);

                                shapeList.Add(myRect);
                            }
                            else if (dataArray[0] == "FreeLine")
                            {
                                FreeLine myFreeLine = new FreeLine();
                                myFreeLine.readText(sr);                                
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
                }
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
                                pt1.X = br.ReadInt32();//reads 4 bytes
                                pt1.Y = br.ReadInt32();
                                pt2.X = br.ReadInt32();
                                pt2.Y = br.ReadInt32();
                                penWidth = br.ReadInt32();
                                penColor = Color.FromArgb(br.ReadInt32());
                                Pen myPen = new Pen(penColor, penWidth);
                                Line myLine = new Line(pt1, pt2, myPen);
                                shapeList.Add(myLine);
                            }
                            else if (shapeType == "Rect")
                            {
                                pt1.X = br.ReadInt32();
                                pt1.Y = br.ReadInt32();
                                pt2.X = br.ReadInt32();
                                pt2.Y = br.ReadInt32();
                                penWidth = br.ReadInt32();
                                penColor = Color.FromArgb(br.ReadInt32());
                                Pen myPen = new Pen(penColor, penWidth);
                                Rect myRect = new Rect(pt1, pt2, myPen);
                                shapeList.Add(myRect);
                            }
                            else if (shapeType == "FreeLine")
                            {
                                penWidth = br.ReadInt32();
                                penColor = Color.FromArgb(br.ReadInt32());
                                Pen myPen = new Pen(penColor, penWidth);
                                FreeLine myFreeLine = new FreeLine(myPen);
                                int count = br.ReadInt32();
                                int i = 0;
                                while (i<count) // DONE//
                                {
                                    pt1.X = br.ReadInt32();
                                    pt1.Y = br.ReadInt32();
                                    myFreeLine.FreeList.Add(pt1);
                                    i++;
                                }
                                shapeList.Add(myFreeLine);
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
            }
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