using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.IO;

namespace WinFormsApp_Course_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.AutoSize = false;
            label1.Size = new Size(150, 40);
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string videoUrl = textBox1.Text.Trim();

            // التعديل هنا: تم إضافة التابع لإجبار النص على التحول لأحرف كبيرة
            string? selectedFormat = cmbFormat.SelectedItem?.ToString()?.ToUpper();

            // 1. Validate inputs
            if (string.IsNullOrEmpty(videoUrl))
            {
                MessageBox.Show("Please enter a video URL first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedFormat))
            {
                MessageBox.Show("Please select a format (MP4 or MP3)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnDownload.Enabled = false; // Disable button to prevent multiple clicks
                lblStatus.Text = "Fetching video details...";

                var youtube = new YoutubeClient();

                // Get video metadata
                var video = await youtube.Videos.GetAsync(videoUrl);

                // Clean the video title from characters that are invalid in Windows file names
                string safeTitle = string.Concat(video.Title.Split(Path.GetInvalidFileNameChars()));

                lblStatus.Text = $"Downloading: {video.Title}...";

                // Get stream manifest
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);

                // Set download path to the current user's Downloads folder
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string filePath = "";

                if (selectedFormat == "MP4")
                {
                    // Get highest quality muxed stream (video + audio)
                    var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                    if (streamInfo != null)
                    {
                        filePath = Path.Combine(downloadsPath, $"{safeTitle}.mp4");
                        await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

                        lblStatus.Text = "Downloaded successfully to Downloads folder!";
                        MessageBox.Show("Video downloaded successfully to your Downloads folder!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Could not find a valid MP4 stream for this video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (selectedFormat == "MP3")
                {
                    // Get highest bitrate audio-only stream
                    var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                    if (streamInfo != null)
                    {
                        filePath = Path.Combine(downloadsPath, $"{safeTitle}.mp3");
                        await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

                        lblStatus.Text = "Downloaded successfully to Downloads folder!";
                        MessageBox.Show("Audio downloaded successfully to your Downloads folder!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Could not find a valid MP3 stream for this video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // In case the ComboBox selection text doesn't match perfectly
                    MessageBox.Show($"Please select a valid format! Current selection: '{selectedFormat}'", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error occurred during download.";
                MessageBox.Show($"Sorry, an error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDownload.Enabled = true; // Re-enable the button
            }
        }
    }
}