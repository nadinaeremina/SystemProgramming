using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_programming
{
    internal class Product
    {
		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		private int count;

		public int Count
		{
			get { return count; }
			set { count = value; }
		}
        public override string ToString()
        {
			return $"Наименование: {Title} \nКоличесво: {Count}";
        }
    }
}
