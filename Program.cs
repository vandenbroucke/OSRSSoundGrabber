using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
public class ReadInput
{
    public String[] paths { get; set; } = new String[] { };
}

class Program
{
    const String rootPath = "https://oldschool.runescape.wiki/images/";
    const String outputFolder = "downloads/";
    static async Task Main(string[] args)
    {
        StreamReader r = new StreamReader("paths.json");
        String jsonString = r.ReadToEnd();
        ReadInput ri = new ReadInput();
        var tryConvert = JsonSerializer.Deserialize<ReadInput>(jsonString);
        if (tryConvert != null)
        {
            ri = (ReadInput)tryConvert;
        }
        Boolean result = await DownloadAndStoreFiles(rootPath, ri.paths, outputFolder);
        Console.WriteLine(result?"SUCCES":"FAILED");
    }
    public static async Task<Boolean> DownloadAndStoreFiles(String rootURL, String[] fileNames, String outputFolder)
    {
        HttpClient httpClient = new HttpClient();
        foreach (String filename in fileNames)
        {
            try
            {
                using (var stream = await httpClient.GetAsync(rootURL + filename).Result.Content.ReadAsStreamAsync())
                {
                    using (var fs = new FileInfo(outputFolder + filename).OpenWrite())
                    {
                        await stream.CopyToAsync(fs);
                    }
                }
            }
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
                return false;
            }
        }        
        return true;
    }
}