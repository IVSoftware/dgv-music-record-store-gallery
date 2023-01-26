using System.ComponentModel;

namespace dgv_music_record_store_gallery
{
    public partial class MainForm : Form
    {
        public MainForm() =>InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridViewGallery.Width = 600 + SystemInformation.VerticalScrollBarWidth;
            dataGridViewGallery.DataSource = Gallery;
            #region F O R M A T    C O L U M N S
            dataGridViewGallery.RowTemplate.Height = 150;
            Gallery.Add(new FourUp());
            foreach (DataGridViewColumn col in dataGridViewGallery.Columns)
            {
                if(col is DataGridViewImageColumn)
                {
                    col.Width = 150;
                }
            }
            var fcol = dataGridViewGallery.Columns[nameof(FourUp.Filler)];
            fcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fcol.HeaderText = string.Empty;
            fcol.DefaultCellStyle.BackColor = Color.Azure;
            #endregion F O R M A T    C O L U M N S
        }
        BindingList<FourUp> Gallery { get; } = new BindingList<FourUp>();
    }
    class FourUp
    {
        public Image ImageA { get; set; } = new Bitmap(32, 32);
        public Image ImageB { get; set; } = new Bitmap(32, 32);
        public Image ImageC { get; set; } = new Bitmap(32, 32);
        public Image ImageD { get; set; } = new Bitmap(32, 32);
        public string Filler => string.Empty;
    }
}