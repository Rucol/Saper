using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Sapper5
{
   public partial class game : Form
   {
      public static int siz = 32, field = 36;
      public int x = 90, y = 0, r = 0, bom = 0, num = 0, bmcount = 0;
      ArrayList a = new ArrayList();   
      ArrayList b = new ArrayList();   
      ArrayList c = new ArrayList();   
      ArrayList d = new ArrayList();   
      ArrayList e = new ArrayList();   
      bool[] f = new bool[36];
      int[] flg = new int[36];
      Point po = new Point();
      PictureBox pb = new PictureBox();
      PictureBox pb2 = new PictureBox();
      bool test1 = false, test2 = false; 
     public Wyniki wynik = new Wyniki();
        public string nick;
        public int score = 0;


        public game()
      {
         InitializeComponent();
         NickName();
        }

      bool rand = true;
      bool rand2 = true;
      bool rand3 = true;
      bool rand4 = true;
      bool rand5 = true;
      bool rand6 = true;
      bool gam = true;
        public void NickName()
        {
            TextBox userNameTextBox = new TextBox();
            Button confirmButton = new Button();

            userNameTextBox.Text = "Podaj nick";
            userNameTextBox.ForeColor = Color.Gray;
            userNameTextBox.GotFocus += (sender, e) =>
            {
                if (userNameTextBox.Text == "Podaj nick")
                {
                    userNameTextBox.Text = "";
                    userNameTextBox.ForeColor = Color.Black;
                }
            };
            userNameTextBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(userNameTextBox.Text))
                {
                    userNameTextBox.Text = "Podaj nick";
                    userNameTextBox.ForeColor = Color.Gray;
                }
            };
            userNameTextBox.Location = new Point(10, 10);
            userNameTextBox.Size = new Size(200, 20);

            confirmButton.Location = new Point(10, 40);
            confirmButton.Text = "Potwierdź";
            confirmButton.Click += (sender, e) =>
            {
                nick = userNameTextBox.Text;
                userNameTextBox.Visible = false;
                confirmButton.Visible = false;
            };
            this.Controls.Add(userNameTextBox);
            this.Controls.Add(confirmButton);
        }
       public void butt(bool test = false, int t = 0)
      {
            r = 0;
         if (t >= 0 && t < 6)
         {
            if (rand == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand = false;
            }
         }
         if (t >= 6 && t < 12)
         {
            if (rand2 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand2 = false;
            }
         }
         if (t >= 12 && t < 18)
         {
            if (rand3 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand3 = false;
            }
         }
         if (t >= 18 && t < 24)
         {
            if (rand4 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand4 = false;
            }
         }
         if (t >= 24 && t < 30)
         {
            if (rand5 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand5 = false;
            }
         }
         if (t >= 30 && t < 36)
         {
            if (rand6 == true)
            {
               r = System.DateTime.Now.Millisecond % 6;
            }
            if (r == 1)
            {
               rand6 = false;
            }
         }
         PictureBox bu = new PictureBox();
            if (r != 1 && test == true) 
            {
                bu.Click += (sender, e) =>
                {
                    score += 10; 
                };
            }
            if (r == 1 && test == true) 
         {
            bu.BackgroundImage = Properties.Resources.bomb;
         }
         else
         {
            bu.BackgroundImage = Properties.Resources._0;
         }
         bu.Size = new Size(32, 32);
         bu.Location = new Point(x, y);
         b.Add(x);
         a.Add(y);
         c.Add(r);
         d.Add(bu);
         this.Controls.Add(bu);
         bu.MouseDown += button1_MouseDown;
      }
      private void Form1_Load(object sender, EventArgs e)
      {
         load();
      }
      public void left(int o)
      {
         if ((int)c[o - 6] == 1)
         {
            bom++;
         }
      }
      public void right(int o)
      {
         if ((int)c[o + 6] == 1)
         {
            bom++;
         }
      }
      public void up(int o)
      {
         if ((int)c[o - 1] == 1)
         {
            bom++;
         }
      }
      public void down(int o)
      {
         if ((int)c[o + 1] == 1)
         {
            bom++;
         }
      }
      public void leftdown(int o)
      {
         if ((int)c[o - 5] == 1)
         {
            bom++;
         }
      }
      private void button1_Click(object sender, EventArgs e)
      {
         if (num == bmcount)
         {
            MessageBox.Show("U win");
         }
         else
         {
            gam = false;
            MessageBox.Show("U lose");
         }
      }
        public void aktualizuj_wynik(int value)
        {
            score += value;

            label3.Text = score.ToString(); 
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (gam == true) 
            {
                if (e.Button == MouseButtons.Left) 
                {
                    bom = 0;
                    pb = sender as PictureBox;

                    for (int p = 0; p < field; p++)
                    {
                        test2 = false;
                        po = new Point((int)b[p], (int)a[p]);

                        if (pb.Location == po)
                        {
                            if ((int)c[p] == 1) 
                            {
                                MessageBox.Show("Game Over");
                                wynik.Add(new WynikModel { Name = nick, Wynik = score });
                                gam = false;

                                for (int u = 0; u < field; u++)
                                {
                                    if ((int)c[u] == 1) 
                                    {
                                        PictureBox pe = (PictureBox)d[u];
                                        pe.BackgroundImage = Properties.Resources.bomb;
                                    }
                                }
                            }
                            else
                            {
                                if (p >= 6 && p % 6 == 0 && p < 30)
                                {
                                    right(p);
                                    down(p);
                                    left(p);
                                    leftdown(p);
                                    rightdown(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else if (p == 0)
                                {
                                    down(p);
                                    right(p);
                                    rightdown(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else if (p == 30)
                                {
                                    down(p);
                                    left(p);
                                    leftdown(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else if (p >= 1 && p <= 4)
                                {
                                    right(p);
                                    up(p);
                                    down(p);
                                    rightup(p);
                                    rightdown(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else if (p == 5)
                                {
                                    up(p);
                                    right(p);
                                    rightup(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else if (p == 35)
                                {
                                    left(p);
                                    up(p);
                                    leftup(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else if (p % 6 == 5 && p != 5 && p != 35)
                                {
                                    right(p);
                                    up(p);
                                    rightup(p);
                                    leftup(p);
                                    left(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else if (p <= 34 && p >= 31)
                                {
                                    left(p);
                                    leftup(p);
                                    up(p);
                                    leftdown(p);
                                    down(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }
                                else
                                {
                                    left(p);
                                    leftup(p);
                                    right(p);
                                    rightup(p);
                                    rightdown(p);
                                    up(p);
                                    leftdown(p);
                                    down(p);

                                    swit();
                                    swit2();
                                    swit3(p);
                                }

                                score += 5; 
                            }
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    test1 = false;
                    test2 = false;

                    for (int i = 0; i < field; i++)
                    {
                        pb2 = sender as PictureBox;
                        Point po2 = new Point((int)b[i], (int)a[i]);

                        if (po2 == pb2.Location)
                        {
                            if ((int)flg[i] % 2 == 0 && Convert.ToInt32(label2.Text) > 0) 
                            {
                                test1 = true;
                                f[i] = false; 
                                pb2.BackgroundImage = Properties.Resources.flag;

                                if ((int)c[i] == 1)
                                {
                                    score += 10; 
                                    bmcount++; 
                                }

                                label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
                            }

                            if ((int)flg[i] % 2 == 1) 
                            {
                                test2 = true;
                                f[i] = true; 
                                pb2.BackgroundImage = Properties.Resources._0;

                                if ((int)c[i] == 1)
                                {
                                    score -= 10; 
                                    bmcount--;  
                                }

                                label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1);
                            }

                            if (test1 == true || test2 == true)
                            {
                                flg[i] = flg[i] + 1;
                            }
                        }
                    }
                }

                aktualizuj_wynik(score);
            }
        }
        public void check()
      {

         for (int i = 0; i < field; i++)
         {
            bom = 0;
            if (i >= 6 && i % 6 == 0 && i < 30)
            { 

               right(i);
               down(i);
               left(i);
               leftdown(i);
               rightdown(i);
            }
            else if (i == 0)
            { 
               down(i);
               right(i);
               rightdown(i);
            }
            else if (i == 30) 
            {
               down(i);
               left(i);
               leftdown(i);
            }
            else if (i >= 1 && i <= 4)
            {
               right(i);
               up(i);
               down(i);
               rightup(i);
               rightdown(i);
            }
            else if (i == 5) 
            {
               up(i);
               right(i);
               rightup(i);
            }
            else if (i == 35) 
            {
               left(i);
               up(i);
               leftup(i);
            }
            else if (i % 6 == 5 && i != 5 && i != 35)
            {
               right(i);
               up(i);
               rightup(i);
               leftup(i);
               left(i);
            }
            else if (i <= 34 && i >= 31)
            {
               left(i);
               leftup(i);
               up(i);
               leftdown(i);
               down(i);
            }
            else
            {
               left(i);
               leftup(i);
               right(i);
               rightup(i);
               rightdown(i);
               up(i);
               leftdown(i);
               down(i);
            }
            e.Add(bom);
         }
      }
      int tim = 0;
      private void timer1_Tick(object sender, EventArgs e)
      {
         tim++;
         label4.Text = tim.ToString();
      }
        private void button3_Click(object sender, EventArgs e)
        {
             Application.Restart();
        }
        public void leftup(int o)
      {
         if ((int)c[o - 7] == 1)
         {
            bom++;
         }
      }
      public void rightup(int o)
      {
         if ((int)c[o + 5] == 1)
         {
            bom++;
         }
      }
      public void rightdown(int o)
      {
         if ((int)c[o + 7] == 1)
         {
            bom++;
         }
      }
      public void swit()
      {
         switch (bom)
         {
            case 0:
               pb.BackgroundImage = Properties.Resources._null;
               break;
            case 1:
               pb.BackgroundImage = Properties.Resources._1;
               break;
            case 2:
               pb.BackgroundImage = Properties.Resources._2;
               break;
            case 3:
               pb.BackgroundImage = Properties.Resources._3;
               break;
         }
      } 
      public void swit2() 
      {
         check();
         for (int t = 0; t < field; t++)
         {
            if ((int)c[t] != 1 && (int)e[t] == 0)
            {

               PictureBox pe2 = (PictureBox)d[t];
               pe2.Location = new Point((int)b[t], (int)a[t]);
               pe2.BackgroundImage = Properties.Resources._null;

            }

         }
      }
      public void swit3(int o)  
      {
         for (int i = 0; i < field; i++)
         {
            if (flg[i] == 1)
            {
               PictureBox pe = (PictureBox)d[i];
               pe.BackgroundImage = Properties.Resources.flag;
            }
         }
      }
      public void load()
      {
         for (int i = 0; i < field; i++)
         {

            if (y != 6 * siz)
            {
               y += siz;
            }
            else
            {
               y = siz;
               x += siz;
            }
            butt(false, i);
         }

         for (int t = 0; t < field; t++)
         {
            if ((int)c[t] == 1)
            {
               num++;
               label2.Text = num.ToString();
            }
         }

      }
   }
}

