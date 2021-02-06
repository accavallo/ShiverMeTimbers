// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function CarouselEvent() {
   $('.carousel-item', '.multi-item-carousel').each(function () {
      var next = $(this).next();
      if (!next.length) {
         next = $(this).siblings(':first');
      }
      next.children(':first-child').clone().appendTo($(this));
   }).each(function () {
      var prev = $(this).prev();
      if (!prev.length) {
         prev = $(this).siblings(':last');
      }
      prev.children(':nth-last-child(2)').clone().prependTo($(this));
   });
}