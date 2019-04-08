function getUrlParam(url) {   //function that takes urlParam and save in object separeted parameters from it
    console.log(url);
    // get query string from url (optional) or window
    var queryString = url ? url.split('?')[1] : window.location.search.slice(1);
    var url_part = url ? url.split('?')[0] : window.location.search.slice(1);
    console.log(url_part);
    // we'll store the parameters here
    var obj = {};

    // if query string exists
    if (queryString) {

        // stuff after # is not part of query string, so get rid of it
        queryString = queryString.split('#')[0];

        // split our query string into its component parts
        var arr = queryString.split('&');

        for (var i = 0; i < arr.length; i++) {
            // separate the keys and the values
            var a = arr[i].split('=');

            // set parameter name and value (use 'true' if empty)
            var paramName = a[0];
            var paramValue = typeof (a[1]) === 'undefined' ? true : a[1];

            // (optional) keep case consistent
            paramName = paramName.toLowerCase();
            if (typeof paramValue === 'string') paramValue = paramValue.toLowerCase();

            // if the paramName ends with square brackets, e.g. colors[] or colors[2]
            if (paramName.match(/\[(\d+)?\]$/)) { // RegEx

                // create key if it doesn't exist
                var key = paramName.replace(/\[(\d+)?\]/, '');
                if (!obj[key]) obj[key] = [];

                // if it's an indexed array e.g. colors[2]
                if (paramName.match(/\[\d+\]$/)) {
                    // get the index value and add the entry at the appropriate position
                    var index = /\[(\d+)\]/.exec(paramName)[1];
                    obj[key][index] = paramValue;
                } else {
                    // otherwise add the value to the end of the array
                    obj[key].push(paramValue);
                }
            } else {
                // we're dealing with a string
                if (!obj[paramName]) {
                    // if it doesn't exist, create property
                    obj[paramName] = paramValue;
                } else if (obj[paramName] && typeof obj[paramName] === 'string') {
                    // if property does exist and it's a string, convert it to an array
                    obj[paramName] = [obj[paramName]];
                    obj[paramName].push(paramValue);
                } else {
                    // otherwise add the property
                    obj[paramName].push(paramValue);
                }
            }
        }
    }
    obj["url_part"] = url_part; // saves as key "url_part" and as value - urlpart with included controler
    return obj;
}
    

function setArrow() { //sets arrow simbol up or down (for name or abrv) and sends url route defined by param send from html object
    var page = getUrlParam(window.location.href);
    if (page.sortby == "name" && page.sortorder == "asc") { 
        $("#name-arrow").addClass("fa-angle-down").removeClass("fa-angle-up")
    }
    else if (page.sortby == "name" && page.sortorder == "desc") {
        $("#name-arrow").addClass("fa-angle-up").removeClass("fa-angle-down")
    }
    else if (page.sortby == "abrv" && page.sortorder == "asc") {
        $("#abrv-arrow").addClass("fa-angle-down").removeClass("fa-angle-up")
    }
    else if (page.sortby == "abrv" && page.sortorder == "desc") {
        $("#abrv-arrow").addClass("fa-angle-up").removeClass("fa-angle-down")
    }
}

//function that on click creates url parameter for previous page(including sortOrder, sortBy and searchBy) 
$("#paging-element-previous").click(function () {
    var page = getUrlParam(window.location.href);
    var counter = parseInt(page.page) - 1;
    if (page.sortorder == undefined && page.sortby == undefined) {
        page.sortorder = "asc";
        page.sortby = "name";
    }
    page.searchby = undefined ? "" : page.searchby;
    if (page.page == undefined || page.page == 1 || page.page == "nan") {
        counter = 1;
    }
    location.replace(page.url_part + "?page=" + counter + "&sortOrder=" + page.sortorder + "&sortBy=" + page.sortby + "&searchBy=" + page.searchby );

});

//function that on click creates url parameter for next page(including sortOrder, sortBy and searchBy) 
$("#paging-element-next").click(function () {
    var page = getUrlParam(window.location.href);
    var counter = parseInt(page.page) + 1;
    if (page.sortorder == undefined && page.sortby == undefined) {
        page.sortorder = "asc";
        page.sortby = "name";
    }
    page.searchby = (page.searchby == undefined ? "" : page.searchby);
    if (page.page == undefined || page.page == null || page.page == "nan") {
        counter = 2;
        }
    location.replace(page.url_part + "?page=" + counter + "&sortOrder=" + page.sortorder + "&sortBy=" + page.sortby + "&searchBy=" + page.searchby);
});



//generating url route for name sorting
$("#name-arrow").click(function () {
    var page = getUrlParam(window.location.href);
    var counter = 1;
    if (page.sortorder == "asc") {
        page.sortorder = "desc";
    }
    else if (page.sortorder == "desc") {
        page.sortorder = "asc";
    }
    page.searchby = page.searchby == undefined ? "" : page.searchby; 
    if (page.sortorder == "asc" || page.sortorder == undefined) {
        location.replace(page.url_part + "?page=" + counter + "&sortOrder=asc&sortBy=name&searchBy=" + page.searchby);
    }
    else {
        location.replace(page.url_part + "?page=" + counter + "&sortOrder=desc&sortBy=name&searchBy=" + page.searchby);
    }
});

//generating url route for abrv sorting
$("#abrv-arrow").click(function () {
    var page = getUrlParam(window.location.href);
    var counter = 1;
    if (page.sortorder == "asc") {
        page.sortorder = "desc";
    }
    else if (page.sortorder == "desc") {
        page.sortorder = "asc";
    }
    page.searchby = page.searchby == undefined ? "" : page.searchby; 
    if (page.sortorder == "asc" || page.sortorder == undefined) {
        location.replace(page.url_part + "?page=" + counter + "&sortOrder=asc&sortBy=abrv&searchBy=" + page.searchby);
    }
    else {
        location.replace(page.url_part + "?page=" + counter + "&sortOrder=desc&sortBy=abrv&searchBy=" + page.searchby);
    }
});
