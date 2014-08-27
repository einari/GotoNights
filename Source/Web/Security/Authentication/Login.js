Bifrost.namespace("Web.Security.Authentication", {
    Login: Bifrost.views.ViewModel.extend(function (login, server, globalMessenger) {
        var self = this;

        this.login = login;

        this.authenticationHub = null;
        this.loggingIn = ko.observable(false);
        this.failedLogin = ko.observable(false);

        this.login.succeeded(function () {
            var promise = Bifrost.execution.Promise.create();
            getUserAndLoginIfLoggedIn(promise, 3)
            .continueWith(function() {
                globalMessenger.publish("userLoggedIn");
            });
            
        });

        this.login.failed(function () {
            self.loggingIn(false);
            self.failedLogin(true);
        });
        
        function getCurrentUser() {
            var promise = Bifrost.execution.Promise.create();
            server.get("/User/GetCurrent").continueWith(function (userInfo) {
                if (userInfo.isLoggedIn === true) {
                    document.cookie = userInfo.cookieName + "=" + userInfo.cookie;

                    self.login.username("");
                    self.login.password("");

                    self.region.userInfo.name(userInfo.name);
                    self.region.userInfo.isLoggedIn(userInfo.isLoggedIn);
                    self.region.userInfo.roles(userInfo.roles);

                    promise.signal();
                } else {
                    promise.fail();
                }
            });
            return promise;
        }

        var loginAttemptCount = 3;
        function getUserAndLoginIfLoggedIn(promise, numberOfAttempts) {
            var loginPromise = Bifrost.execution.Promise.create();
            if (typeof numberOfAttempts != "undefined") loginAttemptCount = numberOfAttempts;
            
            getCurrentUser()
                .continueWith(function () {
                    loginAttemptCount = 0;
                    self.loggingIn(false);
                    self.failedLogin(false);
                    loginPromise.signal();
                })
                .onFail(function () {
                    loginAttemptCount--;
                    if (loginAttemptCount > 0) {
                        setTimeout(getUserAndLoginIfLoggedIn, 100, promise);
                    } else {
                        self.loggingIn(false);
                        self.failedLogin(true);
                        loginPromise.fail();
                    }
                });
            return loginPromise;
        }

        this.performLogin = function () {
            self.loggingIn(true);
            self.failedLogin(false);
            var context = Bifrost.Guid.create();
            self.login.context(context);

            self.login.execute();
        };

        this.close = function () {
            self.login.username("");
            self.login.password("");
            self.loggingIn(false);
            self.failedLogin(false);
        };
    })
});

ko.bindingHandlers.loginOnEnter = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        element.addEventListener("keypress", function (e) {
            if (e.which == 13) {
                viewModel.performLogin();
            }
        }, false);
    }
};
