using System;
using System.Threading;

namespace ConsoleExercises;

public class DownloadManager
{
    public event EventHandler DownloadCompleted;

    public void StartDownload()
    {
        Console.WriteLine("Starting download...");
        // Simulate time-consuming download
        Thread.Sleep(3000); // 3 seconds
        OnDownloadCompleted();
    }

    protected virtual void OnDownloadCompleted()
    {
        DownloadCompleted?.Invoke(this, EventArgs.Empty);
    }
}

public class Ex05
{
    public static void Run()
    {
        Console.WriteLine("--- Exercise 5: Download Completion Notification with Events ---");
        var downloadManager = new DownloadManager();
        downloadManager.DownloadCompleted += (sender, args) =>
        {
            Console.WriteLine("Download has finished!");
        };

        downloadManager.StartDownload();
    }
}