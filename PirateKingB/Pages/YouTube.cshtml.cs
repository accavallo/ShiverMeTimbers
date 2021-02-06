using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace PirateKingB.Pages
{
   partial class CarouselStuff
   {
      public static void GetYouTubeInfo(ref string listItems, ref string carouselInfo)
      {
         string curDir = Directory.GetCurrentDirectory();
         string filePath = curDir + "\\wwwroot\\YouTube Carousel.txt";

         if (File.Exists(filePath))
         {
            try
            {
               string[] lines = File.ReadAllLines(filePath);

               System.Text.StringBuilder carouselBuilder = new System.Text.StringBuilder("");
               System.Text.StringBuilder listBuilder = new System.Text.StringBuilder("");
               for (int index = 0; index < lines.Length; index++)
               {
                  string url = lines.ElementAt(index);
                  carouselBuilder.Append("<div class=\"carousel-item");
                  listBuilder.Append("<li data-target=\"#shiverMeCarouselMatey\" data-slide-to=\"");
                  listBuilder.Append(index);
                  listBuilder.Append("\"");
                  if (index == 0)
                  {
                     carouselBuilder.Append(" active");
                     listBuilder.Append(" class=\"active\"");
                  }
                  carouselBuilder.Append("\">");
                  carouselBuilder.Append("<div class=\"item__third\"><img class=\"pirate-carousel\" src=\"");
                  carouselBuilder.Append(url);
                  carouselBuilder.Append("\" /><div class=\"carousel-caption d-none d-md-block\"></div></div></div>");

                  listBuilder.Append("></li>");
               }

               carouselInfo = carouselBuilder.ToString();
               listItems = listBuilder.ToString();
            }
            catch (IOException ex)
            {
               Console.WriteLine("Exception: {0}", ex.ToString());
            }
         }
      }
   }
   public class YouTubeModel : PageModel
    {
       public string Message { get; set; }

       public string YouTubeCarouselItems { get; set; }
       public string YouTubeListItems { get; set; }

       private List< List<string> > entireVideoList;

       public void OnGet()
       {
           Message = "YouTube page, son!";

         string listItems = "";
         string carouselItems = "";
         CarouselStuff.GetYouTubeInfo(ref listItems, ref carouselItems);
         YouTubeCarouselItems = carouselItems;
         YouTubeListItems = listItems;
      }
   }
}