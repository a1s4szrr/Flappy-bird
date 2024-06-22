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


namespace flappy_bird1
{
    public partial class Form2 :Form
    {
        int engelhızı = 10, gravity = 15, üstengeluzunluğu=10, altengeluzunluğu = 10;
        public int puan;
        public string isim;
       

        public Form2()
        {
            InitializeComponent();
        }
        public void oyunsonu()//metot
        {
            this.BackgroundImage = Properties.Resources.oyunbitis;

            pictureBox3_2ustengel.Hide();
            pictureBox2_bird.Hide();
            pictureBox_1ustengel.Hide();
            pictureBox_1altengel.Hide();
            pictureBox_2altengel.Hide();
            pictureBox_graund.Hide();
            pictureBox3_altengel.Hide();
            pictureBox3_üstengel.Hide();
            label1.Hide();


            label3.Show();
            label2.Show();
            button1.Show();
            button2.Show();
            textBox1.Show();


            
        }

        private void gameTime(object sender, EventArgs e)
        {
            

            pictureBox2_bird.Top += gravity;
            pictureBox_1altengel.Left -= engelhızı;
            pictureBox_1ustengel.Left -= engelhızı;
            pictureBox3_2ustengel.Left -= engelhızı;
            pictureBox_2altengel.Left -= engelhızı;
            pictureBox3_üstengel.Left -= engelhızı;
            pictureBox3_altengel.Left -= engelhızı;
            label1.Text = "PUAN   :" + puan;

            int i;
            int[] rastgele = new int[100];
            Random rnd = new Random();

            //engel uzunluğu
            //int[] rastgeleustengel = new int[100];
            //Random rndust = new Random();
            //int[] rastgelealtengel = new int[100];
            //Random rndalt = new Random();

            


            for (i = 0; i < rastgele.Length; i++)
            {
                //for (int j = 0; j < 1; j++)
                //{
                //    rastgeleustengel[i] = rndust.Next(0, 30);
                //    rastgelealtengel[i] = rndust.Next(0, 30);

                //    üstengeluzunluğu = rastgeleustengel[i];
                //    altengeluzunluğu = rastgelealtengel[i];
                //    pictureBox_1ustengel.Height = üstengeluzunluğu;
                //    pictureBox_1altengel.Height = altengeluzunluğu;
                //}    

                rastgele[i] = rnd.Next(800, 1200);

                SoundPlayer ses = new SoundPlayer();
                if (pictureBox_1ustengel.Left < -180)//puan artırma
                {
                    pictureBox_1ustengel.Left = rastgele[i];

                    if (pictureBox_1altengel.Left < -180)
                    {  
                        string müzik = Application.StartupPath + "//engelgecmeses.wav";
                        ses.SoundLocation = müzik;
                        ses.Play();


                        pictureBox_1altengel.Left = rastgele[i];
                        puan++;
                        label1.Text = puan.ToString();
                    }
                }
                
               

                if (pictureBox3_2ustengel.Left < -180)//puan artırma
                {
                    pictureBox3_2ustengel.Left = rastgele[i];
                    if (pictureBox_2altengel.Left < -180)
                    {   
                        string müzik = Application.StartupPath + "//engelgecmeses.wav";
                        ses.SoundLocation = müzik;
                        ses.Play();


                        pictureBox_2altengel.Left = rastgele[i];
                        puan++;
                        label1.Text = puan.ToString();
                    }
                }

                
                if (pictureBox3_üstengel.Left < -180)//puan artırma
                {
                    pictureBox3_üstengel.Left = rastgele[i];
                    if (pictureBox3_altengel.Left < -180)
                    {
                        string müzik = Application.StartupPath + "//engelgecmeses.wav";
                        ses.SoundLocation = müzik;
                        ses.Play();


                        pictureBox3_altengel.Left = rastgele[i];
                        puan++;
                        label1.Text = puan.ToString();
                    }
                }
                
                //engellerin iç içe gelmemesi için
                if (
                    pictureBox_1ustengel.Bounds.IntersectsWith(pictureBox3_2ustengel.Bounds) ||
                    pictureBox_1ustengel.Bounds.IntersectsWith(pictureBox_2altengel.Bounds) ||
                    pictureBox_1ustengel.Bounds.IntersectsWith(pictureBox3_üstengel.Bounds) ||
                    pictureBox_1ustengel.Bounds.IntersectsWith(pictureBox3_altengel.Bounds)) 
                {
                    pictureBox_1ustengel.Left = rastgele[i];
                    pictureBox_1altengel.Left = rastgele[i];      
                }


                if (
                    pictureBox_1altengel.Bounds.IntersectsWith(pictureBox3_2ustengel.Bounds) ||
                    pictureBox_1altengel.Bounds.IntersectsWith(pictureBox_2altengel.Bounds) ||
                    pictureBox_1altengel.Bounds.IntersectsWith(pictureBox3_üstengel.Bounds) ||
                    pictureBox_1altengel.Bounds.IntersectsWith(pictureBox3_altengel.Bounds))
                {
                    pictureBox_1ustengel.Left = rastgele[i];
                    pictureBox_1altengel.Left = rastgele[i];   
                }

                //--------------------------------------------------------------

                if (
                    pictureBox3_2ustengel.Bounds.IntersectsWith(pictureBox3_üstengel.Bounds) ||
                    pictureBox3_2ustengel.Bounds.IntersectsWith(pictureBox3_altengel.Bounds))
                {
                    pictureBox3_2ustengel.Left = rastgele[i];
                    pictureBox_2altengel.Left = rastgele[i];  
                }

                if (
                    pictureBox_2altengel.Bounds.IntersectsWith(pictureBox3_üstengel.Bounds) ||
                    pictureBox_2altengel.Bounds.IntersectsWith(pictureBox3_altengel.Bounds))
                {
                    pictureBox3_2ustengel.Left = rastgele[i];
                    pictureBox_2altengel.Left = rastgele[i];   
                }

                //--------------------------------------------------------------


                //engellere carptıgında bitiş ekranını acması için 
                if (pictureBox2_bird.Bounds.IntersectsWith(pictureBox_1ustengel.Bounds) ||
                    pictureBox2_bird.Bounds.IntersectsWith(pictureBox_1altengel.Bounds) ||
                    pictureBox2_bird.Bounds.IntersectsWith(pictureBox3_2ustengel.Bounds) ||
                    pictureBox2_bird.Bounds.IntersectsWith(pictureBox_2altengel.Bounds) ||
                    pictureBox2_bird.Bounds.IntersectsWith(pictureBox3_üstengel.Bounds) ||
                    pictureBox2_bird.Bounds.IntersectsWith(pictureBox3_altengel.Bounds) ||
                    pictureBox2_bird.Bounds.IntersectsWith(pictureBox_graund.Bounds) ||
                    pictureBox2_bird.Top < -25)
                {
                    oyunsonu();
                    label2.Text = "aldığınız puan   :" + puan;
                    textBox1.Text=(isim + "--------->" + puan);
                    timer_gamecontrol.Stop();
                }
                
            }

        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {    
                gravity = -5;
            }
        }
        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
