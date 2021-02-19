using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text;

namespace PirateKingB.Pages
{
   partial class CarouselStuff
   {
      public static void GetAboutInfo(ref string listItems, ref string carouselInfo)
      {
         string curDir = Directory.GetCurrentDirectory();
         string filePath = curDir + "\\wwwroot\\About Carousel.txt";

         if (File.Exists(filePath))
         {
            try
            {
               string[] lines = File.ReadAllLines(filePath);

               StringBuilder carouselBuilder = new StringBuilder("");
               StringBuilder listBuilder = new StringBuilder("");
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
                        //class=\"item__third\" //Leftover from showing a previous and next item in the carousel
                  carouselBuilder.Append("<div><img class=\"pirate-carousel\" src=\"/images/");
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
   public class AboutModel : PageModel
   {
      public string Message { get; set; }

      public string AboutListItems { get; set; }
      public string AboutCarouselItems { get; set; }

      public void OnGet()
      {
         Message = "PirateKingB LLC";

         string listItems = "";
         string carouselItems = "";
         CarouselStuff.GetAboutInfo(ref listItems, ref carouselItems);
         AboutCarouselItems = carouselItems;
         AboutListItems = listItems;
      }
   }
}
