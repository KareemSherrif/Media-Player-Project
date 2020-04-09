using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;


namespace Media_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Dictionary<string, string> DictionaryPlayList;
        string source;
        int playingItemIndex;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval =TimeSpan.FromSeconds(0.25);
            timer.Tick += TimerTick;
            DictionaryPlayList = new Dictionary<string, string>();
        }


        #region Functions
        private void PlayNext()
        {
            if (playingItemIndex < LViewItemList.Items.Count - 1)
            {
                playingItemIndex++;
                LViewItemList.SelectedItem = LViewItemList.Items[playingItemIndex];
                source = DictionaryPlayList[LViewItemList.Items[playingItemIndex].ToString()];
                StopPlaying();
                TbtnPlayPause.IsChecked = true;
            }
        } 
        private void PlayPrevious()
        {
            if (playingItemIndex > 0)
            {
                playingItemIndex--;
                LViewItemList.SelectedItem = LViewItemList.Items[playingItemIndex];
                source = DictionaryPlayList[LViewItemList.Items[playingItemIndex].ToString()];
                StopPlaying();
                TbtnPlayPause.IsChecked = true;
            }
        }
        private void Play(string source)
        {
            if(MediaArea.Source != new Uri(source))
            MediaArea.Source = new Uri(source);

            MediaArea.Play();
        }
        private void AddToList(string fileName, string filePath)
        {
            if (DictionaryPlayList.ContainsKey(fileName))    //Incase the same file was added multiple times.
            LViewItemList.Items.Add(fileName);

            else
            {
            DictionaryPlayList.Add(fileName, filePath);
            LViewItemList.Items.Add(fileName); //Gets Data from the dropped file, Then transforms it to string array, then adds it to list.
            }

            if (TBlockEmptyListWarning.Visibility == Visibility.Visible)
                TBlockEmptyListWarning.Visibility = Visibility.Hidden;
        }

        private void StopPlaying()
        {
            timer.Stop();
            MediaArea.Stop();
            TbtnPlayPause.IsChecked = false;
            SliderProgress.Value = 0;
            LblProgress.Content = "00:00:00";
            LblTotalDuration.Content = "00:00:00";
        }
        private void DeleteItem()
        {
            if (LViewItemList.SelectedItem != null && MediaArea.Source == new Uri(DictionaryPlayList[LViewItemList.SelectedItem.ToString()]))
                StopPlaying();
            try
            {
            DictionaryPlayList.Remove(LViewItemList.SelectedItem.ToString());
            LViewItemList.Items.Remove(LViewItemList.SelectedItem);
            if (LViewItemList.Items.IsEmpty)
                TBlockEmptyListWarning.Visibility = Visibility.Visible;
            }
            catch
            {

            }

        }

        #endregion


        #region Events
        private void TBtnMute_Checked(object sender, RoutedEventArgs e)   //Mute
        {
            MediaArea.IsMuted = true;
        }

        private void TBtnMute_Unchecked(object sender, RoutedEventArgs e) //UnMute
        {
            MediaArea.IsMuted = false;
        }

        private void TbtnPlayPause_Checked(object sender, RoutedEventArgs e) //Play
        {

            if (source == null)
            {
                MessageBox.Show("No Media Detected!, Please open or drag & drop a Media file first !");
                TbtnPlayPause.IsChecked = false;
            }
            else
            {
                Play(source);
                if (source.Contains(".mp3") || source.Contains(".wav"))
                    TaskbarItemInfo.Overlay = (ImageSource)FindResource("OverlayMusic");
                else
                    TaskbarItemInfo.Overlay = (ImageSource)FindResource("OverlayVideo");
            }


        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            PlayPrevious();
        }

        private void TbtnPlayPause_Unchecked(object sender, RoutedEventArgs e) //Pause
        {
            timer.Stop();
            MediaArea.Pause();
        }

        private void SliderProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaArea.Position = TimeSpan.FromSeconds(SliderProgress.Value);
        }

        private void MediaArea_MediaOpened(object sender, RoutedEventArgs e)  //When Media Starts
        {
            SliderProgress.Maximum = (MediaArea.NaturalDuration.TimeSpan.TotalSeconds);
            LblTotalDuration.Content = MediaArea.NaturalDuration;
            this.Title = System.IO.Path.GetFileName(MediaArea.Source.OriginalString) + "    - K-PLayer";   //Show Media Name in Title
            timer.Start();

        }

        private void MediaArea_MediaEnded(object sender, RoutedEventArgs e) //When Media Stops
        {
            StopPlaying();
            PlayNext();
        }


        private void TimerTick(object sender, object e)
        {

            if (MediaArea.NaturalDuration.TimeSpan.TotalMilliseconds > 0)
            {
                SliderProgress.Value = MediaArea.Position.TotalSeconds;
                LblProgress.Content = MediaArea.Position;

            }
            else
                SliderProgress.Value = 0;
        }


        private void SubMenuItemOpen_Click(object sender, RoutedEventArgs e) //Opening File Dialog
        {
            MediaArea.Pause();
            TbtnPlayPause.IsChecked = false;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(fileDialog.FileName))
                AddToList(fileDialog.SafeFileName, fileDialog.FileName);

        }
        private void MediaFile_Drop(object sender, DragEventArgs e)   //Drag and Drop Event
        {
            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            string fileName = System.IO.Path.GetFileName(filePath);
            AddToList(fileName, filePath);
        }

        private void LViewItemList_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Double Click a list item
        {
            try
            {
                StopPlaying();
                source = DictionaryPlayList[LViewItemList.SelectedItem.ToString()];
                playingItemIndex = LViewItemList.SelectedIndex;
                LViewItemList.UnselectAll();
                TbtnPlayPause.IsChecked = true;
            }
            catch
            {
                MessageBox.Show("Please choose an Item.");
            }
        }
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e) //Click Delete from Context Menu
        {
            DeleteItem();
        }

        private void LViewItemList_KeyDown(object sender, KeyEventArgs e)   //Press Delete
        {
            DeleteItem();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e) //Press Stop
        {
            StopPlaying();
        }

        private void BtnRewind_Click(object sender, RoutedEventArgs e) //Press Rewind
        {
            if (SliderProgress.Value - 10 >= SliderProgress.Minimum)
                SliderProgress.Value -= 10;
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e) //Press Forward
        {
            if (SliderProgress.Value + 10 <= SliderProgress.Maximum)
                SliderProgress.Value += 10;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e) //Press Next
        {
            PlayNext();
        }
        #endregion


    }
}
