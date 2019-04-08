function vehicleDropdown(url) {
    $("#vehiclemake").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: url,
                type: 'GET',
                data: { query: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.name,
                            value: item.name
                        }
                    }))
                }
            });
        }
    });
}

