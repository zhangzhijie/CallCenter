﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class FCustomerImpInfo : Form
    {
        public FCustomerImpInfo(string title,string content,Color fontColor)
        {
            InitializeComponent();

            this.Text = title;
            this.richTextBox1.ForeColor = fontColor;
            this.richTextBox1.Text = content;
        }
    }
}
