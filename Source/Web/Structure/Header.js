Bifrost.namespace("Web.Structure", {
    Header: Bifrost.views.ViewModel.extend(function (globalMessenger, server) {
        var self = this;

        this.logOut = function () {
            server.post("/User/Logout").continueWith(function () {

                globalMessenger.publish("userLoggedOut");
                document.cookie = "";
                self.region.userInfo.isLoggedIn(false);
                self.region.userInfo.name("Not logged in");
                self.region.userInfo.roles([]);

                History.pushState({}, "", "/");
            });
        };
    })
});