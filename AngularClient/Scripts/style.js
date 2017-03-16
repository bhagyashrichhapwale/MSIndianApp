
$(document).ready(function () {
    $(document).ready(function () {
        var winHt = window.innerHeight;
        
        $("#body").css("height", winHt);
        var ht = $("#body").height();
        alert("ht" + ht);
        $("#homePage").css("height", ht);
        $("#buyPage").css("height", ht);
        $(".tile").height($("#tile1").width());
        $(".carousel").height($("#tile1").width());
        $(".item").height($("#tile1").width());

        $(window).resize(function () {
            if (this.resizeTO) clearTimeout(this.resizeTO);
            this.resizeTO = setTimeout(function () {
                $(this).trigger('resizeEnd');
            }, 10);
        });

        $(window).bind('resizeEnd', function () {
            $(".tile").height($("#tile1").width());
            $(".carousel").height($("#tile1").width());
            $(".item").height($("#tile1").width());
        });

    });

});
