using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AnkiClipper;

namespace AnkiClipper
{
    public partial class Prompt : Form
    {
        private readonly AnkiClipperWorker ankiClipperWorker;
        public Prompt()
        {
            this.ankiClipperWorker = new AnkiClipperWorker(new Clipboard(), new Alert());
            InitializeComponent();
        }

        private void Prompt_Load(object sender, EventArgs e)
        {

        }


        private void Ok_Click(object sender, EventArgs e)
        {
            ProcessInput();
        }

        private void Answer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ProcessInput();
            }
        }

        private void ProcessInput()
        {
            

            string answer = this.Answer.Text;
            this.ankiClipperWorker.WorkerSendToAnki(answer);
            Close();
        }

        private void Answer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Description_Click(object sender, EventArgs e)
        {

        }

    }
}
