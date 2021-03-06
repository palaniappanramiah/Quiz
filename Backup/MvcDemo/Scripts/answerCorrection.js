﻿$(document).ready(function () {
    var vals = [];
    var selectedVal = "true";
    var correctAnswer = $('input:radio[name="radio"]:checked').val();
    $("input").attr('checked', false);
    $("#next").hide();
    $('input:radio').hide();
    $("p").hide();
    $("#logout").hide();

    var $checkes = $('input:checkbox[name="choices[]"]').change(function () {
        vals = $checkes.filter(':checked').map(function () {
            return this.value;
        }).get();
    });

    $('input:radio[name="radio"]').change(function () {
        vals[0] = "value";
        selectedVal = $('input:radio[name="radio"]:checked').val();
    });

    $("#submit").click(function () {
        //$("p").hide();

        if ((vals[0] == null) || (selectedVal == null)) {
            $("p").hide();
            $("#selectAnswer").slideDown(250);
        }
        else {
            $("p").hide();
            if ((vals[0] == correctAnswer || vals[1] == correctAnswer || vals[2] == correctAnswer || vals[3] == correctAnswer)) {
                $("#correctAnswer").slideToggle(250);
            }
            else {
                $("#wrongAnswer").slideToggle(250);
            }
            $(this).unbind();
            $(this).hide();
            $("#next").show();
            $("#logout").show();
        }
    });
});