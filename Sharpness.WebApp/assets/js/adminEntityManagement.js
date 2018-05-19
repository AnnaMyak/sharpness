var stainViewModel = {
    newStain: ko.observable(),
    addDomain: function () {
        $.ajax(
        {
            url: '/API/EntityMynagement/Add',
            type: 'POST',
            data: {
                NewStain: this.newStain()
            },
            dataType: 'json',
            statusCode: {
                200: function () {
                    location.reload();
                },
                202: function () {
                    location.reload();
                },
                403: function () {
                    alert("Domain ungültig oder bereits vorhanden!")
                }
            }
        });
    },
    deleteDomain: function (domainId) {
        $.ajax(
        {
            url: '/API/Domain/Remove?DomainId=' + domainId,
            type: 'POST',
            data: {
                DomainId: domainId
            },
            dataType: 'json',
            statusCode: {
                200: function () {
                    location.reload();
                },
                202: function () {
                    location.reload();
                },
                403: function () {
                    alert("Domain ungültig!")
                }
            }
        });
    }
}

ko.applyBindings(stainViewModel, document.getElementById("stainBlock"));