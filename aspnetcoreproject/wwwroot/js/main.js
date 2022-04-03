$(document).ready(function () {
    $('.owl-carousel').owlCarousel({
        loop:true,
        margin:10,
        nav:true,
        dots:false,
        responsive:{
            0:{
                items:1
            }
        }
    })
    $(window).on("scroll", function () {
        navbar();
    })
    function navbar() {
        if ($(window).scrollTop() > 30) {
            $(".breadcrumb-item a").css('color','black');
            $("#header img").attr("src", "/images/logo-footer.png");
            $("#header").css('background-color','#f4f5f8e3');
            
        }
        else {
            $(".breadcrumb-item a").css('color','white');
            $("#header img").attr("src", "/images/logo.svg");
            $("#header").css('background-color','');
        }
    }
   
    $(document).on("click", ".category-link", function () {
        var classname = $(this).data("filter");
      /*  $(this).addClass("text-danger");*/
        $(".group-wrapper").addClass("d-none");
        $("."+classname).removeClass("d-none");
    });
});

