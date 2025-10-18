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
            EnsureColumns(); 
            dgvSuperheroes.CellClick += dgvSuperheroes_CellClick; 
            LoadSuperheroes();
            
            // Set default focus to Hero ID field for better user experience
            txtHeroID.Focus();
        }

        
        private void EnsureColumns()
        {
            if (dgvSuperheroes.Columns.Count == 0)
            {
                dgvSuperheroes.Columns.Add("HeroID", "Hero ID");
                dgvSuperheroes.Columns.Add("Name", "Name");
                dgvSuperheroes.Columns.Add("Age", "Age");
                dgvSuperheroes.Columns.Add("Superpower", "Superpower");
                dgvSuperheroes.Columns.Add("ExamScore", "Exam Score");
                dgvSuperheroes.Columns.Add("Rank", "Rank");
                dgvSuperheroes.Columns.Add("ThreatLevel", "Threat Level");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadSuperheroesIntoGrid();
        }

        private void LoadSuperheroesIntoGrid()
        {
            EnsureColumns();
            dgvSuperheroes.Rows.Clear(); 

            if (!File.Exists(superheroesFile))
            {
                MessageBox.Show("No superheroes found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(superheroesFile);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue; 
                    string[] parts = line.Split(',');
                    if (parts.Length < 7) continue; 

                    dgvSuperheroes.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading superheroes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void dgvSuperheroes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuperheroes.Rows[e.RowIndex];

                txtHeroID.Text = row.Cells["HeroID"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtAge.Text = row.Cells["Age"].Value?.ToString() ?? "";
                txtSuperpower.Text = row.Cells["Superpower"].Value?.ToString() ?? "";
                txtExamScore.Text = row.Cells["ExamScore"].Value?.ToString() ?? "";
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtHeroID.Text))
            {
                MessageBox.Show("Hero ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Age must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtSuperpower.Text))
            {
                MessageBox.Show("Superpower is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            if (!int.TryParse(txtExamScore.Text, out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Exam Score must be an integer between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            return isValid;
        }
        
        private (string rank, string threat) CalculateRankAndThreat(int score)
        {
            if (score >= 81) return ("S-Rank", "Finals Week (threat to the entire academy)");
            else if (score >= 61) return ("A-Rank", "Midterm Madness (threat to a department)");
            else if (score >= 41) return ("B-Rank", "Group Project Gone Wrong (threat to a study group)");
            else return ("C-Rank", "Pop Quiz (potential threat to an individual student)");
        }

        private void ClearInputs()
        {
            txtHeroID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtSuperpower.Clear();
            txtExamScore.Clear();
        }
        
        //================Add superhero=====================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            int age = int.Parse(txtAge.Text);
            int examScore = int.Parse(txtExamScore.Text);
            var (rank, threat) = CalculateRankAndThreat(examScore);

            string record = $"{txtHeroID.Text},{txtName.Text},{age},{txtSuperpower.Text},{examScore},{rank},{threat}";

            try
            {
                if (!File.Exists(superheroesFile))
                    File.Create(superheroesFile).Close();

                File.AppendAllText(superheroesFile, record + Environment.NewLine);
                MessageBox.Show("Superhero added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadSuperheroesIntoGrid(); // Refresh the grid after adding
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSuperheroes()
        {
            var heroes = new List<Hero>();
            try
            {
                if (File.Exists(superheroesFile))
                {
                    var lines = File.ReadAllLines(superheroesFile);
                    foreach (var line in lines)
                    {
                        var hero = Hero.FromLine(line);
                        if (hero != null)
                        {
                            heroes.Add(hero);
                        }
                    }
                    dgvSuperheroes.DataSource = null;
                    dgvSuperheroes.DataSource = heroes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading heroes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Placeholder methods for Day 3
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
