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
            List<string> descriptions = new List<string>();
            FourUp fourUp = null;

            // Add everything in the Images folder.
            foreach (var image in Directory.GetFiles(path))
            {
                var mod = count % 4;
                if (mod.Equals(0))
                {
                    descriptions.Clear();
                    fourUp = new FourUp();
                    Gallery.Add(fourUp);
                }
                descriptions.Add(Path.GetFileNameWithoutExtension(image));
                fourUp[mod] = Image.FromFile(image);
                fourUp.Description = string.Join(Environment.NewLine, descriptions);
                count++;
            }
            dataGridViewGallery.Refresh();
            dataGridViewGallery.ClearSelection();
            dataGridViewGallery.CellContentClick += onCellContentClick;
        }

        private void onCellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        BindingList<FourUp> Gallery { get; } = new BindingList<FourUp>();
    }
    class FourUp : INotifyPropertyChanged
    {
        string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                if (!Equals(_description, value))
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
        public Image this[int index]
        {
            get => _images[index];
            set
            {
                var name = $"Image{(char)('A' + index)}";
                _images[index] = value;
            }
        }
        private Image[] _images = 
            Enumerable.Range(0,4).Select(_=>new Bitmap(32,32)).ToArray();

        Image _image1 = new Bitmap(32,32);
        public Image ImageA => _images[0];
        public Image ImageB => _images[1];
        public Image ImageC => _images[2];
        public Image ImageD => _images[3];

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}