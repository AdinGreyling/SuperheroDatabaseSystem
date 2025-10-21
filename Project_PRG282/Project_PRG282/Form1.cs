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

        //================Hero ID Modes=====================

        private void SetAddMode()
        {
            txtHeroID.Enabled = false;
            MessageBox.Show("Hero ID is auto-generated");
            txtHeroID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtSuperpower.Clear();
            txtExamScore.Clear();
        }
        
        private void SetUpdateMode()
        {
            txtHeroID.Enabled = true;
            lblHeroID.Text = "Hero ID";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureColumns(); 
            dgvSuperheroes.CellClick += dgvSuperheroes_CellClick; 
            LoadSuperheroes();
            SetAddMode();
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

        private bool ValidateInputs(bool isAdding = false)
        {
            bool isValid = true;
            if (!isAdding && string.IsNullOrWhiteSpace(txtHeroID.Text))
            {
                MessageBox.Show("Hero ID is required for updates.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string GenerateUniqueHeroID()
        {
            string newID;
            Random rand = new Random();
            string[] existingIDs = File.Exists(superheroesFile) ? File.ReadAllLines(superheroesFile)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(',')[0])
                .ToArray() : Array.Empty<string>();

            do
            {
                newID = rand.Next(10000, 99999).ToString("D5");
            } while (existingIDs.Contains(newID));

            return newID;
        }
        
        //================Add superhero=====================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetAddMode();
            if (!ValidateInputs(true)) return;
            string heroID = GenerateUniqueHeroID();
            int age = int.Parse(txtAge.Text);
            int examScore = int.Parse(txtExamScore.Text);
            var (rank, threat) = CalculateRankAndThreat(examScore);
            string record = $"{heroID},{txtName.Text},{age},{txtSuperpower.Text},{examScore},{rank},{threat}";
            try
            {
                if (!File.Exists(superheroesFile))
                    File.Create(superheroesFile).Close();
                File.AppendAllText(superheroesFile, record + Environment.NewLine);
                MessageBox.Show("Superhero added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadSuperheroesIntoGrid();
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

        // ====================== Update Functionality ======================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetUpdateMode();
            if (!ValidateInputs(false)) return;

            if (!File.Exists(superheroesFile))
            {
                MessageBox.Show("No superheroes found to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] lines = File.ReadAllLines(superheroesFile);
            bool updated = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 7) continue;

                if (parts[0] == txtHeroID.Text) 
                {
                    int age = int.Parse(txtAge.Text);
                    int examScore = int.Parse(txtExamScore.Text);
                    var (rank, threat) = CalculateRankAndThreat(examScore);

                    lines[i] = $"{txtHeroID.Text},{txtName.Text},{age},{txtSuperpower.Text},{examScore},{rank},{threat}";
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                File.WriteAllLines(superheroesFile, lines);
                MessageBox.Show("Superhero updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSuperheroesIntoGrid();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Hero ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //=========Delete function=========
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (dgvSuperheroes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a superhero to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            DataGridViewRow selectedRow = dgvSuperheroes.SelectedRows[0];
            string heroID = selectedRow.Cells[0].Value?.ToString();
            string heroName = selectedRow.Cells[1].Value?.ToString();

            if (string.IsNullOrWhiteSpace(heroID))
            {
                MessageBox.Show("Invalid selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete hero '{heroName}' (ID: {heroID})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                
                if (!File.Exists(superheroesFile))
                {
                    MessageBox.Show("No superhero file found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<string> allLines = File.ReadAllLines(superheroesFile).ToList();

                
                int removedCount = allLines.RemoveAll(line =>
                {
                    if (string.IsNullOrWhiteSpace(line)) return false;
                    string[] parts = line.Split(',');
                    if (parts.Length < 7) return false;
                    return parts[0].Trim().Equals(heroID, StringComparison.OrdinalIgnoreCase);
                });

                
                if (removedCount > 0)
                {
                    File.WriteAllLines(superheroesFile, allLines);
                    LoadSuperheroesIntoGrid();
                    MessageBox.Show($"Hero '{heroName}' deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hero not found in file (may already be deleted).", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting hero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //===================Summary==================
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                // Load heroes
                var heroes = new List<Hero>();
                if (File.Exists(superheroesFile))
                {
                    heroes = File.ReadAllLines(superheroesFile)
                                 .Select(line => Hero.FromLine(line))
                                 .Where(h => h != null)
                                 .ToList();
                }

                int total = heroes.Count;
                double avgAge = total > 0 ? heroes.Average(h => h.Age) : 0.0;
                double avgScore = total > 0 ? heroes.Average(h => h.ExamScore) : 0.0;


                int sCount = heroes.Count(h => string.Equals(h.Rank, "S-Rank", StringComparison.OrdinalIgnoreCase));
                int aCount = heroes.Count(h => string.Equals(h.Rank, "A-Rank", StringComparison.OrdinalIgnoreCase));
                int bCount = heroes.Count(h => string.Equals(h.Rank, "B-Rank", StringComparison.OrdinalIgnoreCase));
                int cCount = heroes.Count(h => string.Equals(h.Rank, "C-Rank", StringComparison.OrdinalIgnoreCase));

                // Display to form
                string summaryText =
                $"========== Superhero Summary Report ==========\r\n" +
                $"Date: {DateTime.Now:G}\r\n\r\n" +
                $"Total superheroes: {total}\r\n" +
                $"Average age: {avgAge:F2}\r\n" +
                $"Average exam score: {avgScore:F2}\r\n\r\n" +
                $"Heroes per rank:\r\n" +
                $"   S-Rank: {sCount}\r\n" +
                $"   A-Rank: {aCount}\r\n" +
                $"   B-Rank: {bCount}\r\n" +
                $"   C-Rank: {cCount}\r\n" +
                $"=============================================\r\n";

                txtReport.Text = summaryText;

                
                File.WriteAllText(summaryFile, summaryText);

                
                MessageBox.Show("Summary displayed and saved successfully!",
                                "Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating summary: {ex.Message}", "Summary Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
