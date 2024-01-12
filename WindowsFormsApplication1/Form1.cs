using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            List<ClassType> ft = new List<ClassType>();
            ft.Add(new ClassType() { mindmg = 80, ClassName = "Warrior" });
            ft.Add(new ClassType() { mindmg = 90, ClassName = "Blader" });
            ft.Add(new ClassType() { mindmg = 100, ClassName = "Wizard" });
            ft.Add(new ClassType() { mindmg = 100, ClassName = "Force Archer" });
            ft.Add(new ClassType() { mindmg = 85, ClassName = "Force Blader" });
            ft.Add(new ClassType() { mindmg = 85, ClassName = "Force Shielder" });
            ft.Add(new ClassType() { mindmg = 80, ClassName = "Gladiator" });
            ft.Add(new ClassType() { mindmg = 100, ClassName = "Force Gunner" });
            comboBox1.DataSource = ft;
            comboBox1.DisplayMember = "ClassName";

        }

        //Non Crit Formula: Base attack value +[Base attack value * (%amp/100)+1] + Add attack (Skill) = Damage Output
        //Critical Formula: Base Atk + (Base Atk * AMP/100) + (Add Attack + 1) * (CDI/100) + 1 = Critical Output value

        private void button1_Click(object sender, EventArgs e)
        {
            ClassType ft1                       = comboBox1.SelectedItem as ClassType;
            int field_level                     = Convert.ToInt32(Level.Text) - 100;
            
            //MELEE CLASS - SSA
            int field_attack                    = Convert.ToInt32(Attack.Text);
            int field_ssa                       = Convert.ToInt32(SSA.Text);
            int field_cdi                       = Convert.ToInt32(CriticalDMG.Text);
            int field_mindmg                    = Convert.ToInt32(MinDMG.Text);
            int field_mindmg_class              = Convert.ToInt32(ft1.mindmg);
            int field_skill_ssa                 = Convert.ToInt32(Skill_SSA.Text);
            int field_skill_atk                 = Convert.ToInt32(Skill_SSA_ATK.Text);

            decimal dec_mindmg                  = (decimal)(field_mindmg + field_mindmg_class) / 100;

            decimal dec_cdi                     = (decimal)(field_cdi) / 100;
            decimal dec_ssa_amp                 = (decimal)(field_ssa + field_skill_ssa) / 100;

            decimal result_ssa_from             = Math.Floor((field_attack + (field_attack * dec_ssa_amp) + field_skill_atk + field_level) * dec_mindmg);  // Result from
            decimal result_ssa_to               = Math.Floor((field_attack + (field_attack * dec_ssa_amp) + field_skill_atk + field_level));               // Result to

            decimal result_crit_ssa             = Math.Floor(result_ssa_to * dec_cdi);

            //RANGE CLASS - MSA
            int field_mattack                   = Convert.ToInt32(MagicAttack.Text);
            int field_msa                       = Convert.ToInt32(MSA.Text);
            int field_adddmg_msa                = Convert.ToInt32(AddDMG.Text);

            int field_skill_msa                 = Convert.ToInt32(Skill_MSA.Text);
            int field_skill_matk                = Convert.ToInt32(Skill_MSA_ATK.Text);

            decimal dec_msa_amp                 = (decimal)(field_msa + field_skill_msa) / 100;
            decimal result_noncrit_msa          = Math.Round((field_mattack + (field_mattack * dec_msa_amp) + field_skill_matk + field_level + field_adddmg_msa));
            decimal result_crit_msa             = Math.Round(result_noncrit_msa * dec_cdi);

            /// DISPLAY RESULT CALCULATION 
            SSA_fr_Result.Text                  = Convert.ToString(result_ssa_from);
            SSA_to_Result.Text                  = Convert.ToString(result_ssa_to);
            SSA_Critical.Text                   = Convert.ToString(result_ssa_to + result_crit_ssa);

            MSA_to_Result.Text                  = Convert.ToString(result_noncrit_msa);
            MSA_Critical.Text                   = Convert.ToString(result_noncrit_msa + result_crit_msa);


        }


        private void Base_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Attack.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Attack.Text = Attack.Text.Remove(Attack.Text.Length - 1);
            }
        }

        private void Amp_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(SSA.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                SSA.Text = SSA.Text.Remove(SSA.Text.Length - 1);
            }
        }

        private void Skill_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Skill_SSA_ATK.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Skill_SSA_ATK.Text = Skill_SSA_ATK.Text.Remove(Skill_SSA_ATK.Text.Length - 1);
            }
        }

        private void Critical_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(CriticalDMG.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                CriticalDMG.Text = CriticalDMG.Text.Remove(CriticalDMG.Text.Length - 1);
            }
        }

        private void Skill_AMP_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Skill_SSA.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Skill_SSA.Text = Skill_SSA.Text.Remove(Skill_SSA.Text.Length - 1);
            }
        }

        private void Level_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Level.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Level.Text = Level.Text.Remove(Level.Text.Length - 1);
            }
        }

        private void MinDMG_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(MinDMG.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                MinDMG.Text = MinDMG.Text.Remove(MinDMG.Text.Length - 1);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClassType ft1 = comboBox1.SelectedItem as ClassType;
            //ClassArray.Text = Convert.ToString(ft1.mindmg);
            //MinDMG.Text = Convert.ToString(ft1.mindmg);
        }
        
        private void MagicAttack_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(MagicAttack.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                MagicAttack.Text = MagicAttack.Text.Remove(MagicAttack.Text.Length - 1);
            }
        }

        private void MSA_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(MSA.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                MSA.Text = MSA.Text.Remove(MSA.Text.Length - 1);
            }
        }

        private void AddDMG_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(AddDMG.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                AddDMG.Text = AddDMG.Text.Remove(AddDMG.Text.Length - 1);
            }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SSA_fr_Result.Text      = Convert.ToString(0);
            SSA_to_Result.Text      = Convert.ToString(0);
            SSA_Critical.Text       = Convert.ToString(0);
            MSA_to_Result.Text      = Convert.ToString(0);
            MSA_Critical.Text       = Convert.ToString(0);
        }

        private void Skill_MSA_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Skill_MSA.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Skill_MSA.Text = Skill_MSA.Text.Remove(Skill_MSA.Text.Length - 1);
            }   
        }

        private void Skill_MSA_ATK_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Skill_MSA_ATK.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Skill_MSA_ATK.Text = Skill_MSA_ATK.Text.Remove(Skill_MSA_ATK.Text.Length - 1);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SSA_fr_Result_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
