//var GetMargin = polymorph(
//    function (months, monthParts) {
//        /*-11 = -15(basic) + 4 (left space + left border)*/
//        /*51 - width of cell*/
//        /*13 - width of cell part(12) + 1(border-width)*/
//        return -11 + 51 * months + 13 * monthParts;
//    }
//);
$(document).ready(function () {
    var $tableBody = $('.flights_timetable tbody');
    var widthOfCell, widthOfCellPart, widthOfLastCellPart, basicLeftSpace;
    if (window.matchMedia('(max-width:991px)').matches) {
        widthOfCell = 28;
        widthOfCellPart = 6;
        widthOfLastCellPart = 6;
        basicLeftSpace = -12;
    }else if (window.matchMedia('(max-width:1199px)').matches) {
        widthOfCell = 42;
        widthOfCellPart = 10;
        widthOfLastCellPart = 8;
        basicLeftSpace = -12;
    } else if (window.matchMedia('(min-width:1200px)').matches) {
        console.log('resolution >= 1200');
        widthOfCell = 51;
        widthOfCellPart = 12;
        widthOfLastCellPart = 11;
        basicLeftSpace = -11;
    } else {
        console.log('No resolution found');
    }


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
                val.months.forEach(function (currMonth, monthNum) {
                    console.log(monthNum + " month " + currMonth);
                    /*curr month parts*/
                    currMonth.forEach(function (monthPartVal, monthPartNum) {
                        /*Append img*/
                        if (monthPartVal != 0) {
                            var $message = $('<img>', {
                                src: '/images/flight_mark.png',
                                style: "margin-left:" + GetMargin(monthNum, monthPartNum) + "px;"
                            });
                            /*if last part of month*/
                            if (monthPartNum == 3) {
                                /*not last month && */
                                if (monthNum != 10 && val.months[monthNum + 1][0] != 0) {
                                    $message.css("width", (widthOfLastCellPart + 1) + "px");
                                } else {
                                    $message.css("width", widthOfLastCellPart + "px");
                                }
                            } else {
                                if (currMonth[monthPartNum + 1] != 0) {
                                    $message.css("width", (widthOfCellPart + 1) + "px");
                                } else {
                                    $message.css("width", widthOfCellPart + "px");
                                }
                            }

                            $currTimeline.append($message);
                        }
                    });
                });
            });

        }
    });

    function GetMargin(months, monthParts) {
        return basicLeftSpace + widthOfCell * months + (widthOfCellPart + 1) * monthParts;
    }
});

