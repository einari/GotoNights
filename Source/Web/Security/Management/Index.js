Bifrost.namespace("Web.Security.Management", {
    Index: Bifrost.views.ViewModel.extend(function (users, commandTypes, globalMessenger) {
        var self = this;

        this.users = users.all();

        this.users.subscribe(function(results) {
            results.forEach(function (user) {
                var resetPassword = commandTypes.resetPassword.create({ region: self.region });
                resetPassword.userId(user.id);
                resetPassword.populateFromExternalSource(user);
                user.resetPassword = resetPassword;
                user.isResettingPassword = ko.observable(false);
                user.enableResettingPassword = function() {
                    user.isResettingPassword(true);
                }
                resetPassword.succeeded(function() {
                    user.isResettingPassword(false);
                });
            });
        });



        this.createWizardOpen = function () {
            var command = commandTypes.createUser.create({ region: self.region });
            self.region.createUserCommand(command);
        };

        this.createWizardCompleted = function () {
            var command = self.region.createUserCommand();
            command.succeeded(function () {
                self.users.execute();
                globalMessenger.publish("closeNewUser");
            });

            command.execute();
        };

    })
});