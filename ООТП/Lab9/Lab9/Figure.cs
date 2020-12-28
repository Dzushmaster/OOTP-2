using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Figure
    {
        private float length;
        private float width;
        private float height;
        private int type;
        enum TypeFigure { Flat, Volumetric};//плоская, объемная
        public Figure(){}
        public Figure(float length, float width)//плоская фигура
        {
            if (length < 0 || width < 0) throw new Exception("Exception: Length and width can't be less 0");
            this.length = length;
            this.width = width;
            type = (int)TypeFigure.Flat;
            height = 0;
        }
        public Figure(float length, float width, float height)//объемная фигура
        {
            if(length<0 || width<0|| height<0) throw new Exception("Exception: Length, width and height can't be less 0");
            this.length = length;
            this.width = width;
            this.height = height;
            type = (int)TypeFigure.Volumetric;
        }
        public float Length
        {
            get { return length; }
            set
            {
                if (value < 0) throw new Exception("Exception: Length can't be less 0");
                length = value;
            }
        }

        public float Width 
        {
            get { return width; }
            set
            {
                if (value < 0) throw new Exception("Exception: Width can't be less 0");
                width = value;
            }
        }

        public float Height 
        {
            get { return height; }
            set 
            {
                if (value < 0) throw new Exception("Exception: Height can't be less 0");
                height = value;
            }
        } 
               
        public int Type
        {
            get { return type; }
        }
        public override string ToString()
        {
            if (Type == 1) return "Volumetric figure have\nLength: " + Length + "\nWidth: " + Width + "\nHeigth: " + Height;
            else if (Type == 0) return "Flat figure have\nLength: " + Length + "\nWidth: " + Width;
            return "Is empty";
        }

    }
}
