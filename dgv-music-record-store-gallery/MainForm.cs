using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            dataGridViewGallery.ScrollBars= ScrollBars.Vertical;
            #region F O R M A T    C O L U M N S
            dataGridViewGallery.RowTemplate.Height = 200;
            Gallery.Add(new FourUp());
            foreach (DataGridViewColumn col in dataGridViewGallery.Columns)
            {
                if(col is DataGridViewImageColumn)
                {
                    col.Width = 200;
                    col.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10);
                    col.DefaultCellStyle.BackColor = Color.FromArgb(0x22, 0x22, 0x22);
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            var column = dataGridViewGallery.Columns[nameof(FourUp.Description)];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.HeaderText = string.Empty;
            column.DefaultCellStyle.BackColor = Color.Azure;
            column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;  
            Gallery.Clear();
            #endregion F O R M A T    C O L U M N S

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            int count = 0;
            FourUp fourUp = null;

            // Add everything in the Images folder.
            foreach (var image in Directory.GetFiles(path))
            {
                var mod = count % 4;
                if (mod.Equals(0))
                {
                    fourUp = new FourUp();
                    Gallery.Add(fourUp);
                }
                fourUp.Descriptions[mod] = Path.GetFileNameWithoutExtension(image);
                fourUp.Images[mod] = Image.FromFile(image);
                count++;
            }
            dataGridViewGallery.Refresh();
            dataGridViewGallery.ClearSelection();
            dataGridViewGallery.CellContentClick += onCellContentClick;
        }

        private void onCellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if((e.RowIndex != -1) && (e.ColumnIndex != -1))
            {
                if (dataGridViewGallery[e.ColumnIndex, e.RowIndex] is DataGridViewImageCell imageCell)
                {
                    int index;
                    switch (dataGridViewGallery.Columns[e.ColumnIndex].Name)
                    {
                        case nameof(FourUp.ImageA): index = 0; break;
                        case nameof(FourUp.ImageB): index = 1; break;
                        case nameof(FourUp.ImageC): index = 2; break;
                        case nameof(FourUp.ImageD): index = 3; break;
                        default: return;
                    }
                    var fourUp = Gallery[e.RowIndex];
                    MessageBox.Show($"Column {e.ColumnIndex} Row {e.RowIndex} {fourUp.Descriptions[index]}");
                }
            }
        }
        BindingList<FourUp> Gallery { get; } = new BindingList<FourUp>();
    }
    class FourUp
    {
        public string Description =>
            string.Join(Environment.NewLine, Descriptions);
        public string[] Descriptions =
            Enumerable.Repeat(string.Empty, 4).ToArray();

        public Image[] Images = 
            Enumerable.Range(0,4).Select(_=>new Bitmap(32,32)).ToArray();

        Image _image1 = new Bitmap(32,32);
        public Image ImageA => Images[0];
        public Image ImageB => Images[1];
        public Image ImageC => Images[2];
        public Image ImageD => Images[3];
    }
}