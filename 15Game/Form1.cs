using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15Game
{
    public partial class Form1 : Form
    {
        TableLayoutPanelCellPosition empty;
        int stepsCounter=0;
        DateTime start;
        DateTime end;
        public Form1()
        {
            InitializeComponent();
            empty = tableLayoutPanel1.GetCellPosition(button16);
            for(int i=1; i<17; i++)
            {
                tableLayoutPanel1.Controls[i].Tag= 
                    tableLayoutPanel1.GetCellPosition(tableLayoutPanel1.Controls[i]);
                Console.WriteLine(tableLayoutPanel1.Controls[i].Tag.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void GenerateField()
        {
            Random r = new Random();
            int e = 0;
            for (int i=0; i < 20; i++)
            {
                e = r.Next(1, 5);
                switch(e)
                {
                    case 1: //right
                        if((empty.Column+1)<4)
                        {
                            Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column + 1, empty.Row);
                            TableLayoutPanelCellPosition b = tableLayoutPanel1.GetCellPosition(c);
                            //empty -> button
                            tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                                GetControlFromPosition(empty.Column, empty.Row), b);
                            //button -> empty
                            tableLayoutPanel1.SetCellPosition(c, empty);
                            empty = b;
                        }
                        break;
                    case 2: //left
                        if ((empty.Column - 1) >0)
                        {
                            Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column - 1, empty.Row);
                            TableLayoutPanelCellPosition b = tableLayoutPanel1.GetCellPosition(c);
                            //empty -> button
                            tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                                GetControlFromPosition(empty.Column, empty.Row), b);
                            //button -> empty
                            tableLayoutPanel1.SetCellPosition(c, empty);
                            empty = b;
                        }
                        break;
                    case 3: //up
                        if ((empty.Row + 1) < 4)
                        {
                            Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column, empty.Row+1);
                            TableLayoutPanelCellPosition b = tableLayoutPanel1.GetCellPosition(c);
                            //empty -> button
                            tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                                GetControlFromPosition(empty.Column, empty.Row), b);
                            //button -> empty
                            tableLayoutPanel1.SetCellPosition(c, empty);
                            empty = b;
                        }
                        break;
                    case 4: //down
                        if ((empty.Row - 1) > 0)
                        {
                            Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column, empty.Row-1);
                            TableLayoutPanelCellPosition b = tableLayoutPanel1.GetCellPosition(c);
                            //empty -> button
                            tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                                GetControlFromPosition(empty.Column, empty.Row), b);
                            //button -> empty
                            tableLayoutPanel1.SetCellPosition(c, empty);
                            empty = b;
                        }
                        break;
                }
            }
        }

        void ChangePlaces(Button btn)
        {
            TableLayoutPanelCellPosition b = tableLayoutPanel1.GetCellPosition(btn);
            if (empty.Row==b.Row+1) //down
            {
                Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column, empty.Row - 1);
                TableLayoutPanelCellPosition bc = tableLayoutPanel1.GetCellPosition(c);
                //empty -> button
                tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                    GetControlFromPosition(empty.Column, empty.Row), bc);
                //button -> empty
                tableLayoutPanel1.SetCellPosition(c, empty);
                empty = bc;
                stepsCounter++;
            }
            if (empty.Row == b.Row - 1) //up
            {
                Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column, empty.Row + 1);
                TableLayoutPanelCellPosition bc = tableLayoutPanel1.GetCellPosition(c);
                //empty -> button
                tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                    GetControlFromPosition(empty.Column, empty.Row), bc);
                //button -> empty
                tableLayoutPanel1.SetCellPosition(c, empty);
                empty = bc;
                stepsCounter++;
            }
            if(empty.Column==b.Column-1) //right
            {
                Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column + 1, empty.Row);
                TableLayoutPanelCellPosition bc = tableLayoutPanel1.GetCellPosition(c);
                //empty -> button
                tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                    GetControlFromPosition(empty.Column, empty.Row), bc);
                //button -> empty
                tableLayoutPanel1.SetCellPosition(c, empty);
                empty = bc;
                stepsCounter++;
            }
            if(empty.Column==b.Column+1) //left
            {
                Control c = tableLayoutPanel1.GetControlFromPosition(empty.Column - 1, empty.Row);
                TableLayoutPanelCellPosition bc = tableLayoutPanel1.GetCellPosition(c);
                //empty -> button
                tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.
                    GetControlFromPosition(empty.Column, empty.Row), bc);
                //button -> empty
                tableLayoutPanel1.SetCellPosition(c, empty);
                empty = bc;
                stepsCounter++;
            }
        }

        bool CheckWin()
        {
            int c = 0;
            for(int i=1; i<17; i++)
            {
                TableLayoutPanelCellPosition bc = 
                    tableLayoutPanel1.GetCellPosition(tableLayoutPanel1.Controls[i]);
                if (tableLayoutPanel1.Controls[i].Tag.ToString()==bc.ToString())
                {
                    c++;
                }
            }
            if(c==16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            GenerateField();
            //tableLayoutPanel1.Controls[1].Text = "true";
            Console.WriteLine(empty.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePlaces((sender as Button));
            if(CheckWin())
            {
                end = DateTime.Now;
                MessageBox.Show("You win!!!");
                this.Text = stepsCounter.ToString()+" steps, ";
                this.Text += (end - start).Minutes+" min "+(end-start).Seconds+" sec";
            }
        }
    }
}
