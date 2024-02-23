namespace CharacterConfigurationTool {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            cboxCharacterSelect.SelectedIndex = 0;
            cboxCharacterRank.SelectedIndex = 0;
            cboxLightconeSelect.SelectedIndex = 0;
            cboxLightconeRank.SelectedIndex = 0;
        }
    }
}
