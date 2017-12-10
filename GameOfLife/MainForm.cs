using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        private bool _started = false;
        private Timer _updateTimer;
        private TimeSpan _updatePeriod = TimeSpan.FromSeconds(1);
        private int _width = 100;
        private int _height = 100;
        private bool[,] _grid;
        private bool[,] _backupGrid;
        private Bitmap _bitmap;

        private static readonly Color LiveColor = Color.Black;
        private static readonly Color DeadColor = Color.White;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartStop()
        {
            if (_started)
            {
                StartBtn.Text = "Start";
                _started = false;
            }
            else
            {
                StartBtn.Text = "Stop";
                _started = true;
                ReArmTimer();
            }
        }

        private void RandBtn_Click(object sender, EventArgs e)
        {
            int numProb = 1;
            int denumProb = 8;

            var rand = new Random();
            UpdateWith((x, y) => rand.Next(denumProb) <= numProb - 1);

            BuildImg();
            AdjustImage();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            UpdateWith((x, y) => false);
        }

        private void UpdateWith(Func<int, int, bool> predicate)
        {
            if (_started)
                StartStop();

            for (int x = 0; x < _width; ++x)
                for (int y = 0; y < _height; ++y)
                    _grid[x, y] = predicate(x, y);

            BuildImg();
            AdjustImage();
        }

        private void BuildImg()
        {
            var img = new Bitmap(_width, _height);
            for (int x = 0; x < _width; ++x)
                for (int y = 0; y < _height; ++y)
                    img.SetPixel(x, y, _grid[x, y] ? LiveColor : DeadColor);
            _bitmap = img;
        }

        private void AdjustImage()
        {
            if (_bitmap != null)
            {
                Bitmap result = new Bitmap(pictureBoxGrid.ClientSize.Width, pictureBoxGrid.ClientSize.Height);
                int xResolution = pictureBoxGrid.ClientSize.Width / _width;
                int yResolution = pictureBoxGrid.ClientSize.Width / _height;
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    lock (_bitmap)
                        g.DrawImage(_bitmap, 0, 0, pictureBoxGrid.ClientSize.Width, pictureBoxGrid.ClientSize.Height);
                }
                pictureBoxGrid.Image = result;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _updateTimer = new Timer(OnTimerTick);
            _grid = new bool[_width, _height];
            _backupGrid = new bool[_width, _height];
            BuildImg();
            AdjustImage();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (NumericPace.Value == 0 && !_started)
                MessageBox.Show("You can't start with 0 image per second");
            else
                StartStop();
        }

        private void NumericPace_ValueChanged(object sender, EventArgs e)
        {
            if (NumericPace.Value == 0 && _started)
                StartStop();
            else
            {
                _updatePeriod = TimeSpan.FromSeconds(1 / (double)NumericPace.Value);
                ReArmTimer();
            }
        }

        private void ReArmTimer(TimeSpan when = default(TimeSpan))
        {
            _updateTimer.Change(_started ? when : Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        }

        private void PictureBoxGrid_SizeChanged(object sender, EventArgs e)
        {
            AdjustImage();
        }

        private void PictureBoxGrid_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs evt)
            {
                int x = _width * evt.Location.X / pictureBoxGrid.ClientSize.Width;
                int y = _height * evt.Location.Y / pictureBoxGrid.ClientSize.Height;
                {
                    // left makes the cell alive, others kills it
                    var liveness = _grid[x, y] = (evt.Button == MouseButtons.Left);
                    lock (_bitmap)
                        _bitmap.SetPixel(x, y, liveness ? LiveColor : DeadColor);
                }
                AdjustImage();
            }
        }

        private void OnTimerTick(object _)
        {
            UpdateLiveness();
            ReArmTimer(_updatePeriod);
        }

        private void UpdateLiveness()
        {
            for (int x = 0; x < _width; ++x)
                for (int y = 0; y < _height; ++y)
                {
                    _backupGrid[x, y] = IsAlive(x, y);
                    if (_backupGrid[x, y] != _grid[x, y]) lock(_bitmap)
                        _bitmap.SetPixel(x, y, _backupGrid[x, y] ? LiveColor: DeadColor);
                }
            var toBackup = _grid;
            _grid = _backupGrid;
            _backupGrid = toBackup;
            AdjustImage();
        }

        private bool IsAlive(int x, int y)
        {
            int liveNeigbors = NeighborsOf(x, y).Count(p => _grid[p.X, p.Y]);
            if (liveNeigbors == 2)
                return _grid[x, y];

            return liveNeigbors == 3;
        }

        private IEnumerable<Point> NeighborsOf(int x, int y)
        {
            if (x > 0)
            {
                if (y > 0)
                    yield return new Point(x - 1, y - 1);
                yield return new Point(x - 1, y);
                if (y < _height - 1)
                    yield return new Point(x - 1, y + 1);
            }

            if (y > 0)
                yield return new Point(x, y - 1);
            if (y < _height - 1)
                yield return new Point(x, y + 1);

            if (x < _width - 1)
            {
                if (y > 0)
                    yield return new Point(x + 1, y - 1);
                yield return new Point(x + 1, y);
                if (y < _height - 1)
                    yield return new Point(x + 1, y + 1);
            }
        }
    }
}
