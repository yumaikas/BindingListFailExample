using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BindingListTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Stopwatch s = new Stopwatch();
            InitializeComponent();
            var nameList = new BindingList<Names>();
            s.Start();
            comboBox1.DataSource = nameList;
            //Uncomment the lines below to see the difference in performance
            //nameList.RaiseListChangedEvents = false;
            for (int i = 0; i < 5000; i++)
            {
                nameList.Add(new Names(i.ToString()));
            }
            //nameList.RaiseListChangedEvents = true;
            //nameList.ResetBindings(); 
            var time = s.Elapsed;
            MessageBox.Show(time.ToString()); 
        }
    }
    public class Names
    {
        public static int counter;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Names(string name)
        {
            this.Name = name; 
        }
        public override string ToString()
        {
            return Name; 
        }
    }
}
