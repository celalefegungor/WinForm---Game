using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DolarPatlat
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();


        }
        System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
        Random rnd = new Random();
        int puan = 0;
        int maxpuan = 0;
        int hak = 10;
        int saniye = 60;
        int dakika = 4;

        private void tmrOyun_Tick(object sender, EventArgs e)
        {
            int xKonum = rnd.Next(50, 750);
            int yKonum = rnd.Next(100, 350);
            pctDollar.Location = new Point(xKonum, yKonum);
            pctDollar.Image = Image.FromFile(@"E:\Örnekler\DolarPatlat\giphy.gif");
            pctDollar.Size = new Size(50, 50);

            if (xKonum % 10 == 0)
            {
                pctDollar.Image = Image.FromFile(@"E:\Örnekler\DolarPatlat\coin2.gif");
                pctDollar.Size = new Size(50, 50);
                tmrOyun.Interval = 700;
            }
            else if (xKonum % 10 == 1)
            {
                pctDollar.Image = Image.FromFile(@"E:\Örnekler\DolarPatlat\flame-gif-transparent-5.gif");
                pctDollar.Size = new Size(80, 80);
                tmrOyun.Interval = 1100;
            }
            else
            {
                tmrOyun.Interval = 1000;
            }
        }



        private void pctDollar_Click(object sender, EventArgs e)
        {

            if (tmrOyun.Interval == 1000)
            {
                pctDollar.Image = Image.FromFile(@"E:\Örnekler\DolarPatlat\comic-boom-explosion-2-1017x1024.png");
                pctDollar.Size = new Size(100, 100);
                ++puan;
                pctDollar.BackColor = Color.Transparent;
                label1.Text = "PUAN : " + puan.ToString();
                ses.SoundLocation = "Cash Register Cha Ching-SoundBible.com-184076484.wav";
                ses.Play();
            }

            else if (tmrOyun.Interval == 700)
            {
                puan = puan + 10;
                label1.Text = "PUAN : " + puan.ToString();
                ses.SoundLocation = "Cash Register Cha Ching-SoundBible.com-184076484.wav";
                ses.Play();
            }
            else if (tmrOyun.Interval == 1100)
            {

                puan = 0;
                label1.Text = "PUAN : " + puan.ToString();
                ses.SoundLocation = "Fire_Burning-JaBa-810606813.wav";
                ses.Play();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            --hak;
            label3.Text = "KALAN HAK : " + hak.ToString();
            if (hak == 0)
            {

                if (puan >= maxpuan)
                {
                    maxpuan = puan;
                    label2.Text = "MAX PUAN : " + maxpuan.ToString();
                }
                else
                {
                    label2.Text = "MAX PUAN : " + maxpuan.ToString();
                }
                tmrGeriSayim.Enabled = false;
                pctDollar.Visible = false;
                ses.SoundLocation = "Sad_Trombone-Joe_Lamb-665429450.wav";
                ses.Play();

                DialogResult dialogResult = MessageBox.Show("Tekrar Oynamak İster Misiniz ?", "OYUN BİTTİ !", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    puan = 0;
                    hak = 10;
                    label1.Text = "PUAN : " + puan.ToString();
                    label3.Text = "KALAN HAK : " + hak.ToString();
                    pctDollar.Visible = true;
                    dakika = 4;
                    saniye = 59;
                    tmrGeriSayim.Enabled = true;


                }
                else if (dialogResult == DialogResult.No)
                {
                    Environment.Exit(1);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            this.Update();
        }

        private void tmrGeriSayim_Tick(object sender, EventArgs e)
        {
            label4.Text = "0"+dakika.ToString();
            saniye = saniye - 1;
            label6.Text = saniye.ToString();
            if (saniye<10)
            {
                label6.Text = "0" + saniye.ToString();
                if (saniye==0)
                {
                    if (saniye == 0 && dakika == 0)
                    {

                        if (puan >= maxpuan)
                        {
                            maxpuan = puan;
                            label2.Text = "MAX PUAN : " + maxpuan.ToString();
                        }
                        else
                        {
                            label2.Text = "MAX PUAN : " + maxpuan.ToString();
                        }
                        pctDollar.Visible = false;
                        ses.SoundLocation = "Sad_Trombone-Joe_Lamb-665429450.wav";
                        ses.Play();
                        tmrGeriSayim.Enabled = false;
                        DialogResult dialogResult = MessageBox.Show("Tekrar Oynamak İster Misiniz ?", "OYUN BİTTİ !", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            puan = 0;
                            hak = 10;
                            label1.Text = "PUAN : " + puan.ToString();
                            label3.Text = "KALAN HAK : " + hak.ToString();
                            dakika = 5;
                            saniye = 60;
                            
                            pctDollar.Visible = true;
                            tmrGeriSayim.Enabled = true;

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Environment.Exit(1);
                        }
                    }
                    dakika = dakika - 1;
                    saniye = 59;
                }
            }
           
            
        }
    }
}
