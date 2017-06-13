/*
 * Controls for dropdown select 
 */

$(function () {
    console.log("start");
    var subfamillieSelect = $('#SubfamilieSelect');
    var genusSelect = $('#GenusSelect');
    var speciesSelect = $('#SpeciesSelect');

    var countrySelect = $('#CountrySelect');
    var citySelect = $('#CitySelect');

    AddDisabledIfParentNotSelected(genusSelect , subfamillieSelect);
    AddDisabledIfParentNotSelected(speciesSelect, genusSelect);
    
    AddDisabledIfParentNotSelected(citySelect ,countrySelect);
/*
 * Subfamilie Select
 */
    subfamillieSelect.on('change', function () {
        //if genus has already been chosen
        AddDisabled(speciesSelect);

        if (subfamillieSelect.val() != 0) {
            $.ajax({
                type: "POST",
                url: "/FlightMessages/SubfamilieFilter",
                dataType: 'JSON',
                data: { subfamilieId: subfamillieSelect.val() },
                success: function (data) {
                    RemoveDisabled(genusSelect);
                    AllGenuses(genusSelect);

                    $.each(data, function (index, element) {
                        genusSelect.append('<option value="' + element.id + '">' + element.genusName + '</option>');
                    });
                }
            });
        } else {
            AddDisabled(genusSelect);
            AllGenuses();
        }

        AllSpecies();
    });

/*
 * Genus Select
 */
    genusSelect.on('change', function () {
        if (genusSelect.val() != 0) {
            $.ajax({
                type: "POST",
                url: "/FlightMessages/GenusFilter",
                dataType: 'JSON',
                data: { genusId: genusSelect.val() },
                success: function (data) {
                    RemoveDisabled(speciesSelect);
                    AllSpecies();

                    $.each(data, function (index, element) {
                        speciesSelect.append('<option value="' + element.id + '">' + element.speciesName + '</option>');
                    });
                }
            });
        } else {
            AddDisabled(speciesSelect);
            AllSpecies();
        }
    });
/*
 * Country Select
 */
    countrySelect.on('change', function () {
        var countryId = $(this).val();

        if (countryId != 0) {

            $.ajax({
                type: "POST",
                url: "/FlightMessages/CountryFilter",
                dataType: 'JSON',
                data: { countryId: countrySelect.val() },
                success: function (data) {
                    RemoveDisabled(citySelect);
                    AllCities();

                    $.each(data, function (index, element) {
                        citySelect.append('<option value="' + element.id + '">' + element.name + '</option>');
                    });
                }
            });
        } else {
            AddDisabled(citySelect);
            AllCities();
        }
    });

    function AddDisabled(element) {
        if (!element.hasClass("disable-select")) {
            element.addClass("disable-select");
        }
    }
    function AddDisabledIfParentNotSelected(element, parent) {
        if (parent.val() == 0) {
            AddDisabled(element);
        }
    }
    function RemoveDisabled(element) {
        if (element.hasClass("disable-select")) {
            element.removeClass("disable-select");
        }
    }
    function AllGenuses() {
        genusSelect.html('<option value="0" >Все Роды</option>');
    }
    function AllSpecies() {
        speciesSelect.html('<option value="0">Все Виды</option>');
    }
    function AllCities() {
        citySelect.html('<option value="0">Все Города</option>');
    }
});