var GetMargin = polymorph(
    function (months, monthParts) {
        /*-11 = -15(basic) + 4 (left space + left border)*/
        /*51 - width of cell*/
        /*13 - width of cell part(12) + 1(border-width)*/
        return -11 + 51 * months + 13 * monthParts;
    }
);

$(document).ready(function () {
    //var flight_line = $('.flights_timetable tbody tr').first().find('td:last');

    //flight_line.css("background-color", "yellow");

    //flight_line.append($('<img>', { src: '/images/flight_mark.png', style: "margin-left:" + GetMargin(1, 4) + "px;" }));
    //console.log('margin-left'+ flight_line.find('img').first().css('margin-left'));

    //flight_line.append($('<img>', { src: '/images/flight_mark.png', style: "margin-left:" + 0 + "px;" }));
    //var $tableBody = $('.flights_timetable tbody');



    //$.ajax({
    //    type: "POST",
    //    url: "/Home/TestJson",
    //    dataType: "JSON",
    //    success: function (data) {
    //        $.each(data, function (key, val) {
    //            console.log(key + "-" + JSON.stringify(val));
    //            var $currTimeline = $tableBody.find("tr td:contains('" + val.name + "')").next();

    //            val.months.forEach(function (timeline, monthNum) {
    //                console.log(monthNum + " month " + timeline);

    //                timeline.forEach(function (monthPartVal, monthPartNum) {
    //                        $currTimeline.append($('<img>',
    //                                        {
    //                                            src: '/images/flight_mark.png',
    //                                            style: "margin-left:" + GetMargin(monthNum , monthPartNum) + "px;"
    //                                        }));
    //                    }
    //                });
    //            });

    //        });
    //    }
    //})

    //function getMargin(months, spaces) {
    //    /*47 - ширина месяца , 565/12*/
    //    /*46/4 - ширина ячейки , (47-1)/4*/
    //    return -14 + months*47 + (46/4)*spaces;
    //}

    /// <summary>
    /// s this instance.
    /// </summary>
    /// <returns></returns>
    var $tableBody = $('.flights_timetable tbody');

    $.ajax({
        type: "POST",
        url: "/FlightMessages/FlightsTimetableJson",
        dataType: "JSON",
        success: function (data) {
            /*all species*/
            $.each(data, function (key, val) {
                console.log(key + "-" + JSON.stringify(val));
                /*curr species timeline*/
                var $currTimeline = $tableBody.find("tr td:contains('" + val.name + "')").next();

                /*all months*/
                val.months.forEach(function (timeline, monthNum) {
                    console.log(monthNum + " month " + timeline);
                    /*curr month parts*/
                    timeline.forEach(function (monthPartVal, monthPartNum) {
                        /*Append img*/
                        if (monthPartVal != 0) {
                            var $message = $('<img>', {
                                src: '/images/flight_mark.png',
                                style: "margin-left:" + GetMargin(monthNum, monthPartNum) + "px;"
                            });

                            if (monthPartNum == 3) {
                                if (monthNum != 10 && val.months[monthNum+1][0]) {
                                    $message.css("width", "12px");
                                } else {
                                    $message.css("width", "11px");
                                }
                            } else {
                                if (timeline[monthPartNum + 1] != 0) {
                                    $message.css("width", "13px");
                                }
                            }

                            $currTimeline.append($message);
                        }
                    });
                });
            });

        }
    });
});

