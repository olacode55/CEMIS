var createProductAutocomplete = function () {
    var $input = $(this);

    var options = {
        source: $input.attr("data-autocomplete-Product"),
        select: productautoCompleteSelectHandler
    }

    $input.autocomplete(options);
}; 

$(document).on('keydown.autocomplete', 'input[data-autocomplete-Product]', createProductAutocomplete)
