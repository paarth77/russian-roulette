using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
            loadBullet.Enabled = true;
            spinChambers.Enabled = false;
            fireGun.Enabled = false;                        //Initial running component.
            playAgain.Enabled = false;
            fireaway.Enabled = false;
            label1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }
        RussianRoulette obj = new RussianRoulette();
        int SCnum;
        private void EnableDisableButton()
        {
            bool a = obj.loadBulletButton();
            bool b = obj.spinChamberButton();          //it will enable/disable buttons
            bool c = obj.FireButtonAvailable();
            bool d = obj.fireAwayButton();
            bool e = obj.PAButtonEnabledFalse();
            loadBullet.Enabled = a;
            spinChambers.Enabled = b;
            fireaway.Enabled = d;
            playAgain.Enabled = e;
            fireGun.Enabled = c;
        }
        public void EnableDisableLabel()
        {
            bool f = obj.label1();
            bool g = obj.label6();
            bool h = obj.label7();
            label1.Visible = f;
            label6.Visible = g;
            label7.Visible = h;
        }

        private void scores()
        {
            int f = obj.saveBullet();
            int d = obj.hitBullet();
            label12.Text = f.ToString();
            label13.Text = d.ToString();
        }
        private void loadBullet_Click(object sender, EventArgs e)
        {
            obj.loadBulletInGun();
            EnableDisableLabel();
            EnableDisableButton();
            
        }

        private void spinChambers_Click(object sender, EventArgs e)
        {
            SCnum = obj.spinGunChamber();
            System.Media.SoundPlayer playerr = new System.Media.SoundPlayer(Resource1.mag);
            playerr.Play();
            EnableDisableButton();
            EnableDisableLabel();
        }

        private void fireGun_Click(object sender, EventArgs e)
        {
            SCnum = obj.spinGunChamber();
            obj.triggerGunFunc(SCnum);                                //it passes random value to fireGun Function.
            EnableDisableButton();
            EnableDisableLabel();
            scores();
            obj.counterVariable++;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            obj.resetFunction();
            EnableDisableButton();
            label7.Visible = false;   
            label12.Text = "0";
            label13.Text = "0";
        }

        private void fireaway_Click(object sender, EventArgs e)
        {
            SCnum = obj.spinGunChamber();
            obj.Fireaway(SCnum);
            obj.counterVariable++;
            obj.clickCountVariable++;
            EnableDisableButton();
            EnableDisableLabel();
            scores();  
        }
    }
}
