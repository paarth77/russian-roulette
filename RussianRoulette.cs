using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
     class RussianRoulette
    {
        //global variable declaration
        private int save;
        private int hit;
        private bool enableDisableFB;
        private bool enableDisablePAB;
        private bool enableDisableFAB;
        private bool enableDisableSCB;
        private bool enableDisableLLB;
        private bool enableDisableLabel1;
        private bool enableDisableLabel6;
        private bool enableDisableLabel7;
        public int counterVariable = 0;
        public int clickCountVariable = 0;
        public int fireAwayVariable = 0;
        private int[] gunChamberArr = new int[5] { 0, 0, 0, 0, 0 };

        //class Method
        public bool label1()
        {
            return enableDisableLabel1;
        }
        public bool label6()
        {
            return enableDisableLabel6;
        }
        public bool label7()
        {
            return enableDisableLabel7;
        }
        public bool loadBulletButton()
        {
            return enableDisableLLB;
        }
        public bool spinChamberButton()
        {
            return enableDisableSCB;
        }
        public bool fireAwayButton()
        {
            return enableDisableFAB;        //this function make button Enable/Disable.
        }
        public int hitBullet()
        {
            return hit;                     //returns whether hit has value or not
        }

        public int saveBullet()
        {
            return save;                    //returns whether save has value or not
        }
        public bool FireButtonAvailable()
        {
            return enableDisableFB;           //this function make button enable/disable.
        }

        public bool PAButtonEnabledFalse()
        {
            return enableDisablePAB;          //this function make button Enable/Disable.
        }

        public void loadBulletInGun()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.GunEmpty);
            player.Play();
            Array.Resize(ref gunChamberArr, gunChamberArr.Length + 1);
            gunChamberArr[5] = 1;                                      //Add Bullet into Gun Chamber.
            Console.WriteLine(gunChamberArr[5]);
            enableDisableLLB = false;
            enableDisableSCB = true;
            enableDisableFB = false;
            enableDisableFAB = false;
            enableDisablePAB = false;
            enableDisableLabel1 = true;
            enableDisableLabel6 = false;
            enableDisableLabel7 = false;
        }

        public int spinGunChamber()
        {
            Random rd = new Random();
            int randomIndex = rd.Next(0, gunChamberArr.Length);          // This function spins the chamber of gun.
            int randomNumber = gunChamberArr[randomIndex];
            Console.WriteLine(randomNumber);
            enableDisableLLB = false;
            enableDisableSCB = false;
            enableDisableFB = true;
            enableDisableFAB = true;
            enableDisablePAB = false;
            enableDisableLabel1 = false;
            enableDisableLabel6 = true;
            enableDisableLabel7 = false;
            return randomNumber;
        }

        public void Fireaway(int randNumber1)
        {
            enableDisableLabel1 = false;
            enableDisableLabel6 = false;
            enableDisableLabel7 = true;
            if (clickCountVariable >= 0 && clickCountVariable <= 1)
            {
                save++;
                System.Media.SoundPlayer playerr = new System.Media.SoundPlayer(Resource1.GunEmpty);
                playerr.Play();
                enableDisableFB = true;
                enableDisableFAB = true;
                enableDisablePAB = false;
                if (randNumber1 == gunChamberArr[5])
                {
                    enableDisableLabel7 = false;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.revolver);
                    player.Play();
                    save++;
                    save -= 1;
                    enableDisableFB = false;
                    enableDisableFAB = false;
                    enableDisablePAB = true;
                    string message = "You Win The Game :)";
                    string title = "You Survived!!";
                    MessageBox.Show(message, title);
                }
            }
            else
            {
                enableDisableLabel7 = false;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.revolver);
                player.Play();
                hit++;
                enableDisableFB = false;
                enableDisableFAB = false;
                enableDisablePAB = true;
                string message = "You Loose The Game :(";
                string title = "You Are Dead!!";
                MessageBox.Show(message, title);
            }

        }
        public void triggerGunFunc(int randomnumber)                        //This function Fires the Bullet.
        {
            enableDisableLabel1 = false;
            enableDisableLabel6 = false;
            enableDisableLabel7 = true;
            if (randomnumber == gunChamberArr[5] || counterVariable == 5)                        //In this if/else we are checking that bullet hits or not
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.revolver);
                player.Play();
                hit++;
                enableDisableFB = false;
                enableDisableFAB = false;
                enableDisablePAB = true;
                enableDisableLabel7 = false;
                string message = "You Loose The Game :(";
                string title = "You Are Dead!!";
                MessageBox.Show(message, title);
            }
            else if (clickCountVariable == 2)
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.revolver);
                player.Play();
                hit++;
                enableDisableFB = false;
                enableDisableFAB = false;
                enableDisablePAB = true;
                enableDisableLabel7 = false;
                string message = "You Loose The Game :(";
                string title = "You Are Dead!!";
                MessageBox.Show(message, title);
            }
            else
            {
                save++;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.GunEmpty);
                player.Play();
                enableDisableFB = true;
                enableDisableFAB = true;
                enableDisablePAB = false;                //If bullet is not fired then random number function will fire Again.
            }
        }
        public void resetFunction()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.GameOver);
            player.Play();
            string message = "Game Is Over ";
            string title = "Russian Roulette";
            MessageBox.Show(message, title);
            gunChamberArr = new int[5] { 0, 0, 0, 0, 0 };                    //reset game.
            save = 0;
            hit = 0;
            counterVariable = 0;
            clickCountVariable = 0;
            enableDisableLLB = true;
            enableDisableSCB = false;
            enableDisableFB = false;
            enableDisableFAB = false;
            enableDisablePAB = false;
            enableDisableLabel1 = false;
            enableDisableLabel6 = false;
            enableDisableLabel7 = false;
        }
    }
}
