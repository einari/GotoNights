Bifrost.namespace("Web", {
    RegionDescriptor: Bifrost.views.RegionDescriptor.extend(function (server) {
        this.describe = function (region) {
            if (!Bifrost.isNullOrUndefined(region.userInfo)) return;

            region.userInfo = {
                name: ko.observable("Not logged in"),
                isLoggedIn: ko.observable(false),
                roles: ko.observableArray(),
            };

            region.userInfo.isAdmin = ko.computed(function () {
                return region.userInfo.roles().some(function (role) {
                    if (role === "admin") return true;
                });
            });


            var cookies = document.cookie.split(";");
            cookies.forEach(function (cookie) {
                var keyValue = cookie.split("=");
                var key = keyValue[0];
                var value = keyValue[1];
                if (key.indexOf(".ASPXAUTH") >= 0) {
                    region.userInfo.name("Getting user info");
                    region.userInfo.isLoggedIn(true);

                    server.get("/User/GetCurrent").continueWith(function (userInfo) {
                        region.userInfo.name(userInfo.name);
                        region.userInfo.isLoggedIn(userInfo.isLoggedIn);
                        region.userInfo.roles(userInfo.roles);

                        require(["/Bifrost/Security"])
                    });
                }
            });
        };
    })
});