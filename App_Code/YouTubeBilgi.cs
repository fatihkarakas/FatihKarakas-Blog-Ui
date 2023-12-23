using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// YouTubeBilgi için özet açıklama
/// </summary>
public class YouTubeBilgi
{
    public List<VideoBilgi> Veriler = new List<VideoBilgi>();
    public YouTubeBilgi()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }

    public void Run()
    {
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyCRTPZZjEgLOGbzY39bMfessLEVDM9Goho",
            ApplicationName = "testproject"

        });


        var channelsListRequest = youtubeService.Channels.List("contentDetails");
        //channelsListRequest.Mine = true;
        channelsListRequest.ForUsername = "fkarakasss";

        // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
        var channelsListResponse = channelsListRequest.Execute();
        foreach (var channel in channelsListResponse.Items)
        {
            // From the API response, extract the playlist ID that identifies the list
            // of videos uploaded to the authenticated user's channel.
            var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;

            //Response.Write("<h1>Videos Sayısı</h1>" + uploadsListId + "</br>Test<p>");

            var nextPageToken = "";
            int i = 1;
            while (nextPageToken != null)
            {
                var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
                playlistItemsListRequest.PlaylistId = uploadsListId;
                playlistItemsListRequest.MaxResults = 50;
                playlistItemsListRequest.PageToken = nextPageToken;

                // Retrieve the list of videos uploaded to the authenticated user's channel.
                var playlistItemsListResponse = playlistItemsListRequest.Execute();

                foreach (var playlistItem in playlistItemsListResponse.Items)
                {
                    int sonuc = playlistItemsListResponse.Items.Count();

                    // Print information about each video.
                    //Response.Write(sonuc + "Kadar Veri " + i + " - Video Adı : " + playlistItem.Snippet.Title + " </br> Video ID:  " + playlistItem.Snippet.ResourceId.VideoId + "Video Resim :" + playlistItem.Snippet.Thumbnails.Default__.Url + "</br>");
                    i++;
                  
                    Veriler.Add(new VideoBilgi
                    {
                        Adi = playlistItem.Snippet.Title,
                        Embed = "https://www.youtube.com/embed/" + playlistItem.Snippet.ResourceId.VideoId + "?rel=0",
                        Resimi = playlistItem.Snippet.Thumbnails.Default__.Url,
                        Url = "https://www.youtube.com/watch?v=" + playlistItem.Snippet.ResourceId.VideoId,
                        Aciklama = playlistItem.Snippet.Description
                 
                        
                    });
                }


                nextPageToken = playlistItemsListResponse.NextPageToken;
            }
        }
    }

  
}