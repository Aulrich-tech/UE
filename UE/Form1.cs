using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UE
{
    public partial class txt_reg : Form
    {
        int yearFee = 0;
        int regFee = 0;
        double discount = 0;
        public txt_reg()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_seminar.SelectedIndex == 0)
            {
                lbl_speaker.Text = "Rosa Parks";
                lbl_date.Text = "June 5, 2022";
                lbl_place.Text = "LCT Building";
            }
            else if (cb_seminar.SelectedIndex == 1)
            {
                lbl_speaker.Text = "Jerry Hanna";
                lbl_date.Text = "July 16, 2022";
                lbl_place.Text = "LCT Building";
            }
            else if (cb_seminar.SelectedIndex == 2)
            {
                lbl_speaker.Text = "Martha Thompson";
                lbl_date.Text = "August 20, 2022";
                lbl_place.Text = "TYK Building";
            }
            else if (cb_seminar.SelectedIndex == 3)
            {
                lbl_speaker.Text = "Percy Jackson";
                lbl_date.Text = "September 31, 2022";
                lbl_place.Text = "Engineering Building";
            }
            else if (cb_seminar.SelectedIndex == 4)
            {
                lbl_speaker.Text = "Pedro San Vicente";
                lbl_date.Text = "October 19, 2022";
                lbl_place.Text = "TYK Building";
            }
            else if (cb_seminar.SelectedIndex == 5)
            {
                lbl_speaker.Text = "Juan Dela Cruz";
                lbl_date.Text = "November 10, 2022";
                lbl_place.Text = "Engineering Building";
            }
            else if (cb_seminar.SelectedIndex == 6)
            {
                lbl_speaker.Text = "Harry Potter";
                lbl_date.Text = "December 9,2022";
                lbl_place.Text = "Engineering Building";
            }
            else if (cb_seminar.SelectedIndex == 7)
            {
                lbl_speaker.Text = "Sheldon Copper";
                lbl_date.Text = "January 7, 2023";
                lbl_place.Text = "TYK Building"; ;
            }
            else if (cb_seminar.SelectedIndex == 8)
            {
                lbl_speaker.Text = "Walter White";
                lbl_date.Text = "February 14, 2023";
                lbl_place.Text = "Engineering Building";
            }
        }

        private void btn_compute_Click(object sender, EventArgs e)
        {
            double total = (yearFee + regFee) - ((yearFee + regFee) * discount);
            lbl_cost.Text = " Php " + total + ".00";

        }

        private void cb_yrlvl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_yrlvl.Text == "1st Year")
            {
                yearFee = 180;
                lblyr.ForeColor = ColorTranslator.FromHtml("#a61403");
            }
            else if (cb_yrlvl.Text == "2nd Year")
            {
                yearFee = 220;
                lblyr.ForeColor = ColorTranslator.FromHtml("#8ba603");
            }
            else if (cb_yrlvl.Text == "3rd Year")
            {
                yearFee = 280;
                lblyr.ForeColor = ColorTranslator.FromHtml("#032ca6");
            }
            else if (cb_yrlvl.Text == "4th Year")
            {
                yearFee = 320;
                lblyr.ForeColor = ColorTranslator.FromHtml("#037da6");
            }
            else if (cb_yrlvl.Text == "5th Year")
            {
                yearFee = 400;
                lblyr.ForeColor = ColorTranslator.FromHtml("#8f5b01");
            }
        }

        private void cb_student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_student.Text == "Regular Student")
            {
                discount = 0;
                this.BackColor = ColorTranslator.FromHtml("#fcfce3");
            }
            else if (cb_student.Text == "Student Assistant")
            {
                discount = 0.30;
                this.BackColor = ColorTranslator.FromHtml("#defaf8");
            }
            else if (cb_student.Text == "Scholar Student")
            {
                discount = 0.60;
                this.BackColor = ColorTranslator.FromHtml("#fae4dc");
            }
            else if (cb_student.Text == "Student with School Benefits")
            {
                discount = 0.80;
                this.BackColor = ColorTranslator.FromHtml("#ffe8f5");
            }
            else if (cb_student.Text == "Student Athlete")
            {
                discount = 0.90;
                this.BackColor = ColorTranslator.FromHtml("#ebdcfc");
            }
        }

        private void cb_reg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_reg.Text == "Regular") regFee = 150;
            else if (cb_reg.Text == "Reserve") regFee = 130;
            else if (cb_reg.Text == "Early") regFee = 100;
            else if (cb_reg.Text == "Special") regFee = 200;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_sn.Clear();
            txt_school.Clear();
            txt_payment.Clear();
            lbl_place.Text = "";
            lbl_date.Text = "";
            lbl_speaker.Text = "";
            lbl_cost.Text = "";
            lbl_change.Text = "";
            cb_yrlvl.SelectedIndex = -1;
            cb_student.SelectedIndex = -1;
            cb_reg.SelectedIndex = -1;
            cb_gender.SelectedIndex = -1;
            cb_seminar.SelectedIndex = -1;
            lblname.Text = "";
            lblsn.Text = "";
            lblschool.Text = "";
            lblyr.Text = "";
            lblstudent.Text = "";
            lblreg.Text =   "";
            lblsex.Text =   "";
            lblseminar.Text =   "";
            lblspeaker.Text = "";
            lbldate.Text = "";
            lblplace.Text =     "";
            lblpayment.Text = "";
            lblfee.Text = "";
            lblchange.Text = "";
            lblregsum.Text = "";
            this.BackColor = Color.White;
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            double total = (yearFee + regFee) - ((yearFee + regFee) * discount);
            double payment = 0;

            if (!double.TryParse(txt_payment.Text, out payment))
            {
                MessageBox.Show("Enter a valid payment amount.");
                return;
            }

            double change = payment - total;

            if (change < 0)
            {
                MessageBox.Show("Payment is not enough!");
                return;
            }

            lbl_cost.Text = " Php " + total + ".00";
            lbl_change.Text = " Php " + change + ".00";

            lblname.Text = "Name: " + txt_name.Text;
            lblsn.Text = "Student Number: " + txt_sn.Text;
            lblschool.Text = "School: " + txt_school.Text;
            lblyr.Text = "Year Level: " + cb_yrlvl.Text;
            lblstudent.Text = "Student Type: " + cb_student.Text;
            lblreg.Text = "Registration Type: " + cb_reg.Text;
            lblsex.Text = "Gender: " + cb_gender.Text;
            lblseminar.Text = "Seminar: " + cb_seminar.Text;
            lblspeaker.Text = "Speaker: " + lbl_speaker.Text;
            lbldate.Text = "Date: " + lbl_date.Text;
            lblplace.Text = "Place: " + lbl_place.Text;
            lblpayment.Text = "Payment: Php " + payment + ".00";
            lblfee.Text = "Total Fee: Php " + (yearFee + regFee) + ".00";
            lblchange.Text = "Change: Php " + change + ".00";
            lblregsum.Text = "=========================Registration Successful========================";
        }
    }
}
