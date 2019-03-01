﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz05
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;


        int timeLeft;

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 SECONDS";
            timer1.Start();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("ALL CORRECT");
                startButton.Enabled = true;
            }

            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "TIME!";
                MessageBox.Show("OUT OF TIME");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
        }
    }
}
