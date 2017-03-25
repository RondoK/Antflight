$(document).ready(function () {
    var linesPerPage = 12;
    var expectedLines;

    var flightsTable = $('#flightsTable');
    var loadMoreBtn = $('#load_more');

    var loaded = flightsTable.children('tbody').children('tr').length;

    var subfamilieId, genusId, speciesId,
                    countryId, cityId;
    /*Load More Btn Click*/
    loadMoreBtn.click(function () {
        expectedLines += linesPerPage;

        loadFlights(loaded, AppendWithJSON,
                        subfamilieId, genusId, speciesId,
                        countryId, cityId,
                        function () {
                            if (loaded < expectedLines) {
                                loadMoreBtn.hide();
                            }
                        });
    });

    $("#flightsTable tbody").on('click', "tr", function () {
        console.log('click');
        window.location = $(this).data("href");
    });

    /*Apply Filters Btn Click*/
    $('#applyFiltersBtn').click(function () {
        expectedLines = linesPerPage;
        console.log('applyFilters');

        loadFlights(0 ,ReplaceWithJSON,
                        subfamilieId = $('#SubfamilieSelect').val(),
                        genusId = $('#GenusSelect').val(),
                        speciesId = $('#SpeciesSelect').val(),
                        countryId = $('#CountrySelect').val(),
                        cityId = $('#CitySelect').val(),
                        function () {
                            console.log(loaded + "<" + expectedLines);
                            if (loaded < expectedLines) {
                                loadMoreBtn.hide();
                            } else {
                                if (loadMoreBtn.is(":hidden"))
                                    loadMoreBtn.show();
                            }
                        });

        
    });
    /*AJAX Function loads flights*/
    function loadFlights(alreadyloaded, processJsonDataFunc,
                         subfamilieId, genusId, speciesId,
                         countryId, cityId,
                         afterSuccessFunction) {
        console.log(subfamilieId + 'subf' + genusId + 'g' + speciesId + 'sp'
            + countryId + 'coint' + cityId + 'city');
        $.ajax({
            type: "POST",
            url: "/FlightMessages/GetFilteredFlights",
            dateType: 'JSON',
            asynch: false,
            data: {
                loaded: loaded = alreadyloaded,
                subfamilieId: subfamilieId,
                genusId: genusId,
                speciesId: speciesId,
                countryId: countryId,
                cityId: cityId
            },

            success: function (data) {
                console.log("Ajax success:" + JSON.stringify(data));
                processJsonDataFunc(data);
                afterSuccessFunction();
            }
        });
    }
    /*apend AJAX function result to the last <tr> in the flightsTable */
    function AppendWithJSON(data) {
        console.log('AppendWithJSON');
        var lastTableTr = flightsTable.children('tbody:last-child');
        flightsTable.find('tr:last').addClass('lastReadedLine');
        console.log(flightsTable.find('tr:last').toString());
        AppendTo(data , lastTableTr)
    }
    /*replace in the flightsTable data , with AJAX data result*/
    function ReplaceWithJSON(data) {
        flightsTable.children('tbody').empty();
        console.log('replace' + flightsTable.children('tbody'));
        AppendTo(data, flightsTable.children('tbody'));

    }
    /*append 'data' to 'appendTo' element */
    function AppendTo(data, appendTo) {
        console.log('AppendTo');
        var date, day, month, year;

        $.each(data, function (i, item) {
            date = new Date(item.flightTime);

            day = ("0" + date.getDate()).slice(-2);
            month = ("0" + (date.getMonth() + 1)).slice(-2);
            year = date.getFullYear();
            appendTo.append('<tr class="clickable_rows" data-href="FlightMessages/Message/'+ item.id +'">' + '<td>'
                            + item.species + '</td><td>'
                            + item.city + '</td><td>'
                            + item.country + '</td>'
                            + '<td>' + day + '.' + month + '.' + year + '</td></tr>');
            loaded++;
        });
        console.log("loaded after AppendTo" + loaded);
    }
    
})

