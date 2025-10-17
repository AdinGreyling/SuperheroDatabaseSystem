using System;
using System.IO;
using System.Windows.Forms;

namespace Project_PRG282
{
    public partial class Form1 : Form
    {
        // Variables
        private string superheroesFile = "superheroes.txt";
        private string summaryFile = "summary.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Basic form initialization
            MessageBox.Show("Superhero Management System - Day 1 Setup Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Placeholder methods for future development
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add functionality - Coming in Day 2", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View functionality - Coming in Day 2", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update functionality - Coming in Day 3", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete functionality - Coming in Day 3", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report functionality - Coming in Day 3", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
