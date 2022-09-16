namespace clicker
{
    public partial class Form1 : Form
    {
        public int click = 0;
        public int clickT = 1;
        public int pkt = 0;
        public int najwiecej = 0;
        public int TimeS = 5;
        public int TimeW = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void clickerBtn_Click(object sender, EventArgs e)
        {
            if (click == 0) TimerStart();
            click+=clickT;
            clicksLbl.Text = "Klikniecia : "+click;
        }
        private void TimerStart() 
        {
            TimeS = TimeW;
            WaitSec();

        }

        public async void WaitSec()
        {
            for (int i = 0; i < TimeW; i++)
            {

                timerLbl.Text = "Czas : " + TimeS;
                await Task.Delay(1000);
                TimeS--;
            }
            timerLbl.Text = "Czas : " + TimeS;
            if (click > najwiecej) najwiecej = click;
            najLbl.Text = "Najlepszy Wynik : " + najwiecej;
            pkt += click;
            pktLbl.Text = "Punkty : " + pkt;
            click = 0;
            if (najwiecej <= 10000) progressBar.Value = najwiecej;
            else 
            {
                progressBar.Value = 10000;
                MessageBox.Show("WYGRANA ! ! !");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pkt >= 100) 
            {
                clickT += 2;
                pkt = pkt - 100;
                pktLbl.Text = "Punkty : " + pkt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pkt >= 10000) 
            {
                clickT *= 2;
                pkt = pkt - 10000;
                pktLbl.Text = "Punkty : " + pkt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pkt >= 500) 
            {
                TimeW += 1;
                pkt = pkt - 500;
                pktLbl.Text = "Punkty : " + pkt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pkt >= 5000) 
            {
                TimeW *= 2;
                pkt = pkt - 5000;
                pktLbl.Text = "Punkty : " + pkt;
            }
        }
    }
}