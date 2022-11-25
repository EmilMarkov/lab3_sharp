using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Edition
    {
        protected string name;
        protected DateTime date;
        protected int circulation;

        public Edition(string titleValue, int circulationValue, DateTime dateValue)
        {
            this.name = titleValue;
            this.circulation = circulationValue;
            this.date = dateValue;
        }

        public Edition() : this("WarGAYming", 54, DateTime.Now) { }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public int Circulation
        {
            get { return circulation; }
            set {
                if (value <= 0) { throw new ArgumentOutOfRangeException("\ni slaves!\t300$!\n"); }
                else { this.circulation = value; }
            }
        }

        public DateTime Date
        {
            get => date;
            set { this.date = value; }
        }

        public static bool operator ==(Edition left, Edition right)
        {
            if (right is null) return false;
            return (left.name == right.name && left.circulation == right.circulation);
        }

        public static bool operator !=(Edition left, Edition right)
        {
            if (right is null) return false;
            return (left.name != right.name && left.circulation != right.circulation);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Edition);
        }

        private bool Equals(Edition obj)
        {
            if (obj is null) { return false; }
            else
            {
                return this.name == obj.name && this.circulation == obj.circulation && this.date == obj.date;
            }
        }

        public int GetHashCode()
        {
            return HashCode.Combine(name.GetHashCode(), circulation.GetHashCode());
        }

        public object DeepCopy()
        {
            Edition tmp = new Edition();
            tmp.name = this.name;
            tmp.circulation = this.circulation;
            return (object)tmp;
        }
    }
}
