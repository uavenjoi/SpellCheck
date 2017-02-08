using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spellCheck
{
    public partial class Form1 : Form
    {
        private int startIndex = 0;
        private int finishIndex = 0;
        private string text = null;
        private string res = null;
        private int count=0;


        readonly List<string> _dicList = new List<string>(File.ReadAllLines("dic1.txt"));

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = richTextBox1.Text+" ";
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    continue;
                }
                if (i != startIndex)
                {
                    var word = text.Substring(startIndex, i - startIndex);

                    if (!_dicList.Contains(word))
                    {
                        richTextBox1.Select(startIndex, i - startIndex);
                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
                        richTextBox1.SelectionColor = Color.Red;

                        label1.Text = $"найдено {count} ошибок";
                    }
                }
                startIndex = i + 1;
            }
        }
    }
}