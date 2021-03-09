using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight
{
    public partial class Form1 : Form
    {
        private static Form1 form;
        public Form1()
        {
            InitializeComponent();
            form = this;
        }

       
        Engine Engine = new Engine();
        private void btStart_Click(object sender, EventArgs e)
        {
            Engine.start(this);
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(Engine.x, Engine.y);

            timer1.Start();
        }
        public void start()
		{
            Engine.a = (double)edAngle.Value;
            Engine.v0 = (double)edSpeed.Value;
            Engine.y0 = (double)edHeight.Value;
            Engine.m = (double)edWeight.Value;
            Engine.S = (double)edSquare.Value; ;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.tick();

            chart1.Series[0].Points.AddXY(Engine.x, Engine.y);
            if (Engine.y <= 0) timer1.Stop();
        }
    }
}
