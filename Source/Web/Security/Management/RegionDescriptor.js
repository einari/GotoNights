Bifrost.namespace("Web.Security.Management", {
    RegionDescriptor: Bifrost.views.RegionDescriptor.extend(function (createUser) {
        this.describe = function (region) {
            if (!Bifrost.isNullOrUndefined(region.createUserCommand)) return;
            region.createUserCommand = ko.observable(createUser);
        };
    })
});