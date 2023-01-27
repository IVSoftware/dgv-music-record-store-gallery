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
                }
            }
            var fcol = dataGridViewGallery.Columns[nameof(FourUp.Filler)];
            fcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fcol.HeaderText = string.Empty;
            fcol.DefaultCellStyle.BackColor = Color.Azure;
            Gallery.Clear();
            #endregion F O R M A T    C O L U M N S

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            int count = 0;
            FourUp fourUp = null;

            // Add a bunch of (duplicate) records;
            for (int i = 0; i < 10; i++)
            {
                foreach (var image in Directory.GetFiles(path))
                {
                    var mod = count % 4;
                    if (mod.Equals(0))
                    {
                        fourUp = new FourUp();
                        Gallery.Add(fourUp);
                    }
                    fourUp[mod] = Image.FromFile(image);
                    count++;
                }
            }
            dataGridViewGallery.ClearSelection();
        }
        BindingList<FourUp> Gallery { get; } = new BindingList<FourUp>();
    }
    class FourUp : INotifyPropertyChanged
    {
        public Image this[int index]
        {
            get
            {
                var name = $"Image{(char)('A' + index)}";
                return (Image)(typeof(FourUp).GetProperty(name)?.GetValue(this));
            }
            set
            {
                var name = $"Image{(char)('A' + index)}";
                typeof(FourUp).GetProperty(name)?.SetValue(this, value);
            }
        }
        private Image[] _images;

        Image _imageA = new Bitmap(32,32);
        public Image ImageA
        {
            get => _imageA;
            set
            {
                if (!Equals(_imageA, value))
                {
                    _imageA = value;
                    OnPropertyChanged();
                }
            }
        }

        Image _imageB = new Bitmap(32, 32);
        public Image ImageB
        {
            get => _imageB;
            set
            {
                if (!Equals(_imageB, value))
                {
                    _imageB = value;
                    OnPropertyChanged();
                }
            }
        }

        Image _imageC = new Bitmap(32, 32);
        public Image ImageC
        {
            get => _imageC;
            set
            {
                if (!Equals(_imageC, value))
                {
                    _imageC = value;
                    OnPropertyChanged();
                }
            }
        }

        Image _imageD = new Bitmap(32, 32);
        public Image ImageD
        {
            get => _imageD;
            set
            {
                if (!Equals(_imageD, value))
                {
                    _imageD = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Filler => string.Empty;
    }
}