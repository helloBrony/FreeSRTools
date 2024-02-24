namespace CharacterConfigurationTool {
    public partial class fMain : Form {
        public fMain() {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e) {
            cboxCharacterSelect.SelectedIndex = 0;
            cboxCharacterRank.SelectedIndex = 0;
            cboxLightconeSelect.SelectedIndex = 0;
            cboxLightconeRank.SelectedIndex = 0;
        }
    }
}
