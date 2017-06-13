
$(document).ready(function () {

    var $tableBody = $('.flights_timetable tbody');
    //width of space between solid borders + 1 boder width(1px)
    var widthOfCell;
    //width of space between solid/dashed borders
    var widthOfCellPart;
    //width of last space in month between dashed and solid borders
    var widthOfLastCellPart;
    //left width to deny padding and space between species names & table , = -15 + pic left space  + border width(1px)
    var basicLeftSpace;
   
    if (window.matchMedia('(max-width:767px)').matches) {
        widthOfCell = 35;
        widthOfCellPart = 8;
        widthOfLastCellPart = 7;
        basicLeftSpace = -11;
    }
    else {
        if (window.matchMedia('(max-width:991px)').matches) {
            widthOfCell = 28;
            widthOfCellPart = 6;
            widthOfLastCellPart = 6;
            basicLeftSpace = -12;
        }
        else {
            if (window.matchMedia('(max-width:1199px)').matches) {
                widthOfCell = 42;
                widthOfCellPart = 10;
                widthOfLastCellPart = 8;
                basicLeftSpace = -12;
            }
            else {
                if (window.matchMedia('(min-width:1200px)').matches) {
                    console.log('resolution >= 1200');
                    widthOfCell = 51;
                    widthOfCellPart = 12;
                    widthOfLastCellPart = 11;
                    basicLeftSpace = -11;
                }
                else {
                    console.log('No resolution found');
                }
            }
        }
    }

        $.ajax({
            type: "GET",
            url: "/FlightMessages/FlightsTimetableJson",
            dataType: "JSON",
            success: function (data) {
                /*all species*/
                $.each(data, function (key, val) {
                    /*curr species timeline*/
                    var $currTimeline = $tableBody.find("tr td:contains('" + val.name + "')").next();

                    /*all months*/
                    val.months.forEach(function (currMonth, monthNum) {
                        /*curr month parts*/
                        currMonth.forEach(function (monthPartVal, monthPartNum) {
                            /*Append img*/
                            if (monthPartVal != 0) {
                                var $message = $('<img>', {
                                    src: '/images/flight_mark.gif',
                                    style: "margin-left:" + GetMargin(monthNum, monthPartNum) + "px;"
                                }).addClass("flight_mark");
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


    $.ajax({
        type: "GET",
        url: "/FlightMessages/OriginalTimetableJson",
        dataType: "JSON",
        success: function (data) {
            console.log("Origin " + JSON.stringify(data));
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
                                src: '/images/flight_original_mark.gif',
                                style: "margin-left:" + GetMargin(monthNum, monthPartNum) + "px;"
                            }).addClass("original_flight_mark");
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

