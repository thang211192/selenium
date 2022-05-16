using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace Hls
{
    class Program
    {
        private static string link = "https://cdn.24h.com.vn/upload/3-2021/videoclip/2021-08-12/cp_special_laliga-1628728732-ramos_messi.m3u8";

        private static async Task Main(string[] args1)
        {
            //var ff = new FFmpeg();
            //ff.FFmpegPath = "";
            //var mediaInfo = await FFmpeg.GetMediaInfo(link);
            //var conversion = await FFmpeg.Conversions.FromSnippet.ExtractVideo(mediaInfo.Path, "test.mp4");
            //conversion.OnProgress += async (sender, args) =>
            //{
            //    await Console.Out.WriteLineAsync($"[{args.Duration}/{args.TotalLength}][{args.Percent}%]");
            //};

            //await conversion.SetAudioBitrate(128000).SetOutputFormat(Format.mp3).Start();

            //Console.ReadKey();
        }
       

    }
}
