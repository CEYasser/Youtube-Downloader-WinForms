# YouTube Downloader (WinForms)

A simple Windows desktop application built with C# and .NET that downloads YouTube videos or extracts their audio using the YoutubeExplode library.

## Features
- Downloads high-quality MP4 video (video and audio combined).
- Extracts high-bitrate MP3 audio only to save bandwidth.
- Automatically saves all files directly to the user's Downloads folder.
- Case-insensitive format handling (accepts both mp4 and MP4).
- Disables the download button during processing to prevent multiple clicks.

## Tech Stack
- Language: C#
- Framework: .NET (Windows Forms)
- Library: YoutubeExplode

## How to Use
1. Paste the YouTube link into the text box.
2. Select either MP4 or MP3 from the dropdown menu.
3. Click Download and wait for the success message.

## Portability
Can be published from Visual Studio as a Single-File / Self-contained EXE to run on any Windows computer without external installations.
