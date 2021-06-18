angular.module("umbraco.resources")
    .factory("dataTypeKeyResource", function ($http) {

        var myService = {};
        myService.getAll = function () {
            return $http.get("/Umbraco/backoffice/Api/DataTypeKeyResourceApi/GetAll");
        };

    });

